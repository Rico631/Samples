using FlixOne.InventoryManagement.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests
{
    [TestClass()]
    public class InventoryContextTests
    {
        public ServiceProvider Services { get; private set; }

        [TestInitialize]
        public void Startup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton< IInventoryContext, InventoryContext>();
            Services = services.BuildServiceProvider();
        }

        [TestMethod()]
        public void MaintainBooks_Successful()
        {
            List<Task> tasks = new List<Task>();

            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(AddBook($"Book_{id}"));
            }

            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    tasks.Add(UpdateQuantity($"Book_{id}", quantity));
                }
            }

            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    tasks.Add(UpdateQuantity($"Book_{id}", -quantity));
                }
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var book in Services.GetRequiredService<IInventoryContext>().GetBooks())
            {
                Assert.AreEqual(0, book.Quantity);
            }
        }

        public Task AddBook(string book)
        {
            return Task.Run(() =>
            {
                Assert.IsTrue(Services.GetRequiredService<IInventoryContext>().AddBook(book));
            });
        }

        public Task UpdateQuantity(string book, int quantity)
        {
            return Task.Run(() =>
            {
                Assert.IsTrue(Services.GetRequiredService<IInventoryContext>().UpdateQuantity(book, quantity));
            });
        }
    }
}