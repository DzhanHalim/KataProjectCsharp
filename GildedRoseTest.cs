using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        GildedRose g = new GildedRose();

        [Test]
        public void CheckIfIncreasInQualityItemTest()
        {
            //Arrange
            Item item = new Item { Name = "Aged Brie" };

            //Act
            Assert.IsTrue(g.CheckIfIncreasInQualityItem(item));
        }

        [Test]
        public void CheckSpecialItemTest()
        {
            //Arrange
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
           

            //Act
            Assert.IsTrue(g.CheckSpecialItem(item));

        }

        [Test]
        public void UpdateQualityOfBackstageTest()
        {
            //Arrange          
            Item backstageItem = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 5, SellIn = -1 };
            //Assert
            g.UpdateQualityOfBackstage(backstageItem);

            //Act
            Assert.AreEqual(backstageItem.Quality, 0);

        }

        [Test]
        public void IncreaseQualityTestNegativeSellin()
        {
            //Arrange            
            Item item = new Item() { Name = "Aged Brie", Quality = 5, SellIn = -2 };

            //Assert            
            g.IncreaseQuality(item);


            //Act
            Assert.AreEqual(item.Quality, 7);

        }
        [Test]
        public void IncreaseQualityTestPositiveSellin()
        {
            //Arrange            
            Item item = new Item() { Name = "Aged Brie", Quality = 5, SellIn = 2 };

            //Assert            
            g.IncreaseQuality(item);


            //Act
            Assert.AreEqual(item.Quality, 6);

        }
        [Test]
        public void IncreaseQualityTestMaxQuality()
        {
            //Arrange            
            Item item = new Item() { Name = "Aged Brie", Quality = 50, SellIn = 2 };

            //Assert            
            g.IncreaseQuality(item);


            //Act
            Assert.AreEqual(item.Quality, 50);

        }

        [Test]
        public void DecreaseQualityTestNegativeSellin()
        {
            //Arrange            
            Item item = new Item() { Name = "Elixir of the Mongoose", Quality = 5, SellIn = -2 };

            //Assert            
            g.DecreaseQuality(item);


            //Act
            Assert.AreEqual(item.Quality, 3);

        }
        [Test]
        public void DecreaseQualityTestPositiveSellin()
        {
            //Arrange            
            Item item = new Item() { Name = "Elixir of the Mongoose", Quality = 5, SellIn = 2 };

            //Assert            
            g.DecreaseQuality(item);

            //Act
            Assert.AreEqual(item.Quality, 4);

        }

        [Test]
        public void DecreaseQualityTestMinimumQuality()
        {
            //Arrange            
            Item item = new Item() { Name = "Elixir of the Mongoose", Quality = 0, SellIn = 2 };

            //Assert            
            g.DecreaseQuality(item);

            //Act
            Assert.AreEqual(item.Quality, 0);
        }
        [Test]
        public void DecreaseQualityTestConjuredItems()
        {
            //Arrange            
            Item item = new Item() { Name = "Conjured Item", Quality = 1, SellIn = 2 };

            //Assert            
            g.DecreaseQuality(item);

            //Act
            Assert.AreEqual(item.Quality, 0);
        }
    }
}
