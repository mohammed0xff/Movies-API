using ApiMongoDB.Services;
using Microsoft.OpenApi.Models;
using ApiMongoDB.Config;
using ApiMongoDB.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MongoDBConfig>(builder.Configuration);
builder.Services.AddTransient<IMoviesRepository, MovieRepository>();
builder.Services.AddSingleton<IDbClient, DbClient>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies.WebApi", Version = "v1" })
    );


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.WebApi v1"));
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
