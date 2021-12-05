using Common.Services;

namespace Day5
{
    public class LineContentDay5Mapper : ILineContentMapper<LineContentDay5>
    {
        public LineContentDay5 Map(string[] array)
        {
            var firstPart = array[0];
            var secondPart = array[2];
            var obj = new LineContentDay5
            {
                x1 = Convert.ToInt32(firstPart.Split(',')[0]),
                y1 = Convert.ToInt32(firstPart.Split(',')[1]),
                x2 = Convert.ToInt32(secondPart.Split(',')[0]),
                y2 = Convert.ToInt32(secondPart.Split(',')[1]),
            };

            return obj;
        }
    }
}
