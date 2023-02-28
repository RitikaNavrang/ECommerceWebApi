using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BusinessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation;

public class FileManagerLogic : IFileManagerLogic
{
    private readonly BlobServiceClient _blobServiceClient;
    public FileManagerLogic(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> Upload(FileModel model)
    {
        //var blobContainer = _blobServiceClient.GetBlobContainerClient("uploadfiles");

        //var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

        //await blobClient.UploadAsync(model.ImageFile.OpenReadStream());

        var url = "";

        if (model.ImageFile.Length > 0)
        {
            var container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=rdtecommerce121;AccountKey=B0b5OdXjAplPEKu6zimtq6uxPbwl2zYO+Kaw1S4xifpVSrf8fL25gTM08Fmcgppm7lS2jbfRyr7n+AStiN3fGQ==;EndpointSuffix=core.windows.net", "reetimages");
            var createResponse = await container.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var blob = container.GetBlobClient(model.ImageFile.FileName);
            //await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            using (var fileStream = model.ImageFile.OpenReadStream())
            {
                await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = model.ImageFile.ContentType });
            }

            url = blob.Uri.ToString();
        }
        return url;
        //        return BadRequest();
        //    }
        //            catch (Exception ex)
        //            {
        //                return StatusCode(500, $"Internal server error: {ex}");
        //}

    }


    public async Task<byte[]> Get(string imageName)
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient("reetimages");

        var blobClient = blobContainer.GetBlobClient(imageName);

        var downloadContent = await blobClient.DownloadAsync();

        using (MemoryStream ms = new MemoryStream())
        {
            await downloadContent.Value.Content.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
