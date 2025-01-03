using System.Data;

namespace ScanInRecords.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
