using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Part Info")]
[assembly: AssemblyDescription("Displays the internal part information in the editor.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(PartInfo.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(PartInfo.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(PartInfo.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(PartInfo.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("adef303a-0a30-4a81-aa3c-b99d06751e90")]

[assembly: AssemblyVersion(PartInfo.Version.Number)]
[assembly: AssemblyFileVersion(PartInfo.Version.Number)]
[assembly: KSPAssembly("PartInfo", PartInfo.Version.major, PartInfo.Version.minor)]
[assembly: KSPAssemblyDependency("KSPe", 2, 4)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 4)]
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
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]
