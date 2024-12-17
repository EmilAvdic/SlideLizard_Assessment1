using slidelizardAssigment.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.UsePathBase("/api");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

List<Presentation> presentations = new List<Presentation>();

app.MapGet("/presentation", () =>
{
    return presentations;
});

app.MapPost("/presentation", (Presentation presentation) =>
{
    if(presentations.Select(p => p.Name).Contains(presentation.Name))
    {
        throw new Exception("Presentation already exists");
    }
    presentations.Add(presentation);
    return presentations;
});

app.MapGet("/presentation/statistic", (string fromdate, string todate) =>
{
    DateOnly fromDate = DateOnly.Parse(fromdate);
    DateOnly toDate = DateOnly.Parse(todate);
    return presentations.Where(p => p.FromDate.CompareTo(fromDate) >= 0 && p.ToDate.CompareTo(toDate) <= 0).Count();
});

app.Run();
