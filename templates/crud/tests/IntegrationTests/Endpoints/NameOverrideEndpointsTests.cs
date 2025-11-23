using System.Net.Http.Json;
using Nett.BackOffice.Application.NameOverrides;

namespace Nett.BackOffice.IntegrationTests.Endpoints;

[ExcludeFromCodeCoverage]
public sealed class NameOverrideEndpointsTests(IntegrationAppFactory factory) : IClassFixture<IntegrationAppFactory>
{
    private readonly HttpClient _client = factory.CreateClient();
    
    [Fact]
    public async Task GetNameOverride_WithNameOverrideId_ShouldReturnNameOverride()
    {
        var request = CreateNameOverrideRequest();
        var createNameOverrideResponse = await _client.PostAsJsonAsync("/api/NameFieldOverrides", request, CancellationToken.None);
        var getNameFieldOverrideId = await createNameOverrideResponse.Content.ReadFromJsonAsync<Guid>(CancellationToken.None);
        var response = await _client.GetFromJsonAsync<>($"/api/NameFieldOverrides/{getNameFieldOverrideId}", CancellationToken.None);
        response.IsSuccessStatusCode.ShouldBeTrue();
    }

    [Fact]
    public async Task GetNameOverrideList_WithCreatedNameOverrides_ShouldReturnList()
    {
        var request = CreateNameOverrideRequest();
        await _client.PostAsJsonAsync("/api/NameFieldOverrides", request, CancellationToken.None);
        var response = await _client.GetFromJsonAsync<PaginatedTestResponse<GetNameOverrideListResponse>>("/api/NameFieldOverrides?page=1&limit=10", CancellationToken.None);
        response!.Items.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task Post_ValidRequest_ShouldReturnOk()
    {
        var request = CreateNameOverrideRequest();
        var response = await _client.PostAsJsonAsync("api/NameFieldOverrides", request, CancellationToken.None);
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task PutNameOverride_WithCreatedNameOverrides_ShouldReturnOk()
    {
        var createNameOverrideRequest = CreateNameOverrideRequest();
        await _client.PostAsJsonAsync("/api/NameFieldOverrides", createNameOverrideRequest, CancellationToken.None);
        
        var getNameOverridesResponse = await _client.GetFromJsonAsync<PaginatedTestResponse<GetNameOverrideListResponse>>("/api/NameFieldOverrides?page=1&limit=10", CancellationToken.None);
        var getNameOverrideResponse = NameOverridesResponse!.Items!.First();
        var response = await _client.PutAsJsonAsync("/api/NameFieldOverrides", request, CancellationToken.None);

        response.IsSuccessStatusCode.ShouldBeTrue();
    }

    [Fact]
    public async Task DeleteNameOverride_WithNameOverrideId_ShouldDeleteNameOverride()
    {
        var request = CreateNameOverrideRequest();
        var createNameOverrideResponse = await _client.PostAsJsonAsync("/api/NameFieldOverrides", request, CancellationToken.None);
        var getNameFieldOverrideId = await createNameOverrideResponse.Content.ReadFromJsonAsync<Guid>(CancellationToken.None);
        var response = await _client.DeleteAsync($"/api/NameFieldOverrides/{NameOverrideId}", CancellationToken.None);
        response.IsSuccessStatusCode.ShouldBeTrue();
    }

    private static CreateNameOverrideRequest CreateNameOverrideRequest()
    {
        return new CreateNameOverrideRequest
        {
            Name = Guid.NewGuid().ToString()
        };
    }

    private static UpdateNameOverrideRequest UpdateNameOverrideRequest(Guid id)
    {
        return new UpdateNameOverrideRequest
        {
            Id = id,
            Name = Guid.NewGuid().ToString()
        };
    }

    private class PaginatedTestResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
    }
}
