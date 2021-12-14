using Common.Services;

namespace Day10
{
    public class LineContentDay10Mapper : ILineContentMapper<LineContentDay10>
    {
        public LineContentDay10 Map(string[] array)
        {
            var obj = new LineContentDay10
            {
                Chunks = array[0]
            };

            return obj;
        }
    }
}
