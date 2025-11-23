namespace ProjectNameOverride.Application.NameOverrides;

public sealed record UpdateNameOverrideRequest(Guid Id, string Name);

public sealed class UpdateNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<GetNameOverrideListResponse>> Execute(UpdateNameOverrideRequest request, CancellationToken cancellation)
    {
        var NameFieldOverrideResult = NameOverride.Create(request.Name, id: Id);

        if (NameFieldOverrideResult.IsFailure)
            return result.Error;

        await _repository.Update(result.Value);

        var commitResult = await _unitOfWork(cancellation);
        
        if (commitResult.IsFailure)
            return commitResult.Error;
        
        return new NameOverrideResponse(result.Value.Id);
    }
}

public record UpdateNameOverrideResponse(Guid Id);
