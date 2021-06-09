using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void Add_AddingValidNumber_ShouldAddNumberToCandidates()
        {
            // Arrange (Hierin alles klaarzetten wat nodig is, maak een testset d.m.v. Before Each)
            Cell cell = new Cell(4, 5, 6);

            // Act
            cell.AddCandidate(3);

            // Assert
            Assert.AreEqual(cell.Candidates, 3);
        }
    }
}