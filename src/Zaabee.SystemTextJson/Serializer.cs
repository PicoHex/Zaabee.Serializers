namespace Zaabee.SystemTextJson;

public class Serializer : ITextSerializer
{
    private readonly JsonSerializerOptions? _options;

    public Serializer(JsonSerializerOptions? options = null) =>
        _options = options;

    public Stream ToStream<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToStream(value, _options);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : SystemTextJsonHelper.FromStream<TValue>(stream, _options);

    public Stream ToStream(Type type, object? value) =>
        SystemTextJsonHelper.ToStream(type, value, _options);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : SystemTextJsonHelper.FromStream(type, stream, _options);

    public byte[] ToBytes<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToBytes(value, _options);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes<TValue>(bytes, _options);

    public byte[] ToBytes(Type type, object? value) =>
        SystemTextJsonHelper.ToBytes(type, value, _options);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : SystemTextJsonHelper.FromBytes(type, bytes, _options);

    public string ToText<TValue>(TValue? value) =>
        SystemTextJsonHelper.ToJson(value, _options);

    public TValue? FromText<TValue>(string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonHelper.FromJson<TValue>(text, _options);

    public string ToText(Type type, object? value) =>
        SystemTextJsonHelper.ToJson(type, value, _options);

    public object? FromText(Type type, string? text) =>
        text.IsNullOrWhiteSpace()
            ? default
            : SystemTextJsonHelper.FromJson(type, text, _options);
}