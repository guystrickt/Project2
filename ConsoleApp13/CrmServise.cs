using ConsoleApp13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


public sealed class CrmService : IClientReader, IOrderReader, IClientWriter, IOrderWriter
{
    private readonly IClientRepository _clientRepository;
    private readonly IOrderRepository _orderRepository;

    public event Action<Client> ClientAdded;

    private static readonly Lazy<CrmService> lazy = new Lazy<CrmService>(() =>
    {
        var clientStorage = new JsonFileStorage<Client>("clients.json");
        var orderStorage = new JsonFileStorage<Order>("orders.json");

        var realClientRepo = new ClientRepository(clientStorage);
        var clientRepo = new ClientRepositoryProxy(realClientRepo);

        var orderRepo = new OrderRepository(orderStorage);
        return new CrmService(clientRepo, orderRepo);
    });

    public static CrmService Instance => lazy.Value;

    private CrmService(IClientRepository clientRepository, IOrderRepository orderRepository)
    {
        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
    }

    public void AddClient(Client client)
    {
        _clientRepository.Add(client);
        _clientRepository.SaveAsync().Wait();

        ClientAdded?.Invoke(client);
    }

    public IEnumerable<Client> GetAllClients() => _clientRepository.GetAll();

    public IEnumerable<Client> FindClients(IClientSearchStrategy searchStrategy)
    {
        return _clientRepository.GetAll().Where(client => searchStrategy.IsMatch(client));
    }

    public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAll();

    public void AddOrder(Order order)
    {
        _orderRepository.Add(order);
        _orderRepository.SaveAsync().Wait();
    }
}




