using be.Repositories;
using be.Repositories.impl;

namespace be.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services){
        services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        return services;
    }
}