using Amusoft.XUnit.NLog.Extensions;
using VideoClipper.UnitTests.Toolkit;
using Xunit;
using Xunit.Abstractions;

namespace VideoClipper.UnitTests
{
    public class UnitTest1 : TestBase
    {
        [Fact]
        public void Test1()
        {
        }

        public UnitTest1(ITestOutputHelper outputHelper, GlobalSetupFixture data) : base(outputHelper, data)
        {
        }
    }
}
