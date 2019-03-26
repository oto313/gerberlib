namespace GerberLib.FunctionCodeCommands
{
    public class XYIJFunctionCodeCommand : XYFunctionCodeCommand
    {
        public XYIJFunctionCodeCommand(GerberContext context, string data)
        {
            CoordinatesXYIJ = ParseXYIJ(context, data);
        }

        public override CoordinatesXY CoordinatesXY => CoordinatesXYIJ;

        public virtual CoordinatesXYIJ CoordinatesXYIJ { get; }
    }
}
