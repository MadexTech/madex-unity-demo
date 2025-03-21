using MadexSDK.Api;
using SspnetSDK.Unfiled;

namespace MadexSDK.Demo.Scripts
{
    public class RewardedScript : UnfiledAdScript, IRewardedAdListener
    {
        private void Start()
        {
            Madex.SetRewardedCallbacks(this);
            InitClickListeners();
        }

        public void OnRewardedLoaded(AdPayload adPayload)
        {
            AddLog("OnRewardedLoaded");
        }

        public void OnRewardedLoadFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnRewardedLoadFailed: {error.Description}");
        }

        public void OnRewardedShowFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnRewardedShowFailed: {error.Description}");
        }

        public void OnRewardedShown(AdPayload adPayload)
        {
            AddLog("OnRewardedShown");
        }

        public void OnRewardedClosed(AdPayload adPayload)
        {
            AddLog("OnRewardedClosed");
        }

        public void OnRewardedVideoStarted(AdPayload adPayload)
        {
            AddLog("OnRewardedVideoStarted");
        }

        public void OnRewardedVideoCompleted(AdPayload adPayload)
        {
            AddLog("OnRewardedVideoCompleted");
        }

        public void OnUserRewarded(AdPayload adPayload)
        {
            AddLog("OnUserRewarded");
        }

        protected override string GetPlacementName()
        {
            return EnvironmentVariables.madexRewardedUnitID;
        }

        protected override int GetAdType()
        {
            return Madex.Rewarded;
        }
    }
}