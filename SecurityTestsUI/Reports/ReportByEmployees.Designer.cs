
namespace SecurityTestsUI
{
    partial class ReportByEmployees
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportByEmployees));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.checkBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.tableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.checkBox2 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.tableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.fromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.toDate = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo1,
            this.pageInfo2});
            this.BottomMargin.Name = "BottomMargin";
            // 
            // pageInfo1
            // 
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo1.StyleName = "PageInfo";
            // 
            // pageInfo2
            // 
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.StyleName = "PageInfo";
            this.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label1});
            this.ReportHeader.Name = "ReportHeader";
            // 
            // label1
            // 
            this.label1.Name = "label1";
            this.label1.StyleName = "Title";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table1
            // 
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2,
            this.tableCell3,
            this.tableCell4,
            this.tableCell5,
            this.tableCell6,
            this.tableCell7,
            this.tableCell8,
            this.tableCell9,
            this.tableCell10});
            this.tableRow1.Name = "tableRow1";
            // 
            // tableCell1
            // 
            this.tableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StyleName = "DetailCaption1";
            this.tableCell1.StylePriority.UseBorders = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // tableCell2
            // 
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "DetailCaption1";
            // 
            // tableCell3
            // 
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StyleName = "DetailCaption1";
            // 
            // tableCell4
            // 
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StyleName = "DetailCaption1";
            // 
            // tableCell5
            // 
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.StyleName = "DetailCaption1";
            // 
            // tableCell6
            // 
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.StyleName = "DetailCaption1";
            this.tableCell6.StylePriority.UseTextAlignment = false;
            this.tableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // tableCell7
            // 
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.StyleName = "DetailCaption1";
            this.tableCell7.StylePriority.UseTextAlignment = false;
            this.tableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tableCell8
            // 
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.StyleName = "DetailCaption1";
            this.tableCell8.StylePriority.UseTextAlignment = false;
            this.tableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tableCell9
            // 
            this.tableCell9.Name = "tableCell9";
            this.tableCell9.StyleName = "DetailCaption1";
            // 
            // tableCell10
            // 
            this.tableCell10.Name = "tableCell10";
            this.tableCell10.StyleName = "DetailCaption1";
            // 
            // Detail
            // 
            this.Detail.BackColor = System.Drawing.Color.Aquamarine;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.Detail.Name = "Detail";
            this.Detail.StylePriority.UseBackColor = false;
            // 
            // table2
            // 
            this.table2.Name = "table2";
            this.table2.OddStyleName = "DetailData3_Odd";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell11,
            this.tableCell12,
            this.tableCell13,
            this.tableCell14,
            this.tableCell15,
            this.tableCell16,
            this.tableCell17,
            this.tableCell18,
            this.tableCell19,
            this.tableCell20});
            this.tableRow2.Name = "tableRow2";
            // 
            // tableCell11
            // 
            this.tableCell11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Id]")});
            this.tableCell11.Name = "tableCell11";
            this.tableCell11.StyleName = "DetailData1";
            this.tableCell11.StylePriority.UseBorders = false;
            this.tableCell11.StylePriority.UseTextAlignment = false;
            this.tableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // tableCell12
            // 
            this.tableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UserName]")});
            this.tableCell12.Name = "tableCell12";
            this.tableCell12.StyleName = "DetailData1";
            // 
            // tableCell13
            // 
            this.tableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[RoleName]")});
            this.tableCell13.Name = "tableCell13";
            this.tableCell13.StyleName = "DetailData1";
            // 
            // tableCell14
            // 
            this.tableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name]")});
            this.tableCell14.Name = "tableCell14";
            this.tableCell14.StyleName = "DetailData1";
            // 
            // tableCell15
            // 
            this.tableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Birthday]")});
            this.tableCell15.Multiline = true;
            this.tableCell15.Name = "tableCell15";
            this.tableCell15.StyleName = "DetailData1";
            // 
            // tableCell16
            // 
            this.tableCell16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CounterOfUsedTries]")});
            this.tableCell16.Name = "tableCell16";
            this.tableCell16.StyleName = "DetailData1";
            this.tableCell16.StylePriority.UseTextAlignment = false;
            this.tableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // tableCell17
            // 
            this.tableCell17.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.checkBox1});
            this.tableCell17.Name = "tableCell17";
            this.tableCell17.StyleName = "DetailData1";
            this.tableCell17.StylePriority.UseTextAlignment = false;
            this.tableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.checkBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.checkBox1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckBoxState", "[VereficationStatusByFireSafety]")});
            this.checkBox1.GlyphOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkBox1.Name = "checkBox1";
            // 
            // tableCell18
            // 
            this.tableCell18.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.checkBox2});
            this.tableCell18.Name = "tableCell18";
            this.tableCell18.StyleName = "DetailData1";
            this.tableCell18.StylePriority.UseTextAlignment = false;
            this.tableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // checkBox2
            // 
            this.checkBox2.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.checkBox2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.checkBox2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckBoxState", "[VereficationStatusByIndustrialSafety]")});
            this.checkBox2.GlyphOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkBox2.Name = "checkBox2";
            // 
            // tableCell19
            // 
            this.tableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateTimeOfLastTryByFireSafety]")});
            this.tableCell19.Name = "tableCell19";
            this.tableCell19.StyleName = "DetailData1";
            // 
            // tableCell20
            // 
            this.tableCell20.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateTimeOfLastTryByIndustrialSafety]")});
            this.tableCell20.Name = "tableCell20";
            this.tableCell20.StyleName = "DetailData1";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "SecurityTestsDB";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "GetAllEmployees";
            queryParameter1.Name = "@FromDate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?fromDate", typeof(System.DateTime));
            queryParameter2.Name = "@ToDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?toDate", typeof(System.DateTime));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.StoredProcName = "GetAllEmployees";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // DetailCaption1
            // 
            this.DetailCaption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(148)))), ((int)(((byte)(130)))));
            this.DetailCaption1.BorderColor = System.Drawing.Color.White;
            this.DetailCaption1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption1.BorderWidth = 2F;
            this.DetailCaption1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption1.ForeColor = System.Drawing.Color.White;
            this.DetailCaption1.Name = "DetailCaption1";
            this.DetailCaption1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailCaption1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1
            // 
            this.DetailData1.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData1.BorderWidth = 2F;
            this.DetailData1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1.ForeColor = System.Drawing.Color.Black;
            this.DetailData1.Name = "DetailData1";
            this.DetailData1.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // fromDate
            // 
            this.fromDate.Name = "fromDate";
            this.fromDate.Type = typeof(System.DateTime);
            this.fromDate.ValueInfo = "2021-04-15";
            // 
            // toDate
            // 
            this.toDate.Name = "toDate";
            this.toDate.Type = typeof(System.DateTime);
            this.toDate.ValueInfo = "2021-05-05";
            // 
            // ReportByEmployees
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "GetAllEmployees";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.LocalizationItems.AddRange(new DevExpress.XtraReports.Localization.LocalizationItem[] {
            new DevExpress.XtraReports.Localization.LocalizationItem(this.checkBox1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(2.083333F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.checkBox1, "Default", "SizeF", new System.Drawing.SizeF(324.51F, 25F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.checkBox2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(2.083333F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.checkBox2, "Default", "SizeF", new System.Drawing.SizeF(375.0403F, 25F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.Detail, "Default", "HeightF", 25F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.GroupHeader1, "Default", "HeightF", 28F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.label1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.label1, "Default", "SizeF", new System.Drawing.SizeF(2139F, 24.19433F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.label1, "Default", "Text", "Report By Employees"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.label1, "ru-RU", "Text", "Отчет по сотрудникам"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo1, "Default", "SizeF", new System.Drawing.SizeF(1069.5F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo1, "Default", "TextFormatString", "{0:dd.MM.yyyy HH:mm}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(1069F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo2, "Default", "SizeF", new System.Drawing.SizeF(1069.5F, 23F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.pageInfo2, "Default", "TextFormatString", "page {0} from {1}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "Font", new System.Drawing.Font("Arial", 9.75F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this, "Default", "PaperKind", System.Drawing.Printing.PaperKind.A2),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.ReportHeader, "Default", "HeightF", 60F),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.table1, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.table1, "Default", "SizeF", new System.Drawing.SizeF(2139F, 28F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.table2, "Default", "LocationFloat", new DevExpress.Utils.PointFloat(0F, 0F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.table2, "Default", "SizeF", new System.Drawing.SizeF(2139F, 25F)),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell1, "Default", "Text", "Id"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell1, "ru-RU", "Text", "Ид"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell1, "Default", "Weight", 0.018761877815207346D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell10, "Default", "Text", "Date Time Of Last Try By Industrial Safety"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell10, "ru-RU", "Text", "Дата последней попытки верифицирования по промышленной безопасности"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell10, "Default", "Weight", 0.18762908978348528D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell11, "Default", "Weight", 0.018761877815207346D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell12, "Default", "Weight", 0.057179533471120411D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell13, "Default", "Weight", 0.056677734032586781D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell14, "Default", "Weight", 0.035018321675304609D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell15, "Default", "TextFormatString", "{0:dd.MM.yyyy}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell15, "Default", "Weight", 0.046823495345006426D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell16, "Default", "Weight", 0.10491067352223586D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell17, "Default", "Weight", 0.15268507891026764D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell18, "Default", "Weight", 0.17630840941755055D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell19, "Default", "TextFormatString", "{0:dd.MM.yyyy HH:mm}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell19, "Default", "Weight", 0.16400575927620237D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell2, "Default", "Text", "User Name"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell2, "ru-RU", "Text", "Никнейм"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell2, "Default", "Weight", 0.057179529904316052D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell20, "Default", "TextFormatString", "{0:dd-MM-yyyy HH:mm}"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell20, "Default", "Weight", 0.18762908978348528D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell3, "Default", "Text", "Role Name"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell3, "ru-RU", "Text", "Роль"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell3, "Default", "Weight", 0.056677730465782422D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell4, "Default", "Text", "Name"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell4, "ru-RU", "Text", "Имя"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell4, "Default", "Weight", 0.035018321675304609D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell5, "Default", "Text", "Birthday"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell5, "ru-RU", "Text", "Дата Рождения"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell5, "Default", "Weight", 0.046823495345006426D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell6, "Default", "Text", "Counter Of Used Tries"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell6, "ru-RU", "Text", "Количетсво использованных попыток"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell6, "Default", "Weight", 0.10491067352223586D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell7, "Default", "Text", "Verefication Status By Fire Safety"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell7, "ru-RU", "Text", "Статус верификации по пожарной безопасности"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell7, "Default", "Weight", 0.15268507891026764D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell8, "Default", "Text", "Verefication Status By Industrial Safety"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell8, "ru-RU", "Text", "Статус верификации по промышленной безопасности"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell8, "Default", "Weight", 0.17630840941755055D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell9, "Default", "Text", "Date Time Of Last Try By Fire Safety"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell9, "ru-RU", "Text", "Дата последней попытки верифицирования по пожарной безопасности"),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableCell9, "Default", "Weight", 0.16400575927620237D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableRow1, "Default", "Weight", 1D),
            new DevExpress.XtraReports.Localization.LocalizationItem(this.tableRow2, "Default", "Weight", 11.5D)});
            this.PageHeight = 1654;
            this.PageWidth = 2339;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.fromDate,
            this.toDate});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption1,
            this.DetailData1,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        public DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell10;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell12;
        private DevExpress.XtraReports.UI.XRTableCell tableCell13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell14;
        private DevExpress.XtraReports.UI.XRTableCell tableCell15;
        private DevExpress.XtraReports.UI.XRTableCell tableCell16;
        private DevExpress.XtraReports.UI.XRTableCell tableCell17;
        private DevExpress.XtraReports.UI.XRCheckBox checkBox1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell18;
        private DevExpress.XtraReports.UI.XRCheckBox checkBox2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell19;
        private DevExpress.XtraReports.UI.XRTableCell tableCell20;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle DetailCaption1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData3_Odd;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.Parameters.Parameter fromDate;
        private DevExpress.XtraReports.Parameters.Parameter toDate;
    }
}
