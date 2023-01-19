using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserDiscountGroupManager : IUserDiscountGroupService
    {
        IUserDiscountGroupDal _userDiscountGroupDal;
        public UserDiscountGroupManager(IUserDiscountGroupDal userDiscountGroupDal)
        {
            _userDiscountGroupDal = userDiscountGroupDal;
        }

        public IResult Add(UserDiscountGroup userDiscountGroup)
        {
            _userDiscountGroupDal.Add(userDiscountGroup);
            return new SuccessResult();
        }

        public IResult Delete(UserDiscountGroupDeleteDto userDiscountGroup)
        {
            UserDiscountGroup discountGroup = _userDiscountGroupDal.Get(x => x.UserId == userDiscountGroup.UserId);
            _userDiscountGroupDal.Delete(discountGroup);
            return new SuccessResult();
        }     

        public IDataResult<List<UserDiscountGroup>> GetAll()
        {
            return new SuccessDataResult<List<UserDiscountGroup>>(_userDiscountGroupDal.GetAll());
        }
       

        public IDataResult<UserDiscountGroup> GetByUserId(int id)
        {
            var result = _userDiscountGroupDal.Get(x => x.UserId == id);

            return new SuccessDataResult<UserDiscountGroup>(result);
           
        }

        public IResult Update(UserDiscountGroup userDiscountGroup)
        {
            UserDiscountGroup discountGroup = _userDiscountGroupDal.Get(x => x.UserId == userDiscountGroup.UserId);
            //discountGroup.UserId = userDiscountGroup.UserId;
            discountGroup.DiscountGroupId = userDiscountGroup.DiscountGroupId;
            _userDiscountGroupDal.Update(discountGroup);
            return new SuccessResult();
        }

        //public IResult Update(List<UserDiscountGroup> userDiscountGroup)
        //{
        //    int[] asd;

        //    for (int i = 0; i < userDiscountGroup.length; i++)
        //    {

        //    }
        //}

    }
}
