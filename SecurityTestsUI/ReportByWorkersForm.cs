using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityTestsUI
{
    public partial class ReportByManagersForm : Form
    {
        public ReportByManagersForm()
        {
            InitializeComponent();
        }

        private void ReportByManagerForm_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "securityTestsDataSet.GetAllEmployees". При необходимости она может быть перемещена или удалена.
            this.getAllManagersTableAdapter.Fill(this.securityTestsDataSet.GetAllManagers, dateTimePicker1.Value, dateTimePicker2.Value);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            getAllEmployeesBindingSource.DataSource = db.GetAllManagers(dateTimePicker1.Value, dateTimePicker2.Value);
            Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("fromDate", dateTimePicker1.Value.Date.ToShortDateString() ),
                new Microsoft.Reporting.WinForms.ReportParameter("toDate", dateTimePicker2.Value.Date.ToShortDateString() ),
            };
            reportViewer1.LocalReport.SetParameters(rParams);
            reportViewer1.RefreshReport();
        }
    }
}
