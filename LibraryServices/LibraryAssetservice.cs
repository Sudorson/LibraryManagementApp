using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;

        public LibraryAssetService (LibraryContext context)
        {
             _context = context;
        }


        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.libraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);

        }

       

        public LibraryAsset GetById(int id)
        {
            return
                GetAll()
                .FirstOrDefault(asset => asset.ID == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetIndex(int id)
        {
            if (_context.books.Any(book => book.ID == id))
            {
                return _context.books.FirstOrDefault(book => book.ID == id).Index;
            }

            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_context.books.Any(book => book.ID == id))
            {
                return _context.books.FirstOrDefault(book => book.ID == id).ISBN;
            }

            else return "";
        }

        public string GetTitle(int id)
        {
               return _context.libraryAssets.FirstOrDefault(book => book.ID == id).Titel;
            
        }

        public string GetType(int id)
        {
            var book = _context.libraryAssets.OfType<Book>()
                .Where(b => b.ID == id);
            return book.Any() ? "Book" : "Vedio";
        }
        public string GetAuthoreOrDirector(int id)
        {
            var isBook = _context.libraryAssets.OfType<Book>()
                 .Where(asset => asset.ID == id).Any();
            var isMedia = _context.libraryAssets.OfType<Media>()
                 .Where(asset => asset.ID == id).Any();
            return isBook ?
                _context.books.FirstOrDefault(book => book.ID == id).Author :
                _context.medias.FirstOrDefault(media => media.ID == id).Director
                ?? "Unknown";
        }
    }
}
