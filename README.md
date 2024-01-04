# Billino.StartupManager

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/G2G1SRUJG)

Utility for managing desktop launch on startup

- Windows, registry key
- MacOS, .plist file in launchagents folder ___(Not tested)___
- Linux, .desktop file in autostart folder

---

## Quickstart

Auto detect

```cs
var startupManager = new StartupManager();

var isAutoLaunchEnabled = startupManager.Get();
if (!isAutoLaunchEnabled)
{
	startupManager.Set(true);
}
```

Manual

``` cs
var linuxStartupManager = new LinuxStartupImpl();
// The rest is the same as auto detect
```