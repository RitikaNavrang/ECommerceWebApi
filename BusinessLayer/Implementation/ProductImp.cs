using AutoMapper;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using BusinessLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Db;
using DataAccessLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class ProductImp : IProduct
    {
        private readonly EcDbContext _db;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;

        public ProductImp(EcDbContext db,IMapper mapper, BlobServiceClient blobServiceClient)
        {
            _db = db;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }


        #region Add-Product

        public async Task<Product> AddProductAsync(ProductDto obj,int userid)
        {
            try
            {
                var url = "";

                if (obj.fileupload.Length > 0)
                {
                    var container = new BlobContainerClient("DefaultEndpointsProtocol=https;AccountName=rdtecommerce121;AccountKey=B0b5OdXjAplPEKu6zimtq6uxPbwl2zYO+Kaw1S4xifpVSrf8fL25gTM08Fmcgppm7lS2jbfRyr7n+AStiN3fGQ==;EndpointSuffix=core.windows.net", "reetimages");
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

                    var blob = container.GetBlobClient(obj.fileupload.FileName);
                    //await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = obj.fileupload.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = obj.fileupload.ContentType });
                    }

                    url = blob.Uri.ToString();
                }
                

                var map = _mapper.Map<Product>(obj);
                
                map.CreatedAt= DateTime.Now;
                map.CreatedBy= userid;
                map.UserId= userid;
                map.ImgUrl= url;

                await _db.products.AddAsync(map);
                     _db.SaveChanges();
                return map;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Add-Product


        #region delete-product

        public async Task<string> RemoveProductAsync(int id)
        {
                var del= _db.products.FirstOrDefault(x => x.Id == id);
                 _db.products.Remove(del);
                await _db.SaveChangesAsync();
            return ("successful");
           
        }
        #endregion delete-product



        #region getall-product

        public async Task <IList<Product>> GetAllProductAsync()
        {
           
               var prolist = await _db.products.ToListAsync();
                return prolist;
            
        }
        #endregion getall-product


        #region update-product

        public async Task<Product> UpdateProductAsync(ProductDto obj,int userid)
        {
            try
            {
                //Product get = new Product
                //{
                //    Id = obj.Id,
                //    ProductName = obj.Name,
                //    Price = obj.Price,
                //    CategoryId = obj.CategoryId,
                //};

                var res = _mapper.Map<Product>(obj);
                
                //res.UserId= userid;
                res.ModifiedAt = DateTime.Now;
                res.ModifiedBy = userid;

                 _db.products.Update(res);
                await _db.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion update-product



        #region get-product-image

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
        #endregion get-product-image

    }
}
