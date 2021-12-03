using System.Collections;

namespace Common.Extensions
{
    public static class BitArrayExtension
    {
        public static int ConvertToInt32(this BitArray bitArray)
        {
            var strBits = "";
            foreach (var bit in bitArray)
            {
                if ((bool)bit)
                {
                    strBits += '1';
                }
                else
                {
                    strBits += '0';
                }
            }

            return Convert.ToInt32(strBits, 2);
        }
    }
}
