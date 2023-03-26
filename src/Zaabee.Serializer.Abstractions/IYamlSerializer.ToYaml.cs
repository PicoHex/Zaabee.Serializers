namespace Zaabee.Serializer.Abstractions;

public partial interface IYamlSerializer : ITextSerializer
{
}


public static partial class YamlSerializerExtension
{
    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToYaml<TValue>(this IYamlSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to yaml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToYaml(this IYamlSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);
}