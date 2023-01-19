using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int id);
        IResult Update(UserForUpdateDto userForUpdateDto);
        IResult CreditUpdate(UserCreditAddDto userCreditAddDto,string userName);
        IDataResult<User> GetByAgentCode(string agentCode);
        IResult UserDiscountUpdate(UserDiscountUpdateDto userDiscountUpdateDto);
        IResult UserActivation(UserActivationDto user);

        // User GetByOperationClaiim(UserOperationClaim userOperationClaim);
        // IResult DeclareCredit(UserForCreditDto userForCreditDto);
    }
}
