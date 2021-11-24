using System;
using System.IO;
using TestModels;
using Xunit;

namespace Zaabee.DataContractSerializer.UnitTest
{
    public partial class XmlUnitTest
    {
        [Fact]
        public void StreamNonGenericTest()
        {
            var type = typeof(TestModel);
            var testModel = TestModelFactory.Create();

            var stream1 = testModel.Pack(type);
            var stream2 = new MemoryStream();
            testModel.PackTo(type, stream2);
            var stream3 = new MemoryStream();
            stream3.PackBy(type, testModel);

            var unPackResult1 = (TestModel) stream1.Unpack(type);
            var unPackResult2 = (TestModel) stream2.Unpack(type);
            var unPackResult3 = (TestModel) stream3.Unpack(type);

            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult1.Id, unPackResult1.Age, unPackResult1.CreateTime, unPackResult1.Name,
                    unPackResult1.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult2.Id, unPackResult2.Age, unPackResult2.CreateTime, unPackResult2.Name,
                    unPackResult2.Gender));
            Assert.Equal(
                Tuple.Create(testModel.Id, testModel.Age, testModel.CreateTime, testModel.Name, testModel.Gender),
                Tuple.Create(unPackResult3.Id, unPackResult3.Age, unPackResult3.CreateTime, unPackResult3.Name,
                    unPackResult3.Gender));

            TestModel nullModel = null;
            var streamNull = nullModel.Pack(typeof(TestModel));
            Assert.Equal(0, streamNull.Length);
            Assert.Equal(0, streamNull.Position);

            Assert.Null(DataContractHelper.Unpack(typeof(TestModel), null));
            var ms = new MemoryStream();
            DataContractHelper.Pack(typeof(TestModel), null, ms);
            Assert.Equal(0, ms.Length);
            Assert.Equal(0, ms.Position);
        }
    }
}