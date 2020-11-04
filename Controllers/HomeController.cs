using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CookbookApp.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using CookbookApp.Model.CookbookApp.Model;

namespace CookbookApp.Controllers
{
    public class HomeController : Controller
    {
        static CloudBlobClient blobClient;
        const string blobContainerName = "recipepdfstorage";
        static CloudBlobContainer blobContainer;
        private readonly IConfiguration _configuration;

        private readonly ILogger<HomeController> _logger;
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public async Task<IActionResult> DisplaySelectedRecipe()
        {
            //try
            {

               var storageConnectionString = _configuration.GetConnectionString("StorageConnectionString");
                var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

                blobClient = storageAccount.CreateCloudBlobClient();
                blobContainer = blobClient.GetContainerReference(blobContainerName);
                await blobContainer.CreateIfNotExistsAsync();

                await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

                List<Uri> allBlobs = new List<Uri>();
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                    foreach (IListBlobItem blob in response.Results)
                    {
                        if (blob.GetType() == typeof(CloudBlockBlob))
                            allBlobs.Add(blob.Uri);
                    }
                    blobContinuationToken = response.ContinuationToken;
                } while (blobContinuationToken != null);
               

                return View(allBlobs);

            }

            //catch (Exception ex)
            //{
            //    ViewData["message"] = ex.Message;
            //    ViewData["trace"] = ex.StackTrace;
            //    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            //}

        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
