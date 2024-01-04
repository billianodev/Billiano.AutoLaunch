using System.Diagnostics;
using System.Reflection;

namespace Billiano.AutoLaunch;

/// <summary>
/// 
/// </summary>
public abstract class StartupImplBase : IStartupImpl
{
	/// <summary>
	/// Name of current application
	/// </summary>
	protected static string Name { get; }

	/// <summary>
	/// Current executable path
	/// </summary>
	protected static string Location { get; }

	static StartupImplBase()
	{
		Process process = Process.GetCurrentProcess();
		Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
		Name = assembly.GetName().Name ?? process.ProcessName;
		Location = process.MainModule?.FileName ?? throw new NotSupportedException();
	}

	/// <inheritdoc/>
	public abstract bool Get();

	/// <inheritdoc/>
	public abstract void Set(bool value);
}
