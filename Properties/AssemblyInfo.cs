using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: ComVisible(false)]
[assembly: AssemblyTitle(DesktopToolShortcutRemapper.BuildInfo.Name)]
[assembly: AssemblyDescription(DesktopToolShortcutRemapper.BuildInfo.Description)]
[assembly: AssemblyCompany("net.kazu0617")]
[assembly: AssemblyProduct(DesktopToolShortcutRemapper.BuildInfo.GUID)]
[assembly: AssemblyVersion(DesktopToolShortcutRemapper.BuildInfo.Version)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
namespace DesktopToolShortcutRemapper
{
	public static class BuildInfo
	{
		public const string Version = "2.0.0";

		public const string Name = "DesktopToolShortcutRemapper";
		public const string Description = "Neos mod that remaps desktop tooltip hotkeys.";

		public const string Author = "kazu0617";

		public const string Link = "https://github.com/kazu0617/DesktopToolShortcutRemapper";

		public const string GUID = "net.kazu0617.DesktopToolShortcutRemapper";
	}
}
