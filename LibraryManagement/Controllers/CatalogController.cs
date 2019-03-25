using LibraryData;
using LibraryManagement.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController (ILibraryAsset assets)
        {
            _assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    ID = result.ID,
                    ImgUrl = result.ImgUrl,
                    AuthorOrDirector = _assets.GetAuthoreOrDirector(result.ID),
                    CallNumber = _assets.GetIndex(result.ID),
                    Titel = result.Titel,
                    Type = _assets.GetType(result.ID)
                });
            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}
