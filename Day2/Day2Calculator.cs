using Common.Domain;
using Common.Enums;

namespace Day2
{
    public class Day2Calculator
    {
        public Position Calculate1(List<LineContentDay2> content)
        {
            var position = new Position();

            foreach (var line in content)
            {
                if (line.Direction == EnumDirections.down)
                {
                    position.Depth += line.Movement;
                }

                if (line.Direction == EnumDirections.up)
                {
                    position.Depth -= line.Movement;
                }

                if (line.Direction == EnumDirections.forward)
                {
                    position.Horizontal += line.Movement;
                }
            }

            return position;
        }

        public Position Calculate2(List<LineContentDay2> content)
        {
            var position = new Position();
            var aim = 0;

            foreach (var line in content)
            {
                if (line.Direction == EnumDirections.down)
                {
                    aim += line.Movement;
                }

                if (line.Direction == EnumDirections.up)
                {
                    aim -= line.Movement;
                }

                if (line.Direction == EnumDirections.forward)
                {
                    position.Horizontal += line.Movement;
                    position.Depth += aim * line.Movement;
                }
            }

            return position;
        }
    }
}
