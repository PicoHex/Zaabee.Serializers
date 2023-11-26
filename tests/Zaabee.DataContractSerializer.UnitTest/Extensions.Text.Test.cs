namespace Zaabee.DataContractSerializer.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeXmlTest()
    {
        var testModel = TestModelHelper.Create();
        var json = testModel.ToXml();
        var result = json.FromXml<TestModel>()!;
        Assert.Equal(testModel, result);
    }

    [Fact]
    public void GenericTypeXmlNullTest()
    {
        TestModel? nullModel = null;
        string? nullXml = null;
        var emptyXml = nullModel.ToXml();
        Assert.Null(emptyXml.FromXml<TestModel>());
        Assert.Null(nullXml.FromXml<TestModel>());
    }

    [Fact]
    public void NonGenericTypeXmlTest()
    {
        object testModel = TestModelHelper.Create();
        var json = testModel.ToXml(typeof(TestModel));
        var result = (TestModel)json.FromXml(typeof(TestModel))!;
        Assert.Equal((TestModel)testModel, result);
    }

    [Fact]
    public void NonGenericTypeXmlNullTest()
    {
        object? nullModel = null;
        string? nullXml = null;
        var emptyXml = nullModel.ToXml(typeof(TestModel));
        Assert.Null(emptyXml.FromXml(typeof(TestModel)));
        Assert.Null(nullXml.FromXml(typeof(TestModel)));
    }
}
