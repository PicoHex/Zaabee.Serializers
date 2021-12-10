namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Serialize the generic object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(object? value, Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return;
        TypeModel.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}