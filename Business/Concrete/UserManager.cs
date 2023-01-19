using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Business;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        private readonly IBalanceDal _balanceDal;
        private readonly IInvoiceDal _invoiceDal;

        public UserManager(IUserDal userDal,IBalanceDal balanceDal,IInvoiceDal invoiceDal)
        {
            _userDal = userDal;
            _invoiceDal = invoiceDal;
            _balanceDal = balanceDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public List<OperationClaim> GetUserEmail(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

       // [SecuredOperation("admin")]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
         
        }
        public User GetByOperationClaiim(UserOperationClaim userOperationClaim)
        {
            return null;
        }

        [SecuredOperation("user,admin")]
        public IResult Update(UserForUpdateDto userForUpdateDto)
        {
            User user = _userDal.Get(u => u.AgentCode == userForUpdateDto.AgentCode);
            {
                user.AgentCode = userForUpdateDto.AgentCode;
                user.FirstName = userForUpdateDto.FirstName;
                user.LastName = userForUpdateDto.LastName;
                user.Adress = userForUpdateDto.Adress;
                user.Email = userForUpdateDto.Email;
            }
            _userDal.Update(user);

            return new SuccessResult();
        }

        [SecuredOperation("user,admin")]
        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }

        [SecuredOperation("admin")]
        public IResult CreditUpdate(UserCreditAddDto userCreditAddDto,string userName)
        {
            Invoice invoice = _invoiceDal.Get(x => x.UserId == userCreditAddDto.UserId);
            if (invoice.PaymentStatus == true)
            {
                User user = _userDal.Get(u => u.Id == userCreditAddDto.UserId);
                user.Credits += userCreditAddDto.Credit;
                _userDal.Update(user);

                Balance balance = new Balance()
                {
                    PaymentTypeId = 2,
                    Count = userCreditAddDto.Credit,
                    DeclareUserName = userName,
                    ReceiveUserName = (userCreditAddDto.UserId).ToString(),
                    CreateDate = DateTime.Now,
                }
                ;
                _balanceDal.Add(balance);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }            
        }
        public IDataResult<User> GetByAgentCode(string agentCode)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.AgentCode == agentCode));
        }

        [SecuredOperation("admin")]
        public IResult UserDiscountUpdate(UserDiscountUpdateDto userDiscountUpdateDto)
        {
            User user = _userDal.Get(x => x.Id == userDiscountUpdateDto.Id);
            {              
                user.Discount = userDiscountUpdateDto.Discount;
            }
            _userDal.Update(user);
            return new SuccessResult();
        }


        [SecuredOperation("admin")]
        public IResult UserActivation(UserActivationDto user)
        {
            User users = _userDal.Get(x => x.Id == user.Id);
            users.AgentCode = user.AgentCode;
            users.Status = user.Status;
            _userDal.Update(users);
            return new SuccessResult();
        }
    }
}
