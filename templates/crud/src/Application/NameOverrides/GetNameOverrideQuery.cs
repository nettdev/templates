namespace ProjectNameOverride.Application.NameOverrides;

public sealed record GetNameOverrideRequest(Guid Id);

public sealed class GetNameOverrideQuery(INameOverrideRepository repository)
{
    private readonly INameOverrideRepository _repository = repository;

    public async Task<Result<GetNameOverrideResponse, Error>> Execute(GetNameOverrideRequest request, CancellationToken cancellation = default)
    {
        var NameFieldOverride = await _repository.Find(request, cancellation);

        if (NameFieldOverride is null)
            return new Error { Message = $"{NameOverride} with id {request.Id} not found." };
        
        return new GetNameOverrideResponse(NameFieldOverride.Id, NameFieldOverride.Name);
    }
}

public record GetNameOverrideResponse(Guid Id, string Name);
