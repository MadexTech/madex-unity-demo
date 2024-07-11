using System;
using SspnetSDK.ConsentManagerSDK.Unfiled;
using UnityEngine;
using UnityEngine.UI;
using SspnetSDK.Unfiled;
using MadexSDK.Api;
using MadexSDK.ConsentManagerSDK.Api;

namespace MadexSDK.Demo.Scripts
{
    public class MadexDemo : MonoBehaviour, IInterstitialAdListener, IRewardedAdListener, IConsentListener, IInitializationListener
    {
        public Text logger;
        private readonly ConsentManager _consentManager = new();

        private void Start()
        {
            InitializeSDK();
        }

        public void LoadInterstitialAd()
        {
            try
            {
                Madex.LoadAd(Madex.Interstitial, "50f37030-162d-4e8c-a9c0-e078d8fbf2f7");
            }
            catch (Exception error)
            {
                LogEvent($"{error}");
            }
           
        }

        public void ShowInterstitialAd()
        {
            Madex.ShowAd(Madex.Interstitial, "50f37030-162d-4e8c-a9c0-e078d8fbf2f7");
        }

        public void DestroyInterstitialAd()
        {
            Madex.DestroyAd(Madex.Interstitial);
        }

        public void LoadRewardedAd()
        {
            Madex.LoadAd(Madex.Rewarded, " dacd566d-8487-4bc6-8afc-486f625be870");
        }

        public void ShowRewardedAd()
        {
            Madex.ShowAd(Madex.Rewarded, " dacd566d-8487-4bc6-8afc-486f625be870");
        }

        public void DestroyRewardedAd()
        {
            Madex.DestroyAd(Madex.Rewarded);
        }

        public void ShowConsent()
        {
            _consentManager.ShowConsentWindow();
        }

        private void InitializeSDK()
        {
            try
            {
                Madex.SetInterstitialCallbacks(this);
                Madex.SetRewardedCallbacks(this);

                Madex.SetUserConsent(true);
                Madex.Initialize("d42994c6-2145-4269-9c2f-2adcf9d9703f", this);
                
                _consentManager.SetListener(this);
                
                var builder = new ConsentBuilder()
                    .AppendPolicyURL("https://Madex.me/privacy-policies")
                    .AppendGdpr(true)
                    .AppendBundle("madex.world.app")
                    .AppendName("Example name");
        
                _consentManager.RegisterCustomVendor(builder);
                _consentManager.LoadManager();
                _consentManager.EnableLog(true);
            }
            catch (Exception error)
            {
                LogEvent($"{error}");
            }
        }

        private void LogEvent(string message)
        {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }

        public void OnInterstitialLoaded(AdPayload adPayload)
        {
            LogEvent("OnInterstitialLoaded");
        }

        public void OnInterstitialLoadFailed(AdPayload adPayload, AdException error)
        {
            LogEvent($"OnInterstitialLoadFailed: {error.Description}");
        }

        public void OnInterstitialShown(AdPayload adPayload)
        {
            LogEvent("OnInterstitialShown");
        }

        public void OnInterstitialShowFailed(AdPayload adPayload, AdException error)
        {
            LogEvent($"OnInterstitialShowFailed: {error.Description}");
        }

        public void OnInterstitialClosed(AdPayload adPayload)
        {
            LogEvent("OnInterstitialClosed");
        }

        public void OnRewardedLoaded(AdPayload adPayload)
        {
            LogEvent("OnRewardedLoaded");
        }

        public void OnRewardedLoadFailed(AdPayload adPayload, AdException error)
        {
            LogEvent($"OnRewardedLoadFailed: {error.Description}");
        }

        public void OnRewardedShowFailed(AdPayload adPayload, AdException error)
        {
            LogEvent($"OnRewardedShowFailed: {error.Description}");
        }

        public void OnRewardedShown(AdPayload adPayload)
        {
            LogEvent("OnRewardedShown");
        }

        public void OnRewardedFinished(AdPayload adPayload)
        {
            LogEvent("OnRewardedFinished");
        }

        public void OnRewardedClosed(AdPayload adPayload)
        {
            LogEvent("OnRewardedClosed");
        }

        public void OnRewardedVideoStarted(AdPayload adPayload)
        {
            LogEvent("OnRewardedVideoStarted");
        }

        public void OnRewardedVideoCompleted(AdPayload adPayload)
        {
            LogEvent("OnRewardedVideoCompleted");
        }

        public void OnUserRewarded(AdPayload adPayload)
        {
            LogEvent("OnUserRewarded");
        }

        public void OnConsentManagerLoaded()
        {
            LogEvent("onConsentManagerLoaded");
        }

        public void OnConsentManagerLoadFailed(string error)
        {
            LogEvent($"onConsentManagerLoadFailed - {error}");
        }

        public void OnConsentWindowShown()
        {
            LogEvent("onConsentWindowShown");
        }

        public void OnConsentManagerShownFailed(string error)
        {
            LogEvent($"onConsentManagerShownFailed - ${error}");
        }

        public void OnConsentWindowClosed(bool hasConsent)
        {
            Madex.SetUserConsent(hasConsent);
            LogEvent($"onConsentWindowClosed - {hasConsent}");
        }
        
        public void OnInitializeSuccess()
        {
            LogEvent("OnInitializeSuccess");
        }

        public void OnInitializeFailed(AdException error)
        {
            LogEvent($"OnInitializeFailed - {error}");
        }
    }
}