using System.Runtime.Versioning;

namespace Billiano.AutoLaunch;

/// <summary>
/// 
/// </summary>
[SupportedOSPlatform("macos")]
public class OSXStartupImpl : StartupImplBase
{
	private static readonly string LaunchAgents = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "LaunchAgents");
	private static readonly string Plist = Path.Combine(LaunchAgents, Name + ".plist");

	/// <inheritdoc/>
	public override bool Get()
	{
		return File.Exists(Plist);
	}

	/// <inheritdoc/>
	public override void Set(bool value)
	{
		if (value)
		{
			Directory.CreateDirectory(LaunchAgents);
			File.WriteAllText(Plist, $"""
				<?xml version="1.0" encoding="UTF-8"?>
				<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
				<plist version="1.0">
				<dict>
				    <key>Label</key>
				    <string>com.{Name}</string>
				    <key>ProgramArguments</key>
				    <array>
				        <string>{Location}</string>
				    </array>
				    <key>RunAtLoad</key>
				    <true/>
				    <key>KeepAlive</key>
				    <true/>
				</dict>
				</plist>
				""");
		}
		else
		{
			File.Delete(Plist);
		}
	}
}
