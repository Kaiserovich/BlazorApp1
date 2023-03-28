using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace BlazorTest
{
    public class UnitTest1
    {
       /* [Fact]
        public void Test1()
        {

        
        }*/


    }
    //public class ClientRepositoryTests
    //{
    //    private WeatherTestDataProvider _weatherTestDataProvider;

    //    public ClientRepositoryTests()
    //        => _weatherTestDataProvider = WeatherTestDataProvider.Instance();

    //    private ServiceProvider GetServiceProvider()
    //    {
    //        var services = new ServiceCollection();
    //        Action<DbContextOptionsBuilder> dbOptions = options => options.UseInMemoryDatabase($"WeatherDatabase-{Guid.NewGuid().ToString()}");
    //        services.AddWeatherAppServerDataServices<InMemoryWeatherDbContext>(dbOptions);
    //        services.AddInMemoryWeatherAppServerDataServices();
    //        var provider = services.BuildServiceProvider();

    //        WeatherAppDataServices.AddTestData(provider);

    //        return provider!;
    //    }

    //    [Fact]
    //    public async void TestRepositoryDataBrokerDboWeatherForecastList()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var cancelToken = new CancellationToken();
    //        var listRequest = new ListProviderRequest<DboWeatherForecast>(0, 1000, cancelToken);
    //        var result = await broker!.GetRecordsAsync<DboWeatherForecast>(listRequest);

    //        Assert.Equal(100, result.Items.Count());
    //    }

    //    [Fact]
    //    public async void TestRepositoryDataBrokerDboWeatherSummaryList()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var cancelToken = new CancellationToken();
    //        var listRequest = new ListProviderRequest<DboWeatherSummary>(0, 1000, cancelToken);
    //        var result = await broker!.GetRecordsAsync<DboWeatherSummary>(listRequest);

    //        Assert.Equal(10, result.Items.Count());
    //    }

    //    [Fact]
    //    public async void TestRepositoryDataBrokerFKList()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var result = await broker!.GetFKListAsync<FkWeatherSummary>();

    //        Assert.Equal(10, result.Items.Count());
    //        Assert.IsType<FkWeatherSummary>(result.Items.First());
    //    }


    //    [Fact]
    //    public async void TestAddMovementRepositoryDataBroker()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var testRecord = _weatherTestDataProvider.GetForecast();
    //        var newRecord = testRecord with { };
    //        var id = newRecord.WeatherForecastId;
    //        var result = await broker!.AddRecordAsync<DboWeatherForecast>(newRecord);

    //        var recordResult = await broker.GetRecordAsync<DboWeatherForecast>(id);

    //        Assert.True(result.Success);
    //        Assert.Equal(testRecord, recordResult.Record);
    //    }

    //    [Fact]
    //    public async void TestDeleteRepositoryDataBroker()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var deleteRecord = _weatherTestDataProvider.GetRandomRecord()!;

    //        var oldCountResult = await broker!.GetRecordCountAsync<DboWeatherForecast>();

    //        var id = deleteRecord.WeatherForecastId;
    //        var result = await broker!.DeleteRecordAsync<DboWeatherForecast>(deleteRecord);

    //        var newCountResult = await broker!.GetRecordCountAsync<DboWeatherForecast>();
    //        var recordResult = await broker.GetRecordAsync<DboWeatherForecast>(id);

    //        Assert.True(result.Success);
    //        Assert.Null(recordResult.Record);
    //        Assert.Equal(oldCountResult.Count, newCountResult.Count + 1);

    //    }

    //    [Fact]
    //    public async void TestUpdateRepositoryDataBroker()
    //    {
    //        var provider = GetServiceProvider();
    //        var broker = provider.GetService<IDataBroker>()!;

    //        var record = _weatherTestDataProvider.GetRandomRecord()!;
    //        var testRecord = record with { Date = record.Date.AddDays(1) };
    //        var updatedRecord = testRecord with { };

    //        var id = updatedRecord.WeatherForecastId;
    //        var result = await broker!.UpdateRecordAsync<DboWeatherForecast>(updatedRecord);

    //        var recordResult = await broker.GetRecordAsync<DboWeatherForecast>(id);

    //        Assert.True(result.Success);
    //        Assert.Equal(testRecord, recordResult.Record);
    //    }
    //}

    //[Fact]
    //public void GivenAValidComponent_WhenComponentIsRendered_ThenMarkupMatchesExpectedOutput()
    //{
    //    var cut = RenderComponent<TestComponent>();

    //    cut.MarkupMatches("<p>Hello from TestComponent</p>");
    //}

    //[Fact]
    //public void GivenAComponentWithAParameter_WhenComponentIsRendered_ThenMarkupMatchesExpectedOutput()
    //{
    //    var message = "This is a message";

    //    var cut = RenderComponent<TestComponentWithParameter>(parameters => parameters.Add(p => p.Message, message));

    //    cut.MarkupMatches($"<p>Message: {message}</p>");
    //}

    //[Fact]
    //public void GivenAComponentWithEventHandler_WhenEventHandlerIsExecuted_ThenMarkupMatchesExpectedOutput()
    //{
    //    var cut = RenderComponent<TestComponentWithEventHandler>();

    //    cut.Find("button").Click(ctrlKey: true);

    //    cut.Find("p").MarkupMatches("<p>Control key pressed: True</p>");
    //}

    //[Fact]
    //public void GivenAComponentWithInjectedService_WhenComponentIsRendered_ThenServiceRetrievesExpectedData()
    //{
    //    Services.AddSingleton<IMyDataService, MyDataService>();

    //    var cut = RenderComponent<TestComponentWithInjection>();

    //    Assert.NotNull(cut.Instance.MyData);
    //}

    //[Fact]
    //public void GivenAComponentWithJSInterop_WhenButtonIsClicked_ThenJSFunctionExecutes()
    //{
    //    JSInterop.SetupVoid("alert", "Alert from Blazor component");

    //    var cut = RenderComponent<TestComponentWithJSInterop>();

    //    cut.Find("button").Click();

    //    JSInterop.VerifyInvoke("alert", calledTimes: 1);
    //}

    //[Fact]
    //public void GivenAComponentWithInjectedHttpClient_WhenComponentIsRendered_ThenHttpClientRetrievesExpectedData()
    //{
    //    var content = JsonSerializer.Serialize(new List<string> { "data" });

    //    var mockHttp = new MockHttpMessageHandler();
    //    var httpClient = mockHttp.ToHttpClient();
    //    httpClient.BaseAddress = new Uri("http://localhost");

    //    Services.AddSingleton(httpClient);

    //    mockHttp.When("/api/data")
    //            .Respond(HttpStatusCode.OK, "application/json", content);
    //    var cut = RenderComponent<TestComponentWithHttpClient>();

    //    cut.WaitForAssertion(() => Assert.NotNull(cut.Instance.DataFromApi));
    //}

    //[Fact]
    //public void GivenAComponentWithNavigationManager_WhenButtonIsClicked_ThenNavigationManagerNavigatesToExpectedUri()
    //{
    //    var navigationManager = Services.GetRequiredService<FakeNavigationManager>();
    //    var cut = RenderComponent<TestComponentWithNavigationManager>();

    //    cut.Find("button").Click();

    //    Assert.Equal($"{navigationManager.BaseUri}home", navigationManager.Uri);
    //}
}