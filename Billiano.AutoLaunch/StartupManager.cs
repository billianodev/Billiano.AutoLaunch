using System.Runtime.InteropServices;

namespace Billiano.AutoLaunch;

/// <summary>
/// Automatically manages StartupImpl by detecting current platform
/// </summary>
public class StartupManager : IStartupImpl
{
	private readonly IStartupImpl _source;

	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="NotSupportedException"></exception>
	public StartupManager()
	{
		_source = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsStartupImpl()
			: RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? new OSXStartupImpl()
			: RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? new LinuxStartupImpl()
			: throw new NotSupportedException();
	}

	/// <inheritdoc/>
	public bool Get()
	{
		return _source.Get();
	}

	/// <inheritdoc/>
	public void Set(bool value)
	{
		_source.Set(value);
	}
}
