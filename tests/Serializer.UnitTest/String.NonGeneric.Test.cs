namespace Serializer.UnitTest;

public partial class SerializerTest
{
    [Fact]
    public void JilStringNonGenericTest() =>
        StringNonGenericTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringNonGenericTest() =>
        StringNonGenericTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringNonGenericTest() =>
        StringNonGenericTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringNonGenericTest() =>
        StringNonGenericTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStringNonGenericTest() =>
        StringNonGenericTest(new Zaabee.Xml.Serializer());

    [Fact]
    public void JilStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Jil.Serializer());

    [Fact]
    public void NewtonsoftJsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.NewtonsoftJson.Serializer());

    [Fact]
    public void SystemTextJsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.SystemTextJson.Serializer());

    [Fact]
    public void Utf8JsonStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Utf8Json.Serializer());

    [Fact]
    public void XmlStringNonGenericNullTest() =>
        StringNonGenericNullTest(new Zaabee.Xml.Serializer());

    private static void StringNonGenericTest(ITextSerializer serializer)
    {
        var model = TestModelFactory.Create();
        var type = typeof(TestModel);
        var bytes = serializer.SerializeToString(type, model);
        var deserializeModel = (TestModel)serializer.DeserializeFromString(type, bytes)!;

        Assert.Equal(
            Tuple.Create(model.Id, model.Age, model.CreateTime, model.Name, model.Gender),
            Tuple.Create(deserializeModel.Id, deserializeModel.Age, deserializeModel.CreateTime,
                deserializeModel.Name, deserializeModel.Gender));
    }

    private static void StringNonGenericNullTest(ITextSerializer serializer)
    {
        var type = typeof(TestModel);
        var text = serializer.SerializeToString(type, null);
        Assert.Empty(text);
        var deserializeModel = serializer.DeserializeFromString(type, null);
        Assert.Null(deserializeModel);
    }
}