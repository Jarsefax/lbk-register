namespace LbkRegister.Domain {
    public static class ClassGrouping {
        public enum ClassGroupings {
            Unknown = 0,
            Pups = 1,
            Adults = 2,
            Veterans = 3
        }

        public static ClassGroupings FromClass(this CompetitionClass.Categories group) {
            switch (group) {
                case CompetitionClass.Categories.SixMonths:
                case CompetitionClass.Categories.NineMonths:
                    return ClassGroupings.Pups;
                case CompetitionClass.Categories.NineToFifteenMonths:
                case CompetitionClass.Categories.FifteenToTwentyFourMonths:
                case CompetitionClass.Categories.FifteenMonths:
                    return ClassGroupings.Adults;
                case CompetitionClass.Categories.EightYears:
                    return ClassGroupings.Veterans;
            }

            return ClassGroupings.Unknown;
        }
    }
}
