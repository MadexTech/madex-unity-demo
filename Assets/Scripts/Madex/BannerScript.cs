using MadexSDK.Api;
using SspnetSDK.Unfiled;

namespace MadexSDK.Demo.Scripts
{
    public class BannerScript : UnfiledAdScript, IBannerAdListener
    {
        private void Start()
        {
            Madex.SetBannerCallbacks(this);
            Madex.SetBannerCustomSettings(new BannerSettings().SetShowCloseButton(true));
            InitClickListeners();
        }


        public void OnBannerLoaded(AdPayload adPayload)
        {
            AddLog("OnBannerLoaded");
        }

        public void OnBannerLoadFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnBannerLoadFailed: {error.Description}");
        }

        public void OnBannerShown(AdPayload adPayload)
        {
            AddLog("OnBannerShown");
        }

        public void OnBannerShowFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnBannerShowFailed: {error.Description}");
        }

        public void OnBannerClosed(AdPayload adPayload)
        {
            AddLog("OnBannerClosed");
        }

        public void OnBannerImpression(AdPayload adPayload)
        {
            AddLog("OnBannerImpression");
        }

        protected override string GetPlacementName()
        {
            return EnvironmentVariables.madexBannerUnitID;
        }

        protected override int GetAdType()
        {
            return Madex.Banner;
        }
    }
}