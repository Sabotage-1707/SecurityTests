
namespace SecurityTestsUI
{
    partial class ReportByManagersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.LoadButton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.securityTestsDataSet = new SecurityTestsUI.SecurityTestsDataSet();
            this.getAllEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getAllEmployeesTableAdapter = new SecurityTestsUI.SecurityTestsDataSetTableAdapters.GetAllEmployeesTableAdapter();
            this.getAllManagersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getAllManagersTableAdapter = new SecurityTestsUI.SecurityTestsDataSetTableAdapters.GetAllManagersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.securityTestsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllEmployeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllManagersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(287, 16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(451, 13);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 7;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportViewer1.DocumentMapWidth = 81;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getAllEmployeesBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.getAllManagersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SecurityTestsUI.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 42);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 408);
            this.reportViewer1.TabIndex = 8;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // securityTestsDataSet
            // 
            this.securityTestsDataSet.DataSetName = "SecurityTestsDataSet";
            this.securityTestsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getAllEmployeesBindingSource
            // 
            this.getAllEmployeesBindingSource.DataMember = "GetAllEmployees";
            this.getAllEmployeesBindingSource.DataSource = this.securityTestsDataSet;
            // 
            // getAllEmployeesTableAdapter
            // 
            this.getAllEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // getAllManagersBindingSource
            // 
            this.getAllManagersBindingSource.DataMember = "GetAllManagers";
            this.getAllManagersBindingSource.DataSource = this.securityTestsDataSet;
            // 
            // getAllManagersTableAdapter
            // 
            this.getAllManagersTableAdapter.ClearBeforeFill = true;
            // 
            // ReportByManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "ReportByManagerForm";
            this.Text = "ReportByManagerForm";
            this.Load += new System.EventHandler(this.ReportByManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.securityTestsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllEmployeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getAllManagersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button LoadButton;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getAllEmployeesBindingSource;
        private SecurityTestsDataSet securityTestsDataSet;
        private SecurityTestsDataSetTableAdapters.GetAllEmployeesTableAdapter getAllEmployeesTableAdapter;
        private System.Windows.Forms.BindingSource getAllManagersBindingSource;
        private SecurityTestsDataSetTableAdapters.GetAllManagersTableAdapter getAllManagersTableAdapter;
    }
}