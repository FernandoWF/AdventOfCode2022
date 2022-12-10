using Day10.Commands;

namespace Day10
{
    internal class CPU
    {
        private readonly Queue<Command> commands = new();
        private Command? currentCommand;

        public int LastCycleExecuted { get; private set; } = 0;
        public int RegisterValueAfterLastCycle { get; private set; } = 1;
        public int RegisterValueDuringLastCycle { get; private set; } = 1;
        public bool HasCommands => commands.Count > 0;

        public void ExecuteCycle()
        {
            LastCycleExecuted++;
            RegisterValueDuringLastCycle = RegisterValueAfterLastCycle;
            currentCommand ??= commands.Dequeue();

            if (currentCommand.CyclesLeft > 0)
            {
                var result = currentCommand.Act(RegisterValueAfterLastCycle);
                if (result.HasValue)
                {
                    RegisterValueAfterLastCycle = result.Value;
                }
            }

            if (currentCommand.CyclesLeft == 0)
            {
                currentCommand = null;
            }
        }

        public void QueueNoop()
        {
            commands.Enqueue(new NoopCommand());
        }

        public void QueueAddX(int argument)
        {
            commands.Enqueue(new AddXCommand(argument));
        }
    }
}
