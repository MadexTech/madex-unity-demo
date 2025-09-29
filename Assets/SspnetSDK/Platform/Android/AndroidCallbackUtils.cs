#if UNITY_ANDROID
using System;
using SspnetSDK.Unfiled;
using UnityEngine;

namespace SspnetSDK.Platform.Android
{
    internal static class CallbackUtils
    {
        private const int MaxLen = 1024;

        /// <summary>Защищает тело вызова локальным JNI-кадром и try/catch.</summary>
        public static void SafeJniInvoke(Action body)
        {
            try
            {
                AndroidJNI.PushLocalFrame(16);
                try
                {
                    body?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            finally
            {
                try
                {
                    AndroidJNI.PopLocalFrame(IntPtr.Zero);
                }
                catch
                {
                    /* ignore */
                }
            }
        }

        /// <summary>Прокидывает выполнение в главный поток Unity.</summary>
        public static void OnMainThread(Action a)
        {
            _SspnetMainThreadRunner.Post(a);
        }

        public static string TryCallString(AndroidJavaObject obj, string method)
        {
            if (obj == null || string.IsNullOrEmpty(method)) return string.Empty;
            try
            {
                var s = obj.Call<string>(method);
                return Sanitize(s);
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string Sanitize(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var span = s.AsSpan(0, Math.Min(s.Length, MaxLen));
            char[] buf = null;
            var w = 0;
            for (var i = 0; i < span.Length; i++)
            {
                var ch = span[i];
                if (ch == '\0' || char.IsSurrogate(ch)) continue;
                buf ??= new char[span.Length];
                buf[w++] = ch;
            }

            return buf == null ? span.ToString() : new string(buf, 0, w);
        }

        public static AdPayload MakePayload(AndroidJavaObject adPayload)
        {
            var placement = TryCallString(adPayload, "getPlacementName");
            return new AdPayload(placement);
        }

        public static AdException MakeAdException(AndroidJavaObject error)
        {
            var description = TryCallString(error, "getDescription");
            var message = TryCallString(error, "getMessage");
            var caused = TryCallString(error, "getCaused");
            return new AdException(description, message, caused);
        }
    }
}
#endif