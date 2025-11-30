namespace ProjectNameOverride.Application.NameOverrides;

public sealed record CreateNameOverrideRequest(string Name);

public sealed class CreateNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateNameOverrideResponse>> Execute(CreateNameOverrideRequest request, CancellationToken cancellation)
    {
        var NameFieldOverrideResult = NameOverride.Create(Guid.CreateVersion7(), request.Name, new(""), UserType.None);

        if (NameFieldOverrideResult.IsFailure)
            return NameFieldOverrideResult.Error!;

        await _repository.Add(NameFieldOverrideResult.Value);

        var commitSuccess = await _unitOfWork.Commit(cancellation);
        
        if (!commitSuccess)
            return new Error { Message = "Error saving changes", Code = "Database.Error" };
        
        return new CreateNameOverrideResponse(NameFieldOverrideResult.Value.Id);
    }
}

public record CreateNameOverrideResponse(Guid Id);
