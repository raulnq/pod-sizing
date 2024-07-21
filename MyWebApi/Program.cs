using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/pi", async ([FromQuery] double iterations) =>
{
    var value = CalculatePI(iterations);
    return value;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

double CalculatePI(double iterations)
{
	double numerator = 4;
	double denominator = 1;
	double pi = 0;
	int @operator = 1;
	for (var x=0; x < iterations; x++)
	{
		pi += @operator * (numerator / denominator);
		denominator += 2;
		@operator *= -1;
	}
	return pi;
}