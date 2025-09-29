#if UNITY_ANDROID
using System;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace SspnetSDK.Platform.Android
{
    public class InterstitialCallbacks : AndroidJavaProxy
    {
        private readonly IInterstitialAdListener _listener;

        internal InterstitialCallbacks(IInterstitialAdListener listener)
            : base(AndroidConstants.InterstitialListener)
        {
            _listener = listener;
        }

        public void onInterstitialLoaded(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnInterstitialLoaded(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onInterstitialLoadFail(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnInterstitialLoadFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onInterstitialShown(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnInterstitialShown(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onInterstitialShowFailed(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnInterstitialShowFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onInterstitialClosed(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnInterstitialClosed(payload);
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