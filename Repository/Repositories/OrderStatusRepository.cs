using BusinessObject.Models;
using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderStatusRepository : BaseRepository<OrderStatus>, IOrderStatusRepository
    {


        public OrderStatusRepository(BirdCageProductionContext context) : base(context)
        {
        }
    
    }
}
