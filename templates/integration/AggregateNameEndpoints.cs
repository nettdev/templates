namespace NettDev.Namespace;

[ExcludeFromCodeCoverage]
public sealed class AggregateNameEndpointTests(IntegrationAppFactory factory) : IClassFixture<IntegrationAppFactory>
{
    private readonly HttpClient _client = factory.CreateClient();
    private readonly Faker _faker = new("pt_BR");

    [Fact]
    public async Task Post_ValidRequest_ShouldReturnOk()
    {
        //Arrange
        var CommandNameVarCommand = new CommandNameCommand();
                
        //Act
        var response = await _client.PostAsJsonAsync("/api/{Aggregate}s", CommandNameVarCommand);
    
        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
