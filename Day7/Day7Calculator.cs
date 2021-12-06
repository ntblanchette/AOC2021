namespace Day7
{
    public class Day7Calculator
    {
        public long Calculate1(List<LineContentDay7> content)
        {
            var crabsHorizontalPositions = content[0].Crabs;
            var listOfFuel = GetListOfFuel(crabsHorizontalPositions, (x) => x);
            return listOfFuel.Min(x => x);
        }

        public long Calculate2(List<LineContentDay7> content)
        {
            var crabsHorizontalPositions = content[0].Crabs;
            var listOfFuel = GetListOfFuel(crabsHorizontalPositions, (x) => AddAllFuels(x));
            return listOfFuel.Min(x => x);
        }

        private List<long> GetListOfFuel(List<int> crabsHorizontalPositions, Func<long, long> AddFunction)
        {
            var listOfFuel = new List<long>();
            for (int i = 0; i < crabsHorizontalPositions.Count; i++)
            {
                var position1 = crabsHorizontalPositions[i];
                var fuel = 0L;
                for (int j = 0; j < crabsHorizontalPositions.Count; j++)
                {
                    var position2 = crabsHorizontalPositions[j];
                    fuel += AddFunction(Math.Abs(position1 - position2));
                }
                listOfFuel.Add(fuel);
            }

            return listOfFuel;
        }

        private long AddAllFuels(long positions)
        {
            var result = 0L;
            for (int i = 1; i <= positions; i++)
            {
                result += i;
            }

            return result;
        }
    }
}
