using Microsoft.EntityFrameworkCore;
using EvacUa.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VehicleDb>(opt => opt.UseInMemoryDatabase("VehicleList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Vehicles", async (VehicleDb db) =>
    await db.Vehicles.ToListAsync());
app.MapGet("/Vehicles/complete", async (VehicleDb db) =>
    await db.Vehicles.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/Vehicles/{id}", async (int id, VehicleDb db) =>
    await db.Vehicles.FindAsync(id)
        is Vehicle vehicle
            ? Results.Ok(vehicle)
            : Results.NotFound());


app.MapPost("/Vehicles", async (Vehicle vehicle, VehicleDb db) =>
{
    db.Vehicles.Add(vehicle);
    vehicle.EmailSendF(vehicle);
    await db.SaveChangesAsync();

    return Results.Created($"/Vehicles/{vehicle.Id}", vehicle);
});
app.MapPut("/Vehicles/Getplace/{id}", async (int id,Pasanger pasanger, VehicleDb db) =>
{
    var vehicle = await db.Vehicles.FindAsync(id);
    if (vehicle is null) return Results.NotFound();
    if (vehicle.Places > 0)
    {
        vehicle.Places--;
        pasanger.EmailSendP(pasanger, vehicle);
        vehicle.EmailSendN(pasanger, vehicle);
        if (vehicle.Places == 0)
        {
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
        }
        Results.Ok(vehicle);
       
    }
    else
    {
        return Results.BadRequest();
    }
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/Vehicles/{id}", async (int id, Vehicle inputVehicle, VehicleDb db) =>
{
    var vehicle = await db.Vehicles.FindAsync(id);

    if (vehicle is null) return Results.NotFound();

    vehicle.OwnerName = inputVehicle.OwnerName;
    vehicle.IsComplete = inputVehicle.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Vehicles/{id}", async (long id, VehicleDb db) =>
{
    if (await db.Vehicles.FindAsync(id) is Vehicle vehicle)
    {
        db.Vehicles.Remove(vehicle);
        await db.SaveChangesAsync();
        return Results.Ok(vehicle);
    }

    return Results.NotFound();
});
app.UseDefaultFiles();
app.UseStaticFiles();



app.Run();
