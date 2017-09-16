using Refit;
using System.Threading.Tasks;
using PersonMvvmXF.Entities;

namespace PersonMvvmXF.Services
{
    public interface IService
    {
        [Get("/api/?region=germany")]
        Task<Person> GetPerson();
    }
}
