namespace GerberLib.Commands
{
    class FunctionCodeCommand : Command
    {
        public FunctionCodeCommand(char cmd, int number, string data)
        {
            Cmd = cmd;
            Number = number;
            Data = data;
        }

        public char Cmd { get; }
        public int Number { get; }
        public string Data { get; }
    }
}
