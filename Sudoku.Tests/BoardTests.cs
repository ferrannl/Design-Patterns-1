using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Enums;

namespace Sudoku.Tests
{
    [TestClass]
    public class BoardTests
    {
        private FileReader _fileReader;
        private BoardFactory _boardFactory;
        private int _y;
        private int _x;
        private int _cells;
        private int _fields;
        [TestInitialize]
        public void TestInitialize()
        {
            _y = 0;
            _x = 0;
            _cells = 0;
            _fileReader = new FileReader();
            _boardFactory = new BoardFactory(_fileReader);
        }

        [TestMethod]
        public void Build4x4Board_With4x4File_ReturnsCorrectBoard()
        {
            //Arrange
            _y = 4;
            _x = 4;
            _cells = 16;
            _fields = _y * 3;
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile4x4.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("0340400210030210");
            }

            //Act
            Board board = _boardFactory.Build(path);

            //Assert - Check if board has the right amount of fields
            Assert.AreEqual(_fields, board.Fields.Count);
            int cellCounter = 0;
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellCounter++;
                        }
                    }
                }

            }
            //Assert - Check if board has the right amount of cells that are not null
            Assert.AreEqual(_cells, cellCounter);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build6x6Board_WithNormalParser_ReturnsCorrectBoard()
        {
            //Arrange
            _y = 6;
            _x = 6;
            _cells = 36;
            _fields = _y * 3;
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile6x6.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("003010560320054203206450012045040100");
            }

            //Act
            Board board = _boardFactory.Build(path);


            //Assert - Check if board has the right amount of fields
            Assert.AreEqual(_fields, board.Fields.Count);
            int cellCounter = 0;
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellCounter++;
                        }
                    }
                }

            }
            //Assert - Check if board has the right amount of cells that are not null
            Assert.AreEqual(_cells, cellCounter);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build9x9Board_WithNormalParser_ReturnsCorrectBoard()
        {
            //Arrange
            _y = 9;
            _x = 9;
            _cells = 81;
            _fields = _y * 3;
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile9x9.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("700509001000000000150070063003904100000050000002106400390040076000000000600201004");
            }

            //Act
            Board board = _boardFactory.Build(path);

            //Assert - Check if board has the right amount of fields
            Assert.AreEqual(_fields, board.Fields.Count);
            int cellCounter = 0;
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellCounter++;
                        }
                    }
                }

            }
            //Assert - Check if board has the right amount of cells that are not null
            Assert.AreEqual(_cells, cellCounter);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build4JigsawBoard_WithJigsawParser_ReturnsCorrectBoard()
        {
            //Arrange
            _y = 9;
            _x = 9;
            _cells = 81;
            _fields = _y * 3;
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFilejigsaw.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("SumoCueV1=0J0=8J0=0J0=0J1=0J2=0J2=0J2=5J2=0J2=8J3=0J0=0J1=0J1=0J2=7J2=0J4=0J4=5J4=0J3=0J0=0J1=0J1=9J2=0J2=0J5=0J6=0J4=0J3=7J0=0J1=1J1=6J5=9J5=0J5=0J6=0J4=0J3=0J0=4J1=3J1=0J5=1J7=8J7=0J6=0J4=0J3=0J0=0J5=8J5=7J5=6J7=0J7=3J6=0J4=0J3=0J0=0J5=0J8=5J8=0J7=0J7=0J6=0J4=3J3=0J3=0J3=6J8=0J8=0J7=0J7=0J6=2J4=0J8=9J8=0J8=0J8=0J8=0J7=0J6=8J6=0J6");
            }

            //Act
            Board board = _boardFactory.Build(path);

            //Assert - Check if board has the right amount of fields
            Assert.AreEqual(_fields, board.Fields.Count);
            int cellCounter = 0;
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellCounter++;
                        }
                    }
                }

            }
            //Assert - Check if board has the right amount of cells that are not null
            Assert.AreEqual(_cells, cellCounter);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Solve_4x4Board_ReturnsCorrect()
        {
            //Arrange

            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile4x4.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("0340400210030210");
            }
            var pathToSolvedBoard = AppDomain.CurrentDomain.BaseDirectory + "/testFile4x4Solved.txt";
            using (var file = File.Create(pathToSolvedBoard))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(pathToSolvedBoard))
            {
                outputFile.WriteLine("2341413214233214");
            }


            //Act
            Board board = _boardFactory.Build(path);
            Board solvedBoard = _boardFactory.Build(pathToSolvedBoard);
            board.Solve();
            string cells = "";
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cells = cells + cell.Value;
                        }
                    }
                }

            }
            string cellsSolved = "";
            foreach (var field in solvedBoard.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellsSolved = cellsSolved + cell.Value;
                        }
                    }
                }

            }
            //Assert
            Assert.AreEqual(cells, cellsSolved);
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            if (System.IO.File.Exists(pathToSolvedBoard))
            {
                File.Delete(pathToSolvedBoard);
            }
        }

        [TestMethod]
        public void Solve_6x6Board_ReturnsCorrect()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile6x6.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("003010560320054203206450012045040100");
            }
            var pathToSolvedBoard = AppDomain.CurrentDomain.BaseDirectory + "/testFile6x6Solved.txt";
            using (var file = File.Create(pathToSolvedBoard))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(pathToSolvedBoard))
            {
                outputFile.WriteLine("423516561324154263236451312645645132");
            }


            //Act
            Board board = _boardFactory.Build(path);
            Board solvedBoard = _boardFactory.Build(pathToSolvedBoard);
            board.Solve();
            string cells = "";
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cells = cells + cell.Value;
                        }
                    }
                }

            }
            string cellsSolved = "";
            foreach (var field in solvedBoard.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellsSolved = cellsSolved + cell.Value;
                        }
                    }
                }

            }
            //Assert
            Assert.AreEqual(cells, cellsSolved);
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            if (System.IO.File.Exists(pathToSolvedBoard))
            {
                File.Delete(pathToSolvedBoard);
            }
        }

        [TestMethod]
        public void Solve_9x9Board_ReturnsCorrect()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile9x9.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("700509001000000000150070063003904100000050000002106400390040076000000000600201004");
            }
            var pathToSolvedBoard = AppDomain.CurrentDomain.BaseDirectory + "/testFile9x9Solved.txt";
            using (var file = File.Create(pathToSolvedBoard))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(pathToSolvedBoard))
            {
                outputFile.WriteLine("734569821926318745158472963863924157419753682572186439391845276245697318687231594");
            }


            //Act
            Board board = _boardFactory.Build(path);
            Board solvedBoard = _boardFactory.Build(pathToSolvedBoard);
            board.Solve();
            string cells = "";
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cells = cells + cell.Value;
                        }
                    }
                }

            }
            string cellsSolved = "";
            foreach (var field in solvedBoard.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellsSolved = cellsSolved + cell.Value;
                        }
                    }
                }

            }
            //Assert
            Assert.AreEqual(cells, cellsSolved);
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            if (System.IO.File.Exists(pathToSolvedBoard))
            {
                File.Delete(pathToSolvedBoard);
            }
        }

        [TestMethod]
        public void Solve_JigsawBoard_ReturnsCorrect()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFileJigsaw.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("SumoCueV1=0J0=6J1=0J1=0J1=0J1=0J2=0J3=7J3=0J3=2J0=4J0=0J1=0J1=0J1=7J2=0J2=5J3=8J3=0J0=0J0=0J0=0J1=0J1=0J2=0J3=0J3=0J3=0J0=8J4=0J0=6J0=5J2=3J2=0J2=0J5=0J3=0J4=0J4=0J4=3J6=0J6=9J2=0J2=0J5=0J5=0J4=0J4=0J4=2J6=7J6=8J7=0J7=3J7=0J5=0J4=0J4=0J8=0J6=0J6=0J7=0J7=0J7=0J5=9J8=2J8=0J8=1J8=0J6=0J6=0J7=6J5=3J5=0J8=5J8=0J8=0J8=0J6=0J7=0J7=8J5=0J5");
            }
            var pathToSolvedBoard = AppDomain.CurrentDomain.BaseDirectory + "/testFileJigsawSolved.txt";
            using (var file = File.Create(pathToSolvedBoard))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(pathToSolvedBoard))
            {
                outputFile.WriteLine("SumoCueV1=8J0=6J1=4J1=5J1=2J1=1J2=3J3=7J3=9J3=2J0=4J0=1J1=9J1=3J1=7J2=6J2=5J3=8J3=3J0=9J0=5J0=7J1=8J1=4J2=1J3=2J3=6J3=1J0=8J4=7J0=6J0=5J2=3J2=2J2=9J5=4J3=5J4=7J4=2J4=3J6=6J6=9J2=8J2=4J5=1J5=6J4=1J4=9J4=2J6=7J6=8J7=4J7=3J7=5J5=4J4=3J4=6J8=8J6=9J6=2J7=5J7=1J7=7J5=9J8=2J8=8J8=1J8=4J6=5J6=7J7=6J5=3J5=7J8=5J8=3J8=4J8=1J6=6J7=9J7=8J5=2J5");
            }


            //Act
            Board board = _boardFactory.Build(path);
            Board solvedBoard = _boardFactory.Build(pathToSolvedBoard);
            board.Solve();
            string cells = "";
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cells = cells + cell.Value;
                        }
                    }
                }
            }
            string cellsSolved = "";
            foreach (var field in solvedBoard.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            cellsSolved = cellsSolved + cell.Value;
                        }
                    }
                }
            }
            //Assert
            Assert.AreEqual(cells, cellsSolved);
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            if (System.IO.File.Exists(pathToSolvedBoard))
            {
                File.Delete(pathToSolvedBoard);
            }
        }

        [TestMethod]
        public void CheckCells_CompareCellsToSolvedBoard_CorrectState()
        {

            var path = AppDomain.CurrentDomain.BaseDirectory + "/testFile9x9.txt";
            using (var file = File.Create(path))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine("700509001000000000150070063003904100000050000002106400390040076000000000600201004");
            }
            var pathToSolvedBoard = AppDomain.CurrentDomain.BaseDirectory + "/testFile9x9Solved.txt";
            using (var file = File.Create(pathToSolvedBoard))
            {

            }
            using (StreamWriter outputFile = new StreamWriter(pathToSolvedBoard))
            {
                outputFile.WriteLine("734569821926318745158472963863924157419753682572186439391845276245697318687231594");
            }

            Board board = _boardFactory.Build(path);
            Board solvedBoard = _boardFactory.Build(pathToSolvedBoard);

            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null)
                        {
                            if (cell.Value == 0)
                            {
                                cell.Value = 2;
                            }
                        }
                    }
                }
            }
            board.CheckCells(solvedBoard);
            int fieldIndex = 0;
            int cellIndex = 0;
            bool checkedCorrectly = true;
            foreach (var field in board.Fields)
            {
                if (field is Row)
                {
                    foreach (var cell in field.Cells)
                    {
                        if (cell != null && cell.Edit)
                        {
                            if (cell.State == CheckedState.Correct)
                            {
                                if (cell.Value != solvedBoard.Fields[fieldIndex].Cells[cellIndex].Value)
                                {
                                    checkedCorrectly = false;
                                }
                            }
                            else if (cell.State == CheckedState.Incorrect)
                            {
                                if (cell.Value == solvedBoard.Fields[fieldIndex].Cells[cellIndex].Value)
                                {
                                    checkedCorrectly = false;
                                }
                            }
                        }
                        cellIndex++;
                    }
                }
                fieldIndex++;
            }

            //Assert
            Assert.IsTrue(checkedCorrectly);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
            if (System.IO.File.Exists(pathToSolvedBoard))
            {
                File.Delete(pathToSolvedBoard);
            }
        }
    }
}