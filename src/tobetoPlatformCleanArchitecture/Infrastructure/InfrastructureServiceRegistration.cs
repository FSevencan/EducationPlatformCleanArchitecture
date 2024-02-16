using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Application.Services.ImageService;
using Infrastructure.Adapters.ImageService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ImageServiceBase, AmazonS3ImageServiceAdapter>();

        var awsOptions = configuration.GetAWSOptions();
        awsOptions.Credentials = new BasicAWSCredentials(
            configuration["AWS:AccessKey"],
            configuration["AWS:SecretKey"]
        );

        var s3Client = new AmazonS3Client(awsOptions.Credentials, RegionEndpoint.GetBySystemName(configuration["AWS:Region"]));
        services.AddSingleton<IAmazonS3>(s3Client);

        return services;
    }
}