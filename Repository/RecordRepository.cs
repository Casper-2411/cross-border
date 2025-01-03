using Dapper;
using ScanInRecords.Data;
using ScanInRecords.Models;
using System.Data;

namespace ScanInRecords.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly IDapperContext _context;
        public RecordRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Record>> GetAllAsync()
        {
            var query = "SELECT TOP 10 * FROM SBSAttendance ORDER BY ScanInTime DESC";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Record>(query);
                return result.ToList();
            }
        }
        public async Task Create(Record _Record)
        {
            var query = @"INSERT INTO SBSAttendance(CardId, ScanInTime) VALUES(@CardId,@ScanInTime)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CardId", _Record.CardId, DbType.String);
            parameters.Add("ScanInTime", _Record.ScanInTime, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
