//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------
using FlowerShop.CRUD.Model;

namespace FlowerShop.CRUD.Service
{
    internal interface IClothesService
    {
        Clothes[] ReadAllClothes();
        Clothes GetClothes(int id);
        Clothes CreateClothes(Clothes clothes);
        Clothes ModifyClothes(int id, Clothes clothes);
        bool RemoveClothes(int id);
    }
}
