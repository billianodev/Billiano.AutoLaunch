using System.Runtime.Versioning;

namespace Billiano.AutoLaunch;

/// <summary>
/// 
/// </summary>
[SupportedOSPlatform("linux")]
public class LinuxStartupImpl : StartupImplBase
{
	private static readonly string AutoStart = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "autostart");
	private static readonly string Desktop = Path.Combine(AutoStart, Name + ".desktop");

	/// <inheritdoc/>
	public override bool Get()
	{
		return File.Exists(Desktop);
	}

	/// <inheritdoc/>
	public override void Set(bool value)
	{
		if (value)
		{
			Directory.CreateDirectory(AutoStart);
			File.WriteAllText(Desktop, $"""
				[Desktop Entry]
				Type=Application
				Name={Name}
				Exec={Location}
				StartupNotify=false"
				Terminal=false
				""");
		}
		else
		{
			File.Delete(Desktop);
		}
	}
}
