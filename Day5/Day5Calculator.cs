namespace Day5
{
    public class Day5Calculator
    {
        public int Calculate1(List<LineContentDay5> content)
        {
            var maxIndexX = content.Max(x => Math.Max(x.x1, x.x2)) + 1;
            var maxIndexY = content.Max(x => Math.Max(x.y1, x.y2)) + 1;
            var array = new int[maxIndexX, maxIndexY];

            foreach (var pos in content)
            {
                if (pos.x1 == pos.x2)
                {
                    var minY = Math.Min(pos.y1, pos.y2);
                    var maxY = Math.Max(pos.y1, pos.y2);
                    for (var i = minY; i <= maxY; i++)
                    {
                        array[pos.x1, i]++;
                    }
                }

                if (pos.y1 == pos.y2)
                {
                    var minX = Math.Min(pos.x1, pos.x2);
                    var maxX = Math.Max(pos.x1, pos.x2);
                    for (var i = minX; i <= maxX; i++)
                    {
                        array[i, pos.y1]++;
                    }
                }
            }

            return CountArray(array);
        }

        public int Calculate2(List<LineContentDay5> content)
        {
            var maxIndexX = content.Max(x => Math.Max(x.x1, x.x2)) + 1;
            var maxIndexY = content.Max(x => Math.Max(x.y1, x.y2)) + 1;
            var array = new int[maxIndexX, maxIndexY];

            foreach (var pos in content)
            {
                if (pos.x1 == pos.x2)
                {
                    var minY = Math.Min(pos.y1, pos.y2);
                    var maxY = Math.Max(pos.y1, pos.y2);
                    for (var i = minY; i <= maxY; i++)
                    {
                        array[pos.x1, i]++;
                    }
                }
                else
                {
                    if (pos.y1 == pos.y2)
                    {
                        var minX = Math.Min(pos.x1, pos.x2);
                        var maxX = Math.Max(pos.x1, pos.x2);
                        for (var i = minX; i <= maxX; i++)
                        {
                            array[i, pos.y1]++;
                        }
                    }
                    else
                    {
                        var x = pos.x1;
                        var endingX = pos.x2;
                        var growingX = pos.x1 < pos.x2;

                        var y = pos.y1;
                        var endingY = pos.y2;
                        var growingY = pos.y1 < pos.y2;

                        array[pos.x1, pos.y1]++;
                        while (x != endingX)
                        {
                            if (growingX)
                            {
                                x++;
                            }
                            else
                            {
                                x--;
                            }

                            if (growingY)
                            {
                                y++;
                            }
                            else
                            {
                                y--;
                            }

                            array[x, y]++;
                        }
                    }
                }
            }

            return CountArray(array);
        }

        private int CountArray(int[,] array)
        {
            var count = 0;
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] >= 2)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
