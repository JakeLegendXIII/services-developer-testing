using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using MiscApi.Controllers;

namespace MiscApi.IntegrationTests;

public class InfoResourceTests : IClassFixture<MiscApiBasicFixture>
{
    public readonly HttpClient _client;

    public InfoResourceTests(MiscApiBasicFixture fixture)
    {
        _client = fixture.CreateClient();
    }

    [Fact]
    public async Task GettingApiInfo()
    {
        var response = await _client.GetAsync("/server-info");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);

        var serviceInfo = await response.Content.ReadFromJsonAsync<ServerInfo>();

        Assert.NotNull(serviceInfo);

        var expectedDate = new DateTime(1969, 4, 20, 23, 59, 00);
        Assert.Equal(expectedDate, serviceInfo.LastChecked);
    }
}
