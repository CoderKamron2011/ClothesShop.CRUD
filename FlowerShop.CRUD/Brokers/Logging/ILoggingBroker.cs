//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace FlowerShop.CRUD.Brokers.Logging
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
    }
}
