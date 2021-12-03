using System.Collections;
using Common.Extensions;

namespace Day3
{
    public class Day3Calculator
    {
        public int Calculate1(List<LineContentDay3> content)
        {
            var bitArraySize = content[0].Data.Count;
            var gammaRate = new BitArray(bitArraySize);
            var epsilonRate = new BitArray(bitArraySize);

            for (int bitPosition = 0; bitPosition < bitArraySize; bitPosition++)
            {
                var compteurBitFalse = 0;
                var compteurBitTrue = 0;
                CalculateMostBits(content, bitPosition, ref compteurBitFalse, ref compteurBitTrue);

                gammaRate[bitPosition] = compteurBitTrue > compteurBitFalse;
                epsilonRate[bitPosition] = compteurBitTrue <= compteurBitFalse;
            }

            var gammaValue = gammaRate.ConvertToInt32();
            var epsilonValue = epsilonRate.ConvertToInt32();

            return gammaValue * epsilonValue;
        }

        public int Calculate2(List<LineContentDay3> content)
        {
            var bitArraySize = content[0].Data.Count;

            var oxygenContent = content.ToList();
            static bool funcCompareOxygen(int compteurBitTrue, int compteurBitFalse) => compteurBitTrue >= compteurBitFalse;
            for (int bitPosition = 0; bitPosition < bitArraySize; bitPosition++)
            {
                oxygenContent = FindMostWithEval(oxygenContent, bitPosition, funcCompareOxygen);
            }
            var oxygenGeneratorRating = oxygenContent.Single().Data.ConvertToInt32();

            var co2Content = content.ToList();
            static bool funcCompareCo2(int compteurBitTrue, int compteurBitFalse) => compteurBitTrue < compteurBitFalse;
            for (int bitPosition = 0; bitPosition < bitArraySize; bitPosition++)
            {
                co2Content = FindMostWithEval(co2Content, bitPosition, funcCompareCo2);
            }
            var CO2ScrubberRating = co2Content.Single().Data.ConvertToInt32();

            return oxygenGeneratorRating * CO2ScrubberRating;
        }

        private List<LineContentDay3> FindMostWithEval(List<LineContentDay3> content, int bitPosition, Func<int, int, bool> funcCompare)
        {
            if (content.Count == 1)
            {
                return content;
            }

            var compteurBitFalse = 0;
            var compteurBitTrue = 0;
            CalculateMostBits(content, bitPosition, ref compteurBitFalse, ref compteurBitTrue);

            return content.Where(x => funcCompare(compteurBitTrue, compteurBitFalse) ? x.Data[bitPosition] : !x.Data[bitPosition]).ToList();
        }

        private static void CalculateMostBits(List<LineContentDay3> content, int bitPosition, ref int counterFalse, ref int counterTrue)
        {
            foreach (var item in content)
            {
                var curBool = item.Data[bitPosition];
                if (curBool)
                {
                    counterTrue++;
                }
                else
                {
                    counterFalse++;
                }
            }
        }
    }
}
