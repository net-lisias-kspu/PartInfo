﻿/*
	This file is part of Part Info /L Unleashed
		© 2022 LisiasT
		© 2019-2022 linuxgurugamer

	Part Info /L is licensed as follows:
		* CC-BY-NC-SA : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Part Info /L is distributed in the hope that it will
	be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
	of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/
using System;
using System.Text.RegularExpressions;
using System.Text;

using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

namespace PartInfo
{
    public class ModulePartInfo : PartModule
    {
        [KSPField]
        public string originalPartName;

        Vector2 scrollPos;
        const int MAXMODULES = 100;
        bool[] printModule = null;
        float maxPrintWidth = 0;
        bool copyAll = true;

        const int WIDTH = 500;
        float HEIGHT = Screen.height * 0.75f;

        private Rect winRect;
        bool isVisible = false;

        const string MODULENAME = "ModulePartInfo";

        string bold = "<b>", unbold = "</b>";
        bool showFull = false;
        bool showFullToggle = true;

        public override string GetInfo()
        {
            moduleName = MODULENAME;

            string st = "";
            //if (HighLogic.CurrentGame != null)
            {
                string path = this.part.partInfo.partUrl;

                string mod = "";
                if (path.Length > 0)
                    mod = path.Substring(0, path.IndexOf('/'));

                st = path = bold + "Mod: " + mod + unbold;
                if (originalPartName == part.partInfo.name)
                {
                    st += "\nName: " + this.originalPartName;
                }
                else
                {
                    st += "\nOrig Name: " + this.originalPartName;
                    st += "\nUpdt Name: " + this.part.partInfo.name;
                }
                st += "\nPath: " + this.part.partInfo.partUrl;

                st += "\nSize: " + this.part.partInfo.partSize.ToString("F2");
                st += "\nBulkhead Profiles: " + this.part.partInfo.bulkheadProfiles + "\n";
            }

            return st;
        }

        [KSPEvent(active = true, guiActive = false, guiActiveEditor = true, guiName = "Show Part Info")]
        void ShowPartInfo()
        {
            isVisible = true;
            if (printModule == null)
                printModule = new bool[MAXMODULES];
        }
        void Start()
        {
            if (!HighLogic.LoadedSceneIsEditor && !HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().availableInFlight)
                Destroy(this);
            winRect = new Rect(0, 0, WIDTH, HEIGHT);
            winRect.x = (Screen.width - WIDTH) / 2;
            winRect.y = (Screen.height - HEIGHT) / 2;
            if (HighLogic.LoadedSceneIsFlight)
                Events["ShowPartInfo"].guiActive = true;
            showFullToggle = HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().showFullWindow;

        }
        private void OnGUI()
        {
            if (isVisible)
            {
                if (!HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().useAltSkin)
                {
                    GUI.skin = HighLogic.Skin;
                    bold = "<b>";
                    unbold = "</b>";
                }
                else
                {
                    bold = "";
                    unbold = "";
                }
                //winRect.height = (float)(Screen.height * HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().WindowHeightPercentage + 50);
                //winRect.width = maxPrintWidth;

                winRect = GUILayout.Window((int)part.GetInstanceID(), winRect, Window, "Part Information");
            }
        }

        void CalcWindowSize()
        {
            foreach (PartModule m in part.Modules)
            {
                StringBuilder tmpSb = new StringBuilder();
                string info = m.GetInfo().TrimEnd(' ', '\r', '\n');
                info = info.Replace(@"\n", "\n");
                tmpSb.AppendLine(info);

                string str = tmpSb.ToString();
                GUIContent tmpContent = new GUIContent(str);
                Vector2 tmpSize = GUI.skin.textArea.CalcSize(tmpContent);
                maxPrintWidth = Math.Max(tmpSize.x + 10, maxPrintWidth);
            }

        }

        string FormatMass(double mass)
        {
            if (mass < 1)
                return (mass * 1000).ToString("F2") + " kg";
            return mass.ToString("F3") + " t";
        }
        string GetResourceValues()
        {
            StringBuilder tmpSb = new StringBuilder();
            tmpSb.AppendLine(bold + "Mass: " + unbold + FormatMass(part.mass));

            if (part.Resources.Count > 0)
            {

                tmpSb.AppendLine(bold + "Resources:" + unbold);
                foreach (PartResource r in part.Resources)
                {
                    double mass = r.amount * r.info.density;
                    tmpSb.AppendLine("    " + r.resourceName + ": " + r.amount.ToString("F1") + "/" + r.maxAmount.ToString("F1") + ", mass: " + FormatMass(mass));
                }
            }
            return tmpSb.ToString();
        }


        private string StripHtml(string source)
        {
            string output;

            //get rid of HTML tags
            output = Regex.Replace(source, "<[^>]*>", string.Empty);

            //get rid of multiple blank lines
            output = Regex.Replace(output, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

            return output;
        }
        void AddDashedLine(StringBuilder sbPrint)
        {
            sbPrint.AppendLine("-----------------------------------------------");
        }
        void Window(int id)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder tmpSb = new StringBuilder();
            StringBuilder sbPrint = new StringBuilder();

            if (maxPrintWidth == 0)
            {
                CalcWindowSize();
            }

            string str = GetInfo().TrimEnd('\r', '\n', ' ');
            str = str.Replace(@"\n", "\n");

            sb.AppendLine(str);
            sbPrint.Append(sb);
            AddDashedLine(sbPrint);

            string resVal = GetResourceValues();
            sb.Append(tmpSb);
            sbPrint.Append(tmpSb);
            AddDashedLine(sbPrint);

            GUILayout.BeginVertical();

            int cnt = 0;
            winRect.height = (float)(Screen.height * HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().WindowHeightPercentage);

            if (HighLogic.LoadedSceneIsEditor)
            {
                showFull = (EditorLogic.RootPart == this.part || this.part.parent != null);
            }
            else
            {
                showFull = true;
            }
            if (showFull)
                showFullToggle = GUILayout.Toggle(showFullToggle, "Show all modules");
            else
                showFullToggle = false;
            if (!showFullToggle)
                winRect.height /= 3;


            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(winRect.height - 70));

            GUILayout.BeginHorizontal();
            GUILayout.TextArea(str + "\n" + resVal);

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            bool newCopyAll = GUILayout.Toggle(copyAll, "Copy All");
            if (newCopyAll != copyAll)
            {
                for (int i = 0; i < part.Modules.Count; i++)
                    printModule[i] = newCopyAll;
                copyAll = newCopyAll;
            }

            GUILayout.EndHorizontal();

            if (showFull)
            {
                for (int i = 0; i < part.Modules.Count; i++)
                {
                    PartModule m = part.Modules[i];
                    if (m.moduleName != MODULENAME)
                    {
                        tmpSb = new StringBuilder();
                        string info = m.GetInfo().TrimEnd(' ', '\r', '\n');

                        if (info != null && info != "")
                        {
                            tmpSb.AppendLine(bold + m.moduleName + unbold);
                            tmpSb.AppendLine();

                            info = info.Replace(@"\n", "\n");
                            tmpSb.AppendLine(info);

                            sb.Append(tmpSb);
                            if (printModule[cnt] || copyAll)
                            {
                                sbPrint.Append(tmpSb);
                                AddDashedLine(sbPrint);
                            }

                            GUILayout.BeginHorizontal();
                            printModule[cnt] = GUILayout.Toggle(printModule[cnt], "");
                            if (!printModule[cnt])
                                copyAll = false;
                            if (!HighLogic.CurrentGame.Parameters.CustomParams<PartInfoSettings>().useAltSkin)
                                GUILayout.TextArea(StripHtml(tmpSb.ToString()), GUILayout.Width(winRect.width - 90));
                            else
                                GUILayout.TextArea(StripHtml(tmpSb.ToString()), GUILayout.Width(winRect.width - 80));
                            GUILayout.EndHorizontal();
                            cnt++;
                        }
                    }
                }
            }
            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Close"))
            {
                isVisible = false;
                printModule = null;
            }

            GUIContent strContent;
            if (copyAll)
                strContent = new GUIContent("Copy all to clipboard");
            else
                strContent = new GUIContent("Copy to clipboard");
            Vector2 size = GUI.skin.button.CalcSize(strContent);

            if (GUILayout.Button(strContent, GUILayout.Width(size.x + 20)))
            {
                sbPrint.ToString().CopyToClipboard();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUI.DragWindow();
        }
    }
    internal static class StringStuff
    {
        public static void CopyToClipboard(this string s)
        {
            TextEditor te = new TextEditor();
            te.text = s;
            te.SelectAll();
            te.Copy();
        }
    }
}
