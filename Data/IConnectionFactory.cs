using System.Data;

namespace CRUD.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}