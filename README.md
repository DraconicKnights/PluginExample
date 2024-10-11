<p align="center"><img src="example.png" width="400" alt="Laravel Logo"></a></p>

# Title: Example Plugin

## Unity Project Community Plugin Repo

An example of how plugins can be designed and set for my custom unity project

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


