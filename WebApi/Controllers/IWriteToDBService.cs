using WebApi.Models;

namespace WebApi.Controllers
{
    public interface IWriteToDBService
    {
        public void WriteOccurrencesData(OccurrencesData data);
    }
}
