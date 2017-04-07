
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Interface.Interfaces;
 
namespace LodgerPms.Domain.Departments.Interfaces
{
    public interface IFolioPatternRepository : IRepository<FolioPattern>
    {
        FolioPattern GetByDescription(string description);

    }
}
