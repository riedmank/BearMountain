using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models.Interfaces
{
    public interface ICart
    {
        Task AddBasketItem(BasketItem basketItem);

        BasketItem GetBasketItem(int id);

        Task UpdateBasketItem(BasketItem basketItem);

        Task RemoveBasketItem(BasketItem basketItem);

        Task<IEnumerable<BasketItem>> GetAllItemsForBasketID(int? id);
    }
}
