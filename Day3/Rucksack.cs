namespace Day3
{
    internal class Rucksack
    {
        public Item CommonItem { get; }
        public ISet<char> ItemTypes { get; } = new HashSet<char>();

        public Rucksack(string contents)
        {
            var compartmentItemCount = contents.Length / 2;
            var firstCompartmentContents = contents[..compartmentItemCount];
            var secondCompartmentContents = contents[compartmentItemCount..];

            var firstCompartmentItemTypes = new HashSet<char>();
            var secondCompartmentItemTypes = new HashSet<char>();

            for (var i = 0; i < compartmentItemCount; i++)
            {
                firstCompartmentItemTypes.Add(firstCompartmentContents[i]);
                ItemTypes.Add(firstCompartmentContents[i]);
                secondCompartmentItemTypes.Add(secondCompartmentContents[i]);
                ItemTypes.Add(secondCompartmentContents[i]);
            }

            var commonItemKind = firstCompartmentItemTypes
                .Intersect(secondCompartmentItemTypes)
                .Single();
            CommonItem = new Item(commonItemKind);
        }
    }
}
