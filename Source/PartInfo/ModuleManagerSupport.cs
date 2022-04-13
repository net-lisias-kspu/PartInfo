/*
	This file is part of Part Info /L Unleashed
		© 2022 LisiasT
		© 2019-2022 linuxgurugamer

	Part Info /L is licensed as follows:
		* CC-BY-NC-SA : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Part Info /L is distributed in the hope that it will
	be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
	of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/
using System.Collections.Generic;

namespace KerbalObPartInfojectInspector
{
	public static class ModuleManagerSupport
	{
		public static IEnumerable<string> ModuleManagerAddToModList()
		{
			string[] r = { typeof(ModuleManagerSupport).Namespace };
			return r;
		}
	}
}
