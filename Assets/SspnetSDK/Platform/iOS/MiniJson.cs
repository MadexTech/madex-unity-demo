using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SspnetSDK.Platform.iOS
{
    public static class MiniJson
    {
        public static string Serialize(object obj)
        {
            var sb = new StringBuilder(128);
            WriteValue(sb, obj);
            return sb.ToString();
        }

        private static void WriteValue(StringBuilder sb, object value)
        {
            if (value == null)
            {
                sb.Append("null");
                return;
            }

            switch (value)
            {
                case string s:
                    WriteString(sb, s);
                    return;
                case bool b:
                    sb.Append(b ? "true" : "false");
                    return;
                case char c:
                    WriteString(sb, c.ToString());
                    return;

                // числа
                case sbyte or byte or short or ushort or int or uint or long or ulong or float or double or decimal:
                    sb.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
                    return;

                // массивы/списки
                case IList list:
                    WriteArray(sb, list);
                    return;

                // словари
                case IDictionary dict:
                    WriteObject(sb, dict);
                    return;

                default:
                    // фоллбек: попробуем как словарь<string, object>
                    if (value is IEnumerable enumerable && value.GetType().IsGenericType)
                    {
                        // IEnumerable, но не IList — сериализуем как массив
                        var tmp = new List<object>();
                        foreach (var it in enumerable) tmp.Add(it);
                        WriteArray(sb, tmp);
                        return;
                    }

                    // иначе строка
                    WriteString(sb, value.ToString());
                    return;
            }
        }

        private static void WriteString(StringBuilder sb, string s)
        {
            sb.Append('"');
            foreach (var ch in s)
                switch (ch)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (ch < 32)
                            sb.Append("\\u").Append(((int) ch).ToString("x4"));
                        else
                            sb.Append(ch);
                        break;
                }

            sb.Append('"');
        }

        private static void WriteArray(StringBuilder sb, IEnumerable arr)
        {
            sb.Append('[');
            var first = true;
            foreach (var item in arr)
            {
                if (!first) sb.Append(',');
                first = false;
                WriteValue(sb, item);
            }

            sb.Append(']');
        }

        private static void WriteObject(StringBuilder sb, IDictionary dict)
        {
            sb.Append('{');
            var first = true;
            foreach (DictionaryEntry kv in dict)
            {
                if (!first) sb.Append(',');
                first = false;
                WriteString(sb, kv.Key?.ToString() ?? "null");
                sb.Append(':');
                WriteValue(sb, kv.Value);
            }

            sb.Append('}');
        }
    }
}