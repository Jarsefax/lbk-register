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
                    return Rings.One;
                case CompetitionGroup.Groups.Two:
                    return Rings.One;
                case CompetitionGroup.Groups.Four:
                    return Rings.One;
                case CompetitionGroup.Groups.Nine:
                    return Rings.One;

                case CompetitionGroup.Groups.Three:
                    return Rings.Two;
                case CompetitionGroup.Groups.Five:
                    return Rings.Two;
                case CompetitionGroup.Groups.Six:
                    return Rings.Two;
                case CompetitionGroup.Groups.Seven:
                    return Rings.Two;
                case CompetitionGroup.Groups.Eight:
                    return Rings.Two;
                case CompetitionGroup.Groups.Ten:
                    return Rings.Two;
            }

            return Rings.Unknown;
        }
    }
}
