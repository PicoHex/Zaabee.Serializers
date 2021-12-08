namespace Zaabee.Jil;

public static partial class JilExtensions
{
    public static async Task PackByAsync<TValue>(this Stream? stream, TValue? value, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, stream, options, encoding);

    public static async Task PackByAsync(this Stream? stream, object? value, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.PackAsync(value, stream, options, encoding);

    public static async Task<TValue?> UnpackAsync<TValue>(this Stream? stream, Options? options = null, Encoding? encoding = null) =>
        await JilHelper.UnpackAsync<TValue>(stream, options, encoding);

    public static async Task<object?> UnpackAsync(this Stream? stream, Type type, Options? options = null,
        Encoding? encoding = null) =>
        await JilHelper.UnpackAsync(type, stream, options, encoding);
}