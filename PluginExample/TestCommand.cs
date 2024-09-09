using System.Diagnostics.CodeAnalysis;
using Players;
using Players.PlayerCore;
using Utils.Attributes;
using Utils.CommandCore;

namespace PluginExample;

[Command("test", CommandContext.InGame, "Test command for plugin", "", PlayerPerms.PlayerInfo)]
public class TestCommand : ICommand
{
    public void Execute(Player player, ArraySegment<string> arguments, [UnscopedRef] out string response)
    {
        player.Name = "Example Test";
        response = "This is working correctly";
    }
}