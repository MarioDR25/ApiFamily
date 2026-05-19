using ApiFamily;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

FamilyStructure familiaJackson = new("Jasckson");


app.MapGet("/", () => Results.Ok(familiaJackson.GetAllMembers()));


app.MapGet("/{id}", (int id) =>
{
    Member? member = familiaJackson.GetMember(id);
    return member is null ? Results.NotFound("Miembro no encontrado") : Results.Ok(member);
});


app.MapPost("/", (Member member) =>
{
    Member newMember = familiaJackson.AddMember(member);
    return Results.Created($"/", newMember);
});



app.MapDelete("/{id}", (int id) =>
{
    familiaJackson.DeleteMember(id);
    return Results.NoContent();
});



app.Run();
