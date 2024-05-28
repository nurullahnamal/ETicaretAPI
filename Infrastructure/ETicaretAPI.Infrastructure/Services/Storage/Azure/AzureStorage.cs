﻿using System.Data.Common;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ETicaretAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Infrastructure.Services.Storage.Azure;

public class AzureStorage : Storage, IAzureStorage
{
    readonly BlobServiceClient _blobServiceClient;
    BlobContainerClient _blobContainerClient;

    public AzureStorage(IConfiguration configuration)
    {
        _blobServiceClient = new(configuration["Storage:Azure"]);
    }
    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string ContainerName, IFormFileCollection files)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
        List<(string fileName, string pathOrContainerName)> datas = new();
        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(ContainerName, file.Name, HasFile);

            BlobClient blobClient = _blobContainerClient.GetBlobClient(file.Name);
            await blobClient.UploadAsync(file.OpenReadStream());
            datas.Add((fileNewName, $" {ContainerName}/{fileNewName}"));
        }

        return datas;
    }

    public async Task DeleteAsync(string ContainerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteAsync();

    }

    public List<string> GetFiles(string ContainerName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
        return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
    }

    public bool HasFile(string ContainerName, string fileName)
    {

        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
        return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
    }
}