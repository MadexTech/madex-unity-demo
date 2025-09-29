#if UNITY_ANDROID
using System;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace SspnetSDK.Platform.Android
{
    public class RewardedCallbacks : AndroidJavaProxy
    {
        private readonly IRewardedAdListener _listener;

        internal RewardedCallbacks(IRewardedAdListener listener)
            : base(AndroidConstants.RewardedListener)
        {
            _listener = listener;
        }

        public void onRewardedLoaded(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedLoaded(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedLoadFail(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedLoadFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedShown(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedShown(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedShowFailed(AndroidJavaObject adPayload, AndroidJavaObject error)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                var ex = CallbackUtils.MakeAdException(error);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedShowFailed(payload, ex);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedClosed(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedClosed(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedVideoStarted(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedVideoStarted(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onRewardedVideoCompleted(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnRewardedVideoCompleted(payload);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                });
            });
        }

        public void onUserRewarded(AndroidJavaObject adPayload)
        {
            CallbackUtils.SafeJniInvoke(() =>
            {
                var payload = CallbackUtils.MakePayload(adPayload);
                CallbackUtils.OnMainThread(() =>
                {
                    try
                    {
                        _listener?.OnUserRewarded(payload);
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