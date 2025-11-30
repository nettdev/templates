namespace ProjectNameOverride.Application.NameOverrides;

public sealed record UpdateNameOverrideRequest(Guid Id, string Name);

public sealed class UpdateNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<UpdateNameOverrideResponse>> Execute(UpdateNameOverrideRequest request, CancellationToken cancellation)
    {
        var NameFieldOverrideResult = Create(request.Id, request.Name, new(""), UserType.None);

        if (NameFieldOverrideResult.IsFailure)
            return NameFieldOverrideResult.Error;

        await _repository.Update(NameFieldOverrideResult.Value);

        var commitSuccess = await _unitOfWork.Commit(cancellation);
        
        if (!commitSuccess)
            return new Error { Message = "Error saving changes", Code = "Database.Error" };
        
        return new UpdateNameOverrideResponse(NameFieldOverrideResult.Value.Id);
    }
}

public record UpdateNameOverrideResponse(Guid Id);
