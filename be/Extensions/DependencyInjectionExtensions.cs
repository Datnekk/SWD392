using be.Repositories;
using be.Repositories.impl;

namespace be.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services){
        services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddScoped<IExaminationRepository, ExaminationRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IResultRepository, ResultRepository>();
        services.AddScoped<IWarningRepository, WarningRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        return services;
    }
}