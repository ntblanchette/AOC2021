namespace Day9
{
    public class Day9Calculator
    {
        public long Calculate1(List<LineContentDay9> content)
        {
            var lowerNumbers = GetLowerAdjacentNumbers(content);

            return lowerNumbers.Sum(x => x + 1);
        }

        public long Calculate2(List<LineContentDay9> content)
        {
            var largestBassins = GetThreeLargestBassin(content);

            return largestBassins.Aggregate((a, x) => a * x);
        }

        private List<int> GetThreeLargestBassin(List<LineContentDay9> content)
        {
            var lowerNumbers = GetLowerAdjacentNumbersPositions(content);
            var largestBassins = GetBassinsSizes(content, lowerNumbers);

            return largestBassins.OrderByDescending(x => x).ToList().GetRange(0, 3);
        }

        private List<int> GetBassinsSizes(List<LineContentDay9> content, List<Tuple<int, int>> lowerIndexes)
        {
            var sizes = new List<int>();
            foreach (var pair in lowerIndexes)
            {
                var indexes = new List<Tuple<int, int>>() { pair };
                GetAdjacentIndexes(content, new List<Tuple<int, int>>() { pair }, indexes);
                sizes.Add(indexes.Count);
            }

            return sizes;
        }

        private List<Tuple<int, int>> GetAdjacentIndexes(List<LineContentDay9> content, List<Tuple<int, int>> indexes, List<Tuple<int, int>> allBassinIndexes)
        {
            var newIndexes = new List<Tuple<int, int>>();
            foreach (var curIndex in indexes)
            {
                newIndexes.AddRange(GetAdjacentIndexes(content, curIndex, allBassinIndexes));
            }

            if (newIndexes.Count > 0)
                return GetAdjacentIndexes(content, newIndexes, allBassinIndexes);

            return newIndexes;
        }

        private List<Tuple<int,int>> GetLowerAdjacentNumbersPositions(List<LineContentDay9> lines)
        {
            var lowerNumbers = new List<Tuple<int, int>>();

            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Numbers.Count; j++)
                {
                    var number = lines[i].Numbers[j];
                    var adjacentNumbers = GetAdjacentNumbers(lines, i, j);

                    if (adjacentNumbers.All(x => number < x))
                    {
                        lowerNumbers.Add(new Tuple<int, int>(i,j));
                    }
                }
            }

            return lowerNumbers;
        }

        private List<int> GetLowerAdjacentNumbers(List<LineContentDay9> lines)
        {
            var lowerNumbers = new List<int>();

            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Numbers.Count; j++)
                {
                    var number = lines[i].Numbers[j];
                    var adjacentNumbers = GetAdjacentNumbers(lines, i, j);

                    if (adjacentNumbers.All(x=> number < x))
                    {
                        lowerNumbers.Add(number);
                    }
                }
            }

            return lowerNumbers;
        }

        private List<int> GetAdjacentNumbers(List<LineContentDay9> lines, int i, int j)
        {
            var jMinus1 = j - 1;
            var jPlus1 = j + 1;
            var iMinus1 = i - 1;
            var iPlus1 = i + 1;

            var numbers = new List<int>();
            if (jMinus1 >= 0)
            {
                numbers.Add(lines[i].Numbers[jMinus1]);
            }
            if (jPlus1 < lines[i].Numbers.Count)
            {
                numbers.Add(lines[i].Numbers[jPlus1]);
            }
            if (iMinus1 >= 0)
            {
                numbers.Add(lines[iMinus1].Numbers[j]);
            }
            if (iPlus1 < lines.Count)
            {
                numbers.Add(lines[iPlus1].Numbers[j]);
            }

            return numbers;
        }

        private List<Tuple<int, int>> GetAdjacentIndexes(List<LineContentDay9> lines, Tuple<int, int> pair, List<Tuple<int, int>> allBassinIndexes)
        {
            var i = pair.Item1;
            var j = pair.Item2;

            var jMinus1 = j - 1;
            var jPlus1 = j + 1;
            var iMinus1 = i - 1;
            var iPlus1 = i + 1;

            var indexes = new List<Tuple<int,int>>();
            if (jMinus1 >= 0 && lines[i].Numbers[jMinus1] != 9)
            {
                indexes.Add(new Tuple<int, int>(i, jMinus1));
            }
            if (jPlus1 < lines[i].Numbers.Count && lines[i].Numbers[jPlus1] != 9)
            {
                indexes.Add(new Tuple<int, int>(i, jPlus1));
            }
            if (iMinus1 >= 0 && lines[iMinus1].Numbers[j] != 9)
            {
                indexes.Add(new Tuple<int, int>(iMinus1, j));
            }
            if (iPlus1 < lines.Count && lines[iPlus1].Numbers[j] != 9)
            {
                indexes.Add(new Tuple<int, int>(iPlus1, j));
            }

            var newPairs = indexes.Except(allBassinIndexes).ToList();
            
            allBassinIndexes.AddRange(newPairs);

            return newPairs;
        }
    }
}
