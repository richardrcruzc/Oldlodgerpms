
using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Core.Commands;
using LodgerPms.Domain.Interface.Interfaces;

namespace LodgerPms.DepartmentsDataLayer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DepartmentsContext _context;

        public UnitOfWork(DepartmentsContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
