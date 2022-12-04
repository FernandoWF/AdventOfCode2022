namespace Day4
{
    internal class Assignment
    {
        public int StartingSection { get; }
        public int EndingSection { get; }

        public Assignment(int startingSection, int endingSection)
        {
            StartingSection = startingSection;
            EndingSection = endingSection;
        }

        public bool FullyContains(Assignment other)
        {
            return StartingSection <= other.StartingSection && EndingSection >= other.EndingSection;
        }

        public bool Overlaps(Assignment other)
        {
            return FullyContains(other)
                || other.FullyContains(this)
                || (StartingSection <= other.StartingSection && EndingSection >= other.StartingSection)
                || (StartingSection <= other.EndingSection && EndingSection >= other.EndingSection);
        }

        public override string ToString()
        {
            return $"{StartingSection}-{EndingSection}";
        }
    }
}
