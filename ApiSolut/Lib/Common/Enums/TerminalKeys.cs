using System.Runtime.Serialization;

namespace Common.Enums
{
    public enum TerminalKeys
    {
        [EnumMember(Value = "dotnet")] Dotnet,
        [EnumMember(Value = "bash")] Bash,
        [EnumMember(Value = "cmd")] Cmd,
        [EnumMember(Value = "git")] Git,
        [EnumMember(Value = "sh")] Sh,
    }
}