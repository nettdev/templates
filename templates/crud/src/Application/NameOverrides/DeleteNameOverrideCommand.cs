namespace ProjectNameOverride.Application.NameOverrides;

public sealed record DeleteNameOverrideRequest(Guid Id);

public sealed class DeleteNameOverrideCommand(INameOverrideRepository repository, IUnitOfWork unitOfWork)
{
    private readonly INameOverrideRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<GetNameOverrideListResponse>> Execute(DeleteNameOverrideRequest request, CancellationToken cancellation)
    {
        await _repository.Delete(request.Id);

        var commitResult = await _unitOfWork(cancellation);
        
        if (commitResult.IsFailure)
            return commitResult.Error;
        
        return new NameOverrideResponse($"NameOverride with id {request.Id} deleted");
    }
}

public record DeleteNameOverrideResponse(string Message);
