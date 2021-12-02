namespace Common.Domain
{
    public class Position
    {
        public int Horizontal { get; set; }
        public int Depth { get; set; }

        public long Compute()
        {
            return Horizontal * Depth;
        }
    }
}
