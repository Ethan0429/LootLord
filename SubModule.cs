using HarmonyLib;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.MountAndBlade;

namespace LootLord
{
    public class SubModule : MBSubModuleBase
    {
        public static string ErrorFile;

        protected override void OnSubModuleLoad()
        {
            try
            {
                base.OnSubModuleLoad();
                new Harmony("LootLord").PatchAll();
            }
            catch (Exception ex)
            {
                try
                {
                    string text = string.Format("Error-{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now);
                    SubModule.ErrorFile = text;
                    string arg_85_0 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), text);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("Installed Modules:");
                    stringBuilder.AppendLine(Managed.GetModulesVersionStr());
                    stringBuilder.AppendLine("Exception Message:");
                    stringBuilder.AppendLine(ex.ToString());
                    File.WriteAllText(arg_85_0, stringBuilder.ToString());
                }
                catch
                {
                }
            }
        }
    }
}