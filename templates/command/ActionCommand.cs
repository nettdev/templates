namespace NettDev.Namespace;

#if (removeValidator)
public sealed class ActionCommand(I{Aggregate}Repository repository)
{
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(ActionRequest request)
    {
        return Guid.Empty;
    }
}
#else
public sealed class ActionCommand(IValidator<ActionRequest> validor, I{Aggregate}Repository repository)
{
    private readonly IValidator<ActionRequest> _validator = validor;
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(ActionRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult.MapToError();

        var aggregateParameter = request.MapTo{Aggregate}();

        return Guid.Empty;
    }
}
#endif