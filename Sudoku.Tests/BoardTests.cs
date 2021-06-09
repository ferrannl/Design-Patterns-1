using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Solve_4x4Board_ReturnsCorrect()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Board board = new Board();

            // Act
            var result = board.Solve();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Solve_6x6Board_ReturnsCorrect()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Board board = new Board();

            // Act
            var result = board.Solve();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Solve_9x9Board_ReturnsCorrect()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Board board = new Board();

            // Act
            var result = board.Solve();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Solve_JigsawBoard_ReturnsCorrect()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Board board = new Board();

            // Act
            var result = board.Solve();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Solve_SamuraiBoard_ReturnsCorrect()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Board board = new Board();

            // Act
            var result = board.Solve();

            // Assert
            Assert.IsTrue(result);
        }
    }
}