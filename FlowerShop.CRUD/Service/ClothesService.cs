//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------
using FlowerShop.CRUD.Brokers.Logging;
using FlowerShop.CRUD.Brokers.Storage;
using FlowerShop.CRUD.Model;

namespace FlowerShop.CRUD.Service
{
    internal class ClothesService : IClothesService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ClothesService()
        {
            this.storageBroker = new ArrayStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Clothes CreateClothes(Clothes clothes)
        {
            return clothes is null
                ? InvalidCreateClothes()
                : ValidationAndCreateClothes(clothes);
        }
        public Clothes GetClothes(int id)
        {
            return id is 0
                ? InvalidGetClothesById()
                : ValidationAndGetClothes(id);

        }

        public Clothes ModifyClothes(int id, Clothes clothes)
        {
            return clothes is null
                ? InvalidModifyClothes()
                : ValidationAndModifyClothes(id, clothes);
        }

        public Clothes[] ReadAllClothes()
        {
            var flowers = this.storageBroker.GetAllClothes();

            if (flowers.Length is 0)
            {
                this.loggingBroker.LogError("Not exist Information!");
                return flowers;
            }
            else
            {
                foreach (var clothesItem in flowers)
                {
                    if (clothesItem is not null)
                    {
                        this.loggingBroker.LogInformation(
                                $"Id: {clothesItem.Id}\n" +
                                $"Name: {clothesItem.Name}\n" +
                                $"Decription: {clothesItem.Decription}\n" +
                                $"Amount: {clothesItem.Amount}\n" +
                                $"Cost: {clothesItem.Cost}\n" +
                                $"Size: {clothesItem.Size}");
                    }
                }
            }
            return flowers;
        }

        public bool RemoveClothes(int id)
        {
            return id is 0
                    ? InvalidRemoveClothesById()
                    : ValidationAndRemoveClothes(id);
        }

        private Clothes ValidationAndCreateClothes(Clothes clothes)
        {
            if (clothes.Id is 0
                || String.IsNullOrWhiteSpace(clothes.Name)
                || clothes.Amount is 0
                || clothes.Cost is 0)
            {
                this.loggingBroker.LogError("The information you want to send is incomplete.");
                return new Clothes();
            }
            else
            {
                var flowerInfo = this.storageBroker.AddClothes(clothes);
                if (flowerInfo is null)
                {
                    this.loggingBroker.LogError("Not Added flower.");
                    return new Clothes();
                }
                else
                {
                    this.loggingBroker.LogInformation("Flower is added.");
                    return flowerInfo;
                }
            }
        }

        private Clothes InvalidCreateClothes()
        {
            this.loggingBroker.LogError("The information is not fully loaded.");
            return new Clothes();
        }

        private Clothes ValidationAndModifyClothes(int id, Clothes clothes)
        {
            if (id is 0
                || clothes.Id is 0
                || String.IsNullOrWhiteSpace(clothes.Name)
                || clothes.Amount is 0
                || clothes.Cost is 0
                || clothes.Size is 0)
            {
                this.loggingBroker.LogError("The data is invalid.");
                return new Clothes();
            }
            else
            {
                var flowers = this.storageBroker.Update(id, clothes);
                if (flowers is null)
                {
                    this.loggingBroker.LogError("Not Update!");
                    return new Clothes();
                }
                else
                {
                    this.loggingBroker.LogInformation("Clothes is updated!");
                    return flowers;
                }
            }
        }

        private Clothes InvalidModifyClothes()
        {
            this.loggingBroker.LogError("The information is not fully loaded.");
            return new Clothes();
        }

        private bool ValidationAndRemoveClothes(int id)
        {
            bool isDelete = this.storageBroker.Delete(id);

            if (isDelete is true)
            {
                this.loggingBroker.LogInformation("The information in the id has been deleted.");
                return true;
            }
            else
            {
                this.loggingBroker.LogError("Id is Not Found.");
                return false;
            }
        }

        private bool InvalidRemoveClothesById()
        {
            this.loggingBroker.LogError("Invlid id.");
            return false;
        }

        private Clothes ValidationAndGetClothes(int id)
        {
            Clothes isClothes = this.storageBroker.GetClothes(id);
            if (isClothes is not null)
            {
                this.loggingBroker.LogInformation("Success.");
                return isClothes;
            }
            else
            {
                this.loggingBroker.LogError("No data found for this id.");
                return new Clothes();
            }
        }

        private Clothes InvalidGetClothesById()
        {
            this.loggingBroker.LogError("Invlid id.");
            return new Clothes();
        }
    }
}
