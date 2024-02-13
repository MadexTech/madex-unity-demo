using SspnetSDK.ConsentManagerSDK.Unfiled;

#if UNITY_ANDROID
using MadexSDK.ConsentManagerSDK.Platform.Android;
#elif UNITY_IPHONE
using MadexSDK.ConsentManagerSDK.Platform.iOS;
#else
using MadexSDK.ConsentManagerSDK.Platform.Dummy;
#endif


namespace MadexSDK.ConsentManagerSDK.Platform
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