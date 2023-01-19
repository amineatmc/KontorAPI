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
    public class UseCreditManager : IUseCreditService
    {
        IUseCreditDal _useCreditDal;
        IUserService _userService;
        IUserDal _userDal;
        public UseCreditManager(IUseCreditDal useCreditDal, IUserService userService,IUserDal userDal)
        {
            _useCreditDal = useCreditDal;
            _userService = userService;
            _userDal = userDal;
        }
        public IResult Add(UseCredit useCredit)
        {
            //var user = _userService.GetByUserId();
            //useCredit.AgentCode.Remove(0, 3);
            var user = _userService.GetByAgentCode(useCredit.AgentCode);
           {
                user.Data.Credits -= 1;
           }
            _userDal.Update(user.Data);          


            _useCreditDal.Add(useCredit);
            return new SuccessResult();
        }

        public IDataResult<PagedModel<List<UseCredit>>> GetAllByInfoQuery(UseCreditDto useCredit)
        {
            int pageNumber = (int)(useCredit?.Pagination?.PageNumber != null ? useCredit.Pagination.PageNumber : 1);
            int pageSize = (int)(useCredit?.Pagination?.PageSize != null ? useCredit.Pagination.PageSize : 10);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            int start = (int)((pageNumber - 1) * pageSize);

            var credit = _useCreditDal.GetAllByInfoQuery(useCredit).Skip(start).Take(pageSize).ToList();
            var totalRecords = _useCreditDal.GetAllByInfoQuery(useCredit).Count();

            if (totalRecords == 0)
            {
                return new SuccessDataResult<PagedModel<List<UseCredit>>>();
            }
            else if (credit.Count == 0)
            {
                return new ErrorDataResult<PagedModel<List<UseCredit>>>();
            }
            return new SuccessDataResult<PagedModel<List<UseCredit>>>(new PagedModel<List<UseCredit>>(credit, totalRecords, pageNumber, pageSize));
        }
    }
}
