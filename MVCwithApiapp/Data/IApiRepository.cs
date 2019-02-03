using MVCwithApiapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Data
{
    public interface IApiRepository
    {
        Task<Report[]> GetAllReports();
        IEnumerable<User> GetAllReportByUserName();
        IEnumerable<Report> GetAllReportByUserId(int id);
        Task<Report> GetReportByReportId(int id);
        void AddReport(object report);
        Task<bool> SaveChangeAsync();

        void RemoveEntity<T>(T report) where T:class;

    }
}
