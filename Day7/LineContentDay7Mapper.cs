using Common.Services;

namespace Day7
{
    public class LineContentDay7Mapper : ILineContentMapper<LineContentDay7>
    {
        public LineContentDay7 Map(string[] array)
        {
            var obj = new LineContentDay7
            {
                Crabs = array[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList()
            };

            return obj;
        }
    }
}
