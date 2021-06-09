using SecurityTestsUI.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для ReportByEmployeesView.xaml
    /// </summary>
    public partial class ReportsView : Window
    {
        public ReportsView()
        {
            InitializeComponent();
        }
        public ReportsView(ReportByEmployees report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportsView(ReportByManagers report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }

        public ReportsView(ReportByWorkers report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportsView(ReportByEmployeesRu report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }
        public ReportsView(ReportByManagersRu report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }

        public ReportsView(ReportByWorkersRu report)
        {
            InitializeComponent();
            reportViewer.DocumentSource = report;
            report.CreateDocument();
        }
    }
}
