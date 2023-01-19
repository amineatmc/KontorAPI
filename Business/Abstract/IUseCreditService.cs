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
    public interface IUseCreditService 
    {
        IResult Add(UseCredit useCredit);
        IDataResult<PagedModel<List<UseCredit>>> GetAllByInfoQuery(UseCreditDto useCredit);


    }
}
