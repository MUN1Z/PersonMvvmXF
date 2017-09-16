using Refit;

namespace PersonMvvmXF.Services
{
    public class ServiceGenerator
    {
        public static IService GetService()
        {
            return RestService.For<IService>("http://uinames.com");
        }
    }
}
