namespace ProjectNameOverride.Application.NameOverrides;

public sealed class GetNameOverrideListRequest : PagedRequest<NameOverride, GetNameOverrideListResponse>
{
    public string? Search { get; set; }

    public override IReadOnlyCollection<Expression<Func<NameOverride, bool>>> ToFilters()
    {
        var filters = new List<Expression<Func<NameOverride, bool>>>();
        if (!string.IsNullOrWhiteSpace(Search))
        {
            filters.Add(x => EF.Functions.ILike(x.Name, $"%{Search}%"));
        }
        return filters;
    }

    public override Expression<Func<NameOverride, GetNameOverrideListResponse>> ToProjection() =>
        x => new GetNameOverrideListResponse(x.Id, x.Name);
}

public sealed class GetNameOverrideListQuery(INameOverrideRepository repository)
{
    private readonly INameOverrideRepository _repository = repository;

    public async Task<PagedResponse<GetNameOverrideListResponse>> Execute(GetNameOverrideListRequest request, CancellationToken cancellation = default)
    {
        var response = await _repository.Query(request, cancellation);
        return response;
    }
}

public record GetNameOverrideListResponse(Guid Id, string Name);
