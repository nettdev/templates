namespace ProjectNameOverride.Application.NameOverrides;

public sealed record GetNameOverrideRequest(Guid Id);

public sealed class GetNameOverrideListQuery(INameOverrideRepository repository)
{
    private readonly INameOverrideRepository _repository = repository;

    public async Task<Result<GetNameOverrideListResponse>> Execute(GetNameOverrideRequest request, CancellationToken cancellation = default)
    {
        var NameFieldOverride = await repo.Find(request, cancellation);

        if (NameFieldOverride is null)
            return $"{NameOverride} with id {request.Id} not found.";
        
        return response;
    }
}

public record GetNameOverrideListResponse(string Name);
