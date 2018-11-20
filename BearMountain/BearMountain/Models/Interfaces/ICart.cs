using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Interfaces
{
    public interface ICart
    {
        Task AddBasketItem(BasketItems item);

        Task RemoveBasketItem(int id);

        Task<List<Product>> GetAllItemsForBasketID(int? id);
    }
}
