#if UNITY_EDITOR

using AdvancedSceneManager.Editor;
using UnityEditor;
using UnityEngine.UIElements;

namespace AdvancedSceneManager.Plugin.Locking
{

    public static class UI
    {

        public static bool showButtons
        {
            get => EditorPrefs.GetBool("AdvancedSceneManager.Locking.ShowButtons", true);
            set => EditorPrefs.SetBool("AdvancedSceneManager.Locking.ShowButtons", value);
        }

        internal static void OnLoad()
        {
            SettingsTab.Settings.Add(() =>
                new Toggle("Display lock buttons:").
                    Setup(e =>
                    {
                        showButtons = e.newValue;
                        EditorApplication.RepaintHierarchyWindow();
                    },
                    defaultValue: showButtons,
                    tooltip: "Enable or disable lock buttons (does not disable functionality, saved in EditorPrefs)"
                    ),
                header: SettingsTab.Settings.DefaultHeaders.Appearance);
        }

    }

}

#endif