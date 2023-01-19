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
    public class BalanceManager : IBalanceService
    {
        private readonly IBalanceDal _balanceDal;
        private readonly IOrderDal _orderDal;
        private readonly IUserCreditDal _userCreditDal;

        public BalanceManager(IBalanceDal balanceDal,IUserCreditDal userCreditDal)
        {
            _balanceDal = balanceDal;
            _userCreditDal = userCreditDal;
        }
        public IResult Add(Balance balance)
        {
             _balanceDal.Add(balance);        
            return new SuccessResult();
        }

        public IDataResult<PagedModel<List<Balance>>> GetAllByInfoQuery(BalanceDto balanceDto)
        {
            int pageNumber = (int)(balanceDto?.Pagination?.PageNumber != null ? balanceDto.Pagination.PageNumber : 1);
            int pageSize = (int)(balanceDto?.Pagination?.PageSize != null ? balanceDto.Pagination.PageSize : 10);
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            int start = (int)((pageNumber - 1) * pageSize);

            var balances = _balanceDal.GetAllByInfoQuery(balanceDto).Skip(start).Take(pageSize).ToList();
            var totalRecords = _balanceDal.GetAllByInfoQuery(balanceDto).Count();

            if (totalRecords == 0)
            {
                return new SuccessDataResult<PagedModel<List<Balance>>>();
            }
            else if (balances.Count == 0)
            {
                return new ErrorDataResult<PagedModel<List<Balance>>>();
            }
            return new SuccessDataResult<PagedModel<List<Balance>>>(new PagedModel<List<Balance>>(balances, totalRecords, pageNumber, pageSize));
        }
    }
}
