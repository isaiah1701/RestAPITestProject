using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Xunit;
using Newtonsoft.Json;
using RestAPITestProject.Utilities;
using AventStack.ExtentReports;



namespace RestAPITestProject;

public class RestSharpTests : IDisposable
{
    private static ExtentHelper _extentHelper;

    public RestSharpTests()
    {
        if (_extentHelper == null)
        {
            _extentHelper = new ExtentHelper();
            _extentHelper.InitializeReport();
        }



           
    }

    [Fact]
    public void TestGetRequest()
    {
        var test1 = _extentHelper.CreateTest("Get Request Test");

        _extentHelper.LogInfo(test1, "Starting TestGetRequest");

        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("posts/1", Method.Get);
        _extentHelper.LogInfo(test1, "Getting information");

        var response = client.Execute(request);
        var content = response.Content;

        Assert.Equal(200, (int)response.StatusCode);
        Console.WriteLine($"Status Code: {(int)response.StatusCode}");
        Console.WriteLine($"Response Content: {content}");
        _extentHelper.LogInfo(test1, "Response Content: " + content);
        _extentHelper.LogPass(test1, "TestGetRequest Passed");
    }

    [Fact]
    public void TestPostRequest()
    {
        var test2 = _extentHelper.CreateTest("Post Request Test");

        _extentHelper.LogInfo(test2, "Starting TestPostRequest");
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("/posts", Method.Post);
        request.RequestFormat = DataFormat.Json;
        request.AddHeader("Content-Type", "application/json");

        _extentHelper.LogInfo(test2, "Added Headers");
        var body = new
        {
            title = "foo",
            body = "bar",
            userId = 1
        };
        request.AddJsonBody(body);
        var response = client.Execute(request);

        Assert.Equal(201, (int)response.StatusCode);
        var jsonResponse = JObject.Parse(response.Content);
        _extentHelper.LogInfo(test2, "Response Content: " + response.Content);
        Assert.Equal("foo", jsonResponse["title"]);
        _extentHelper.LogPass(test2, "TestPostRequest Passed");
        Console.WriteLine($"Status Code: {(int)response.StatusCode}");
        Console.WriteLine($"Response Content: {response.Content}");
    }


   

    public void Dispose()
    {
        _extentHelper.FlushReport();
    }
}
