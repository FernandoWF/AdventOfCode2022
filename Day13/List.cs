using System.Collections;

namespace Day13
{
    internal class List : PacketData, IReadOnlyList<PacketData>
    {
        private const char ListStartCharacter = '[';
        private const char ListEndCharacter = ']';
        private const char ValuesSeparatorCharacter = ',';
        private readonly List<PacketData> values = new();

        public string Body { get; }
        public int Count => values.Count;

        public List(string bodySource, int bodyStartIndex)
        {
            if (bodySource.Length <= bodyStartIndex || bodySource[bodyStartIndex] != ListStartCharacter)
            {
                throw new ArgumentException("Specified parameters do not define the start of a list");
            }

            for (var i = bodyStartIndex + 1; i < bodySource.Length; i++)
            {
                char character = bodySource[i];

                if (character == ListStartCharacter)
                {
                    var list = new List(bodySource, i);
                    values.Add(list);
                    i += list.Body.Length - 1;
                }
                else if (character == ListEndCharacter)
                {
                    Body = bodySource.Substring(bodyStartIndex, i - bodyStartIndex + 1);
                    break;
                }
                else if (char.IsDigit(character))
                {
                    var startOfInteger = i;
                    var digitCount = 1;
                    bool isNextCharacterDigit;

                    do
                    {
                        isNextCharacterDigit = char.IsDigit(bodySource[i + 1]);
                        if (isNextCharacterDigit)
                        {
                            digitCount++;
                            i++;
                        }
                    }
                    while (isNextCharacterDigit);

                    values.Add(new Integer(bodySource.Substring(startOfInteger, digitCount)));
                }
                else if (character != ValuesSeparatorCharacter)
                {
                    throw new ArgumentException($"Invalid character inside body source: {character}");
                }
            }

            if (Body == null)
            {
                throw new ArgumentException("Specified parameters do not define a valid list");
            }
        }

        public IEnumerator<PacketData> GetEnumerator() => values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public PacketData this[int index] => values[index];
    }
}
