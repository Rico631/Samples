using FlixOne.InventoryManagement.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlixOne.InventoryManagement.Repository
{
    public interface IInventoryReadContext
    {
        Book[] GetBooks();
    }
    
    public interface IInventoryWriteContext
    {
        bool AddBook(string name);
        bool UpdateQuantity(string name, int quantity);
    }

    public interface IInventoryContext : IInventoryReadContext, IInventoryWriteContext
    {
    }

    public class InventoryContext : IInventoryContext
    {
        //public static InventoryContext Singleton
        //{
        //    get
        //    {
        //        if (_context == null)
        //        {
        //            lock (_lock)
        //            {
        //                if (_context == null)
        //                    _context = new InventoryContext();
        //            }
        //        }
        //        return _context;
        //    }
        //}

        private static object _lock = new object();
        //private static InventoryContext _context;

        private readonly IDictionary<string, Book> _books;
        public InventoryContext()
        {
            _books = new ConcurrentDictionary<string, Book>();
        }



        public Book[] GetBooks()
        {
            return _books.Values.ToArray();
        }

        public bool AddBook(string name)
        {
            _books.Add(name, new Book { Name = name });
            return true;
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            lock (_lock)
            {
                _books[name].Quantity += quantity;
            }
            return true;
        }
    }
}
