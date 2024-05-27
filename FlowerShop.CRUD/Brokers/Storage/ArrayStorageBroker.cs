//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------
using FlowerShop.CRUD.Model;

namespace FlowerShop.CRUD.Brokers.Storage
{
    internal class ArrayStorageBroker : IStorageBroker
    {
        public Clothes[] Clothes {  get; set; } = new Clothes[10];
        public ArrayStorageBroker() 
        {
            Clothes[0] = new Clothes()
            {
                Id = 1,
                Name = "Jeans",
                Cost = 90000,
                Amount = 1,
                Size = 30,
                Decription = "Well"
            };
            Clothes[1] = new Clothes()
            {
                Id = 2,
                Name = "Sneakers",
                Cost = 2,
                Amount = 2,
                Size = 38,
                Decription = "in fashion sneakers"
            };
        }
        public Clothes AddClothes(Clothes clothes)
        {
            for (int itaration = 0; itaration < Clothes.Length; itaration++)
            {
                if (Clothes[itaration] is null)
                {
                    Clothes[itaration] = new Clothes()
                    {
                        Id = clothes.Id,
                        Name = clothes.Name,
                        Amount = clothes.Amount,
                        Cost = clothes.Cost,
                        Decription = clothes.Decription,
                        Size = clothes.Size
                    };
                    return clothes;
                }
            }

            return new Clothes();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Clothes[] GetAllClothes()
        {
            throw new NotImplementedException();
        }

        public Clothes GetClothes(int id)
        {
            throw new NotImplementedException();
        }

        public Clothes Update(int id, Clothes clothes)
        {
            throw new NotImplementedException();
        }
    }
}
