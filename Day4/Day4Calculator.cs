namespace Day4
{
    public class Day4Calculator
    {
        public int Calculate1(List<LineContentDay4> content)
        {
            var numbersCalled = content.First().Numbers;
            var boards = content.Skip(1).Chunk(5).Select(x => x.Select(y => y.Numbers.ToArray()).ToArray()).ToList();

            return GetWinningBoard(boards, numbersCalled);
        }

        public int Calculate2(List<LineContentDay4> content)
        {
            var numbersCalled = content.First().Numbers;
            var boards = content.Skip(1).Chunk(5).Select(x => x.Select(y => y.Numbers.ToArray()).ToArray()).ToList();

            return GetLastWinningBoard(boards, numbersCalled);
        }

        private int GetWinningBoard(List<int[][]> boards, List<int> numbersCalled)
        {
            var boardsTags = boards.Select(x => new bool[][] { new bool[5], new bool[5], new bool[5], new bool[5], new bool[5] }).ToList();

            foreach (var number in numbersCalled)
            {
                for (int indexBoard = 0; indexBoard < boards.Count; indexBoard++)
                {
                    var boardNumbers = boards[indexBoard];
                    var boardTags = boardsTags[indexBoard];
                    SetFlags(number, boardNumbers, boardTags);

                    var boardHasABingo = IsBoardBingo(boardTags);
                    if (boardHasABingo)
                    {
                        return CalculateBoard(boardNumbers, boardTags, number);
                    }
                }
            }

            return 0;
        }

        private int GetLastWinningBoard(List<int[][]> boards, List<int> numbersCalled)
        {
            var boardsTags = boards.Select(x => new bool[][] { new bool[5], new bool[5], new bool[5], new bool[5], new bool[5] }).ToList();

            foreach (var number in numbersCalled)
            {
                for (int indexBoard = 0; indexBoard < boards.Count; indexBoard++)
                {
                    var boardNumbers = boards[indexBoard];
                    var boardTags = boardsTags[indexBoard];
                    SetFlags(number, boardNumbers, boardTags);

                    if (boardsTags.All(x=> IsBoardBingo(x)))
                    {
                        return CalculateBoard(boardNumbers, boardTags, number);
                    }
                }
            }

            return 0;
        }

        private void SetFlags(int number, int[][] numbers, bool[][] flags)
        {
            for (int indexLine = 0; indexLine < numbers.Length; indexLine++)
            {
                var lineOfBoard = numbers[indexLine].ToList();
                var indexOfNumber = lineOfBoard.IndexOf(number);
                if (indexOfNumber >= 0)
                {
                    flags[indexLine][indexOfNumber] = true;
                }
            }
        }

        private int CalculateBoard(int[][] numbers, bool[][] flags, int number)
        {
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    if (!flags[i][j])
                    {
                        sum += numbers[i][j];
                    }
                }
            }

            return sum * number;
        }

        private bool IsBoardBingo(bool[][] flags)
        {
            var bingoHorizontal = flags.Any(x => x.All(y => y));
            if (bingoHorizontal)
            {
                return true;
            }

            for (int i = 0; i < 5; i++)
            {
                if (flags.All(x => x[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
