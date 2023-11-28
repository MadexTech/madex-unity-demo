#if UNITY_IPHONE
using AOT;
using SspnetSDK.ConsentManager.Unfiled;

namespace MadexSDK.ConsentManager.Platform.iOS
{
    public class IOSConsentManagerClient : IConsentManagerClient
    {
        private static IConsentListener _listener;
        
        public void LoadManager()
        {
            ConsentManagerObjCBridge.MadexLoadConsent();
        }

        public void ShowConsentWindow()
        {
            ConsentManagerObjCBridge.MadexShowConsent();
        }

        public bool HasConsent()
        {
           return ConsentManagerObjCBridge.MadexHasConsent();
        }

        public void SetCustomStorage()
        {
           // TODO
        }

        public void EnableDebug(bool isDebug)
        {
            ConsentManagerObjCBridge.MadexConsentEnableDebug(isDebug);
        }

        public void RegisterCustomVendor(ConsentBuilder builder)
        {
            ConsentManagerObjCBridge.MadexRegisterCustomConsentVendor(
                builder.GetAppName(),
                builder.GetPolicyURL(),
                builder.GetBundle(),
                builder.GetGdpr()
            );
        }

        public void SetListener(IConsentListener listener)
        {
            _listener = listener;
            ConsentManagerObjCBridge.MadexSetConsentDelegate(
                OnConsentManagerLoaded,
                OnConsentManagerLoadFailed,
                OnConsentWindowShown,
                OnConsentManagerShownFailed,
                OnConsentWindowClosed
                );
        }
        
        #region Consent Delegate

        [MonoPInvokeCallback(typeof(ConsentCallbacks))]
        internal static void OnConsentManagerLoaded()
        {
            _listener?.OnConsentManagerLoaded();
        }
        
        [MonoPInvokeCallback(typeof(ConsentFailCallbacks))]
        internal static void OnConsentManagerLoadFailed(string message)
        {
            _listener?.OnConsentManagerLoadFailed(message);
        }

        [MonoPInvokeCallback(typeof(ConsentCallbacks))]
        internal static void OnConsentWindowShown()
        {
            _listener?.OnConsentWindowShown();
        }

        [MonoPInvokeCallback(typeof(ConsentFailCallbacks))]
        internal static void OnConsentManagerShownFailed(string message)
        {
            _listener?.OnConsentManagerShownFailed(message);
        }
        
        [MonoPInvokeCallback(typeof(ConsenClosedCallbacks))]
        internal static void OnConsentWindowClosed(bool hasConsent)
        {
            _listener?.OnConsentWindowClosed(hasConsent);
        }

        #endregion
    }
}
#endif