namespace Billiano.AutoLaunch;

/// <summary>
/// 
/// </summary>
public interface IStartupImpl
{
	/// <summary>
	/// Get whether auto start is enabled
	/// </summary>
	/// <returns></returns>
	bool Get();

	/// <summary>
	/// Set auto start to enabled or disabled
	/// </summary>
	/// <param name="value"></param>
	void Set(bool value);
}
