namespace LbkRegister.Domain {
    public static class CompetitionRing {
        public enum Rings {
            Unknown,
            One,
            Two
        }

        public static Rings FromGroup(this CompetitionGroup.Groups group) {
            switch (group) {
                case CompetitionGroup.Groups.Unknown:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.One:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Two:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Three:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Four:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Five:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Six:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Seven:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Eight:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Nine:
                    return Rings.Unknown;
                case CompetitionGroup.Groups.Ten:
                    return Rings.Unknown;
            }

            return Rings.Unknown;
        }
    }
}
