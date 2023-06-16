using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class WriteToDBService : IWriteToDBService
    {
        private readonly WebApiContext _context;
        public void WriteOccurrencesData(OccurrencesData data)
        {
            _context.OccurrencesData.AddAsync(data);
            _context.SaveChanges();
        }

        public WriteToDBService(WebApiContext context) 
        {
            _context = context;
        }
    }
}
