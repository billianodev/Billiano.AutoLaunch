using System.Runtime.Versioning;
using Microsoft.Win32;

namespace Billiano.AutoLaunch;

/// <summary>
/// 
/// </summary>
[SupportedOSPlatform("windows")]
public sealed class WindowsStartupImpl : StartupImplBase
{
	private static readonly RegistryKey? SubKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

	/// <inheritdoc/>
	public override bool Get()
	{
		return SubKey?.GetValue(Name) != null;
	}

	/// <inheritdoc/>
	public override void Set(bool value)
	{
		if (value)
		{
			SubKey?.SetValue(Name, Location);
		}
		else
		{
			SubKey?.DeleteValue(Name, false);
		}
	}
}
