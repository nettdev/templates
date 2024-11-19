namespace NettDev.Namespace;

#if (removeValidator)
public sealed class SomeOperationCommand(I{Aggregate}Repository repository)
{
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(SomeOperationRequest request)
    {
        return Guid.Empty;
    }
}
#else
public sealed class SomeOperationCommand(IValidator<SomeOperationRequest> validor, I{Aggregate}Repository repository)
{
    private readyonly IValidator<SomeOperationRequest> _validator = validor;
    private readonly I{Aggregate}Repository _repository = repository;

    public async Task<Result<Guid, Error>> Execute(SomeOperationRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if(!validationResult.Failure)
            return validationResult.Errors;

        return Guid.Empty;
    }
}
#endif