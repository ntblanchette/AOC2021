using Common.Services;

namespace Day6
{
    public class LineContentDay6Mapper : ILineContentMapper<LineContentDay6>
    {
        public LineContentDay6 Map(string[] array)
        {
            var obj = new LineContentDay6
            {
                ListOfFish = array[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList()
            };

            return obj;
        }
    }
}
