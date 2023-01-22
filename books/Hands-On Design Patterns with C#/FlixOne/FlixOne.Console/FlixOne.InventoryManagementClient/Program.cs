using FlixOne.InventoryManagement.Commands;
using FlixOne.InventoryManagement.Repository;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.InventoryManagementClient;

class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        IServiceProvider provider = services.BuildServiceProvider();

        var service = provider.GetRequiredService<ICatalogService>();
        service.Run();
        Console.WriteLine("CatalogService has completed.");
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IUserInterface, ConsoleUserInterface>();
        services.AddTransient<IInventoryCommandFactory, InventoryCommandFactory>();
        services.AddTransient<ICatalogService, CatalogService>();

        var context = new InventoryContext();
        services.AddSingleton<IInventoryContext, InventoryContext>(x => context);
        services.AddSingleton<IInventoryReadContext, InventoryContext>(x => context);
        services.AddSingleton<IInventoryWriteContext, InventoryContext>(x => context);
    }
}
