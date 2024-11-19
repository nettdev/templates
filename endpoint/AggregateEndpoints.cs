namespace NettDev.Namespace;


public static class AggregateEndpoints
{
    public static void MapAggregateEndpoints(this this RouteGroupBuilder builder))
    {
        builder.MapGet("/", async (GetAggregateQuery query, Guid id) =>
            await query.Execute(request)) is {} data ? Ok(data) : NotFound("Aggregate not found");

        builder.MapGet("/", async (GetAggregateListQuery query, [AsParameters] GetAggregateListRequest request) =>
            Ok(await query.Execute(request)));

        builder.MapPost("/", async (CreateAggregateCommand command, CreateAggregateRequest request) =>
            (await command.Execute(request)).Match<Results<Ok<Guid>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)));

        builder.MapPut("/", async (ChangeAggregateCommand command, ChangeAggregateRequest request) =>
            (await command.Execute(request)).Match<Results<Ok<bool>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)));

        builder.MapDelete("/", async (DeleteAggregateCommand command, DeleteAggregateRequest request) =>
            (await command.Execute(request)).Match<Results<Ok<bool>, BadRequest<Error>>>((data) => Ok(data), (error) => BadRequest(error)));
    }
}
