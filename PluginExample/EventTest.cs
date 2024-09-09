using Utils.Attributes;
using Utils.Enums;
using Utils.EventCore.Events;
using Utils.Logging;

namespace PluginExample;

public class EventTest
{
    [ServerEvent(ServerEventType.PlayerJoin)]
    public void OnPlayerJoin(PlayerJoinEvent playerJoinEvent)
    {
        Logger.Instance.LogInfo($"Welcome to the server {playerJoinEvent.Player.Name}!");
        playerJoinEvent.Player.Launch(playerJoinEvent.Player.ID, 5);
    }

    [ServerEvent(ServerEventType.PlayerKicked)]
    public void OnPlayerKicked(PlayerKickEvent playerKickEvent)
    {
        Logger.Instance.LogInfo($"Player {playerKickEvent.Target.Name} has been kicked.");
    }

    [ServerEvent(ServerEventType.PlayerLeave)]
    public void OnPlayerLeave(PlayerLeaveEvent playerLeaveEvent)
    {
        Logger.Instance.LogInfo($"Player {playerLeaveEvent.Player.Name} has left the server.");
    }

    [ServerEvent(ServerEventType.PlayerBan)]
    public void OnPlayerBanned(PlayerBanEvent playerBanEvent)
    {
        playerBanEvent.Actor.Kick(playerBanEvent.Actor.ID, "Example");
    }
}