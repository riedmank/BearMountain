using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Interfaces
{
    public interface ICart
    {
        Task AddBasketItem(BasketItem item);

        Task RemoveBasketItem(int basketId, int productId);

        Task<List<BasketItem>> GetAllItemsForBasketID(int? id);
    }
}
