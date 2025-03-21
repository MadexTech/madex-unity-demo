#if UNITY_ANDROID && !UNITY_EDITOR
using MadexSDK.ConsentManagerSDK.Platform.Android;
#elif UNITY_IPHONE && !UNITY_EDITOR
using MadexSDK.ConsentManagerSDK.Platform.iOS;
#else
using MadexSDK.ConsentManagerSDK.Platform.Dummy;
#endif
using SspnetSDK.ConsentManagerSDK.Unfiled;


namespace MadexSDK.ConsentManagerSDK.Platform
{
    internal static class ConsentManagerClientFactory
    {
        internal static IConsentManagerClient GetConsentManagerClient()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidConsentManagerClient();
#elif UNITY_IPHONE && !UNITY_EDITOR
            return new IOSConsentManagerClient();
#else
            return new DummyConsentManagerClient();
#endif
        }
    }
}