using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ConsoleUI
    {
        private readonly IEnumerable<IClientReader> _clientReaders;
        private readonly IClientWriter _clientWriter;
        private readonly IOrderReader _orderReader;
        private readonly IOrderWriter _orderWriter;

        public ConsoleUI(IEnumerable<IClientReader> clientReaders, IClientWriter clientWriter, IOrderReader orderReader, IOrderWriter orderWriter)
        {
            _clientReaders = clientReaders;
            _clientWriter = clientWriter;
            _orderReader = orderReader;
            _orderWriter = orderWriter;
        }

        public void Show(BaseReportGenerator report1, BaseReportGenerator report2)
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Добавить клиента");
                Console.WriteLine("2. Показать всех клиентов");
                Console.WriteLine("3. Добавить заказ");
                Console.WriteLine("4. Показать все заказы");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите опцию: ");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    AddClientInteractive();
                }
                else if (input == "2")
                {
                    ShowAllClients();
                }
                else if (input == "3")
                {
                    AddOrderInteractive();
                }
                else if (input == "4")
                {
                    ShowAllOrders();
                }
                else if (input == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверная опция. Попробуйте снова.");
                }
            }
        }

        private void AddClientInteractive()
        {
            Console.Write("Имя: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            var email = Console.ReadLine() ?? string.Empty;

            var client = new Client(0, name, email, DateTime.Now);
            _clientWriter.AddClient(client);

            Console.WriteLine($"Клиент добавлен с ID={client.Id}");
        }

        private void AddOrderInteractive()
        {
            // List clients for selection
            var clients = _clientReaders.SelectMany(r => r.GetAllClients()).OrderBy(c => c.Id).ToList();
            if (!clients.Any())
            {
                Console.WriteLine("Нет доступных клиентов. Сначала добавьте клиента.");
                return;
            }

            Console.WriteLine("Выберите клиента по ID (или введите 0 для отмены):");
            foreach (var c in clients)
            {
                Console.WriteLine(c);
            }

            if (!int.TryParse(Console.ReadLine(), out var clientId) || clientId == 0)
            {
                Console.WriteLine("Отменено.");
                return;
            }

            var clientExists = clients.Any(c => c.Id == clientId);
            if (!clientExists)
            {
                Console.WriteLine("Клиент с таким ID не найден.");
                return;
            }

            Console.Write("Описание заказа: ");
            var desc = Console.ReadLine() ?? string.Empty;
            Console.Write("Сумма: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Неверная сумма. Отменено.");
                return;
            }
            Console.Write("Дата исполнения (yyyy-MM-dd) или пусто: ");
            var dateStr = Console.ReadLine();
            DateOnly due = DateOnly.FromDateTime(DateTime.Now);
            if (!string.IsNullOrWhiteSpace(dateStr) && DateOnly.TryParse(dateStr, out var parsed))
            {
                due = parsed;
            }

            var order = new Order(0, clientId, desc, amount, due);
            _orderWriter.AddOrder(order);

            Console.WriteLine($"Заказ добавлен с ID={order.Id} для клиента {clientId}");
        }

        private void ShowAllOrders()
        {
            Console.WriteLine("\n--- Список всех заказов ---");
            var orders = _orderReader.GetAllOrders().OrderBy(o => o.Id);
            foreach (var o in orders)
            {
                Console.WriteLine(o);
            }
        }

        public void ShowAllClients()
        {
            Console.WriteLine("\n--- Список ВСЕХ клиентов из ВСЕХ источников ---");

            var allClients = _clientReaders.SelectMany(reader => reader.GetAllClients()).OrderBy(c => c.Id);

            foreach (var client in allClients)
            {
                Console.WriteLine(client);
            }
        }
    }
}

