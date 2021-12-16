using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrderManagementService
    {
        private BookShop2SystemDBContext ctx = new BookShop2SystemDBContext();

        public List<OrderDTO> Get(string query)
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())

                if (query == null)
                {
                    foreach (var item in unitOfWork.OrderRepository.Get())
                    {
                        orderDTOs.Add(new OrderDTO
                        {
                            Id = item.Id,
                            BookId = item.BookId,
                            Book = new BookDTO
                            {
                                Id = item.BookId,
                                Author = item.Book.Author,
                                Name = item.Book.Name,
                                Pages = item.Book.Pages,
                                Price = item.Book.Price,
                                Publisher = item.Book.Publisher,
                                Year = item.Book.Year
                            },
                            BuyerId = item.BuyerId,
                            Buyer = new BuyerDTO
                            {
                                Id = item.BuyerId,
                                Name = item.Buyer.Name,
                                Age = item.Buyer.Age,
                                Money = item.Buyer.Money,
                                PhoneNumber = item.Buyer.PhoneNumber,
                                Email = item.Buyer.Email,
                                Sex = item.Buyer.Sex
                            },
                            Address = item.Address,
                            DeliveryService = item.DeliveryService,
                            FinalPrice = item.FinalPrice,
                            TimeOfOrder = item.TimeOfOrder
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.OrderRepository.GetByQuery().Where(c => c.Buyer.Name.Contains(query)).ToList())
                    {
                        orderDTOs.Add(new OrderDTO
                        {
                            Id = item.Id,
                            BookId = item.BookId,
                            Book = new BookDTO
                            {
                                Id = item.BookId,
                                Author = item.Book.Author,
                                Name = item.Book.Name,
                                Pages = item.Book.Pages,
                                Price = item.Book.Price,
                                Publisher = item.Book.Publisher,
                                Year = item.Book.Year
                            },
                            BuyerId = item.BuyerId,
                            Buyer = new BuyerDTO
                            {
                                Id = item.BuyerId,
                                Name = item.Buyer.Name,
                                Age = item.Buyer.Age,
                                Money = item.Buyer.Money,
                                PhoneNumber = item.Buyer.PhoneNumber,
                                Email = item.Buyer.Email,
                                Sex = item.Buyer.Sex
                            },
                            Address = item.Address,
                            DeliveryService = item.DeliveryService,
                            FinalPrice = item.FinalPrice,
                            TimeOfOrder = item.TimeOfOrder
                        });
                    }

                }

            return orderDTOs;
        }

        public OrderDTO GetById(int id)
        {
            Order item = ctx.Orders.Find(id);

            OrderDTO orderDTO = new OrderDTO
            {
                Id = item.Id,
                BookId = item.BookId,
                Book = new BookDTO
                {
                    Id = item.BookId,
                    Author = item.Book.Author,
                    Name = item.Book.Name,
                    Pages = item.Book.Pages,
                    Price = item.Book.Price,
                    Publisher = item.Book.Publisher,
                    Year = item.Book.Year
                },
                BuyerId = item.BuyerId,
                Buyer = new BuyerDTO
                {
                    Id = item.BuyerId,
                    Name = item.Buyer.Name,
                    Age = item.Buyer.Age,
                    Money = item.Buyer.Money,
                    PhoneNumber = item.Buyer.PhoneNumber,
                    Email = item.Buyer.Email,
                    Sex = item.Buyer.Sex
                },
                Address = item.Address,
                DeliveryService = item.DeliveryService,
                FinalPrice = item.FinalPrice,
                TimeOfOrder = item.TimeOfOrder
            };
            return orderDTO;
        }

        public bool Save(OrderDTO orderDTO)
        {
            if (orderDTO.Book == null || orderDTO.BookId == 0)
            {
                return false;
            }

            else if (orderDTO.Buyer == null || orderDTO.BuyerId == 0)
            {
                return false;
            }

            Order Order = new Order
            {
                Id = orderDTO.Id,
                BookId = orderDTO.BookId,
                BuyerId = orderDTO.BuyerId,
                Address = orderDTO.Address,
                DeliveryService = orderDTO.DeliveryService,
                FinalPrice = orderDTO.FinalPrice,
                TimeOfOrder = orderDTO.TimeOfOrder
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (orderDTO.Id == 0)
                    {
                        unitOfWork.OrderRepository.Insert(Order);
                    }
                    else
                    {
                        unitOfWork.OrderRepository.Update(Order);
                    }

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Order Order = ctx.Orders.Find(id);
                ctx.Orders.Remove(Order);
                ctx.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
