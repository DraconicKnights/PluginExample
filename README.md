# Title: Example Plugin

## Unity Project Community Plugin Repo

An example of how plugins can be designed and set for my custom unity project

## Work in Progress

## Important

- plugins require inheritance of the IPlugin interface to be properly registered
- plugins must be placed within the generated plugin directory with the game project files

## Example Entry Point

```csharp
// Example Plugin Entry Point
public class ExamplePlugin : IPlugin
{
    public string Name => "Example Plugin";
    public string Description => "This is an example plugin";
    public string Author => "Dragon";
    public string Version => "1.0";

    public void OnEnable()
    {
        Logger.Instance.LogInfo("Example Plugin Enabled");
    }

    public void OnDisable()
    {
        Logger.Instance.LogInfo("Example Plugin Disabled");
    }

    public void OnEvent<T>(ServerEventType eventType, T eventArgs)
    {
        
    }

    public IEnumerable<object> GetEventHandlers()
    {
        return new List<object> { new EventTest() };
    }
    
    public IEnumerable<ICommand> GetCommands()
    {
        return new List<ICommand> { new TestCommand() };
    }
}
```

## Information
- The plugin is retrieved from the server's plugin directory and then activated
- Upon activation OnEnable is invoked and triggered thus beginning the plugin instantiation
- All Developer content info is passed to the server to be logged for making ease of tracking server plugins
- All events and commands are registered via the GetEventHandlers and GetCommand Functions

## Example Event Handler

```csharp
// Example Event Handler Object
public class EventTest
{
    [ServerEvent(ServerEventType.PlayerJoin)]
    public void OnPlayerJoin(PlayerJoinEvent playerJoinEvent)
    {
        Logger.Instance.LogInfo($"Welcome to the server {playerJoinEvent.Player.Name}!");
        Logger.Instance.LogOutput("This is a test and the plugin is working");
    }

    [ServerEvent(ServerEventType.PlayerKicked)]
    public void OnPlayerKicked(PlayerKickEvent playerKickEvent)
    {
        Logger.Instance.LogInfo(playerKickEvent.Actor.HasPermission(PlayerPerms.KickPlayer)
            ? $"Player {playerKickEvent.Target.Name} has permission to use this command"
            : $"Player {playerKickEvent.Actor.Name} does not have permission to use this command");
    }

    [ServerEvent(ServerEventType.PlayerLeave)]
    public void OnPlayerLeave(PlayerLeaveEvent playerLeaveEvent)
    {
        Logger.Instance.LogInfo($"Player {playerLeaveEvent.Player.Name} has left the server.");
    }

    [ServerEvent(ServerEventType.PlayerBan)]
    public void OnPlayerBanned(PlayerBanEvent playerBanEvent)
    {
        GameManager.Singleton.GameTimer.SetTimer(10, () =>
        {
            Logger.Instance.LogInfo($"Player: {playerBanEvent.Target.Name} has been banned by {playerBanEvent.Actor.Name}");
        });
    }
}
```

## Example Custom Command
```csharp
// Example custom command addition
[Command("test", CommandContext.InGame, "Test command for plugin", "", PlayerPerms.Default)]
public class TestCommand : ICommand
{
    public void Execute(Player player, ArraySegment<string> arguments, out string response)
    {

        if (!player.HasPermission(PlayerPerms.PlayerInfo))
        {
            response = "Player can't use this command";
            return;
        }
        
        player.Name = "Example Test";
        response = "This is working correctly";
    }
}
```
