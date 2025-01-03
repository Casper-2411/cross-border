using ScanInRecords.Models;

namespace ScanInRecords.Repository
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllAsync();
        Task Create(Record _Record);
    }
}
