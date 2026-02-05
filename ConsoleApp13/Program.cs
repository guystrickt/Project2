using ConsoleApp13;
using Newtonsoft.Json;
public class Program
{
    public static async Task Main(string[] args)
    {
        var crmService = CrmServise.Instance;
        var notifier = new Notifier();
        var ui = new ConsoleUI(crmService);

        crmService.ClientAdded += notifier.OnClientAdded;

        ui.Show();
    }
}

public record Client(int Id, string Name, string Email, DateTime CreatedAt);
public record Order(int Id, int ClientId, string Description, decimal Amount, DateOnly Deudate);











































