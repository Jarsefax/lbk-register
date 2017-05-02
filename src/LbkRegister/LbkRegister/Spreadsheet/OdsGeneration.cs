using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using Ionic.Zip;

namespace LbkRegister.Spreadsheet {
    internal class OdsGeneration {
        // Namespaces. We need this to initialize XmlNamespaceManager so that we can search XmlDocument.
        private static string[,] namespaces = new string[,]
        {
            {"table", "urn:oasis:names:tc:opendocument:xmlns:table:1.0"},
            {"office", "urn:oasis:names:tc:opendocument:xmlns:office:1.0"},
            {"style", "urn:oasis:names:tc:opendocument:xmlns:style:1.0"},
            {"text", "urn:oasis:names:tc:opendocument:xmlns:text:1.0"},
            {"draw", "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0"},
            {"fo", "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0"},
            {"dc", "http://purl.org/dc/elements/1.1/"},
            {"meta", "urn:oasis:names:tc:opendocument:xmlns:meta:1.0"},
            {"number", "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0"},
            {"presentation", "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0"},
            {"svg", "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0"},
            {"chart", "urn:oasis:names:tc:opendocument:xmlns:chart:1.0"},
            {"dr3d", "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0"},
            {"math", "http://www.w3.org/1998/Math/MathML"},
            {"form", "urn:oasis:names:tc:opendocument:xmlns:form:1.0"},
            {"script", "urn:oasis:names:tc:opendocument:xmlns:script:1.0"},
            {"ooo", "http://openoffice.org/2004/office"},
            {"ooow", "http://openoffice.org/2004/writer"},
            {"oooc", "http://openoffice.org/2004/calc"},
            {"dom", "http://www.w3.org/2001/xml-events"},
            {"xforms", "http://www.w3.org/2002/xforms"},
            {"xsd", "http://www.w3.org/2001/XMLSchema"},
            {"xsi", "http://www.w3.org/2001/XMLSchema-instance"},
            {"rpt", "http://openoffice.org/2005/report"},
            {"of", "urn:oasis:names:tc:opendocument:xmlns:of:1.2"},
            {"rdfa", "http://docs.oasis-open.org/opendocument/meta/rdfa#"},
            {"config", "urn:oasis:names:tc:opendocument:xmlns:config:1.0"}
        };

        internal static ZipFile Generate(DataSet odsFile) {
            var file = ZipFile.Read(Assembly.GetExecutingAssembly().GetManifestResourceStream("LbkRegister.IO.template.ods"));

            var contentXml = GetContentXmlFile(file);

            var nmsManager = InitializeXmlNamespaceManager(contentXml);

            var sheetsRootNode = GetSheetsRootNodeAndRemoveChildrens(contentXml, nmsManager);

            foreach (DataTable sheet in odsFile.Tables) {
                SaveSheet(sheet, sheetsRootNode);
            }

            SaveContentXml(file, contentXml);

            return file;
        }
        private static XmlDocument GetContentXmlFile(ZipFile zipFile) {
            // Get file(in zip archive) that contains data ("content.xml").
            var contentZipEntry = zipFile["content.xml"];

            // Extract that file to MemoryStream.
            var contentStream = new MemoryStream();
            contentZipEntry.Extract(contentStream);
            contentStream.Seek(0, SeekOrigin.Begin);

            // Create XmlDocument from MemoryStream (MemoryStream contains content.xml).
            var contentXml = new XmlDocument();
            contentXml.Load(contentStream);

            return contentXml;
        }

        private static XmlNamespaceManager InitializeXmlNamespaceManager(XmlDocument xmlDocument) {
            var nmsManager = new XmlNamespaceManager(xmlDocument.NameTable);

            for (int i = 0; i < namespaces.GetLength(0); i++) {
                nmsManager.AddNamespace(namespaces[i, 0], namespaces[i, 1]);
            }

            return nmsManager;
        }

