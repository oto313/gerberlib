namespace GerberLib.FunctionCodeCommands
{
    public class XYFunctionCodeCommand : FunctionCodeCommand
    {
        public XYFunctionCodeCommand()
        {
            
        }
        public XYFunctionCodeCommand(GerberContext context, string data)
        {
            CoordinatesXY = ParseXY(context, data);
        }

        public virtual CoordinatesXY CoordinatesXY { get; }
    }
}
