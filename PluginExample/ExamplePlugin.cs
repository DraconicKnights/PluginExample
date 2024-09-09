using Interfaces;
using Utils.CommandCore;
using Utils.Enums;
using Utils.Logging;

namespace PluginExample;

public class ExamplePlugin : IPlugin
{
    public string Name => "Example Plugin";
    public string Description => "";
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