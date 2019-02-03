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
                  .Include(u=>u.user)
                  .Where(i => i.user.UserId == id)
                  .ToList();
            

        }

        public IEnumerable<User> GetAllReportByUserName()
        {
            throw new NotImplementedException();
        }

        public async Task<Report[]> GetAllReports()
        {
            var result = _ctx.Reports
                .Include(u => u.user)
                .OrderBy(p => p.user);
            return await result.ToArrayAsync();
                
        }

        public async Task<Report> GetReportByReportId(int id)
        {
            var result=  _ctx.Reports
                .Include(u => u.user)
                .Where(R => R.ReportId == id);
            return await result.FirstOrDefaultAsync();
                
        }

        public void RemoveEntity<T>(T report)where T:class
        {
            _ctx.Remove(report);
            
                
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _ctx.SaveChangesAsync()) > 0;
        }
    }
}
