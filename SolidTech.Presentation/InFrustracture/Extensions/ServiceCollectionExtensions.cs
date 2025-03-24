namespace SolidTech.Presentation.InFrustracture.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ISolutionService, SolutionService>();
            services.AddScoped<IProjectCategoryService, ProjectCategoryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICustomerCommentService, CustomerCommentService>();
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