        private static XmlNode GetSheetsRootNodeAndRemoveChildrens(XmlDocument contentXml, XmlNamespaceManager nmsManager) {
            var tableNodes = GetTableNodes(contentXml, nmsManager);

            var sheetsRootNode = tableNodes.Item(0).ParentNode;
            // remove sheets from template file
            foreach (XmlNode tableNode in tableNodes) {
                sheetsRootNode.RemoveChild(tableNode);
            }

            return sheetsRootNode;
        }

        // In ODF sheet is stored in table:table node
        private static XmlNodeList GetTableNodes(XmlDocument contentXmlDocument, XmlNamespaceManager nmsManager) =>
            contentXmlDocument.SelectNodes("/office:document-content/office:body/office:spreadsheet/table:table", nmsManager);

        private static void SaveSheet(DataTable sheet, XmlNode sheetsRootNode) {
            var ownerDocument = sheetsRootNode.OwnerDocument;

            var sheetNode = ownerDocument.CreateElement("table:table", GetNamespaceUri("table"));

            var sheetName = ownerDocument.CreateAttribute("table:name", GetNamespaceUri("table"));
            sheetName.Value = sheet.TableName;
            sheetNode.Attributes.Append(sheetName);

            SaveColumnDefinition(sheet, sheetNode, ownerDocument);

            SaveRows(sheet, sheetNode, ownerDocument);

            sheetsRootNode.AppendChild(sheetNode);
        }

        private static string GetNamespaceUri(string prefix) {
            for (int i = 0; i < namespaces.GetLength(0); i++) {
                if (namespaces[i, 0] == prefix) {
                    return namespaces[i, 1];
                }
            }

            throw new InvalidOperationException("Can't find that namespace URI");
        }

        private static void SaveColumnDefinition(DataTable sheet, XmlNode sheetNode, XmlDocument ownerDocument) {
            var columnDefinition = ownerDocument.CreateElement("table:table-column", GetNamespaceUri("table"));

            var columnsCount = ownerDocument.CreateAttribute("table:number-columns-repeated", GetNamespaceUri("table"));
            columnsCount.Value = sheet.Columns.Count.ToString(CultureInfo.InvariantCulture);
            columnDefinition.Attributes.Append(columnsCount);

            sheetNode.AppendChild(columnDefinition);
        }

        private static void SaveRows(DataTable sheet, XmlNode sheetNode, XmlDocument ownerDocument) {
            DataRowCollection rows = sheet.Rows;
            for (int i = 0; i < rows.Count; i++) {
                var rowNode = ownerDocument.CreateElement("table:table-row", GetNamespaceUri("table"));

                SaveCell(rows[i], rowNode, ownerDocument);

                sheetNode.AppendChild(rowNode);
            }
        }

        private static void SaveCell(DataRow row, XmlNode rowNode, XmlDocument ownerDocument) {
            object[] cells = row.ItemArray;

            for (int i = 0; i < cells.Length; i++) {
                var cellNode = ownerDocument.CreateElement("table:table-cell", GetNamespaceUri("table"));

                if (row[i] != DBNull.Value) {
                    // We save values as text (string)
                    XmlAttribute valueType = ownerDocument.CreateAttribute("office:value-type", GetNamespaceUri("office"));
                    valueType.Value = "string";
                    cellNode.Attributes.Append(valueType);

                    XmlElement cellValue = ownerDocument.CreateElement("text:p", GetNamespaceUri("text"));
                    cellValue.InnerText = row[i].ToString();
                    cellNode.AppendChild(cellValue);
                }

                rowNode.AppendChild(cellNode);
            }
        }

        private static void SaveContentXml(ZipFile templateFile, XmlDocument contentXml) {
            templateFile.RemoveEntry("content.xml");

            var memStream = new MemoryStream();
            contentXml.Save(memStream);
            memStream.Seek(0, SeekOrigin.Begin);

            templateFile.AddEntry("content.xml", memStream);
        }
    }
}
