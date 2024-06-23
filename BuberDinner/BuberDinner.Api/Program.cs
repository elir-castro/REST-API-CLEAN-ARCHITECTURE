using BuberDinner.Application;
using BuberDinner.Infraestructure;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfraestructure(builder.Configuration);

    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    //builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandleMiddleware>();
    app.UseExceptionHandler("/error");

    app.Map("/error", (HttpContext httpContext) =>
    {
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


