using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrderDTO> GetOrderById(int id)
    {
        Order order = await _repository.GetOrderById(id);
        OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
        return orderDTO;
    }

    public async Task<OrderDTO> AddOrder(Order newOrder)
    {
        Order order = await repository.AddOrder(newOrder);
        OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(order);
        return orderDTO;
    }


}

