using StoreApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Persister.Base;
public abstract class BusinessPersister<T> where T : BusinessModel<T>
{
    public abstract Task<T?> GetByIdAsync(int id);
    public abstract Task<IEnumerable<T>> GetAllAsync();
    protected abstract Task InsertAsync(T model);
    protected abstract Task UpdateAsync(T model);
    protected abstract Task DeleteAsync(T model);
    public virtual async Task Save(T model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model), "Model cannot be null");
        }
        if (model.IsDeleted)
        {
            if (model.Id > 0)
            {
                if (model.Validate(Mode.Delete))
                {
                    await DeleteAsync(model);
                }
            }
        }
        else
        {
            if (model.Id <= 0)
            {
                if (model.Validate(Mode.Insert))
                {
                    await InsertAsync(model);
                }
            }
            else
            {
                if (model.Validate(Mode.Update))
                {
                    await UpdateAsync(model);
                }
            }
        }
    }
}
