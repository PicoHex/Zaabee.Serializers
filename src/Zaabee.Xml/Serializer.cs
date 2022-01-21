namespace Zaabee.Xml;

public class Serializer : IXmlSerializer
{
    public byte[] ToBytes<TValue>(TValue? value) =>
        XmlHelper.ToBytes(value);

    public byte[] ToBytes(Type type, object? value) =>
        XmlHelper.ToBytes(type, value);

    public TValue? FromBytes<TValue>(byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : XmlHelper.FromBytes<TValue>(bytes);

    public object? FromBytes(Type type, byte[]? bytes) =>
        bytes is null || bytes.Length is 0
            ? default
            : XmlHelper.FromBytes(type, bytes);

    public string ToText<TValue>(TValue? value) =>
        XmlHelper.ToXml(value);

    public string ToText(Type type, object? value) =>
        XmlHelper.ToXml(type, value);

    public TValue? FromText<TValue>(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml<TValue>(text);

    public object? FromText(Type type, string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? default
            : XmlHelper.FromXml(type, text);

    public Stream ToStream<TValue>(TValue? value) =>
        XmlHelper.ToStream(value);

    public Stream ToStream(Type type, object? value) =>
        XmlHelper.ToStream(type, value);

    public TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : XmlHelper.FromStream<TValue>(stream);

    public object? FromStream(Type type, Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : XmlHelper.FromStream(type, stream);

    public string ToXml<TValue>(TValue? value) =>
        XmlHelper.ToXml(value);

    public TValue? FromXml<TValue>(string? xml) =>
        string.IsNullOrWhiteSpace(xml)
            ? default
            : XmlHelper.FromXml<TValue>(xml);

    public string ToXml(Type type, object? value) =>
        XmlHelper.ToXml(type, value);

    public object? FromXml(Type type, string? xml) =>
        string.IsNullOrWhiteSpace(xml)
            ? default
            : XmlHelper.FromXml(type, xml);
}