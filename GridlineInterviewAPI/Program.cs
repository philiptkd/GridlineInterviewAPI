using GridlineInterviewAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// puts ef core logs into file in DAL folder
var writer = new StreamWriter("../GridlineInterviewAPI.DAL/EFCoreLog.txt", append: true);

// Add services to the container.

// prevents the recursive serialization bug
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GridlineContext>(options =>
{
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var DbPath = System.IO.Path.Join(path, "local.db");

    options.UseSqlite($"Data Source={DbPath}");
    options.LogTo(writer.WriteLine);

    // performance boost by removing unnecessary feature in API
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
