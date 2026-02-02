using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services;

public class OrderService : IOrderService
{

    IOrderRepository repository;
    IMapper mapper;

    public OrderService(IOrderRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<OrderDTO> GetOrderById(int id)
    {
        Order order = await repository.GetOrderById(id);
        OrderDTO orderDTO = mapper.Map<Order,OrderDTO>(order);
        return orderDTO;
    }

    public async Task<OrderDTO> AddOrder(Order newOrder)
    {
        Order order = await repository.AddOrder(newOrder);
        OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(order);
        return orderDTO;
    }


}

