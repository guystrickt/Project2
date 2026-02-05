using ConsoleApp13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


public sealed class CrmServise
{
    private readonly IClientRepository _clientRepository;
    private readonly IOrderRepository _orderRepository;

    public event Action<Client> ClientAdded;

    private static readonly Lazy<CrmServise> lazy = new Lazy<CrmServise>(() =>
    {       
        var clientStorage = new JsonFileStorage<Client>("clients.json");
        var orderStorage = new JsonFileStorage<Order>("orders.json");

        var realClientRepo = new ClientRepository(clientStorage);
        var clientRepo =  new ClientRepositoryProxy(realClientRepo);

        var orderRepo = new OrderRepository(orderStorage);
        return new CrmServise(clientRepo, orderRepo);
    });
    public static CrmServise Instance => lazy.Value;
    private CrmServise(IClientRepository clientRepository, IOrderRepository orderRepository)
    {

        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
    }
    public Client AddClient(Client client)
    {
        _clientRepository.Add(client);
        _clientRepository.SaveAsync();

        ClientAdded?.Invoke(client);

        return client;
    }


    public IEnumerable<Client> GetClients() => _clientRepository.GetAll();
    public IEnumerable<Client> FindClients(IClientSerchStrategy serchStrategy)
    {
        return _clientRepository.GetAll().Where(client => serchStrategy.IsMatch(client));
    }
}




    
