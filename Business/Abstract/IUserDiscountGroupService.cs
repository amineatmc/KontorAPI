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
    public interface IUserDiscountGroupService 
    {
        IDataResult<UserDiscountGroup> GetByUserId(int id);
        //IDataResult<UserDiscountGroup> GetByAgentCode(string agentCode);
        IResult Add(UserDiscountGroup userDiscountGroup);
        IResult Update(UserDiscountGroup userDiscountGroup);
        IResult Delete(UserDiscountGroupDeleteDto userDiscountGroup);
        IDataResult<List<UserDiscountGroup>> GetAll();
      //  IResult Update(List<UserDiscountGroup> userDiscountGroup);

    }
}
