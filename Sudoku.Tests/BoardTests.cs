using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void Build4x4Board_With4x4File_ReturnsCorrect()
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
        public void Build6x6Board_WithNormalParser_ReturnsCorrect()
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
        public void Build9x9Board_WithNormalParser_ReturnsCorrect()
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
        public void Build4JigsawBoard_WithJigsawParser_ReturnsCorrect()
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