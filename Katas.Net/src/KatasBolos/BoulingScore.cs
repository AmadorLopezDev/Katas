using System.Text.RegularExpressions;

namespace KatasBolos {
    public class BoulingScore {
        public int Score(string game) {
            var frames = game.Split('|');
            ValidateFrames(frames);

            if (frames.All(frame => frame == "X" || frame == "XX"))
                return 300;

            return 0;
        }

        private static void ValidateFrames(string[] frames) {
            HaveNotTenFrames(frames);
            AllCharactersAreValid(frames);
        }

        private static void AllCharactersAreValid(string[] frames) {
            var regex = new Regex(@"^[X|\d|\-|\/]{1,2}$");
            foreach (var frame in frames) {
                if (!regex.IsMatch(frame)) {
                    throw new System.ArgumentException("Match must have valid frames");
                }
            }
        }

        private static void HaveNotTenFrames(string[] frames) {
            if (frames.Length != 10) {
                throw new System.ArgumentException("Match must have ten frames");
            }
        }
    }
}