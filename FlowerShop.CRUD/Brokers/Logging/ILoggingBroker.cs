
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.CRUD.Brokers.Logging
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
    }
}
