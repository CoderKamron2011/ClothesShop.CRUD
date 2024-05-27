//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------
using FlowerShop.CRUD.Model;

namespace FlowerShop.CRUD.Brokers.Storage
{
    internal interface IStorageBroker
    {
        Clothes GetClothes(int id);
        Clothes[] GetAllClothes();
        Clothes AddClothes(Clothes clothes);
        Clothes Update(int id, Clothes clothes);
        bool Delete(int id);
    }
}
