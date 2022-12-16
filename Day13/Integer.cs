namespace Day13
{
    internal class Integer : PacketData
    {
        public int Value { get; }

        public Integer(string body)
        {
            Value = int.Parse(body);
        }

        public override string ToString() => Value.ToString();
    }
}
