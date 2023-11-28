#if UNITY_ANDROID
namespace MadexSDK.ConsentManager.Platform.Android
{
    internal static class ConsentManagerConsants
    {
            public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";
            public const string ConsentManager = "sspnet.tech.consent.madex.ConsentManager";
            public const string Listener = "sspnet.tech.consent.core.ConsentListener";
            public const string Builder = "sspnet.tech.consent.core.ConsentBuilder";
    }
}
#endif