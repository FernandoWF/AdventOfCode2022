namespace Day10.Commands
{
    internal class AddXCommand : Command
    {
        public int Argument { get; }

        public AddXCommand(int argument)
        {
            Argument = argument;
            CyclesLeft = 2;
        }

        public override int? Act(int registerValue)
        {
            base.Act(registerValue);

            return CyclesLeft > 0 ? null : registerValue + Argument;
        }
    }
}
