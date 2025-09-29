#if UNITY_ANDROID
using System;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace SspnetSDK.Platform.Android
{
    public class BannerCallbacks : AndroidJavaProxy
    {
        private readonly IBannerAdListener _listener;

        internal BannerCallbacks(IBannerAdListener listener)
            : base(AndroidConstants.BannerListener)
        {
            _listener = listener;
        }

        public void onBannerLoaded(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerLoaded(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onBannerLoadFailed(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerLoadFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onBannerShown(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerShown(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onBannerShowFailed(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerShowFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onBannerClosed(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerClosed(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onBannerImpression(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnBannerImpression(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }
    }
}
#endif