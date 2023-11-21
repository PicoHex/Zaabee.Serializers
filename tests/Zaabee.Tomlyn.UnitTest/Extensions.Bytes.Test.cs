namespace Zaabee.Tomlyn.UnitTest;

public partial class ExtensionsTest
{
    [Fact]
    public void GenericTypeBytesTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
        
        Assert.Equal(testModel, result);
    }

    [Fact]
    public void GenericTypeBytesNullTest()
    {
        TestModel? nullModel = null;
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes().FromBytes<TestModel>());
        Assert.Null(Array.Empty<byte>().FromBytes<TestModel>());
        Assert.Null(nullBytes.FromBytes<TestModel>());
    }

    [Fact]
    public void NonGenericTypeBytesNullTest()
    {
        object? nullModel = null;
        byte[]? nullBytes = null;
        Assert.Null(nullModel.ToBytes().FromBytes());
        Assert.Null(Array.Empty<byte>().FromBytes());
        Assert.Null(nullBytes.FromBytes());
    }

    [Fact]
    public void ObjectBytesTest()
    {
        var testModel = TestModelHelper.Create();
        var bytes = testModel.ToBytes();
        var result = bytes.FromBytes<TestModel>()!;
        
        Assert.Equal(testModel, result);
    }
}