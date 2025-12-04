using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Talky.Common.Data.Config;

namespace Talky.Common.Data;

public class DbContext
{
    private readonly IOptions<ConnectionStrings> connectionStrings;

    public DbContext(IOptions<ConnectionStrings> connectionStrings)
    {
        this.connectionStrings = connectionStrings;
    }
    
    public SqlConnection Connection => new(connectionStrings.Value.DBConnection);
}