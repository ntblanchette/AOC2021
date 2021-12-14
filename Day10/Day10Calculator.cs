namespace Day10
{
    public class Day10Calculator
    {
        public long Calculate1(List<LineContentDay10> content)
        {
            var illegalChars = GetIllegalCaracters(content);

            return illegalChars.Select(x => GetPointsCalc1(x)).Sum();
        }

        private int GetPointsCalc1(char x)
        {
            if (x == ')')
            {
                return 3;
            }
            else if (x == ']')
            {
                return 57;
            }
            else if (x == '}')
            {
                return 1197;
            }
            else if (x == '>')
            {
                return 25137;
            }
            else
            {
                return 0;
            }
        }

        private List<char> GetIllegalCaracters(List<LineContentDay10> content)
        {
            var list = new List<char>();

            foreach (var line in content)
            {
                list.Add(GetFirstIllegalCaracter(line.Chunks));
            }

            return list;
        }

        private char GetFirstIllegalCaracter(string chunks)
        {
            string stringRemovedFromLegalChars = RemoveAllIllegalChars(ref chunks);

            var index = stringRemovedFromLegalChars.IndexOfAny(new char[] { ')', ']', '}', '>' });
            if (index >= 0)
                return chunks[index];

            return ' ';
        }

        private string RemoveAllIllegalChars(ref string chunks)
        {
            var stringRemovedFromLegalChars = RemoveLegalChars(chunks);
            while (stringRemovedFromLegalChars != chunks)
            {
                chunks = stringRemovedFromLegalChars;
                stringRemovedFromLegalChars = RemoveLegalChars(chunks);
            }

            return stringRemovedFromLegalChars;
        }

        private string RemoveLegalChars(string chunks)
        {
            return chunks.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");
        }

        public long Calculate2(List<LineContentDay10> content)
        {
            var incompletes = GetIncompleteLines(content).OrderBy(x => x).ToList();
            var newIndex = incompletes.Count / 2;
            return incompletes[newIndex];
        }

        private List<long> GetIncompleteLines(List<LineContentDay10> content)
        {
            var list = new List<long>();

            foreach (var line in content)
            {
                var incompleteString = GetIncompleteString(line.Chunks);
                if (incompleteString != null)
                {
                    list.Add(CalcPointsFromIncompleteSequence(incompleteString));
                }                    
            }

            return list;
        }

        private long CalcPointsFromIncompleteSequence(string incompleteString)
        {
            var listOfChars = "";
            for (var i = incompleteString.Length - 1; i >= 0; i--)
            {
                var c = incompleteString[i];
                listOfChars += GetReverseChar(c);
            }

            var points = 0L;
            foreach (var c in listOfChars)
            {
                points = (points * 5) + GetPointsCalc2(c);
            }

            return points;
        }

        private int GetPointsCalc2(char x)
        {
            if (x == ')')
            {
                return 1;
            }
            else if (x == ']')
            {
                return 2;
            }
            else if (x == '}')
            {
                return 3;
            }
            else if (x == '>')
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private char GetReverseChar(char x)
        {
            if (x == '(')
            {
                return ')';
            }
            else if (x == '[')
            {
                return ']';
            }
            else if (x == '{')
            {
                return '}';
            }
            else if (x == '<')
            {
                return '>';
            }

            throw new ArgumentException();
        }

        private string GetIncompleteString(string chunks)
        {
            string stringRemovedFromLegalChars = RemoveAllIllegalChars(ref chunks);

            var index = stringRemovedFromLegalChars.IndexOfAny(new char[] { ')', ']', '}', '>' });
            if (index < 0)
                return stringRemovedFromLegalChars;

            return null;
        }
    }
}
