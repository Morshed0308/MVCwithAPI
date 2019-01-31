using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCwithApiapp.Data.Entities;

namespace MVCwithApiapp.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly ApiContext _ctx;

        public ApiRepository(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public void  AddReport(object report)
        {
            _ctx.Add(report);
        }

        public IEnumerable<Report> GetAllReportByUserId(int id)
        {
            return _ctx.Reports
                  .Include(u=>u.user.UserId)
                  .Where(i => i.user.UserId == id)
                  .ToList();
            //throw new NotImplementedException();

        }

        public IEnumerable<User> GetAllReportByUserName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAllReports()
        {
            return _ctx.Reports
                .Include(u=>u.user)
                .OrderBy(p => p.user)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
