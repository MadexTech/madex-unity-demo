#pragma warning disable 0649
using System.Diagnostics.CodeAnalysis;
using SspnetSDK.Editor.Utils;
using UnityEditor;

namespace MadexSDK.Editor.Utils
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "RedundantJumpStatement")]
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MadexRemoveHelper
    {
        public static void RemovePlugin()
        {
            if (EditorUtility.DisplayDialog("Remove Madex",
                    "Are you sure you want to remove Madex from the project?",
                    "Yes",
                    "Cancel"
                ))
                RemoveUtils.RemovePlugin("MadexSDK/Editor/InternalResources/remove_sdk_list.xml");
        }

        public static void RemoveConsentManager()
        {
            if (EditorUtility.DisplayDialog("Remove Consent Manager",
                    "Are you sure you want to remove the Consent Manager from the project?",
                    "Yes",
                    "Cancel"))
                RemoveUtils.RemoveConsentManager(
                    "MadexSDK/ConsentManagerSDK/Editor/InternalResources/remove_consent_list.xml");
        }
    }
}