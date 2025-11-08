using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using House;

namespace Testen
{
    [TestFixture]
    public class HouseOperationsTests
    {
        
      
      [Test]
      public void Exercise1_GivenAListOfHouses_ReturnsAListWithHousesWhereThePriceIsBiggerThan150000()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            var sut = new HouseOperations(listOfHouses);
            //Act
            var resultOne = sut.Exercise1()[0];
            var resultTwo= sut.Exercise1()[1];
            int resultThree= sut.Exercise1()[2].Bouwjaar;
            //Assert
            Assert.That(resultOne.Eigenaar, Is.EqualTo("Axel"));
            Assert.That(resultTwo.Eigenaar, Is.EqualTo("Jef"));
            Assert.That(resultThree, Is.EqualTo(1970));

        }
        [Test]
        public void Exercise2_GivenAListOfHouses_ReturnsAListWithHousesWhereThePriceIsLowerThan175000AndBuildYearHigherThan2010()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            var sut = new HouseOperations(listOfHouses);
            //Act+Assert
            Assert.That(sut.Exercise2()[0].Eigenaar, Is.EqualTo("Jef"));
            Assert.That(sut.Exercise2()[1].Eigenaar, Is.EqualTo("Jan"));          
        }
        [Test]
        public void Exercise3_GivenAListOfHouses_ReturnsAIEnumerableWithMunicipilatiesThatExists()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            var sut = new HouseOperations(listOfHouses);
            //Act+Assert
            Assert.That(sut.Exercise3().Contains("Brussel"));
            Assert.That(sut.Exercise3().Contains("Gent"));
            Assert.That(sut.Exercise3().Contains("Aalst"));
            Assert.That(sut.Exercise3().Contains("Antwerpen"));
        }
        [Test]
        public void Exercise4_GivenAListOfHouses_ReturnsAIEnumerableWithMunicipilatiesThatHaveAppartments()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var house9 = new _House("SpiderMan", "Vilvoorde", 1970, 160000, Housetype.Appartement);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            listOfHouses.Add(house9);
            var sut = new HouseOperations(listOfHouses);
            //Act+Assert
            Assert.That(sut.Exercise4().Contains("Brussel"));
            Assert.That(sut.Exercise4().Contains("Vilvoorde"));

        }
        [Test]
        public void Exercise5_GivenAListOfHouses_ReturnsTheAveragePriceOfSemiOpenHouses()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            var sut = new HouseOperations(listOfHouses);
            //Act
            double result= sut.Exercise5();
            //Assert
            Assert.That(result, Is.EqualTo(156666.67));
        }
        [Test]
        public void Exercise6_GivenAListOfHouses_ReturnsTheMostExpensiveHouseWithoutOwner()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Jef", "Brussel", 1970, 160000, Housetype.Halfopen);
            var house9 = new _House("Brussel", 1970, 222222, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            listOfHouses.Add(house9);
            var sut = new HouseOperations(listOfHouses);
            //Act
            double result = sut.Exercise6();
            //Assert
            Assert.That(result, Is.EqualTo(222222));
        }

        [Test]
        public void Exercise7_GivenAListOfHouses_ReturnsTheThreeOldestHousesFromBrussels()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Abdelmounaim", "Brussel", 1970, 160000, Housetype.Halfopen);
            
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
           
            var sut = new HouseOperations(listOfHouses);
            //Act
            var result = sut.Exercise7();
            //Assert
            Assert.That(result[0].Eigenaar, Is.EqualTo("Abdelmounaim"));
            Assert.That(result[1].Eigenaar, Is.EqualTo("Jos"));
            Assert.That(result[2].Eigenaar, Is.EqualTo("Jef"));
            Assert.That(result[2].Prijs, Is.EqualTo(250000));
        }

        [Test]
        public void Exercise8_GivenAListOfHouses_ReturnsHousesBuildedBefore2000AndThatAreHalfOpen()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Abdelmounaim", "Brussel", 1970, 160000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            var sut = new HouseOperations(listOfHouses);
            //Act
            var result = sut.Exercise8();
            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        //[Test]
        //public void Exercise9_GivenAListOfHouses_ReturnTheOwnersWithMoreThan2Houses()
        //{
            
        //}

        [Test]
        public void Exercise10_GivenAlistOfHouses_ReturnsMunicipalitiesThatHaveAHalfOpenHouseMoreExpensiveThan120000()
        {
            //Arrange
            var house1 = new _House("Jef", "Brussel", 2017, 150000, Housetype.Appartement);
            var house2 = new _House("Jos", "Brussel", 2009, 100000, Housetype.Appartement);
            var house3 = new _House("Jos", "Gent", 1990, 145000, Housetype.Open);
            var house4 = new _House("Piet", "Aalst", 1980, 110000, Housetype.Halfopen);
            var house5 = new _House("Jan", "Antwerpen", 2018, 125000, Housetype.Open);
            var house6 = new _House("Axel", "Brussel", 2020, 200000, Housetype.Halfopen);
            var house7 = new _House("Jef", "Brussel", 2017, 250000, Housetype.Open);
            var house8 = new _House("Abdelmounaim", "Laken", 1970, 160000, Housetype.Halfopen);
            var house9= new _House("Slager", "Evere", 2005, 270000, Housetype.Halfopen);
            var listOfHouses = new List<_House>();
            listOfHouses.Add(house1);
            listOfHouses.Add(house2);
            listOfHouses.Add(house3);
            listOfHouses.Add(house4);
            listOfHouses.Add(house5);
            listOfHouses.Add(house6);
            listOfHouses.Add(house7);
            listOfHouses.Add(house8);
            listOfHouses.Add(house9);
            var sut = new HouseOperations(listOfHouses);
            //Act
            var result = sut.Exercise10();
            //Assert
            Assert.That(result[0], Is.EqualTo("Brussel"));
            Assert.That(result[1], Is.EqualTo("Evere"));
            Assert.That(result[2], Is.EqualTo("Laken"));


        }
    }

   
}
