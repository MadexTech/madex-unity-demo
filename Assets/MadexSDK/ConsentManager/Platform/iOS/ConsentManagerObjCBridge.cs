#if UNITY_IPHONE
using System.Runtime.InteropServices;

namespace MadexSDK.ConsentManager.Platform.iOS
{
    internal delegate void ConsentCallbacks();

    internal delegate void ConsentFailCallbacks(string messgae);
    
    internal delegate void ConsenClosedCallbacks(bool hasConsent);

    internal static class ConsentManagerObjCBridge
    {
        
        #region Declare external C interface

        [DllImport("__Internal")]
        internal static extern void MadexLoadConsent();
        
        [DllImport("__Internal")]
        internal static extern void MadexShowConsent();

        [DllImport("__Internal")]
        internal static extern bool MadexHasConsent();

        [DllImport("__Internal")]
        internal static extern void MadexConsentEnableDebug(bool isDebug);

        [DllImport("__Internal")]
        internal static extern void MadexRegisterCustomConsentVendor(
            string appName,
            string policyUrl,
            string bundle,
            bool isGdpr);

        [DllImport("__Internal")]
        internal static extern void MadexSetConsentDelegate(
            ConsentCallbacks onLoaded,
            ConsentFailCallbacks onLoadedFailed,
            ConsentCallbacks onShown,
            ConsentFailCallbacks onShownFailed,
            ConsenClosedCallbacks onClosed
        );

        #endregion
    }
}
#endif