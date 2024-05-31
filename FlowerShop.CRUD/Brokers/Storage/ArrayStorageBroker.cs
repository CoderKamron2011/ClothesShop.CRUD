//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------
using FlowerShop.CRUD.Model;

namespace FlowerShop.CRUD.Brokers.Storage
{
    internal class ArrayStorageBroker : IStorageBroker
    {
        public Clothes[] ClothesInfo {  get; set; } = new Clothes[10];
        public ArrayStorageBroker() 
        {
            ClothesInfo[0] = new Clothes()
            {
                Id = 1,
                Name = "Jeans",
                Cost = 90000,
                Amount = 1,
                Size = 30,
                Decription = "Well"
            };
            ClothesInfo[1] = new Clothes()
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
            for (int itaration = 0; itaration < ClothesInfo.Length; itaration++)
            {
                if (ClothesInfo[itaration] is null)
                {
                    ClothesInfo[itaration] = new Clothes()
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
            for (int itaration = 0; itaration < ClothesInfo.Length; itaration++)
            {
                if (ClothesInfo[itaration] is not null)
                {
                    if (ClothesInfo[itaration].Id == id)
                    {
                        ClothesInfo[itaration] = new Clothes();
                        return true;
                    }
                }
            }

            return false;
        }

        public Clothes[] GetAllClothes() => this.ClothesInfo;

        public Clothes GetClothes(int id)
        {
            for (int itaration = 0; itaration < ClothesInfo.Length; itaration++)
            {
                if (ClothesInfo[itaration] is not null)
                {
                    if (ClothesInfo[itaration].Id == id)
                    {
                        return ClothesInfo[itaration];
                    }
                }
            }

            return new Clothes();
        }

        public Clothes Update(int id, Clothes clothes)
        {
            for (int itaration = 0; itaration < ClothesInfo.Length; itaration++)
            {
                if (ClothesInfo[itaration] is not null)
                {
                    if (ClothesInfo[itaration].Id == id)
                    {
                        ClothesInfo[itaration] = new Clothes()
                        {
                            Name = clothes.Name,
                            Amount = clothes.Amount,
                            Cost = clothes.Cost,
                            Decription = clothes.Decription,
                            Size = clothes.Size,
                            Id = id,
                        };
                        return clothes;
                    }
                }
            }

            return new Clothes();
        }
    }
}
