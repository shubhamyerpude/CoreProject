using Microsoft.Extensions.Configuration;

namespace CorePractice.Services
{
    public interface IGreeter
    {
        string GetResponseMessage();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetResponseMessage()
        {
            return _configuration["Greeting"];
        }
    }
}