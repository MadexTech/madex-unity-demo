using SspnetSDK.ConsentManager.Unfiled;

#if UNITY_ANDROID
using YabbiSDK.ConsentManager.Platform.Android;
#elif UNITY_IPHONE
using MadexSDK.ConsentManager.Platform.iOS;
#else
using MadexSDK.ConsentManager.Platform.Dummy;
#endif


namespace MadexSDK.ConsentManager.Platform
{
    internal static class ConsentManagerClientFactory
    {
        internal static IConsentManagerClient GetConsentManagerClient()
        {
#if UNITY_ANDROID
			return new AndroidConsentManagerClient();
#elif UNITY_IPHONE
			return new IOSConsentManagerClient();
#else
            return new DummyConsentManagerClient();
#endif
        }
    }
}