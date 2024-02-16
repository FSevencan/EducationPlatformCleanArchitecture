using Amazon.S3.Model;
using Amazon.S3;
using Application.Services.ImageService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Infrastructure.Adapters.ImageService;
public class AmazonS3ImageServiceAdapter : ImageServiceBase
{
    private readonly IAmazonS3 _amazonS3;
    private readonly string _bucketName;
    private readonly string _region;

    public AmazonS3ImageServiceAdapter(IConfiguration configuration, IAmazonS3 amazonS3)
    {
        _amazonS3 = amazonS3;
        _bucketName = configuration["AWS:BucketName"];
        _region = configuration["AWS:Region"];
    }

    public override async Task<string> UploadAsync(IFormFile formFile)
    {
        await FileMustBeInImageFormat(formFile);

        var uploadRequest = new PutObjectRequest
        {
            InputStream = formFile.OpenReadStream(),
            BucketName = _bucketName,
            Key = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName),
            ContentType = formFile.ContentType,
        };

        var response = await _amazonS3.PutObjectAsync(uploadRequest);

        return $"https://{_bucketName}.s3.{_region}.amazonaws.com/{uploadRequest.Key}";

    }

    public override async Task DeleteAsync(string imageUrl)
    {
        var key = imageUrl.Split('/').Last();
        var deleteRequest = new DeleteObjectRequest
        {
            BucketName = _bucketName,
            Key = key
        };

        await _amazonS3.DeleteObjectAsync(deleteRequest);
    }
}

