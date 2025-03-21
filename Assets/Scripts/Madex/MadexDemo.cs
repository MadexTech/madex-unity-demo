using MadexSDK.Api;
using Scripts.Utils;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace MadexSDK.Demo.Scripts
{
    public class MadexDemo : MonoBehaviour, IInitializationListener
    {
        private void Start()
        {
            Madex.EnableDebug(true);
            Madex.Initialize(EnvironmentVariables.publisherID, this);
        }

        public void OnInitializeSuccess()
        {
        }

        public void OnInitializeFailed(AdException error)
        {
        }

        public void ShowInterstitialScence()
        {
            SceneNavigationManager.Instance.LoadSceneAdditively("InterstitialScence");
        }

        public void ShowRewardedScence()
        {
            SceneNavigationManager.Instance.LoadSceneAdditively("RewardedScence");
        }

        public void ShowBannerScence()
        {
            SceneNavigationManager.Instance.LoadSceneAdditively("BannerScence");
        }

        public void ShowConsentScence()
        {
            SceneNavigationManager.Instance.LoadSceneAdditively("ConsentManagerScence");
        }
    }
}