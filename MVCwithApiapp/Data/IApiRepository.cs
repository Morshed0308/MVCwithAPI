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
        IEnumerable<Report> GetAllReports();
        IEnumerable<User> GetAllReportByUserName();
        IEnumerable<Report> GetAllReportByUserId(int id);
        void AddReport(object report);
        bool SaveAll();

    }
}
