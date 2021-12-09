using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface IBusinessService<T> where T: EntityBase
    {
        Task<IEnumerable<T>> GetAllAsyc();

        Task<T> AddAsync(T product);

        Task<T> GetByIdAsync(Guid id);

        Task<T> UpdateSync(T model);

        Task DeleteAsync(Guid id);
    }
}
