namespace Sigmeh.View.Reports
{
    partial class rptRME
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.dsRME = new Telerik.Reporting.SqlDataSource();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.aprovadorIDCaptionTextBox = new Telerik.Reporting.TextBox();
            this.aprovadorIDDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox13 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.20000067353248596D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229164481163025D);
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            this.labelsGroupHeaderSection.Style.Visible = false;
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.16770794987678528D);
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5999001264572144D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1});
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0078124268911778927D), Telerik.Reporting.Drawing.Unit.Cm(0.00010002215276472271D));
            this.subReport1.Name = "subReport1";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("equipamentoID", "=Fields.EquipamentoID"));
            typeReportSource1.TypeName = "Sigmeh.View.Reports.rptDadosBasicosEquipamento, Sigmeh.View, Version=1.0.0.0, Cul" +
    "ture=neutral, PublicKeyToken=null";
            this.subReport1.ReportSource = typeReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.29218864440918D), Telerik.Reporting.Drawing.Unit.Cm(1.599600076675415D));
            this.subReport1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // dsRME
            // 
            this.dsRME.ConnectionString = "SigmehConnection";
            this.dsRME.Name = "dsRME";
            this.dsRME.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@xml_RMEID", System.Data.DbType.Xml, "=Parameters.xml_RMEID.Value")});
            this.dsRME.SelectCommand = "dbo.stp_RelatorioRME";
            this.dsRME.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.3999996185302734D), Telerik.Reporting.Drawing.Unit.Cm(0.029999999329447746D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.0000009536743164D), Telerik.Reporting.Drawing.Unit.Cm(0.48621970415115356D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.Style.Color = System.Drawing.Color.Black;
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Name = "Segoe UI";
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.StyleName = "Caption";
            this.textBox1.Value = "Tipo:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.4800004959106445D), Telerik.Reporting.Drawing.Unit.Cm(0.028457833454012871D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5999932289123535D), Telerik.Reporting.Drawing.Unit.Cm(0.48621949553489685D));
            this.textBox5.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox5.Style.Color = System.Drawing.Color.Black;
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "Segoe UI";
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.StyleName = "Caption";
            this.textBox5.Value = "Executado por:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.380000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.026916153728961945D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5000004768371582D), Telerik.Reporting.Drawing.Unit.Cm(0.48621949553489685D));
            this.textBox6.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox6.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox6.Style.Color = System.Drawing.Color.Black;
            this.textBox6.Style.Font.Bold = true;
            this.textBox6.Style.Font.Name = "Segoe UI";
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.StyleName = "Caption";
            this.textBox6.Value = "Aprovado por:";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(3.8678078651428223D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox8,
            this.textBox11,
            this.textBox1,
            this.textBox2,
            this.panel1,
            this.aprovadorIDCaptionTextBox,
            this.aprovadorIDDataTextBox,
            this.textBox7,
            this.textBox12});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.019999990239739418D), Telerik.Reporting.Drawing.Unit.Cm(0.51642036437988281D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.48621970415115356D));
            this.textBox8.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox8.Style.Color = System.Drawing.Color.Black;
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Segoe UI";
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.StyleName = "Caption";
            this.textBox8.Value = "Relatório Técnico";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.419270515441895D), Telerik.Reporting.Drawing.Unit.Cm(0.51642036437988281D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.9999997615814209D), Telerik.Reporting.Drawing.Unit.Cm(0.48621970415115356D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox11.Style.Color = System.Drawing.Color.Black;
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Name = "Segoe UI";
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox11.StyleName = "Caption";
            this.textBox11.Value = "Defeitos constatados";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Cm(0.029999999329447746D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.48621988296508789D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Name = "Segoe UI";
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.ManutencaoTipoDescricao";
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox4,
            this.textBox6,
            this.textBox10,
            this.textBox3,
            this.textBox9});
            this.panel1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.019999990239739418D), Telerik.Reporting.Drawing.Unit.Cm(0.0030838313978165388D));
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.280000686645508D), Telerik.Reporting.Drawing.Unit.Cm(0.51313620805740356D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Format = "{0:d}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(22.360397338867188D), Telerik.Reporting.Drawing.Unit.Cm(0.029999999329447746D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8998000621795654D), Telerik.Reporting.Drawing.Unit.Cm(0.48313570022583008D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.Font.Bold = false;
            this.textBox4.Style.Font.Name = "Segoe UI";
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.DataRealizacao";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.88020133972168D), Telerik.Reporting.Drawing.Unit.Cm(0.026916153728961945D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.9997992515563965D), Telerik.Reporting.Drawing.Unit.Cm(0.48621955513954163D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox10.Style.Font.Name = "Segoe UI";
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "= Fields.AprovadorNome";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.88020133972168D), Telerik.Reporting.Drawing.Unit.Cm(0.029999999329447746D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4799997806549072D), Telerik.Reporting.Drawing.Unit.Cm(0.48313561081886292D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Color = System.Drawing.Color.Black;
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Name = "Segoe UI";
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.StyleName = "Caption";
            this.textBox3.Value = "Realizado em:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.080000877380371D), Telerik.Reporting.Drawing.Unit.Cm(0.026916153728961945D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2998003959655762D), Telerik.Reporting.Drawing.Unit.Cm(0.48621955513954163D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox9.Style.Font.Name = "Segoe UI";
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "Data";
            this.textBox9.Value = "= Fields.ExecutorNome";
            // 
            // aprovadorIDCaptionTextBox
            // 
            this.aprovadorIDCaptionTextBox.CanGrow = true;
            this.aprovadorIDCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0078124268911778927D), Telerik.Reporting.Drawing.Unit.Cm(0.00019964059174526483D));
            this.aprovadorIDCaptionTextBox.Name = "aprovadorIDCaptionTextBox";
            this.aprovadorIDCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4921875D), Telerik.Reporting.Drawing.Unit.Cm(0.49980032444000244D));
            this.aprovadorIDCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.Black;
            this.aprovadorIDCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.aprovadorIDCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.aprovadorIDCaptionTextBox.Style.Color = System.Drawing.Color.White;
            this.aprovadorIDCaptionTextBox.Style.Font.Bold = true;
            this.aprovadorIDCaptionTextBox.Style.Font.Name = "Segoe UI";
            this.aprovadorIDCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.aprovadorIDCaptionTextBox.StyleName = "Caption";
            this.aprovadorIDCaptionTextBox.Value = "Identificador:";
            // 
            // aprovadorIDDataTextBox
            // 
            this.aprovadorIDDataTextBox.CanGrow = true;
            this.aprovadorIDDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5000002384185791D), Telerik.Reporting.Drawing.Unit.Cm(0.0030838313978165388D));
            this.aprovadorIDDataTextBox.Name = "aprovadorIDDataTextBox";
            this.aprovadorIDDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.8997994661331177D), Telerik.Reporting.Drawing.Unit.Cm(0.49691605567932129D));
            this.aprovadorIDDataTextBox.Style.BackgroundColor = System.Drawing.Color.Black;
            this.aprovadorIDDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.aprovadorIDDataTextBox.Style.Color = System.Drawing.Color.White;
            this.aprovadorIDDataTextBox.Style.Font.Name = "Segoe UI";
            this.aprovadorIDDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.aprovadorIDDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.aprovadorIDDataTextBox.StyleName = "Data";
            this.aprovadorIDDataTextBox.Value = "= FORMAT(\'{0:0000}\',Fields.RegistroManutencaoID)";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.019999990239739418D), Telerik.Reporting.Drawing.Unit.Cm(1.0028400421142578D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.880000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.54115045070648193D));
            this.textBox7.Style.Font.Name = "Segoe UI";
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "= Fields.RelatorioDescricao";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.419270515441895D), Telerik.Reporting.Drawing.Unit.Cm(1.0028403997421265D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.880000114440918D), Telerik.Reporting.Drawing.Unit.Cm(0.54115045070648193D));
            this.textBox12.Style.Font.Name = "Segoe UI";
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "= Fields.DefeitoDescricao";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.0999999046325684D), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.000001907348633D), Telerik.Reporting.Drawing.Unit.Cm(0.69989991188049316D));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox13.Value = "Relatório de registros de manutenção de equipamentos";
            // 
            // rptRME
            // 
            this.DataSource = this.dsRME;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.groupFooterSection;
            group2.GroupHeader = this.groupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.EquipamentoID"));
            group2.Name = "group";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.groupHeaderSection,
            this.groupFooterSection,
            this.detail,
            this.reportHeaderSection1});
            this.Name = "rptRME";
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D), Telerik.Reporting.Drawing.Unit.Mm(25.399999618530273D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "xml_RMEID";
            reportParameter1.Text = "xml_RMEID";
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Color = System.Drawing.Color.White;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(24.299999237060547D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource dsRME;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox aprovadorIDCaptionTextBox;
        private Telerik.Reporting.TextBox aprovadorIDDataTextBox;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBox13;

    }
}