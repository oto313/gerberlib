using System.Collections.Generic;

namespace GerberLib.Commands
{
    public class ExtendedCommandData {
        public ExtendedCommandData(string cmd, string cmdData, IEnumerable<IEnumerable<string>> additionalData)
        {
            Cmd = cmd;
            CmdData = cmdData;
            AdditionalData = additionalData;
        }
        public string Cmd { get; }
        public string CmdData { get; }
        public IEnumerable<IEnumerable<string>> AdditionalData { get; }
    }
}
