using Microsoft.AspNetCore.Authorization;
using Nett.BackOffice.Application.NameOverrides;

namespace ProjectNameOverride.Infrastructure.Endpoints;

[ExcludeFromCodeCoverage]
public static class NameOverrideEndpoints
{
    public static void MapNameOverrideEndpoints(this RouteGroupBuilder builder)
    {
        builder.MapGet("/{id}", [Authorize] async (GetNameOverrideQuery query, Guid id, CancellationToken cancellation) =>
        {
            var result = await query.Execute(new GetNameOverrideRequest(id), cancellation);
            return result.Match<Results<Ok<GetNameOverrideResponse>, BadRequest<Error>>>((data) => Ok(data), (error) => NotFound(error));
        });

        builder.MapGet("/", [Authorize] async (GetNameOverrideListQuery query, [AsParameters] GetNameOverrideListRequest request, CancellationToken cancellation) =>
        {
            var response = await query.Execute(request, cancellation);
            return Ok(response);
        });

        builder.MapPost("/", [Authorize] async (CreateNameOverrideCommand command, CreateNameOverrideRequest request, CancellationToken cancellation) =>
        {
            var result = await command.Execute(request, cancellation);
            return result.Match<Results<Ok<CreateNameOverrideResponse>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)); 
        });

        builder.MapPut("/", [Authorize] async (UpdateNameOverrideCommand command, UpdateNameOverrideRequest request, CancellationToken cancellation) =>
        {
            var result = await command.Execute(request, cancellation);
            result.Match<Results<Ok<UpdateNameOverrideResponse>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)); 
        });

        builder.MapDelete("/{id:guid}", [Authorize] async (DeleteNameOverrideCommand command, Guid id, CancellationToken cancellation) =>
        {
            var result  = await command.Execute(new DeleteNameOverrideRequest{ Id = id }, cancellation);
            return result.Match<Results<Ok<DeleteNameOverrideResponse>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)); 
        });
    }
}
