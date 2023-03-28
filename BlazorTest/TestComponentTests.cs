using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTest
{
    public class TestComponentTests : TestContext
    {
        [Fact]
        public void TestComponentWithEventHandler()
        {
            var cut = RenderComponent<TestComponent>();
            cut.Find("button").Click();
            cut.Find("p").MarkupMatches("<p>Button clicked: True</p>");
        }
    }
}