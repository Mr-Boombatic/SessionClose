using System;
using System.Web.Services;
using System.Xml.Serialization;

namespace Lab2_attempt_4_
{

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebService(Description = "Фин. отчеты")]
    public class FinReportService : WebService
    {
        [WebMethod(Description = "Получение списка ID отчетов по периоду")]
        public GetReportIdArrayResult GetReportIdArray(GetReportIdArrayArg arg)
        {
            return new GetReportIdArrayResult()
            {
                ReportIdArray = new int[] { 357, 358, 360, 361 }
            };
        }

        [WebMethod(Description = "Получение отчета по ID")]
        public GetReportResult GetReport(GetReportArg arg)
        {
            return new GetReportResult()
            {
                Report = new FinReport
                {
                    ReportID = arg.ReportID,
                    Date = new DateTime(2015, 03, 15),
                    Info = getReportInfo(arg.ReportID)
                }
            };
        }

        private string getReportInfo(int reportID)
        {
            return "ReportID = " + reportID;
        }
    }


    [Serializable]
    public class FinReport
    {
        public int ReportID { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }
    }

    public class GetReportIdArrayArg
    {
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }

    public class GetReportIdArrayResult
    {
        public int[] ReportIdArray { get; set; }
    }

    public class GetReportArg
    {
        public int ReportID { get; set; }
    }

    public class GetReportResult
    {
        public FinReport Report { get; set; }
    }
}