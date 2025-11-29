namespace ProjectNameOverride.Application.NameOverrides;

public sealed record DeleteNameOverrideRequest(Guid Id);

public sealed class DeleteNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<DeleteNameOverrideResponse>> Execute(DeleteNameOverrideRequest request, CancellationToken cancellation)
    {
        await _repository.Delete(request.Id);

        var commitSuccess = await _unitOfWork.Commit(cancellation);
        
        if (!commitSuccess)
            return new Error { Message = "Error saving changes", Code = "Database.Error" };
        
        return new DeleteNameOverrideResponse($"NameOverride with id {request.Id} deleted");
    }
}

public record DeleteNameOverrideResponse(string Message);
