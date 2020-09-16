using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zaabee.NewtonsoftJson
{
    public static class StreamExtension
    {
        public static void PackBy(this Stream stream, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Pack(obj, stream, settings, encoding);

        public static T Unpack<T>(this Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Unpack<T>(stream, settings, encoding);

        public static object Unpack(this Stream stream, Type type, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            NewtonsoftJsonHelper.Unpack(type, stream, settings, encoding);

        public static async Task PackByAsync(this Stream stream, object obj, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            await NewtonsoftJsonHelper.PackAsync(obj, stream, settings, encoding);

        public static async Task<T> UnpackAsync<T>(this Stream stream, JsonSerializerSettings settings = null,
            Encoding encoding = null) =>
            await NewtonsoftJsonHelper.UnpackAsync<T>(stream, settings, encoding);

        public static async Task<object> UnpackAsync(this Stream stream, Type type,
            JsonSerializerSettings settings = null, Encoding encoding = null) =>
            await NewtonsoftJsonHelper.UnpackAsync(type, stream, settings, encoding);
    }
}