namespace Zaabee.SpanJson;

public sealed class Serializer : IJsonSerializer, IStreamSerializerAsync
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        SpanJsonHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        SpanJsonHelper.ToBytes(value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SpanJsonHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SpanJsonHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        SpanJsonHelper.ToJson(value);

    public string ToText(Type type, object? value) =>
        SpanJsonHelper.ToJson(value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SpanJsonHelper.FromJson<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : SpanJsonHelper.FromJson(type, text);

    public MemoryStream ToStream<TValue>(TValue? value) =>
        SpanJsonHelper.ToStream(value);

    public MemoryStream ToStream(Type type, object? value) =>
        SpanJsonHelper.ToStream(value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SpanJsonHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : SpanJsonHelper.FromStream(type, stream);

    public string ToJson<TValue>(TValue? value) =>
        ToText(value);

    public TValue? FromJson<TValue>(string? json) =>
        FromText<TValue>(json);

    public string ToJson(Type type, object? value) =>
        ToText(type, value);

    public object? FromJson(Type type, string? json) =>
        FromText(type, json);

    public async Task PackAsync<TValue>(TValue? value, Stream? stream, CancellationToken cancellationToken = default) =>
        await SpanJsonHelper.PackAsync(value, stream, cancellationToken);

    public async Task PackAsync(Type type, object? value, Stream? stream,
        CancellationToken cancellationToken = default) =>
        await SpanJsonHelper.PackAsync(value, stream, cancellationToken);

    public async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await SpanJsonHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public async Task<object?> FromStreamAsync(Type type, Stream? stream,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : await SpanJsonHelper.FromStreamAsync(type, stream, cancellationToken);
}