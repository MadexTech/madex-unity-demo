#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using SspnetSDK.Editor.NetworkManager;
using SspnetSDK.Editor.Utils;

namespace MadexSDK.Editor.Utils
{
    public class MadexEditorSettings : ScriptableObject
    {
        [MenuItem("Madex/Documentation")]
        public static void OpenDocumentation()
        {
            Application.OpenURL("https://mobileadx.gitbook.io/mobileadx/unity-plugin");
        }

        [MenuItem("Madex/Official site")]
        public static void OpenPublisherUrl()
        {
            Application.OpenURL("https://madex.world");
        }

#if UNITY_2018_1_OR_NEWER        
        [MenuItem("Madex/Dependency manager")]
        public static void ShowSdkManager()
        {
            SspnetAdapterManager.ShowSdkManager("https://github.com/MadexTech/madex-unity-demo/releases/download/version/madex-unity-plugin.unitypackage");
        }
#endif
        
        [MenuItem("Madex/Plugin settings")]
        public static void ShowInternalSettings()
        {
            SspnetInternalSettings.ShowInternalSettings();
        }

        [MenuItem("Madex/Remove plugin")]
        public static void RemovePlugin()
        {
            MadexRemoveHelper.RemovePlugin();
        }
        
        [MenuItem("Madex/Remove Consent Manager")]
        public static void RemoveConsentPlugin()
        {
            MadexRemoveHelper.RemoveConsentManager();
        }
    }
}
#endif
