
using Alba;

namespace CoursesApi.IntegrationTests.CoursesResource.Fixtures;

public class CoursesResourceFicture : IAsyncLifetime
{
    public IAlbaHost AlbaHost = null;
    public async Task DisposeAsync()
    {
        await AlbaHost.DisposeAsync();
    }
    public async Task InitializeAsync()
    {
        AlbaHost = await Alba.AlbaHost.For<global::Program>(builder =>
        {

        });
    }
}