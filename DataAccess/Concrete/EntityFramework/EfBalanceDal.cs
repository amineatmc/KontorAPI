using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBalanceDal : EfEntityRepositoryBase<Balance, KontorContext>, IBalanceDal
    {
        public List<Balance> GetAllByInfoQuery(BalanceDto balanceDto)
        {
            using (KontorContext context = new KontorContext())
            {
                Expression<Func<Balance, bool>> query = q =>

                //(balanceDto.Count > 0 ? q.Count == balanceDto.Count : true)
                //(balanceDto.Id > 0 ? q.Id== balanceDto.Id : true)
                //&& (balanceDto.CreateDate > 0 ? q.CreateDate==balanceDto.CreateDate : true)
                (balanceDto.PaymentTypeId > 0 ? q.PaymentTypeId == balanceDto.PaymentTypeId : true)
               && (balanceDto.DeclareUserName != null ? q.DeclareUserName.Contains(balanceDto.DeclareUserName) : true)
               && (balanceDto.ReceiveUserName != null ? q.ReceiveUserName.Contains(balanceDto.ReceiveUserName) : true);

                return context.Set<Balance>().Where(query).ToList();
            }
        }
    }
}
