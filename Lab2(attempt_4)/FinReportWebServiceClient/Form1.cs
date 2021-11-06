using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinReportWebServiceClient.ProxyClass;

namespace FinReportWebServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static FinReportService GetFinReportService()
        {
            var service = new FinReportService();
            service.Url = "http://localhost:44331/FinReportService.asmx";
            service.Timeout = 1000 * 10000;
            return service;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var service = GetFinReportService();
            var arg = new GetReportIdArrayArg();
            arg.DateBegin = new DateTime(2015, 03, 01);
            arg.DateEnd = new DateTime(2015, 03, 02);

            var result = service.GetReportIdArray(arg);
            MessageBox.Show("result.ReportIdArray.Length = " + result.ReportIdArray.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var service = GetFinReportService();
            var arg = new GetReportArg();
            arg.ReportID = 45;

            var result = service.GetReport(arg);
            MessageBox.Show(result.Report.Info);
        }
    }
}
