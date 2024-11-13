using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Interfaces.Repositories
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        public Task<Group> GetGroupDetails(Guid id);
    }
}
