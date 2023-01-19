using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountGroupManager : IDiscountGroupService
    {
        IDiscountGroupDal _discountGroupDal;
        public DiscountGroupManager(IDiscountGroupDal discountGroupDal)
        {
            _discountGroupDal = discountGroupDal;
        }

        public IDataResult<List<DiscountGroup>> GetAll()
        {
            return new SuccessDataResult<List<DiscountGroup>>(_discountGroupDal.GetAll());
        }

        public IDataResult<DiscountGroup> GetById(int id)
        {            
            return new SuccessDataResult<DiscountGroup>(_discountGroupDal.Get(x => x.Id == id));          
        }

        public IDataResult<DiscountGroup> GetByUserId(int id)
        {
            return new SuccessDataResult<DiscountGroup>(_discountGroupDal.Get(x=>x.Id == id));
        }
    }
}
