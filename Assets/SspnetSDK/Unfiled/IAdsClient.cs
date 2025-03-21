namespace SspnetSDK.Unfiled
{
    public interface IAdsClient
    {
        public const int Interstitial = 1;
        public const int Banner = 2;
        public const int Rewarded = 3;

        public void Initialize(string publisherID, IInitializationListener listener);
        public bool IsInitialized();
        public bool CanLoadAd(int adType, string placementName);
        public void LoadAd(int adType, string placementName);
        public void ShowAd(int adType, string placementName);
        public bool IsAdLoaded(int adType, string placementName);
        public void DestroyAd(int adType);
        public void DestroyAd(int adType, string placementName);
        public void SetInterstitialCallbacks(IInterstitialAdListener adListener);
        public void SetRewardedCallbacks(IRewardedAdListener adListener);
        public void SetBannerCallbacks(IBannerAdListener adListener);
        public void SetBannerCustomSettings(BannerSettings settings);
        public void SetCustomParams(string key, string value);
        public void SetUserConsent(bool hasConsent);
        public void EnableDebug(bool enabled);
        public bool HasUserConsent();
        public string GetSdkVersion();
    }
}