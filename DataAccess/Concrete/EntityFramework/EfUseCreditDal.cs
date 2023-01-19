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
    public class EfUseCreditDal : EfEntityRepositoryBase<UseCredit, KontorContext>, IUseCreditDal
    {
        public List<UseCredit> GetAllByInfoQuery(UseCreditDto useCredit)
        {
            using (KontorContext context = new KontorContext())
            {
                Expression<Func<UseCredit, bool>> query = q =>
                  (useCredit.Plate != null ? q.Plate.Contains(useCredit.Plate) : true)
               && (useCredit.SerialNo != null ? q.SerialNo.Contains(useCredit.SerialNo) : true)
               && (useCredit.AgentCode != null ? q.AgentCode.Contains(useCredit.AgentCode) : true);

                return context.Set<UseCredit>().Where(query).ToList();
            }
        }
    }
}
