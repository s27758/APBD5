namespace Api;

public class Startup
{
    public static readonly List<Animal> animals = new List<Animal>();
    public static readonly List<Visit> visits = new List<Visit>();
    public static int nextAnimalId = 1;
    public static int nextVisitId = 1;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}