using System;
using System.Collections.Generic;
using FrooxEngine;
using HarmonyLib;
using NeosModLoader;

namespace DesktopToolShortcutRemapper
{
    public class DesktopToolShortcutRemapper : NeosMod
    {
        public override string Name => BuildInfo.Name;
        public override string Author => BuildInfo.Author;
        public override string Version => BuildInfo.Version;
        public override string Link => BuildInfo.Link;

        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key_Enable = new("enabled", "Enables this mod.", () => true);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key2_enable = new("Key2/enable", "Enable to remapping for Key2.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key3_enable = new("Key3/enable", "Enable to remapping for Key3.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key4_enable = new("Key4/enable", "Enable to remapping for Key4.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key5_enable = new("Key5/enable", "Enable to remapping for Key5.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key6_enable = new("Key6/enable", "Enable to remapping for Key6.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key7_enable = new("Key7/enable", "Enable to remapping for Key7.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key8_enable = new("Key8/enable", "Enable to remapping for Key8.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key9_enable = new("Key9/enable", "Enable to remapping for Key9.", () => false);
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> Key0_enable = new("Key0/enable", "Enable to remapping for Key0.", () => false);

        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key2_URi = new("Key2/Uri", "Set Uri to remapping for Key2.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key3_URi = new("Key3/Uri", "Set Uri to remapping for Key3.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key4_URi = new("Key4/Uri", "Set Uri to remapping for Key4.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key5_URi = new("Key5/Uri", "Set Uri to remapping for Key5.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key6_URi = new("Key6/Uri", "Set Uri to remapping for Key6.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key7_URi = new("Key7/Uri", "Set Uri to remapping for Key7.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key8_URi = new("Key8/Uri", "Set Uri to remapping for Key8.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key9_URi = new("Key9/Uri", "Set Uri to remapping for Key9.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> Key0_URi = new("Key0/Uri", "Set Uri to remapping for Key0.", () => "neosrec:///G-Neos/Inventory/Essential Tools/ComponentCloneTip");

        private static ModConfiguration Config;

        private static Dictionary<Uri, Uri> toolRemapping = new Dictionary<Uri, Uri>();

        public override void OnEngineInit()
        {
            Config = GetConfiguration();
            Config.Save(true);
            if (!Config.GetValue(Key_Enable) | !RemappingUri()) return;

            Harmony harmony = new Harmony(BuildInfo.GUID);
            harmony.PatchAll();
        }
        private static bool RemappingUri()
        {
            // rebind 5 to component clone
            for (int remapkeys = 0; remapkeys <= 9; remapkeys++)
            {
                string from, to;
                bool enable;
                switch (remapkeys)
                {
                    case 0:
                        from = "GlueTip";
                        enable = Config.IsKeyDefined(Key0_enable) ? Config.GetValue(Key0_enable) : false;
                        to = Config.IsKeyDefined(Key0_URi) ? Config.GetValue(Key0_URi) : null;
                        break;
                    case 2:
                        from = "DevToolTip";
                        enable = Config.IsKeyDefined(Key2_enable) ? Config.GetValue(Key2_enable) : false;
                        to = Config.IsKeyDefined(Key2_URi) ? Config.GetValue(Key2_URi) : null;
                        break;
                    case 3:
                        from = "LogixTip";
                        enable = Config.IsKeyDefined(Key3_enable) ? Config.GetValue(Key3_enable) : false;
                        to = Config.IsKeyDefined(Key3_URi) ? Config.GetValue(Key3_URi) : null;
                        break;
                    case 4:
                        from = "MaterialTip";
                        enable = Config.IsKeyDefined(Key4_enable) ? Config.GetValue(Key4_enable) : false;
                        to = Config.IsKeyDefined(Key4_URi) ? Config.GetValue(Key4_URi) : null;
                        break;
                    case 5:
                        from = "ShapeTip";
                        enable = Config.IsKeyDefined(Key5_enable) ? Config.GetValue(Key5_enable) : false;
                        to = Config.IsKeyDefined(Key5_URi) ? Config.GetValue(Key5_URi) : null;
                        break;
                    case 6:
                        from = "LightTip";
                        enable = Config.IsKeyDefined(Key6_enable) ? Config.GetValue(Key6_enable) : false;
                        to = Config.IsKeyDefined(Key6_URi) ? Config.GetValue(Key6_URi) : null;
                        break;
                    case 7:
                        from = "GrabbableSetterTip";
                        enable = Config.IsKeyDefined(Key7_enable) ? Config.GetValue(Key7_enable) : false;
                        to = Config.IsKeyDefined(Key7_URi) ? Config.GetValue(Key7_URi) : null;
                        break;
                    case 8:
                        from = "CharacterColliderSetterTip";
                        enable = Config.IsKeyDefined(Key8_enable) ? Config.GetValue(Key8_enable) : false;
                        to = Config.IsKeyDefined(Key8_URi) ? Config.GetValue(Key8_URi) : null;
                        break;
                    case 9:
                        from = "Microphone";
                        enable = Config.IsKeyDefined(Key9_enable) ? Config.GetValue(Key9_enable) : false;
                        to = Config.IsKeyDefined(Key9_URi) ? Config.GetValue(Key9_URi) : null;
                        break;
                    default:
                        from = null;
                        enable = false;
                        to = null;
                        break;
                }
                if (from == null || !enable || to == null) continue;
                toolRemapping.Add(new Uri("neosrec:///G-Neos/Inventory/SpawnObjects/ShortcutTooltips/" + from), new Uri(to));
                Debug($"Tool Remapped for \"{remapkeys}\" into \"{to}\"");
            }
            return true;

        }

        [HarmonyPatch(typeof(CommonTool), nameof(CommonTool.SpawnAndEquip))]
        class Patch
        {
            static bool Prefix(ref Uri uri)
            {
                if (toolRemapping.TryGetValue(uri, out Uri remappedUri))
                {
                    Debug($"converted \"{uri}\" into \"{remappedUri}\"");
                    uri = remappedUri;
                }
                return true;
            }
        }
    }
}
