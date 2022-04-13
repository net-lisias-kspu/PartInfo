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
#if false
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//
// the PartInfo() function isn't called all the time, just when things change
// so this will update it for this module every time th editor is entered
//
namespace PartInfo
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    class PartInfoReloader : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(ReloadInfos());
        }
        

        private IEnumerator ReloadInfos()
        {
            yield return null;

            for (int i0 = PartLoader.LoadedPartsList.Count - 1; i0 >= 0; i0--)
            {
                AvailablePart aPart = PartLoader.LoadedPartsList[i0];

                for (var i1 = aPart.moduleInfos.Count - 1; i1 >= 0; i1--)
                {
                    Debug.Log("moduleName: " + aPart.moduleInfos[i1].moduleName);
                    var info = aPart.moduleInfos[i1];
                    string newInfos = "";
                    if (info.moduleName == "ModulePartInfo")
                    {

                        for (var i2 = aPart.partPrefab.Modules.Count - 1; i2 >= 0; --i2)
                        {

                            if (aPart.partPrefab.Modules[i1].moduleName == "ModulePartInfo")
                            {
                                PartModule pm = aPart.partPrefab.Modules[i2];

                                newInfos = pm.GetInfo();
                                break;
                            }
                        }
                        if (newInfos != "")
                        {
                            Debug.Log("info.info (before): " + info.info);
                            Debug.Log("newInfos: " + newInfos);
                            info.info = "\n" + newInfos;
                            //break;

                            Debug.Log("final info.info: " + info.info + ",   newInfos: " + newInfos);
                            break;
                        }                     
                    }
                }
            }
        }    
    }
}
#endif