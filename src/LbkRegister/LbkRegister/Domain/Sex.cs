namespace LbkRegister.Domain {
    public static class Sex {
        private const string _maleIdentifier = "hane";
        private const string _femaleIdentifier = "tik";

        public enum Genders {
            Unknown = 0,
            Male = 1,
            Female = 2
        }

        public static Genders FromInput(this string input) {
            if (input.ToLower().Contains(_maleIdentifier)) {
                return Genders.Male;
            }

            if (input.ToLower().Contains(_femaleIdentifier)) {
                return Genders.Female;
            }

            return Genders.Unknown;
        }
    }
}
