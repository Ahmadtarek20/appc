using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_Start.Models;

namespace Rest_Start.Services
{
    interface IOrderRepository
    {
        void AddOrder(Order product);
        void DeleteOrder(int id);
    }
}
