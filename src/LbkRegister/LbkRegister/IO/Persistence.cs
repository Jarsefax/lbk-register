using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Ionic.Zip;
using LbkRegister.Domain;
using Newtonsoft.Json;

namespace LbkRegister.Data {
    static class Persistence {
        private const string _saveFilePath = "LEBHK";
        private const string _saveFileName = "registreringar";
        private const string _catalogFileName = "katalog";
        
        internal static void Initialize() {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _saveFilePath);
            Directory.CreateDirectory(path);
        }

        internal static void Save(Registration registration, IEnumerable<Registration> existing) {
            var result = existing.Concat(new[] { registration });

            Save(result);
        }

        internal static void Delete(Registration registration, IEnumerable<Registration> registrations) {
            var result = registrations.Where(x => x != registration);

            Save(result);
        }

        internal static IEnumerable<Registration> Load() {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _saveFilePath);
            var files = Directory.GetFiles(path);
            if (files.Any() == false) {
                return new Registration[0];
            }

            var count = 
                files.Where(f => Path.GetFileNameWithoutExtension(f).Contains(_saveFileName))
                .Max(n => int.Parse(Path.GetFileNameWithoutExtension(n).Substring(_saveFileName.Length)));
            var fullPath = Path.Combine(path, _saveFileName) + count.ToString() + ".txt";

            return JsonConvert.DeserializeObject<IEnumerable<Registration>>(File.ReadAllText(fullPath));
        }

        internal static void Save(IEnumerable<Registration> result) {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _saveFilePath);
            var files = Directory.GetFiles(path);
            var count = files.Where(f => Path.GetFileNameWithoutExtension(f).Contains(_saveFileName)).Any()
                ? files
                    .Where(f => Path.GetFileNameWithoutExtension(f).Contains(_saveFileName))
                    .Max(n => int.Parse(Path.GetFileNameWithoutExtension(n).Substring(_saveFileName.Length))) + 1
                : 0;
            var fullPath = Path.Combine(path, _saveFileName) + count.ToString() + ".txt";

            File.WriteAllText(fullPath, JsonConvert.SerializeObject(result));
        }

        //internal static void SaveCatalog(DataSet odsFile) {
        //    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _saveFilePath);
        //    var files = Directory.GetFiles(path);
        //    var count = files.Where(f => Path.GetFileNameWithoutExtension(f).Contains(_catalogFileName)).Any()
        //        ? files
        //            .Where(f => Path.GetFileNameWithoutExtension(f).Contains(_catalogFileName))
        //            .Max(n => int.Parse(Path.GetFileNameWithoutExtension(n).Substring(_catalogFileName.Length))) + 1
        //        : 0;
        //    var fullPath = Path.Combine(path, _catalogFileName) + count.ToString() + ".xls";

        //    var templateFile = ZipFile.Read(Assembly.GetExecutingAssembly().GetManifestResourceStream("LbkRegister.IO.template.ods"));

        //    var contentXml = GetContentXmlFile(templateFile);

        //    var nmsManager = InitializeXmlNamespaceManager(contentXml);

        //    var sheetsRootNode = GetSheetsRootNodeAndRemoveChildrens(contentXml, nmsManager);

        //    foreach (DataTable sheet in odsFile.Tables) {
        //        SaveSheet(sheet, sheetsRootNode);
        //    }

        //    SaveContentXml(templateFile, contentXml);

        //    templateFile.Save(fullPath);
        //}

        internal static void SaveCatalog(ZipFile file) {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _saveFilePath);
            var files = Directory.GetFiles(path);
            var count = files.Where(f => Path.GetFileNameWithoutExtension(f).Contains(_catalogFileName)).Any()
                ? files
                    .Where(f => Path.GetFileNameWithoutExtension(f).Contains(_catalogFileName))
                    .Max(n => int.Parse(Path.GetFileNameWithoutExtension(n).Substring(_catalogFileName.Length))) + 1
                : 0;
            var fullPath = Path.Combine(path, _catalogFileName) + count.ToString() + ".xls";            

            file.Save(fullPath);
        }        
    }
}