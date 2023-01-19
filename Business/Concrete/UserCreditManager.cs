using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
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
    public class UserCreditManager : IUserCreditService
    {
        IUserCreditDal _userCreditDal;
        public UserCreditManager(IUserCreditDal userCreditDal)
        {
            _userCreditDal = userCreditDal;
        }

        //[SecuredOperation("user,admin")]
        //public IResult Add(UserCredit userCredit)
        //{
        //        _userCreditDal.Add(userCredit);
        //    return new SuccessResult(Messages.Success);
        }

        //public IResult Add(UserForCreditDto userForCreditDto)
        //{
        //    _userCreditDal.Add(userForCreditDto);
        //    return new SuccessResult(Messages.Success);
        //}
       
       // [SecuredOperation("user,admin")]
       // public IDataResult<List<UserCredit>> GetAll()
       // {
       //     return new SuccessDataResult<List<UserCredit>>(_userCreditDal.GetAll());
       // }

       //// [SecuredOperation("admin")]
       // public IDataResult<List<UserCredit>> GetById(int id)
       // {
       //     return new SuccessDataResult<List<UserCredit>>(_userCreditDal.GetAll(u => u.Id == id));
       // }

       // [SecuredOperation("user,admin")]
       // public IResult Update(UserCredit userCredit)
       // {
       //     UserCredit userforupdate = _userCreditDal.Get(u => u.Id == userCredit.UserId);
       //     userforupdate.Credits += userCredit.Credits;
            
       //     _userCreditDal.Update(userforupdate);
       //     return new SuccessResult();
       // }
}
