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
                var segmentStrings = DetermineSegementStrings(line);
                for (int i = 0; i < segmentStrings.Length; i++)
                {
                    segmentStrings[i] = Sorted(segmentStrings[i]);
                }

                for (int i = 0; i < line.Digits.Count; i++)
                {
                    line.Digits[i] = Sorted(line.Digits[i]);
                }
                string fourDigitString = "";
                foreach (var segment in line.Digits)
                {
                    for (int i = 0; i < segmentStrings.Length; i++)
                    {
                        if (segmentStrings[i] == segment) fourDigitString += i;
                    }
                }
                count += int.Parse(fourDigitString);
            }

            return count;
        }

        public string Sorted(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }

        private string[] DetermineSegementStrings(LineContentDay8 line)
        {
            string[] segmentStrings = new string[10];
            Extract1478(line, segmentStrings);
            var fourMinusOne = FourMinusOne(segmentStrings);
            Extract960(line, segmentStrings, fourMinusOne);
            Extract253(line, segmentStrings, fourMinusOne);

            return segmentStrings;
        }

        private string FourMinusOne(string[] segments)
        {
            string fourMinusOne = ""; //4-1 vals
            IEnumerable<char> chars = segments[4].Except(segments[1]);
            foreach (var c in chars)
            {
                fourMinusOne += c.ToString();
            }
            return fourMinusOne;
        }

        private void Extract1478(LineContentDay8 line, string[] segments)
        {
            foreach (var segment in line.SignalPaterns)
            {
                switch (segment.Length)
                {
                    case 2:
                        segments[1] = segment;
                        break;
                    case 3:
                        segments[7] = segment;
                        break;
                    case 4:
                        segments[4] = segment;
                        break;
                    case 7:
                        segments[8] = segment;
                        break;
                }
            }
        }

        private void Extract253(LineContentDay8 line, string[] segments, string fourMinusOne)
        {
            for (int i = 0; i < line.SignalPaterns.Count; i++) //determine 253
            {
                if (line.SignalPaterns[i].Length != 5)
                    continue;

                if (line.SignalPaterns[i].Except(segments[1]).Count() == 3) //det 3
                    segments[3] = line.SignalPaterns[i];
                else if (line.SignalPaterns[i].Except(fourMinusOne).Count() == 3) //det 5
                    segments[5] = line.SignalPaterns[i];
                else segments[2] = line.SignalPaterns[i]; //determine 2
            }
        }

        private void Extract960(LineContentDay8 line, string[] segments, string fourMinusOne)
        {
            for (int i = 0; i < line.SignalPaterns.Count; i++) //determine 960
            {
                if (line.SignalPaterns[i].Length != 6)
                    continue;

                if (line.SignalPaterns[i].Except(segments[4]).Count() == 2) //determine 9
                    segments[9] = line.SignalPaterns[i];
                else if (line.SignalPaterns[i].Except(fourMinusOne).Count() == 4) //determine 6
                    segments[6] = line.SignalPaterns[i];
                else segments[0] = line.SignalPaterns[i]; //determine 0
            }
        }

        private bool UniqueNumberOfSegments(string segment)
        {
            return GetNumberPossibilities(segment).Count == 1;
        }

        private List<int> GetNumberPossibilities(string segment)
        {
            var charCount = segment.Length;
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
