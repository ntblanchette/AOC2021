namespace Day1
{
    public class Day1Calculator
    {
        public int GetIncreases(List<LineContentDay1> content)
        {
            var counter = 0;
            
            for (int i = 1; i < content.Count; i++)
            {
                var previousElem = content[i - 1];
                var currentElem = content[i];

                if (currentElem.Depth > previousElem.Depth)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int GetThreeMeasurementListIncreases(List<LineContentDay1> content)
        {
            var listThreeMeasurement = GetThreeMeasurementList(content);

            return GetIncreases(listThreeMeasurement);
        }

        public List<LineContentDay1> GetThreeMeasurementList(List<LineContentDay1> content)
        {
            var list = new List<LineContentDay1>();

            for (int i = 0; i <= content.Count - 3; i++)
            {
                var sum = content.GetRange(i, 3).Sum(x => x.Depth);
                list.Add(new LineContentDay1() { Depth = sum });
            }

            return list;
        }
    }
}
