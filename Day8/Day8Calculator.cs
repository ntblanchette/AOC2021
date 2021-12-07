namespace Day8
{
    public class Day8Calculator
    {
        private static List<int> Paterns => new() { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };

        public long Calculate1(List<LineContentDay8> content)
        {
            var count = 0;
            foreach (var line in content)
            {
                count += line.Digits.Count(x => UniqueNumberOfSegments(x));
            }

            return count;
        }

        public long Calculate2(List<LineContentDay8> content)
        {
            var count = 0;
            foreach (var line in content)
            {
                count += CalculateLineValue(line);
            }

            return count;
        }

        private int CalculateLineValue(LineContentDay8 line)
        {
            var strDigit = "";
            foreach(var t in line.Digits)
            {
                strDigit += CalcPatern(t);

            }

            return Convert.ToInt32(strDigit);
        }

        private int CalcPatern(List<char> charList)
        {
            var t = GetNumberPossibilities(charList);
            if (t.Count == 1)
            {
                return t[0];
            }

            return 0;
        }

        private bool UniqueNumberOfSegments(List<char> charList)
        {
            return GetNumberPossibilities(charList).Count == 1;
        }

        private List<int> GetNumberPossibilities(List<char> charList)
        {
            var charCount = charList.Count;
            var indexes = new List<int>();

            for (int i = 0; i < Paterns.Count; i++)
            {
                if (Paterns[i] == charCount) {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

    }
}
