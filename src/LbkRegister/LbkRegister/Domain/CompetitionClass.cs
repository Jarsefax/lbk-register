using System;
using System.Collections.Generic;

namespace LbkRegister.Domain {
    public static class CompetitionClass {
        public const string _sixMonthsName = "Valp 4-6 mån";
        public const string _nineMonthsName = "Valp 6-9 mån";
        public const string _nineToFifteenMonthsName = "Junior 9-15 mån";
        public const string _fifteenToTwentyFourMonthsName = "Unghund 15-24 mån";
        public const string _fifteenMonthsName = "Vuxen från 15 mån";
        public const string _eightYearsName = "Veteran från 8 år";

        public enum Categories {
            SixMonths = 1,
            NineMonths = 2,
            NineToFifteenMonths = 3,
            FifteenToTwentyFourMonths = 4,
            FifteenMonths = 5,
            EightYears = 6
        }

        public static IEnumerable<Categories> List => 
            new List<Categories> {
                Categories.SixMonths,
                Categories.NineMonths,
                Categories.NineToFifteenMonths,
                Categories.FifteenToTwentyFourMonths,
                Categories.FifteenMonths,
                Categories.EightYears
            };

        public static string ToName(this Categories category) {
            switch (category) {
                case Categories.SixMonths:
                    return _sixMonthsName;
                case Categories.NineMonths:
                    return _nineMonthsName;
                case Categories.NineToFifteenMonths:
                    return _nineToFifteenMonthsName;
                case Categories.FifteenToTwentyFourMonths:
                    return _fifteenToTwentyFourMonthsName;
                case Categories.FifteenMonths:
                    return _fifteenMonthsName;
                case Categories.EightYears:
                    return _eightYearsName;
                default:
                    return string.Empty;
            }
        }

        public static Categories FromName(this string name) {
            switch (name) {
                case _sixMonthsName:
                    return Categories.SixMonths;
                case _nineMonthsName:
                    return Categories.NineMonths;
                case _nineToFifteenMonthsName:
                    return Categories.NineToFifteenMonths;
                case _fifteenMonthsName:
                    return Categories.FifteenToTwentyFourMonths;
                case _fifteenToTwentyFourMonthsName:
                    return Categories.FifteenMonths;
                case _eightYearsName:
                    return Categories.EightYears;
                default:
                    throw new Exception("Unknown competition class name");
            }
        }

        public static Categories GetCategory(this string line) {
            if (line.Contains(_sixMonthsName)) {
                return Categories.SixMonths;
            }

            if (line.Contains(_nineMonthsName)) {
                return Categories.NineMonths;
            }

            if (line.Contains(_nineToFifteenMonthsName)) {
                return Categories.NineToFifteenMonths;
            }

            if (line.Contains(_fifteenToTwentyFourMonthsName)) {
                return Categories.FifteenToTwentyFourMonths;
            }

            if (line.Contains(_fifteenMonthsName)) {
                return Categories.FifteenMonths;
            }

            if (line.Contains(_eightYearsName)) {
                return Categories.EightYears;
            }

            throw new Exception(line + " matchar ingen grupp...");
        }
    }
}
