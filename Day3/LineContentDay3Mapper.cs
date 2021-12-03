using Common.Services;
using System.Collections;

namespace Day3
{
    public class LineContentDay3Mapper : ILineContentMapper<LineContentDay3>
    {
        public LineContentDay3 Map(string[] array)
        {
            var boolArray = array[0].ToCharArray().Select(c => c == '1').ToArray();

            var obj = new LineContentDay3
            {
                Data = new BitArray(boolArray)
            };

            return obj;
        }
    }
}
