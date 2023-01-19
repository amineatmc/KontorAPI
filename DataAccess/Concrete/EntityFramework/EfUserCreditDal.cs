using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserCreditDal : EfEntityRepositoryBase<UserCredit, KontorContext>, IUserCreditDal
    {
        //public void Add(UserForCreditDto userForCreditDto)
        //{
        //    using (KontorContext context = new KontorContext())
        //    {
        //        var result = from o in context.UserCredits

        //                     select new UserForCreditDto
        //                     {
        //                         Id = userForCreditDto.Id,
        //                         Credit = userForCreditDto.Credit
        //                     };
        //       // return;
        //    }
        //}
    }
}
