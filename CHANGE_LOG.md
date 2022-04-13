# Part Info /L Unleashed :: Change Log

* 2022-0413: 0.0.6.2 (LisiasT) for KSP >= 1.3.1
	* Adding KSPe Facilities
		+ Log
		+ Installment Checks
		+ Abstracted GUI
	* Certifying the thing to run from KSP 1.3.1 to newest ! **#HURRAY!!** 
* 2021-0815: 0.0.6.2 (LinuxGuruGamer) for KSP 1.12.2
	+ Added AssemblyFileVersion
	+ Updated version file for 1.12
	+ Thanks to @yalov for this:
		- Fixed Empty "Part Information" and nullref spam on asteroids in flight
* 2021-0407: 0.0.6.1 (LinuxGuruGamer) for KSP 1.11.2
	+ Added code to deal with embedded character sequence @"\n", found in new ModuleCargoPart
* 2021-0203: 0.0.6 (LinuxGuruGamer) for KSP 1.11.1
	+ Fixed CopyAll to enable ALL copy toggles when selected
	+ Deselecting CopyAll will disable ALL copy toggles
	+ Disable CopyAll if one or more of the copy toggles is deselected
* 2021-0125: 0.0.5 (LinuxGuruGamer) for KSP 1.11.0
	+ Added part size & Bulkhead Profiles
	+ Added Show Full toggle to show a shorter window
	+ Added config option to default to large window
* 2020-0926: 0.0.4.1 (LinuxGuruGamer) for KSP 1.10.1
	+ Replace html stripper code for better stripping
* 2020-0920: 0.0.4 (LinuxGuruGamer) for KSP 1.10.1
	+ Cleaned up output by stripping the markdown
* 2020-0818: 0.0.3.7 (LinuxGuruGamer) for KSP 1.10.1
	+ Added display of mass of part and resources
* 2020-0815: 0.0.3.6 (LinuxGuruGamer) for KSP 1.10.1
	+ Added display of resources
	+ Added alternate skin
	+ Added resizing of window as percentage of screen height
* 2020-0815: 0.0.3.5 (LinuxGuruGamer) for KSP 1.10.1
	+ Fixed modulePartInfo being shown 2x
* 2020-0808: 0.0.3.4 (LinuxGuruGamer) for KSP 1.10.1
	+ Fixed missing part info section
	+ Fixed issue with trying to show windows for more than one part
* 2020-0808: 0.0.3.3 (LinuxGuruGamer) for KSP 1.10.1
	+ Added all part module info to display window
	+ Added option to have PAW entry available in the flight scene
	+ Changed output so that if the original part name was the same as the current part name, to only show the name
	+ Implemented using Stringbuilder to build the display string
	+ Added ability to copy all or just copy some of the part modules
* 2020-0806: 0.0.3.2 (LinuxGuruGamer) for KSP 1.10.1
	+ Thanks to user @Gordon-Dry for this:
		- Do not add ModulePartInfo to ThrottleControlledAvionics "parts" because ThrottleControlledAvionics uses dummy parts for tech tree unlocks of its modules.
	+ Along the same lines, Breaking Ground's deployable parts are now excluded
	+ Fixes #3
* 2020-0711: 0.0.3.1 (LinuxGuruGamer) for KSP 1.10.0
	+ Fixed typo in Close button
* 2020-0703: 0.0.3 (LinuxGuruGamer) for KSP 1.10.0
	+ Added modname into partinfo output
	+ Added PartInfo action in editor, to show partinfo for selected part already placed in window
		- Has button to copy to clipboard
* 2020-0521: 0.0.2.1 (LinuxGuruGamer) for KSP 1.9.1
	+ Fixed URL in .version file
* 2019-1101: 0.0.2 (LinuxGuruGamer) for KSP 1.8.1
	+ Updated for KSP 1.8
* 2019-0805: 0.0.1.3 (LinuxGuruGamer) for KSP 1.7.3
	+ Updated assemblyversion.tt
	+ Added InstallChecker
* 2019-0208: 0.0.1.2 (LinuxGuruGamer) for KSP 1.6.1
	+ Added original name
	+ Shortened verbage
* 2019-0208: 0.0.1.1 (LinuxGuruGamer) for KSP 1.6.1
	+ Full release
* 2019-0207: 0.0.1 (LinuxGuruGamer) for KSP 1.6.1 PRE-RELEASE
	+ PartInfo initial release
