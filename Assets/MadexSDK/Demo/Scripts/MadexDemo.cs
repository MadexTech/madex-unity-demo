using System;
using UnityEngine;
using UnityEngine.UI;
using SspnetSDK.Unfiled;
using MadexSDK.Api;

namespace MadexSDK.Demo.Scripts
{
    public class MadexDemo : MonoBehaviour, IInterstitialAdListener, IRewardedAdListener
    {
        public Text logger;

        private void Start()
        {
            InitializeSDK();
        }

        public void LoadInterstitialAd()
        {
            try
            {
                Madex.LoadAd(Madex.Interstitial, "b8359c60-9bde-47c9-85ff-3c7afd2bd982");
            }
            catch (Exception error)
            {
                LogEvent($"{error}");
            }
           
        }

        public void ShowInterstitialAd()
        {
            Madex.ShowAd(Madex.Interstitial, "b8359c60-9bde-47c9-85ff-3c7afd2bd982");
        }

        public void DestroyInterstitialAd()
        {
            Madex.DestroyAd(Madex.Interstitial);
        }

        public void LoadRewardedAd()
        {
            Madex.LoadAd(Madex.Rewarded, "eaac7a7f-b0b0-46d2-ac95-bd58578e9e29");
        }

        public void ShowRewardedAd()
        {
            Madex.ShowAd(Madex.Rewarded, "eaac7a7f-b0b0-46d2-ac95-bd58578e9e29");
        }

        public void DestroyRewardedAd()
        {
            Madex.DestroyAd(Madex.Rewarded);
        }

        public void ShowConsent()
        {
        }

        private void InitializeSDK()
        {
            try
            {
                Madex.SetInterstitialCallbacks(this);
                Madex.SetRewardedCallbacks(this);

                Madex.SetUserConsent(true);
                Madex.Initialize("65057899-a16a-4877-989b-38c432a7fa15");
                
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

        public void onConsentManagerLoaded()
        {
            LogEvent("onConsentManagerLoaded");
        }

        public void onConsentManagerLoadFailed(string error)
        {
            LogEvent($"onConsentManagerLoadFailed - {error}");
        }

        public void onConsentWindowShown()
        {
            LogEvent("onConsentWindowShown");
        }

        public void onConsentManagerShownFailed(string error)
        {
            LogEvent($"onConsentManagerShownFailed - ${error}");
        }

        public void onConsentWindowClosed(bool hasConsent)
        {
            Madex.SetUserConsent(hasConsent);
            LogEvent($"onConsentWindowClosed - {hasConsent}");
        }
    }
}