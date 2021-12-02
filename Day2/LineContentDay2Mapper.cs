using Common.Enums;
using Common.Services;

namespace Day2
{
    public class LineContentDay2Mapper : ILineContentMapper<LineContentDay2>
    {
        public LineContentDay2 Map(string[] array)
        {
            var obj = new LineContentDay2
            {
                Direction = (EnumDirections)Enum.Parse(typeof(EnumDirections), array[0]),
                Movement = Convert.ToInt32(array[1])
            };

            return obj;
        }
    }
}
