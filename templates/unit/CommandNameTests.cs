namespace {NettDev.Namespace};

[ExcludeFromCodeCoverage]
public sealed class CommandNameTests
{
    private readonly IAggregateNameRepository _AggregatNameVarRepository;
    private readonly Faker _faker = new("pt_BR");
    private readonly CommandNameCommand _command;

    [Fact]
    public async Task Execute_WithValidRequest_ShouldSaveOnDatabase()
    {
        //Arrange
        var request = new CreateAggregateNameRequest();

        //Act
        await _command.Execute(request);

        //Assert
        await _AggregateNameVarRepository.Received().Add(Arg.Is<{AggregateName}>(p => p.Id == request.Id!));
    }

    [Fact]
    public async Task Execute_WithInvalidRequest_ShouldReturnError()
    {
        //Arrange
        var request = new CreateAggregateNameRequest();

        //Act
        var result = await _command.Execute(request);

        //Assert
        result.IsFailure.Should().BeTrue();
        result.Error!.Errors.Select(x => x.{AggregateName}).Should().Contain("Name");
    }
}
