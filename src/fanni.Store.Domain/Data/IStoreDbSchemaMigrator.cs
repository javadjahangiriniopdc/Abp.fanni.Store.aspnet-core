using System.Threading.Tasks;

namespace fanni.Store.Data
{
    public interface IStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
