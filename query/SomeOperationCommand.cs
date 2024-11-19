namespace NettDev.Namespace;

#if (removeValidator)
public sealed class SomeOperarionCommand(I{Aggregate}Repository repository)
{
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(SomeOperarionRequest request)
    {
        return Guid.Empty;
    }
}
#else
public sealed class SomeOperarionCommand(IValidator<SomeOperarionRequest> validor, I{Aggregate}Repository repository)
{
    private readyonly IValidator<SomeOperarionRequest> _validator = validor;
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(SomeOperarionRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if(!validationResult.Failure)
            return validationResult.Errors;

        return Guid.Empty;
    }
}
#endif