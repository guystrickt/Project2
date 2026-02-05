using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp13
{
    public class Notifier
    {
        public void OnClientAdded(Client client)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Уведомление]: Добавлен новый клиент '{client.Name}' с мейлом: {client.Email}");
            Console.ResetColor();
        }
    }
}
