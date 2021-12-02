namespace Day1
{
    public class IntCalculator
    {
        public int GetIncreases(List<int> listOfInt)
        {
            var counter = 0;
            
            for (int i = 1; i < listOfInt.Count; i++)
            {
                var previousElem = listOfInt[i - 1];
                var currentElem = listOfInt[i];

                if (currentElem > previousElem)
                {
                    counter++;
                }
            }

            return counter;
        }

        public List<int> GetThreeMeasurementList(List<int> listOfInt)
        {
            var list = new List<int>();

            for (int i = 0; i <= listOfInt.Count - 3; i++)
            {
                var sum = listOfInt.GetRange(i, 3).Sum(x => x);
                list.Add(sum);
            }

            return list;
        }
    }
}
