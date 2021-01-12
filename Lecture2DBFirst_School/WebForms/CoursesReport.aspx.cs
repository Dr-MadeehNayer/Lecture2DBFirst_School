using Lecture2DBFirst_School.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lecture2DBFirst_School.WebForms
{
    public partial class CoursesReport : System.Web.UI.Page
    {
        private Lecture2SchoolEntities db = new Lecture2SchoolEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/reports/rptCourses.rdlc");

            ReportDataSource datasource = new ReportDataSource("Courses", db.Courses.ToList());
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            
           
        }
    }
}