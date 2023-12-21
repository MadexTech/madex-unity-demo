using System;
using SspnetSDK.ConsentManagerSDK.Unfiled;
using UnityEngine;
using UnityEngine.UI;
using SspnetSDK.Unfiled;
using MadexSDK.Api;
using MadexSDK.ConsentManagerSDK.Api;

namespace MadexSDK.Demo.Scripts
{
    public class MadexDemo : MonoBehaviour, IInterstitialAdListener, IRewardedAdListener, IConsentListener
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
                Madex.Initialize("d42994c6-2145-4269-9c2f-2adcf9d9703f");
                
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

        public void OnInterstitialLoaded()
        {
            LogEvent("OnInterstitialLoaded");
        }

        public void OnInterstitialLoadFailed(AdException error)
        {
            LogEvent($"OnInterstitialLoadFailed: {error.Description}");
        }

        public void OnInterstitialShown()
        {
            LogEvent("OnInterstitialShown");
        }

        public void OnInterstitialShowFailed(AdException error)
        {
            LogEvent($"OnInterstitialShowFailed: {error.Description}");
        }

        public void OnInterstitialClosed()
        {
            LogEvent("OnInterstitialClosed");
        }

        public void OnRewardedLoaded()
        {
            LogEvent("OnRewardedLoaded");
        }

        public void OnRewardedLoadFailed(AdException error)
        {
            LogEvent($"OnRewardedLoadFailed: {error.Description}");
        }

        public void OnRewardedShowFailed(AdException error)
        {
            LogEvent($"OnRewardedShowFailed: {error.Description}");
        }

        public void OnRewardedShown()
        {
            LogEvent("OnRewardedShown");
        }

        public void OnRewardedFinished()
        {
            LogEvent("OnRewardedFinished");
        }

        public void OnRewardedClosed()
        {
            LogEvent("OnRewardedClosed");
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
    }
}