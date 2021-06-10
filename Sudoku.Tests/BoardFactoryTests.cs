using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Tests
{
    [TestClass]
    public class BoardFactoryTests
    {
        private FileReader _fileReader;
        private BoardFactory _boardFactory;

        [TestInitialize]
        public void TestInitialize()
        {

            _fileReader = new FileReader();
            _boardFactory = new BoardFactory(_fileReader);
        }

        [TestMethod]
        public void Build4x4Board_WithNormalParser_ReturnsCorrect()
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

            //Act
            Board board = _boardFactory.Build(path);

            //Assert
            Assert.IsNotNull(board);
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build6x6Board_WithNormalParser_ReturnsCorrect()
        {
            //Arrange

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


            //Assert
            Assert.IsNotNull(board);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build9x9Board_WithNormalParser_ReturnsCorrect()
        {
            //Arrange

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

            //Assert
            Assert.IsNotNull(board);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [TestMethod]
        public void Build4JigsawBoard_WithJigsawParser_ReturnsCorrect()
        {
            //Arrange

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

            //Assert
            Assert.IsNotNull(board);

            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}