using System.IO;
using static InventoryItem;
using COTL_API.CustomLocalization;
    
namespace CotLTemplateMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "Lang.Polish.Mod";
        public const string PluginName = "PolishMod";
        public const string PluginVer = "0.0.1";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;



        private void Awake()
        {
            Log = Logger;
            PluginPath = Path.GetDirectoryName(Info.Location);

                string localizationPath = Path.Combine(Plugin.PluginPath, "Assets", "polish.language");
                CustomLocalizationManager.LoadLocalization("Polish", localizationPath);
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            LogInfo($"Unloaded {PluginName}!");
        }
    }
}