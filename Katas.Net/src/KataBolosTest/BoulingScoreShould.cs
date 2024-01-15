using KatasBolos;

namespace KataBolosTest {
    public class BoulingScoreShould {

        private BoulingScore boulingScore;

        [SetUp]
        public void Setup() {
            boulingScore = new BoulingScore();
        }

        [Test]
        public void Do_Not_Return_Result_If_Match_Have_Not_Ten_Frames() {
            var errorFrames = "X|X|X|X|X|X|X|X|X||XX";

            Assert.Throws<ArgumentException>(() => boulingScore.Score(errorFrames));
        }

        [TestCase("X|@|X|X|X|X|X|X|X|XX")]
        [TestCase("X|*|X|X|X|X|X|X|X|XX")]
        [TestCase("X|X|€|X|X|X|X|X|X|XX")]
        [TestCase("X|5-|X|X|X|X|X|X|X|+")]
        [TestCase("X%5-%X%X%X%X%X%X%X%--")]
        public void Do_Not_Return_Result_If_Any_Frame_Have_Straing_Chars(string frames) {
            Assert.Throws<ArgumentException>(() => boulingScore.Score(frames));
        }

        [Test]
        public void Return_300_If_All_Frames_Are_Strike() {
            var allStrikeFrames = "X|X|X|X|X|X|X|X|X|XX";

            var result = boulingScore.Score(allStrikeFrames);

            Assert.AreEqual(300, result);
        }
    }
}