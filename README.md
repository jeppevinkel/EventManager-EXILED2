# EventManager-EXILED2

## Commands
Currently only commands for the server console.

Writing `em` or `eventmanager` in the server console wil display all available commands.

## API

```cs
class EventManager.Api.Api()

/// <summary>
/// Register event to EventManager. Returns false if the event plugin fails to register.
/// If the name is null, it will use the plugin name stored in the assembly.
/// </summary>
public static bool RegisterEvent(IPlugin<IConfig> plugin, string name = null);

/// <summary>
/// Returns the currently running event.
/// </summary>
/// <returns>Currently running event.</returns>
public static Event GetCurrentEvent();

/// <summary>
/// Returns the next event.
/// </summary>
/// <returns>Next event.</returns>
public static Event GetNextEvent();

/// <summary>
/// Returns a readonly list of all registered events.
/// </summary>
/// <returns>List of events.</returns>
public static ReadOnlyCollection<Event> GetEventList();
```

## Example Plugin
[Example Plugin of how to utilize the EventManager.](https://github.com/jeppevinkel/ExampleEvent-EXILED2)