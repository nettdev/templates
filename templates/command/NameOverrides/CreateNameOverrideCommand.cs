namespace ProjectNameOverride.Application.NameOverrides;

public sealed record CreateNameOverrideRequest(string Name);

public sealed class CreateNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<GetNameOverrideListResponse>> Execute(CreateNameOverrideRequest request, CancellationToken cancellation)
    {
        var NameFieldOverrideResult = NameOverride.Create(request.Name);

        if (NameFieldOverrideResult.IsFailure)
            return result.Error;

        await _repository.Add(result.Value);

        var commitResult = await _unitOfWork(cancellation);
        
        if (commitResult.IsFailure)
            return commitResult.Error;
        
        return new CreateNameOverrideResponse(result.Value.Id);
    }
}

public record CreateNameOverrideResponse(Guid Id);
