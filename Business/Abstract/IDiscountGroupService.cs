using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDiscountGroupService
    {
        IDataResult<DiscountGroup> GetById(int id);
        IDataResult<DiscountGroup> GetByUserId(int id);
        IDataResult<List<DiscountGroup>> GetAll();

    }
}
