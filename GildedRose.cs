using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public List<string> IncreasInQualityItems = new List<string>();
        public GildedRose()
        {
            // this list is currently filled by me, but if there will be conneciton to the DB, then this code will be
            // removed
            IncreasInQualityItems.Add("Aged Brie");
            IncreasInQualityItems.Add("Backstage passes to a TAFKAL80ETC concert");
        }

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            // this list is currently filled by me, but if there will be conneciton to the DB, then this code will be
            // removed
            IncreasInQualityItems.Add("Aged Brie");
            IncreasInQualityItems.Add("Backstage passes to a TAFKAL80ETC concert");
        }
        public bool CheckIfIncreasInQualityItem(Item i)
        {
            if (IncreasInQualityItems.Contains(i.Name))
            {
                return true;
            }
            return false;
        }


        public bool CheckSpecialItem(Item i)
        {
            // this is a current solution, if we have more special items in the future
            // then I would create a list of those items and check if the current item name exists in that list            
            if (i.Name == "Sulfuras, Hand of Ragnaros")
            {
                return true;
            }
            return false;
        }
        public void UpdateQualityOfBackstage(Item item)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 11)
                {
                    item.Quality++;
                }

                if (item.SellIn <= 6)
                {
                    item.Quality++;
                }

                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
            }
        }
        public void IncreaseQuality(Item i)
        {
            if (i.Quality < 50)
            {
                i.Quality++;
            }
            if (i.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateQualityOfBackstage(i);
            }
            else
            {
                if (i.SellIn <= 0 && i.Quality < 50)
                {
                    i.Quality++;
                }
            }
        }

        public void DecreaseQuality(Item i)
        {
            if (i.Quality > 0)
            {
                i.Quality--;
            }
            if (i.SellIn <= 0 && i.Quality > 0)
            {
                i.Quality--;
            }
            // for conjured items, this is a current solution, if we have more items in the future that decrease twice
            // each day, then I would create a list of those items and check if the current item name exists in that list            
            if (i.Name.Contains("Conjured") && i.Quality > 0)
            {
                i.Quality--;
            }

        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                //if not a special item
                if (!CheckSpecialItem(item))
                {

                    // if decrease in quality item
                    if (!CheckIfIncreasInQualityItem(item))
                    {
                        DecreaseQuality(item);
                    }

                    // if increase in quality item
                    else
                    {
                        IncreaseQuality(item);
                    }

                    // decrease selling day
                    item.SellIn--;
                    if (item.Quality > 50)
                    {
                        item.Quality = 50;
                    }
                }
            }
        }
    }
}
