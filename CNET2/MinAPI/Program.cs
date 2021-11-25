using Microsoft.EntityFrameworkCore;
using MinAPI.Data;
using MinAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// pridani databaze do asp.net core - definice datoveho napojeni na databazi / entity framework
builder.Services.AddDbContext<StatsDb>(opt => opt.UseSqlite("Data Source=stats.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// server_url/hello
app.MapGet("/hello", () => "Hello!");


// POST -> /stats
app.MapPost("/stats", (StatsDb db, StatsResult result) =>
{
    db.StatsResults.Add(result);
    db.SaveChanges();

    // vraci se objekt, ktery je po ulozeni doplnen o ID + Result.Created
    return Results.Created($"/stats/{result.Id}", result);

});


// GET -> /stats/5
app.MapGet("/stats/{id}", (StatsDb db, int id) =>
{
    var result = db.StatsResults.Where(x => x.Id == id).FirstOrDefault();
    if(result != null)
    {
        return Results.Ok(result);
    }
    else
    {
        return Results.NotFound(); 
    }
});

// GET -> /stats/all
app.MapGet("/stats/all", (StatsDb db) => GetAllResults(db));

app.Run();

static List<StatsResult> GetAllResults(StatsDb db)
{

    return db.StatsResults.ToList();
    
}