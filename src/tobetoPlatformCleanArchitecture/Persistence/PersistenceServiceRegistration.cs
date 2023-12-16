using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformConnectionString")));        
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IApplicationEducationRepository, ApplicationEducationRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IProducerCompanyRepository, ProducerCompanyRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<ISectionAboutRepository, SectionAboutRepository>();
        services.AddScoped<ISectionCourseRepository, SectionCourseRepository>();
        services.AddScoped<ISectionInstructorRepository, SectionInstructorRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IUserSectionRepository, UserSectionRepository>();
        services.AddScoped<IUserSurveyRepository, UserSurveyRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        return services;
    }
}
