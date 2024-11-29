using WebApplicationDemo.Services.Persons;

namespace WebApplicationDemo.Helpers
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            var baseAddress = "http://localhost:5100/api/";
            services.AddHttpContextAccessor();
            services.AddHttpClient<IPersonService, PersonService>(client => client.BaseAddress = new Uri(baseAddress));
            return services;
        }
    }
}
