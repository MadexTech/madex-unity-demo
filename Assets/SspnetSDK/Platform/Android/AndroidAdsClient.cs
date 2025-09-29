#if UNITY_ANDROID
using System.Collections;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace SspnetSDK.Platform.Android
{
    public class AndroidAdsClient : IAdsClient
    {
        private AndroidJavaObject _activity;


        private AndroidJavaClass _nativeClass;

        public void Initialize(string publisherID, IInitializationListener listener)
        {
            GetCoreClass().CallStatic("initialize", publisherID, new InitializationCallbacks(listener));
        }

        public bool IsInitialized()
        {
            return GetCoreClass().CallStatic<bool>("isInitialized");
        }

        public bool CanLoadAd(int adType, string placementName)
        {
            return GetCoreClass().CallStatic<bool>("canLoadAd", adType, placementName);
        }

        public void ShowAd(int adType, string placementName)
        {
            GetCoreClass().CallStatic("showAd", GetActivity(), adType, placementName);
        }

        public bool IsAdLoaded(int adType, string placementName)
        {
            return GetCoreClass().CallStatic<bool>("isAdLoaded", adType, placementName);
        }

        public void LoadAd(int adType, string placementName)
        {
            GetCoreClass().CallStatic("loadAd", GetActivity(), adType, placementName);
        }

        public void DestroyAd(int adType, string placementName)
        {
            GetCoreClass().CallStatic("destroyAd", adType, placementName);
        }

        public void DestroyAd(int adType)
        {
            GetCoreClass().CallStatic("destroyAd", adType);
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            GetCoreClass().CallStatic("setInterstitialListener", new InterstitialCallbacks(adListener));
        }

        public void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            GetCoreClass().CallStatic("setRewardedListener", new RewardedCallbacks(adListener));
        }

        public void SetBannerCallbacks(IBannerAdListener adListener)
        {
            GetCoreClass().CallStatic("setBannerListener", new BannerCallbacks(adListener));
        }

        public void SetBannerCustomSettings(BannerSettings settings)
        {
            using var bannerSettingsClass = new AndroidJavaClass(AndroidConstants.BannerSettings);
            // Получаем Builder через статический метод builder()
            var builder = bannerSettingsClass.CallStatic<AndroidJavaObject>("builder");

            // Устанавливаем необходимые параметры
            builder.Call<AndroidJavaObject>("setShowCloseButton", settings.ShowCloseButton);
            builder.Call<AndroidJavaObject>("setBannerPosition", settings.BannerPosition);
            builder.Call<AndroidJavaObject>("setRefreshIntervalSeconds", settings.RefreshIntervalSeconds);

            // Создаем нативный объект BannerSettings через build()
            var nativeBannerSettings = builder.Call<AndroidJavaObject>("build");

            // Передаем созданный объект в основной класс
            GetCoreClass().CallStatic("setBannerCustomSettings", nativeBannerSettings);
        }


        public void SetCustomParams(string key, object value)
        {
            GetCoreClass().CallStatic("setCustomParams", key, ConvertToJavaArg(value));
        }

        public void SetUserConsent(bool hasConsent)
        {
            GetCoreClass().CallStatic("setUserConsent", hasConsent);
        }

        public void EnableDebug(bool enabled)
        {
            GetCoreClass().CallStatic("enableDebug", enabled);
        }

        public bool HasUserConsent()
        {
            return GetCoreClass().CallStatic<bool>("hasUserConsent");
        }

        public string GetSdkVersion()
        {
            return GetCoreClass().CallStatic<string>("getSdkVersion");
        }

        private object ConvertToJavaArg(object v)
        {
            if (v == null) return null;

            if (v is AndroidJavaObject ajo) return ajo;

            switch (v)
            {
                case string s: return s;
                case char c: return c.ToString();

                case int i: return new AndroidJavaObject("java.lang.Integer", i);
                case long l: return new AndroidJavaObject("java.lang.Long", l);
                case float f: return new AndroidJavaObject("java.lang.Float", f);
                case double d: return new AndroidJavaObject("java.lang.Double", d);
                case bool b: return new AndroidJavaObject("java.lang.Boolean", b);
                case byte by: return new AndroidJavaObject("java.lang.Byte", by);
                case short sh: return new AndroidJavaObject("java.lang.Short", sh);

                case byte[] bytes: return bytes; // Unity сам создаст jbyteArray
            }

            if (v is IDictionary dict) return ToJavaHashMap(dict);
            if (v is IList list) return ToJavaArrayList(list);

            // Фоллбек: как строка (или сериализуй в JSON, если нужно строго сохранить структуру)
            return v.ToString();
        }

        private AndroidJavaObject ToJavaHashMap(IDictionary dict)
        {
            var map = new AndroidJavaObject("java.util.HashMap");
            var putMethod = map.Get<AndroidJavaObject>("entrySet"); // заставим JIT подгрузить класс
            foreach (DictionaryEntry kv in dict)
                map.Call<AndroidJavaObject>("put",
                    kv.Key?.ToString(),
                    ConvertToJavaArg(kv.Value));
            return map;
        }

        private AndroidJavaObject ToJavaArrayList(IList list)
        {
            var arrayList = new AndroidJavaObject("java.util.ArrayList");
            foreach (var item in list) arrayList.Call<bool>("add", ConvertToJavaArg(item));
            return arrayList;
        }

        private AndroidJavaClass GetCoreClass()
        {
            return _nativeClass ??= new AndroidJavaClass(AndroidConstants.SspnetCore);
        }

        private AndroidJavaObject GetActivity()
        {
            if (_activity != null) return _activity;
            var playerClass = new AndroidJavaClass(AndroidConstants.UnityActivityClassName);
            _activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");

            return _activity;
        }

        private static AndroidJavaObject BoolToAndroid(bool value)
        {
            var boleanClass = new AndroidJavaClass("java.lang.Boolean");
            var boolean = boleanClass.CallStatic<AndroidJavaObject>("valueOf", value);
            return boolean;
        }
    }
}
#endif