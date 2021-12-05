namespace Day6
{
    public class Day6Calculator
    {
        public long Calculate1(List<LineContentDay6> content, int numberOfDays)
        {
            var dicOfFish = InitDictionnary(content[0].ListOfFish);
            for (int i = 1; i <= numberOfDays; i++)
            {
                var newFish = ProcessFishList(dicOfFish);
            }

            return dicOfFish.Sum(x=>x.Value);
        }

        private Dictionary<int, long> InitDictionnary(List<int> listOfFish)
        {
            var dic = new Dictionary<int, long>();
            for (int i = 0; i <= 8; i++)
            {
                dic.Add(i, listOfFish.Count(x => x == i));
            }

            return dic;
        }

        private long ProcessFishList(Dictionary<int, long> dicOfFish)
        {
            var numberOfNewFish = dicOfFish[0];
            for (int i = 1; i <= 8; i++)
            {
                dicOfFish[i - 1] = dicOfFish[i];
            }
            dicOfFish[8] = numberOfNewFish;
            dicOfFish[6] += numberOfNewFish;

            return numberOfNewFish;
        }
    }
}
