namespace ABCReader
{
    partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
         this.button_tabDNA_ReadFastaDNA = new System.Windows.Forms.Button();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPageMain_DNA = new System.Windows.Forms.TabPage();
         this.panel_tabDNA_bottom = new System.Windows.Forms.Panel();
         this.groupBox_tabDNA_bottomViewDNA = new System.Windows.Forms.GroupBox();
         this.richTextBox_tabDNA_DNAview = new System.Windows.Forms.RichTextBox();
         this.panel_tabDNA_top = new System.Windows.Forms.Panel();
         this.groupBox_tabDNA_top_writeWindow = new System.Windows.Forms.GroupBox();
         this.button_tabDNA_ShowSaveDataWindow = new System.Windows.Forms.Button();
         this.groupBox_tabDNA_top_viewOptions = new System.Windows.Forms.GroupBox();
         this.panel_tabDNA_top_ORFs = new System.Windows.Forms.Panel();
         this.radioButton_tabDNA_ShowAllFrames = new System.Windows.Forms.RadioButton();
         this.radioButton_tabDNA_showFrame0 = new System.Windows.Forms.RadioButton();
         this.radioButton_tabDNA_showFrame1 = new System.Windows.Forms.RadioButton();
         this.radioButton_tabDNA_showFrame2 = new System.Windows.Forms.RadioButton();
         this.checkBox_tabDNA_ShowAlsoDNA = new System.Windows.Forms.CheckBox();
         this.panel_tabDNA_top_53or35 = new System.Windows.Forms.Panel();
         this.radioButton_tabDNA_BothDirections = new System.Windows.Forms.RadioButton();
         this.radioButton_tabDNA_3to5 = new System.Windows.Forms.RadioButton();
         this.radioButton_tabDNA_5to3 = new System.Windows.Forms.RadioButton();
         this.button_tabDNA_SaveCodingDNAfile = new System.Windows.Forms.Button();
         this.comboBox_tabDNA_DNAlist = new System.Windows.Forms.ComboBox();
         this.checkBox_tabDNA_realProteins = new System.Windows.Forms.CheckBox();
         this.groupBox_tabDNA_top_readDNA = new System.Windows.Forms.GroupBox();
         this.checkBox2Convert = new System.Windows.Forms.CheckBox();
         this.checkBox_tabDNA_SortDNAbyLength = new System.Windows.Forms.CheckBox();
         this.tabPageMain_Prots = new System.Windows.Forms.TabPage();
         this.tabControl_tabProtsBottom = new System.Windows.Forms.TabControl();
         this.tabPage_21 = new System.Windows.Forms.TabPage();
         this.splitContainer_tabProts = new System.Windows.Forms.SplitContainer();
         this.richTextBox_tabProts_protView1 = new System.Windows.Forms.RichTextBox();
         this.panel_tabProts_tab1_RightFill_RichTBRight = new System.Windows.Forms.Panel();
         this.richTextBox_tabProts_proteinBlastView = new System.Windows.Forms.RichTextBox();
         this.panel_tabProts_tab1_RightTop = new System.Windows.Forms.Panel();
         this.label_tabProts_1 = new System.Windows.Forms.Label();
         this.numericUpDown_tabProts_MaxHitsForBlastP = new System.Windows.Forms.NumericUpDown();
         this.tabPage_22 = new System.Windows.Forms.TabPage();
         this.panel_tabProt_tab22_Right = new System.Windows.Forms.Panel();
         this.panel_tabProt_tab22__Right_Internal2 = new System.Windows.Forms.Panel();
         this.richTextBox_tabProt_SimiliarInfo = new System.Windows.Forms.RichTextBox();
         this.panel_tabProt_tab22__Right_Internal3 = new System.Windows.Forms.Panel();
         this.DGV_ProtsComp_Small = new System.Windows.Forms.DataGridView();
         this.contextMenu_DGV_SmallComp = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.toolStripMenuICompDNAinLog = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemCompProtsInLog = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemCompBothInLog = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuAddToList = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuRemoveFromList = new System.Windows.Forms.ToolStripMenuItem();
         this.panel_tabProt_tab22__Right_Internal1 = new System.Windows.Forms.Panel();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButton3 = new System.Windows.Forms.RadioButton();
         this.radioButton4 = new System.Windows.Forms.RadioButton();
         this.label_tabProt_LastRemovedNumber = new System.Windows.Forms.Label();
         this.button_tabProt_removeDuplicates = new System.Windows.Forms.Button();
         this.label10 = new System.Windows.Forms.Label();
         this.numericUpDown_tabProt_minCzValue = new System.Windows.Forms.NumericUpDown();
         this.button_tabProt_ReScanProteins = new System.Windows.Forms.Button();
         this.panel_tabProt_tab22_Left = new System.Windows.Forms.Panel();
         this.DGV_ProtsComp_Big = new System.Windows.Forms.DataGridView();
         this.contextMenu_DGV_BigComp = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.ignorujSekwencjęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.przestańIgnorowaćSekwencjęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.panel_tabProt_top = new System.Windows.Forms.Panel();
         this.panel_tabProt_Top_Exp1 = new System.Windows.Forms.Panel();
         this.panel_tabProt_Top_Exp2 = new System.Windows.Forms.Panel();
         this.groupBox_tabProt_top_chart = new System.Windows.Forms.GroupBox();
         this.chart_tabProt_1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.groupBox_tabProt_saveOptions = new System.Windows.Forms.GroupBox();
         this.button_tabProt_LoadXML = new System.Windows.Forms.Button();
         this.button_tabProt_SaveXML = new System.Windows.Forms.Button();
         this.button_tabProt_SaveProteinToFile = new System.Windows.Forms.Button();
         this.checkBox_tabProt_WriteAlsoDNAFile = new System.Windows.Forms.CheckBox();
         this.groupBox_tabProt_top_left = new System.Windows.Forms.GroupBox();
         this.groupBox_tabProt_proteinViewer = new System.Windows.Forms.GroupBox();
         this.radioButton_tabProts_comboUnsort = new System.Windows.Forms.RadioButton();
         this.radioButton_tabProts_comboSortAlfa = new System.Windows.Forms.RadioButton();
         this.checkBox_tabProt_ShowBlastData = new System.Windows.Forms.CheckBox();
         this.checkBox_tabProt_ShowDNA = new System.Windows.Forms.CheckBox();
         this.comboBox_tabProt_ProteinsList = new System.Windows.Forms.ComboBox();
         this.panel_tabProt_top_protSizeToRead = new System.Windows.Forms.Panel();
         this.label_tabProtMinLength = new System.Windows.Forms.Label();
         this.numericUpDown_tabProt_minLength = new System.Windows.Forms.NumericUpDown();
         this.radioButton_tabProt_only1Longest = new System.Windows.Forms.RadioButton();
         this.radioButton_tabProt_allLongerThan = new System.Windows.Forms.RadioButton();
         this.checkBox_tabProt_onlyWithSTOP = new System.Windows.Forms.CheckBox();
         this.checkBox_tabProt_startFromMET = new System.Windows.Forms.CheckBox();
         this.panel_tabProt_top_53or35 = new System.Windows.Forms.Panel();
         this.radioButton_tabProt_BothDirections = new System.Windows.Forms.RadioButton();
         this.radioButton_tabProt_3to5 = new System.Windows.Forms.RadioButton();
         this.radioButton_tabProt_5to3 = new System.Windows.Forms.RadioButton();
         this.button_tabProt_SearchProteinsInDNAs = new System.Windows.Forms.Button();
         this.tabPageMain_BlastP = new System.Windows.Forms.TabPage();
         this.panel_tabBlastP_bottom = new System.Windows.Forms.Panel();
         this.splitContainer_tabBlast = new System.Windows.Forms.SplitContainer();
         this.DGV_Blast = new System.Windows.Forms.DataGridView();
         this.contextMenu_DGV_Blast = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.usuńWynikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.richTextBox_tabBlastP_blastView = new System.Windows.Forms.RichTextBox();
         this.panel_tabBlastP_top = new System.Windows.Forms.Panel();
         this.groupBox_tabBlastP_TopChart = new System.Windows.Forms.GroupBox();
         this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.groupBox_tabBlastP_top_SaveToFile = new System.Windows.Forms.GroupBox();
         this.button_tabBlastP_Save1 = new System.Windows.Forms.Button();
         this.groupBox_tabBlastP_top_scanOptions = new System.Windows.Forms.GroupBox();
         this.button_tabBlastP_RefreshDGV = new System.Windows.Forms.Button();
         this.numericUpDown_tabBlastP_CompSet = new System.Windows.Forms.NumericUpDown();
         this.numericUpDown_tabBlastP_minCoverage = new System.Windows.Forms.NumericUpDown();
         this.button_tabBlastP_ActivateBlastPscan = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.textBox_tabBlastP_maxEvalue = new System.Windows.Forms.TextBox();
         this.comboBox_tabBlastP_BlastDBname = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tabPageMain_TX = new System.Windows.Forms.TabPage();
         this.panel_tabTX_BottomForTabControl = new System.Windows.Forms.Panel();
         this.tabControl_tabTX = new System.Windows.Forms.TabControl();
         this.tabPage_tabTX_tabAlign = new System.Windows.Forms.TabPage();
         this.panel_tabTX_tabAlign_BottomP = new System.Windows.Forms.Panel();
         this.richTextBox_tabTX_results = new System.Windows.Forms.RichTextBox();
         this.panel_tabTX_tabAlign_Top = new System.Windows.Forms.Panel();
         this.comboBox_tabTX_comboSelectAlignForShowAll = new System.Windows.Forms.ComboBox();
         this.button1 = new System.Windows.Forms.Button();
         this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
         this.label16 = new System.Windows.Forms.Label();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.radioButton_tabTX_showProts = new System.Windows.Forms.RadioButton();
         this.radioButton_tabTX_showDNA = new System.Windows.Forms.RadioButton();
         this.label15 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.hScrollBar_tabTX = new System.Windows.Forms.HScrollBar();
         this.numericUpDown_tabTX_frameSize = new System.Windows.Forms.NumericUpDown();
         this.numericUpDown_tabTX_font = new System.Windows.Forms.NumericUpDown();
         this.tabPage_tabTX_tabSequences = new System.Windows.Forms.TabPage();
         this.splitContainer_tabTX_tab2 = new System.Windows.Forms.SplitContainer();
         this.panel_tabTX_tab2_LeftBottom = new System.Windows.Forms.Panel();
         this.DGV_tabTX_Main = new System.Windows.Forms.DataGridView();
         this.panel_tabTX_tab2_LeftTop = new System.Windows.Forms.Panel();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.button_tabTX_getTXdata = new System.Windows.Forms.Button();
         this.panel_tabTX_tab2_RightBottom = new System.Windows.Forms.Panel();
         this.DGV_tabTX_Ignored = new System.Windows.Forms.DataGridView();
         this.panel_tabTX_tab2_RightTop = new System.Windows.Forms.Panel();
         this.panel_tabTX_Top = new System.Windows.Forms.Panel();
         this.groupBox_tabTX_saveAlign = new System.Windows.Forms.GroupBox();
         this.button_tabTX_savePrank = new System.Windows.Forms.Button();
         this.button_tabTX_saveTCoffee = new System.Windows.Forms.Button();
         this.button_tabTX_saveMafft = new System.Windows.Forms.Button();
         this.button_tabTX_saveMuscle = new System.Windows.Forms.Button();
         this.button_tabTX_saveClustalW = new System.Windows.Forms.Button();
         this.groupBox_tabTX_selAminos = new System.Windows.Forms.GroupBox();
         this.checkBox_ColorTrigger = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoV = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoY = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoW = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoT = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoS = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoR = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoQ = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoG = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoP = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoN = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoM = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoL = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoK = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoI = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoH = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoF = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoE = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoD = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoC = new System.Windows.Forms.CheckBox();
         this.checkBox_aminoA = new System.Windows.Forms.CheckBox();
         this.groupBox_tabTX_Results = new System.Windows.Forms.GroupBox();
         this.checkBoxP = new System.Windows.Forms.CheckBox();
         this.checkBoxT = new System.Windows.Forms.CheckBox();
         this.checkBoxF = new System.Windows.Forms.CheckBox();
         this.checkBoxC = new System.Windows.Forms.CheckBox();
         this.checkBoxM = new System.Windows.Forms.CheckBox();
         this.groupBox_tabTX_runTX = new System.Windows.Forms.GroupBox();
         this.button_tabTX_loadFromFile = new System.Windows.Forms.Button();
         this.button_tabTX_runTX = new System.Windows.Forms.Button();
         this.comboBox_tabTX_alignMethod = new System.Windows.Forms.ComboBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.button_tabTX_alignFromBlast = new System.Windows.Forms.Button();
         this.button_tabTX_alignFromProts = new System.Windows.Forms.Button();
         this.button_tabTX_ShowFull = new System.Windows.Forms.Button();
         this.button_tabTX_ShowAlignment = new System.Windows.Forms.Button();
         this.tabPageMain_Notepad = new System.Windows.Forms.TabPage();
         this.panel_tabOther_1 = new System.Windows.Forms.Panel();
         this.panel_tabOther_Bottom = new System.Windows.Forms.Panel();
         this.splitContainer_tabNotepad = new System.Windows.Forms.SplitContainer();
         this.richTextBox_tabNotepad_Left = new System.Windows.Forms.RichTextBox();
         this.richTextBox_tabNotepad_Right = new System.Windows.Forms.RichTextBox();
         this.panel_tabOthers_Top = new System.Windows.Forms.Panel();
         this.groupBox_tabOtherAlignments = new System.Windows.Forms.GroupBox();
         this.label13 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.button_tabNotepad_AlignNW = new System.Windows.Forms.Button();
         this.textBox_tabOther_Seq2 = new System.Windows.Forms.TextBox();
         this.panel_tabOther_NWorSW = new System.Windows.Forms.Panel();
         this.radioButton_tabNotepad_SW = new System.Windows.Forms.RadioButton();
         this.radioButton_tabNotepad_NW = new System.Windows.Forms.RadioButton();
         this.textBox_tabOther_Seq1 = new System.Windows.Forms.TextBox();
         this.button_tabNotepad_ClearTBoxes = new System.Windows.Forms.Button();
         this.button_tabNotepad_BlastN = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.textBox6 = new System.Windows.Forms.TextBox();
         this.textBox5 = new System.Windows.Forms.TextBox();
         this.textBox4 = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.button_tabNotepad_RemoveDuplicates = new System.Windows.Forms.Button();
         this.tabPageMain_BlastDB = new System.Windows.Forms.TabPage();
         this.panel_tabRefDB_bottom = new System.Windows.Forms.Panel();
         this.splitContainer_tabRefDB = new System.Windows.Forms.SplitContainer();
         this.DGV_blastDBs = new System.Windows.Forms.DataGridView();
         this.panel_tabRefDB_bottom_rightFill = new System.Windows.Forms.Panel();
         this.panel_tabRefDB_tmp2 = new System.Windows.Forms.Panel();
         this.textBox_tabRefDB_sequence = new System.Windows.Forms.TextBox();
         this.panel_tabRefDB_tmp1 = new System.Windows.Forms.Panel();
         this.label6 = new System.Windows.Forms.Label();
         this.button_tabRefDB_ClearFields = new System.Windows.Forms.Button();
         this.label7 = new System.Windows.Forms.Label();
         this.textBox_tabRefDB_seqID = new System.Windows.Forms.TextBox();
         this.panel_tabRefDB_bottom_right = new System.Windows.Forms.Panel();
         this.button_tabRefDB_RemoveSeq = new System.Windows.Forms.Button();
         this.button_tabRefDB_AddFastaFile = new System.Windows.Forms.Button();
         this.button_tabRefDB_CompileDB = new System.Windows.Forms.Button();
         this.button_tabRefDB_EditRow = new System.Windows.Forms.Button();
         this.button_tabRefDB_AddNewProt = new System.Windows.Forms.Button();
         this.panel_tabRefDB_top = new System.Windows.Forms.Panel();
         this.label8 = new System.Windows.Forms.Label();
         this.comboBox_tabDB_BaseSelection = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.tabPageMain_Log = new System.Windows.Forms.TabPage();
         this.panel_tabLog_bottom = new System.Windows.Forms.Panel();
         this.richTextBox_tabLog = new System.Windows.Forms.RichTextBox();
         this.panel_tabLog_top = new System.Windows.Forms.Panel();
         this.label11 = new System.Windows.Forms.Label();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.tabControl1.SuspendLayout();
         this.tabPageMain_DNA.SuspendLayout();
         this.panel_tabDNA_bottom.SuspendLayout();
         this.groupBox_tabDNA_bottomViewDNA.SuspendLayout();
         this.panel_tabDNA_top.SuspendLayout();
         this.groupBox_tabDNA_top_writeWindow.SuspendLayout();
         this.groupBox_tabDNA_top_viewOptions.SuspendLayout();
         this.panel_tabDNA_top_ORFs.SuspendLayout();
         this.panel_tabDNA_top_53or35.SuspendLayout();
         this.groupBox_tabDNA_top_readDNA.SuspendLayout();
         this.tabPageMain_Prots.SuspendLayout();
         this.tabControl_tabProtsBottom.SuspendLayout();
         this.tabPage_21.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabProts)).BeginInit();
         this.splitContainer_tabProts.Panel1.SuspendLayout();
         this.splitContainer_tabProts.Panel2.SuspendLayout();
         this.splitContainer_tabProts.SuspendLayout();
         this.panel_tabProts_tab1_RightFill_RichTBRight.SuspendLayout();
         this.panel_tabProts_tab1_RightTop.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProts_MaxHitsForBlastP)).BeginInit();
         this.tabPage_22.SuspendLayout();
         this.panel_tabProt_tab22_Right.SuspendLayout();
         this.panel_tabProt_tab22__Right_Internal2.SuspendLayout();
         this.panel_tabProt_tab22__Right_Internal3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_ProtsComp_Small)).BeginInit();
         this.contextMenu_DGV_SmallComp.SuspendLayout();
         this.panel_tabProt_tab22__Right_Internal1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProt_minCzValue)).BeginInit();
         this.panel_tabProt_tab22_Left.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_ProtsComp_Big)).BeginInit();
         this.contextMenu_DGV_BigComp.SuspendLayout();
         this.panel_tabProt_top.SuspendLayout();
         this.panel_tabProt_Top_Exp1.SuspendLayout();
         this.panel_tabProt_Top_Exp2.SuspendLayout();
         this.groupBox_tabProt_top_chart.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chart_tabProt_1)).BeginInit();
         this.groupBox_tabProt_saveOptions.SuspendLayout();
         this.groupBox_tabProt_top_left.SuspendLayout();
         this.groupBox_tabProt_proteinViewer.SuspendLayout();
         this.panel_tabProt_top_protSizeToRead.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProt_minLength)).BeginInit();
         this.panel_tabProt_top_53or35.SuspendLayout();
         this.tabPageMain_BlastP.SuspendLayout();
         this.panel_tabBlastP_bottom.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabBlast)).BeginInit();
         this.splitContainer_tabBlast.Panel1.SuspendLayout();
         this.splitContainer_tabBlast.Panel2.SuspendLayout();
         this.splitContainer_tabBlast.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_Blast)).BeginInit();
         this.contextMenu_DGV_Blast.SuspendLayout();
         this.panel_tabBlastP_top.SuspendLayout();
         this.groupBox_tabBlastP_TopChart.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
         this.groupBox_tabBlastP_top_SaveToFile.SuspendLayout();
         this.groupBox_tabBlastP_top_scanOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabBlastP_CompSet)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabBlastP_minCoverage)).BeginInit();
         this.tabPageMain_TX.SuspendLayout();
         this.panel_tabTX_BottomForTabControl.SuspendLayout();
         this.tabControl_tabTX.SuspendLayout();
         this.tabPage_tabTX_tabAlign.SuspendLayout();
         this.panel_tabTX_tabAlign_BottomP.SuspendLayout();
         this.panel_tabTX_tabAlign_Top.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabTX_frameSize)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabTX_font)).BeginInit();
         this.tabPage_tabTX_tabSequences.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabTX_tab2)).BeginInit();
         this.splitContainer_tabTX_tab2.Panel1.SuspendLayout();
         this.splitContainer_tabTX_tab2.Panel2.SuspendLayout();
         this.splitContainer_tabTX_tab2.SuspendLayout();
         this.panel_tabTX_tab2_LeftBottom.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_tabTX_Main)).BeginInit();
         this.panel_tabTX_tab2_LeftTop.SuspendLayout();
         this.panel_tabTX_tab2_RightBottom.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_tabTX_Ignored)).BeginInit();
         this.panel_tabTX_Top.SuspendLayout();
         this.groupBox_tabTX_saveAlign.SuspendLayout();
         this.groupBox_tabTX_selAminos.SuspendLayout();
         this.groupBox_tabTX_Results.SuspendLayout();
         this.groupBox_tabTX_runTX.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.tabPageMain_Notepad.SuspendLayout();
         this.panel_tabOther_1.SuspendLayout();
         this.panel_tabOther_Bottom.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabNotepad)).BeginInit();
         this.splitContainer_tabNotepad.Panel1.SuspendLayout();
         this.splitContainer_tabNotepad.Panel2.SuspendLayout();
         this.splitContainer_tabNotepad.SuspendLayout();
         this.panel_tabOthers_Top.SuspendLayout();
         this.groupBox_tabOtherAlignments.SuspendLayout();
         this.panel_tabOther_NWorSW.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.tabPageMain_BlastDB.SuspendLayout();
         this.panel_tabRefDB_bottom.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabRefDB)).BeginInit();
         this.splitContainer_tabRefDB.Panel1.SuspendLayout();
         this.splitContainer_tabRefDB.Panel2.SuspendLayout();
         this.splitContainer_tabRefDB.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.DGV_blastDBs)).BeginInit();
         this.panel_tabRefDB_bottom_rightFill.SuspendLayout();
         this.panel_tabRefDB_tmp2.SuspendLayout();
         this.panel_tabRefDB_tmp1.SuspendLayout();
         this.panel_tabRefDB_bottom_right.SuspendLayout();
         this.panel_tabRefDB_top.SuspendLayout();
         this.tabPageMain_Log.SuspendLayout();
         this.panel_tabLog_bottom.SuspendLayout();
         this.panel_tabLog_top.SuspendLayout();
         this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
         this.toolStripContainer1.ContentPanel.SuspendLayout();
         this.toolStripContainer1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // button_tabDNA_ReadFastaDNA
         // 
         this.button_tabDNA_ReadFastaDNA.Image = ((System.Drawing.Image)(resources.GetObject("button_tabDNA_ReadFastaDNA.Image")));
         this.button_tabDNA_ReadFastaDNA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabDNA_ReadFastaDNA.Location = new System.Drawing.Point(6, 19);
         this.button_tabDNA_ReadFastaDNA.Name = "button_tabDNA_ReadFastaDNA";
         this.button_tabDNA_ReadFastaDNA.Size = new System.Drawing.Size(122, 48);
         this.button_tabDNA_ReadFastaDNA.TabIndex = 0;
         this.button_tabDNA_ReadFastaDNA.Text = "Wczytaj DNA";
         this.button_tabDNA_ReadFastaDNA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabDNA_ReadFastaDNA.UseVisualStyleBackColor = true;
         this.button_tabDNA_ReadFastaDNA.Click += new System.EventHandler(this.button_tabDNA_ReadFastaDNA_Click);
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPageMain_DNA);
         this.tabControl1.Controls.Add(this.tabPageMain_Prots);
         this.tabControl1.Controls.Add(this.tabPageMain_BlastP);
         this.tabControl1.Controls.Add(this.tabPageMain_TX);
         this.tabControl1.Controls.Add(this.tabPageMain_Notepad);
         this.tabControl1.Controls.Add(this.tabPageMain_BlastDB);
         this.tabControl1.Controls.Add(this.tabPageMain_Log);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(1155, 634);
         this.tabControl1.TabIndex = 1;
         this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
         this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
         // 
         // tabPageMain_DNA
         // 
         this.tabPageMain_DNA.Controls.Add(this.panel_tabDNA_bottom);
         this.tabPageMain_DNA.Controls.Add(this.panel_tabDNA_top);
         this.tabPageMain_DNA.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_DNA.Name = "tabPageMain_DNA";
         this.tabPageMain_DNA.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageMain_DNA.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_DNA.TabIndex = 0;
         this.tabPageMain_DNA.Text = "DNA -> Białka";
         this.tabPageMain_DNA.UseVisualStyleBackColor = true;
         // 
         // panel_tabDNA_bottom
         // 
         this.panel_tabDNA_bottom.Controls.Add(this.groupBox_tabDNA_bottomViewDNA);
         this.panel_tabDNA_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabDNA_bottom.Location = new System.Drawing.Point(3, 153);
         this.panel_tabDNA_bottom.Name = "panel_tabDNA_bottom";
         this.panel_tabDNA_bottom.Size = new System.Drawing.Size(1141, 452);
         this.panel_tabDNA_bottom.TabIndex = 4;
         // 
         // groupBox_tabDNA_bottomViewDNA
         // 
         this.groupBox_tabDNA_bottomViewDNA.Controls.Add(this.richTextBox_tabDNA_DNAview);
         this.groupBox_tabDNA_bottomViewDNA.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox_tabDNA_bottomViewDNA.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabDNA_bottomViewDNA.Name = "groupBox_tabDNA_bottomViewDNA";
         this.groupBox_tabDNA_bottomViewDNA.Size = new System.Drawing.Size(1141, 452);
         this.groupBox_tabDNA_bottomViewDNA.TabIndex = 3;
         this.groupBox_tabDNA_bottomViewDNA.TabStop = false;
         this.groupBox_tabDNA_bottomViewDNA.Text = "Widok";
         // 
         // richTextBox_tabDNA_DNAview
         // 
         this.richTextBox_tabDNA_DNAview.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabDNA_DNAview.Location = new System.Drawing.Point(3, 16);
         this.richTextBox_tabDNA_DNAview.Name = "richTextBox_tabDNA_DNAview";
         this.richTextBox_tabDNA_DNAview.ReadOnly = true;
         this.richTextBox_tabDNA_DNAview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
         this.richTextBox_tabDNA_DNAview.Size = new System.Drawing.Size(1135, 433);
         this.richTextBox_tabDNA_DNAview.TabIndex = 1;
         this.richTextBox_tabDNA_DNAview.Text = "";
         // 
         // panel_tabDNA_top
         // 
         this.panel_tabDNA_top.Controls.Add(this.groupBox_tabDNA_top_writeWindow);
         this.panel_tabDNA_top.Controls.Add(this.groupBox_tabDNA_top_viewOptions);
         this.panel_tabDNA_top.Controls.Add(this.groupBox_tabDNA_top_readDNA);
         this.panel_tabDNA_top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabDNA_top.Location = new System.Drawing.Point(3, 3);
         this.panel_tabDNA_top.Name = "panel_tabDNA_top";
         this.panel_tabDNA_top.Size = new System.Drawing.Size(1141, 150);
         this.panel_tabDNA_top.TabIndex = 0;
         // 
         // groupBox_tabDNA_top_writeWindow
         // 
         this.groupBox_tabDNA_top_writeWindow.Controls.Add(this.button_tabDNA_ShowSaveDataWindow);
         this.groupBox_tabDNA_top_writeWindow.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabDNA_top_writeWindow.Location = new System.Drawing.Point(531, 0);
         this.groupBox_tabDNA_top_writeWindow.Name = "groupBox_tabDNA_top_writeWindow";
         this.groupBox_tabDNA_top_writeWindow.Size = new System.Drawing.Size(135, 150);
         this.groupBox_tabDNA_top_writeWindow.TabIndex = 5;
         this.groupBox_tabDNA_top_writeWindow.TabStop = false;
         this.groupBox_tabDNA_top_writeWindow.Text = "Zapis do pliku";
         // 
         // button_tabDNA_ShowSaveDataWindow
         // 
         this.button_tabDNA_ShowSaveDataWindow.Location = new System.Drawing.Point(6, 19);
         this.button_tabDNA_ShowSaveDataWindow.Name = "button_tabDNA_ShowSaveDataWindow";
         this.button_tabDNA_ShowSaveDataWindow.Size = new System.Drawing.Size(123, 42);
         this.button_tabDNA_ShowSaveDataWindow.TabIndex = 0;
         this.button_tabDNA_ShowSaveDataWindow.Text = "Zapis Danych";
         this.button_tabDNA_ShowSaveDataWindow.UseVisualStyleBackColor = true;
         this.button_tabDNA_ShowSaveDataWindow.Click += new System.EventHandler(this.button_tabDNA_ShowSaveDataWindow_Click);
         // 
         // groupBox_tabDNA_top_viewOptions
         // 
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.panel_tabDNA_top_ORFs);
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.checkBox_tabDNA_ShowAlsoDNA);
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.panel_tabDNA_top_53or35);
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.button_tabDNA_SaveCodingDNAfile);
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.comboBox_tabDNA_DNAlist);
         this.groupBox_tabDNA_top_viewOptions.Controls.Add(this.checkBox_tabDNA_realProteins);
         this.groupBox_tabDNA_top_viewOptions.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabDNA_top_viewOptions.Location = new System.Drawing.Point(142, 0);
         this.groupBox_tabDNA_top_viewOptions.Name = "groupBox_tabDNA_top_viewOptions";
         this.groupBox_tabDNA_top_viewOptions.Size = new System.Drawing.Size(389, 150);
         this.groupBox_tabDNA_top_viewOptions.TabIndex = 3;
         this.groupBox_tabDNA_top_viewOptions.TabStop = false;
         this.groupBox_tabDNA_top_viewOptions.Text = "Podgląd sekwencji (0 wczytanych)";
         // 
         // panel_tabDNA_top_ORFs
         // 
         this.panel_tabDNA_top_ORFs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabDNA_top_ORFs.Controls.Add(this.radioButton_tabDNA_ShowAllFrames);
         this.panel_tabDNA_top_ORFs.Controls.Add(this.radioButton_tabDNA_showFrame0);
         this.panel_tabDNA_top_ORFs.Controls.Add(this.radioButton_tabDNA_showFrame1);
         this.panel_tabDNA_top_ORFs.Controls.Add(this.radioButton_tabDNA_showFrame2);
         this.panel_tabDNA_top_ORFs.Location = new System.Drawing.Point(6, 63);
         this.panel_tabDNA_top_ORFs.Name = "panel_tabDNA_top_ORFs";
         this.panel_tabDNA_top_ORFs.Size = new System.Drawing.Size(252, 46);
         this.panel_tabDNA_top_ORFs.TabIndex = 10;
         // 
         // radioButton_tabDNA_ShowAllFrames
         // 
         this.radioButton_tabDNA_ShowAllFrames.AutoSize = true;
         this.radioButton_tabDNA_ShowAllFrames.Checked = true;
         this.radioButton_tabDNA_ShowAllFrames.Location = new System.Drawing.Point(3, 3);
         this.radioButton_tabDNA_ShowAllFrames.Name = "radioButton_tabDNA_ShowAllFrames";
         this.radioButton_tabDNA_ShowAllFrames.Size = new System.Drawing.Size(196, 17);
         this.radioButton_tabDNA_ShowAllFrames.TabIndex = 3;
         this.radioButton_tabDNA_ShowAllFrames.TabStop = true;
         this.radioButton_tabDNA_ShowAllFrames.Text = "Pokazuj wszystkie dane z sekwencji";
         this.radioButton_tabDNA_ShowAllFrames.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_ShowAllFrames.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_ShowAllFrames_CheckedChanged);
         // 
         // radioButton_tabDNA_showFrame0
         // 
         this.radioButton_tabDNA_showFrame0.AutoSize = true;
         this.radioButton_tabDNA_showFrame0.Location = new System.Drawing.Point(3, 24);
         this.radioButton_tabDNA_showFrame0.Name = "radioButton_tabDNA_showFrame0";
         this.radioButton_tabDNA_showFrame0.Size = new System.Drawing.Size(72, 17);
         this.radioButton_tabDNA_showFrame0.TabIndex = 4;
         this.radioButton_tabDNA_showFrame0.Text = "Frame + 0";
         this.radioButton_tabDNA_showFrame0.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_showFrame0.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_showFrame0_CheckedChanged);
         // 
         // radioButton_tabDNA_showFrame1
         // 
         this.radioButton_tabDNA_showFrame1.AutoSize = true;
         this.radioButton_tabDNA_showFrame1.Location = new System.Drawing.Point(81, 24);
         this.radioButton_tabDNA_showFrame1.Name = "radioButton_tabDNA_showFrame1";
         this.radioButton_tabDNA_showFrame1.Size = new System.Drawing.Size(72, 17);
         this.radioButton_tabDNA_showFrame1.TabIndex = 5;
         this.radioButton_tabDNA_showFrame1.Text = "Frame + 1";
         this.radioButton_tabDNA_showFrame1.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_showFrame1.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_showFrame1_CheckedChanged);
         // 
         // radioButton_tabDNA_showFrame2
         // 
         this.radioButton_tabDNA_showFrame2.AutoSize = true;
         this.radioButton_tabDNA_showFrame2.Location = new System.Drawing.Point(159, 24);
         this.radioButton_tabDNA_showFrame2.Name = "radioButton_tabDNA_showFrame2";
         this.radioButton_tabDNA_showFrame2.Size = new System.Drawing.Size(72, 17);
         this.radioButton_tabDNA_showFrame2.TabIndex = 6;
         this.radioButton_tabDNA_showFrame2.Text = "Frame + 2";
         this.radioButton_tabDNA_showFrame2.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_showFrame2.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_showFrame2_CheckedChanged);
         // 
         // checkBox_tabDNA_ShowAlsoDNA
         // 
         this.checkBox_tabDNA_ShowAlsoDNA.AutoSize = true;
         this.checkBox_tabDNA_ShowAlsoDNA.Checked = true;
         this.checkBox_tabDNA_ShowAlsoDNA.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabDNA_ShowAlsoDNA.Location = new System.Drawing.Point(149, 46);
         this.checkBox_tabDNA_ShowAlsoDNA.Name = "checkBox_tabDNA_ShowAlsoDNA";
         this.checkBox_tabDNA_ShowAlsoDNA.Size = new System.Drawing.Size(82, 17);
         this.checkBox_tabDNA_ShowAlsoDNA.TabIndex = 9;
         this.checkBox_tabDNA_ShowAlsoDNA.Text = "Pokaż DNA";
         this.checkBox_tabDNA_ShowAlsoDNA.UseVisualStyleBackColor = true;
         // 
         // panel_tabDNA_top_53or35
         // 
         this.panel_tabDNA_top_53or35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabDNA_top_53or35.Controls.Add(this.radioButton_tabDNA_BothDirections);
         this.panel_tabDNA_top_53or35.Controls.Add(this.radioButton_tabDNA_3to5);
         this.panel_tabDNA_top_53or35.Controls.Add(this.radioButton_tabDNA_5to3);
         this.panel_tabDNA_top_53or35.Location = new System.Drawing.Point(6, 111);
         this.panel_tabDNA_top_53or35.Name = "panel_tabDNA_top_53or35";
         this.panel_tabDNA_top_53or35.Size = new System.Drawing.Size(252, 26);
         this.panel_tabDNA_top_53or35.TabIndex = 8;
         // 
         // radioButton_tabDNA_BothDirections
         // 
         this.radioButton_tabDNA_BothDirections.AutoSize = true;
         this.radioButton_tabDNA_BothDirections.Location = new System.Drawing.Point(159, 3);
         this.radioButton_tabDNA_BothDirections.Name = "radioButton_tabDNA_BothDirections";
         this.radioButton_tabDNA_BothDirections.Size = new System.Drawing.Size(85, 17);
         this.radioButton_tabDNA_BothDirections.TabIndex = 2;
         this.radioButton_tabDNA_BothDirections.Text = "Oba kierunki";
         this.radioButton_tabDNA_BothDirections.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_BothDirections.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_BothDirections_CheckedChanged);
         // 
         // radioButton_tabDNA_3to5
         // 
         this.radioButton_tabDNA_3to5.AutoSize = true;
         this.radioButton_tabDNA_3to5.Location = new System.Drawing.Point(81, 4);
         this.radioButton_tabDNA_3to5.Name = "radioButton_tabDNA_3to5";
         this.radioButton_tabDNA_3to5.Size = new System.Drawing.Size(56, 17);
         this.radioButton_tabDNA_3to5.TabIndex = 1;
         this.radioButton_tabDNA_3to5.Text = "3\' -> 5\'";
         this.radioButton_tabDNA_3to5.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_3to5.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_3to5_CheckedChanged);
         // 
         // radioButton_tabDNA_5to3
         // 
         this.radioButton_tabDNA_5to3.AutoSize = true;
         this.radioButton_tabDNA_5to3.Checked = true;
         this.radioButton_tabDNA_5to3.Location = new System.Drawing.Point(3, 3);
         this.radioButton_tabDNA_5to3.Name = "radioButton_tabDNA_5to3";
         this.radioButton_tabDNA_5to3.Size = new System.Drawing.Size(56, 17);
         this.radioButton_tabDNA_5to3.TabIndex = 0;
         this.radioButton_tabDNA_5to3.TabStop = true;
         this.radioButton_tabDNA_5to3.Text = "5\' -> 3\'";
         this.radioButton_tabDNA_5to3.UseVisualStyleBackColor = true;
         this.radioButton_tabDNA_5to3.CheckedChanged += new System.EventHandler(this.radioButton_tabDNA_5to3_CheckedChanged);
         // 
         // button_tabDNA_SaveCodingDNAfile
         // 
         this.button_tabDNA_SaveCodingDNAfile.Image = ((System.Drawing.Image)(resources.GetObject("button_tabDNA_SaveCodingDNAfile.Image")));
         this.button_tabDNA_SaveCodingDNAfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabDNA_SaveCodingDNAfile.Location = new System.Drawing.Point(264, 42);
         this.button_tabDNA_SaveCodingDNAfile.Name = "button_tabDNA_SaveCodingDNAfile";
         this.button_tabDNA_SaveCodingDNAfile.Size = new System.Drawing.Size(119, 42);
         this.button_tabDNA_SaveCodingDNAfile.TabIndex = 7;
         this.button_tabDNA_SaveCodingDNAfile.Text = "Zapisz białko\r\ndo pliku    ";
         this.button_tabDNA_SaveCodingDNAfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabDNA_SaveCodingDNAfile.UseVisualStyleBackColor = true;
         this.button_tabDNA_SaveCodingDNAfile.Click += new System.EventHandler(this.button_tabDNA_SaveCodingDNAfile_Click);
         // 
         // comboBox_tabDNA_DNAlist
         // 
         this.comboBox_tabDNA_DNAlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabDNA_DNAlist.FormattingEnabled = true;
         this.comboBox_tabDNA_DNAlist.Location = new System.Drawing.Point(6, 19);
         this.comboBox_tabDNA_DNAlist.Name = "comboBox_tabDNA_DNAlist";
         this.comboBox_tabDNA_DNAlist.Size = new System.Drawing.Size(378, 21);
         this.comboBox_tabDNA_DNAlist.TabIndex = 1;
         this.comboBox_tabDNA_DNAlist.SelectedIndexChanged += new System.EventHandler(this.comboBox_tabDNA_DNAlist_SelectedIndexChanged);
         // 
         // checkBox_tabDNA_realProteins
         // 
         this.checkBox_tabDNA_realProteins.AutoSize = true;
         this.checkBox_tabDNA_realProteins.Checked = true;
         this.checkBox_tabDNA_realProteins.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabDNA_realProteins.Location = new System.Drawing.Point(6, 46);
         this.checkBox_tabDNA_realProteins.Name = "checkBox_tabDNA_realProteins";
         this.checkBox_tabDNA_realProteins.Size = new System.Drawing.Size(137, 17);
         this.checkBox_tabDNA_realProteins.TabIndex = 2;
         this.checkBox_tabDNA_realProteins.Text = "Tylko białka Mel-STOP";
         this.checkBox_tabDNA_realProteins.UseVisualStyleBackColor = true;
         this.checkBox_tabDNA_realProteins.CheckedChanged += new System.EventHandler(this.checkBox_tabDNA_realProteins_CheckedChanged);
         // 
         // groupBox_tabDNA_top_readDNA
         // 
         this.groupBox_tabDNA_top_readDNA.Controls.Add(this.checkBox2Convert);
         this.groupBox_tabDNA_top_readDNA.Controls.Add(this.checkBox_tabDNA_SortDNAbyLength);
         this.groupBox_tabDNA_top_readDNA.Controls.Add(this.button_tabDNA_ReadFastaDNA);
         this.groupBox_tabDNA_top_readDNA.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabDNA_top_readDNA.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabDNA_top_readDNA.Name = "groupBox_tabDNA_top_readDNA";
         this.groupBox_tabDNA_top_readDNA.Size = new System.Drawing.Size(142, 150);
         this.groupBox_tabDNA_top_readDNA.TabIndex = 2;
         this.groupBox_tabDNA_top_readDNA.TabStop = false;
         this.groupBox_tabDNA_top_readDNA.Text = "Wczytywanie danych";
         // 
         // checkBox2Convert
         // 
         this.checkBox2Convert.AutoSize = true;
         this.checkBox2Convert.Checked = true;
         this.checkBox2Convert.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox2Convert.Location = new System.Drawing.Point(6, 120);
         this.checkBox2Convert.Name = "checkBox2Convert";
         this.checkBox2Convert.Size = new System.Drawing.Size(75, 17);
         this.checkBox2Convert.TabIndex = 9;
         this.checkBox2Convert.Text = "Konwersja";
         this.checkBox2Convert.UseVisualStyleBackColor = true;
         // 
         // checkBox_tabDNA_SortDNAbyLength
         // 
         this.checkBox_tabDNA_SortDNAbyLength.AutoSize = true;
         this.checkBox_tabDNA_SortDNAbyLength.Checked = true;
         this.checkBox_tabDNA_SortDNAbyLength.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabDNA_SortDNAbyLength.Location = new System.Drawing.Point(6, 77);
         this.checkBox_tabDNA_SortDNAbyLength.Margin = new System.Windows.Forms.Padding(2);
         this.checkBox_tabDNA_SortDNAbyLength.Name = "checkBox_tabDNA_SortDNAbyLength";
         this.checkBox_tabDNA_SortDNAbyLength.Size = new System.Drawing.Size(121, 17);
         this.checkBox_tabDNA_SortDNAbyLength.TabIndex = 8;
         this.checkBox_tabDNA_SortDNAbyLength.Text = "Sortuj of najdłuższej";
         this.checkBox_tabDNA_SortDNAbyLength.UseVisualStyleBackColor = true;
         // 
         // tabPageMain_Prots
         // 
         this.tabPageMain_Prots.Controls.Add(this.tabControl_tabProtsBottom);
         this.tabPageMain_Prots.Controls.Add(this.panel_tabProt_top);
         this.tabPageMain_Prots.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_Prots.Margin = new System.Windows.Forms.Padding(2);
         this.tabPageMain_Prots.Name = "tabPageMain_Prots";
         this.tabPageMain_Prots.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_Prots.TabIndex = 2;
         this.tabPageMain_Prots.Text = "Analiza białek";
         this.tabPageMain_Prots.UseVisualStyleBackColor = true;
         // 
         // tabControl_tabProtsBottom
         // 
         this.tabControl_tabProtsBottom.Controls.Add(this.tabPage_21);
         this.tabControl_tabProtsBottom.Controls.Add(this.tabPage_22);
         this.tabControl_tabProtsBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl_tabProtsBottom.Location = new System.Drawing.Point(0, 183);
         this.tabControl_tabProtsBottom.Name = "tabControl_tabProtsBottom";
         this.tabControl_tabProtsBottom.SelectedIndex = 0;
         this.tabControl_tabProtsBottom.Size = new System.Drawing.Size(1147, 425);
         this.tabControl_tabProtsBottom.TabIndex = 2;
         // 
         // tabPage_21
         // 
         this.tabPage_21.Controls.Add(this.splitContainer_tabProts);
         this.tabPage_21.Location = new System.Drawing.Point(4, 22);
         this.tabPage_21.Name = "tabPage_21";
         this.tabPage_21.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_21.Size = new System.Drawing.Size(1139, 399);
         this.tabPage_21.TabIndex = 0;
         this.tabPage_21.Text = "Podgląd danych białka";
         this.tabPage_21.UseVisualStyleBackColor = true;
         // 
         // splitContainer_tabProts
         // 
         this.splitContainer_tabProts.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer_tabProts.Location = new System.Drawing.Point(3, 3);
         this.splitContainer_tabProts.Margin = new System.Windows.Forms.Padding(2);
         this.splitContainer_tabProts.Name = "splitContainer_tabProts";
         // 
         // splitContainer_tabProts.Panel1
         // 
         this.splitContainer_tabProts.Panel1.Controls.Add(this.richTextBox_tabProts_protView1);
         // 
         // splitContainer_tabProts.Panel2
         // 
         this.splitContainer_tabProts.Panel2.Controls.Add(this.panel_tabProts_tab1_RightFill_RichTBRight);
         this.splitContainer_tabProts.Panel2.Controls.Add(this.panel_tabProts_tab1_RightTop);
         this.splitContainer_tabProts.Size = new System.Drawing.Size(1133, 393);
         this.splitContainer_tabProts.SplitterDistance = 365;
         this.splitContainer_tabProts.SplitterWidth = 3;
         this.splitContainer_tabProts.TabIndex = 0;
         // 
         // richTextBox_tabProts_protView1
         // 
         this.richTextBox_tabProts_protView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabProts_protView1.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabProts_protView1.Margin = new System.Windows.Forms.Padding(2);
         this.richTextBox_tabProts_protView1.Name = "richTextBox_tabProts_protView1";
         this.richTextBox_tabProts_protView1.Size = new System.Drawing.Size(365, 393);
         this.richTextBox_tabProts_protView1.TabIndex = 0;
         this.richTextBox_tabProts_protView1.Text = "";
         // 
         // panel_tabProts_tab1_RightFill_RichTBRight
         // 
         this.panel_tabProts_tab1_RightFill_RichTBRight.Controls.Add(this.richTextBox_tabProts_proteinBlastView);
         this.panel_tabProts_tab1_RightFill_RichTBRight.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabProts_tab1_RightFill_RichTBRight.Location = new System.Drawing.Point(0, 29);
         this.panel_tabProts_tab1_RightFill_RichTBRight.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabProts_tab1_RightFill_RichTBRight.Name = "panel_tabProts_tab1_RightFill_RichTBRight";
         this.panel_tabProts_tab1_RightFill_RichTBRight.Size = new System.Drawing.Size(765, 364);
         this.panel_tabProts_tab1_RightFill_RichTBRight.TabIndex = 2;
         // 
         // richTextBox_tabProts_proteinBlastView
         // 
         this.richTextBox_tabProts_proteinBlastView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabProts_proteinBlastView.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabProts_proteinBlastView.Margin = new System.Windows.Forms.Padding(2);
         this.richTextBox_tabProts_proteinBlastView.Name = "richTextBox_tabProts_proteinBlastView";
         this.richTextBox_tabProts_proteinBlastView.Size = new System.Drawing.Size(765, 364);
         this.richTextBox_tabProts_proteinBlastView.TabIndex = 0;
         this.richTextBox_tabProts_proteinBlastView.Text = "";
         // 
         // panel_tabProts_tab1_RightTop
         // 
         this.panel_tabProts_tab1_RightTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProts_tab1_RightTop.Controls.Add(this.label_tabProts_1);
         this.panel_tabProts_tab1_RightTop.Controls.Add(this.numericUpDown_tabProts_MaxHitsForBlastP);
         this.panel_tabProts_tab1_RightTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabProts_tab1_RightTop.Location = new System.Drawing.Point(0, 0);
         this.panel_tabProts_tab1_RightTop.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabProts_tab1_RightTop.Name = "panel_tabProts_tab1_RightTop";
         this.panel_tabProts_tab1_RightTop.Size = new System.Drawing.Size(765, 29);
         this.panel_tabProts_tab1_RightTop.TabIndex = 1;
         // 
         // label_tabProts_1
         // 
         this.label_tabProts_1.AutoSize = true;
         this.label_tabProts_1.Location = new System.Drawing.Point(2, 6);
         this.label_tabProts_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label_tabProts_1.Name = "label_tabProts_1";
         this.label_tabProts_1.Size = new System.Drawing.Size(48, 13);
         this.label_tabProts_1.TabIndex = 1;
         this.label_tabProts_1.Text = "MaxHits:";
         // 
         // numericUpDown_tabProts_MaxHitsForBlastP
         // 
         this.numericUpDown_tabProts_MaxHitsForBlastP.Location = new System.Drawing.Point(52, 5);
         this.numericUpDown_tabProts_MaxHitsForBlastP.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabProts_MaxHitsForBlastP.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.numericUpDown_tabProts_MaxHitsForBlastP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDown_tabProts_MaxHitsForBlastP.Name = "numericUpDown_tabProts_MaxHitsForBlastP";
         this.numericUpDown_tabProts_MaxHitsForBlastP.Size = new System.Drawing.Size(46, 20);
         this.numericUpDown_tabProts_MaxHitsForBlastP.TabIndex = 0;
         this.numericUpDown_tabProts_MaxHitsForBlastP.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // tabPage_22
         // 
         this.tabPage_22.Controls.Add(this.panel_tabProt_tab22_Right);
         this.tabPage_22.Controls.Add(this.panel_tabProt_tab22_Left);
         this.tabPage_22.Location = new System.Drawing.Point(4, 22);
         this.tabPage_22.Name = "tabPage_22";
         this.tabPage_22.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_22.Size = new System.Drawing.Size(1139, 399);
         this.tabPage_22.TabIndex = 1;
         this.tabPage_22.Text = "Tabela porównawcza białek";
         this.tabPage_22.UseVisualStyleBackColor = true;
         // 
         // panel_tabProt_tab22_Right
         // 
         this.panel_tabProt_tab22_Right.Controls.Add(this.panel_tabProt_tab22__Right_Internal2);
         this.panel_tabProt_tab22_Right.Controls.Add(this.panel_tabProt_tab22__Right_Internal3);
         this.panel_tabProt_tab22_Right.Controls.Add(this.panel_tabProt_tab22__Right_Internal1);
         this.panel_tabProt_tab22_Right.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabProt_tab22_Right.Location = new System.Drawing.Point(596, 3);
         this.panel_tabProt_tab22_Right.Name = "panel_tabProt_tab22_Right";
         this.panel_tabProt_tab22_Right.Size = new System.Drawing.Size(540, 393);
         this.panel_tabProt_tab22_Right.TabIndex = 1;
         // 
         // panel_tabProt_tab22__Right_Internal2
         // 
         this.panel_tabProt_tab22__Right_Internal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProt_tab22__Right_Internal2.Controls.Add(this.richTextBox_tabProt_SimiliarInfo);
         this.panel_tabProt_tab22__Right_Internal2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabProt_tab22__Right_Internal2.Location = new System.Drawing.Point(0, 111);
         this.panel_tabProt_tab22__Right_Internal2.Name = "panel_tabProt_tab22__Right_Internal2";
         this.panel_tabProt_tab22__Right_Internal2.Size = new System.Drawing.Size(540, 81);
         this.panel_tabProt_tab22__Right_Internal2.TabIndex = 4;
         // 
         // richTextBox_tabProt_SimiliarInfo
         // 
         this.richTextBox_tabProt_SimiliarInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabProt_SimiliarInfo.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabProt_SimiliarInfo.Name = "richTextBox_tabProt_SimiliarInfo";
         this.richTextBox_tabProt_SimiliarInfo.Size = new System.Drawing.Size(538, 79);
         this.richTextBox_tabProt_SimiliarInfo.TabIndex = 0;
         this.richTextBox_tabProt_SimiliarInfo.Text = "";
         // 
         // panel_tabProt_tab22__Right_Internal3
         // 
         this.panel_tabProt_tab22__Right_Internal3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProt_tab22__Right_Internal3.Controls.Add(this.DGV_ProtsComp_Small);
         this.panel_tabProt_tab22__Right_Internal3.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel_tabProt_tab22__Right_Internal3.Location = new System.Drawing.Point(0, 192);
         this.panel_tabProt_tab22__Right_Internal3.Name = "panel_tabProt_tab22__Right_Internal3";
         this.panel_tabProt_tab22__Right_Internal3.Size = new System.Drawing.Size(540, 201);
         this.panel_tabProt_tab22__Right_Internal3.TabIndex = 3;
         // 
         // DGV_ProtsComp_Small
         // 
         this.DGV_ProtsComp_Small.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_ProtsComp_Small.ContextMenuStrip = this.contextMenu_DGV_SmallComp;
         this.DGV_ProtsComp_Small.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_ProtsComp_Small.Location = new System.Drawing.Point(0, 0);
         this.DGV_ProtsComp_Small.Name = "DGV_ProtsComp_Small";
         this.DGV_ProtsComp_Small.Size = new System.Drawing.Size(538, 199);
         this.DGV_ProtsComp_Small.TabIndex = 0;
         this.DGV_ProtsComp_Small.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DGV_ProtsComp_Small_RowPrePaint);
         this.DGV_ProtsComp_Small.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV_ProtsComp_Small_MouseClick);
         // 
         // contextMenu_DGV_SmallComp
         // 
         this.contextMenu_DGV_SmallComp.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.contextMenu_DGV_SmallComp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuICompDNAinLog,
            this.toolStripMenuItemCompProtsInLog,
            this.toolStripMenuItemCompBothInLog,
            this.toolStripMenuAddToList,
            this.toolStripMenuRemoveFromList});
         this.contextMenu_DGV_SmallComp.Name = "contextMenuStrip1";
         this.contextMenu_DGV_SmallComp.Size = new System.Drawing.Size(235, 114);
         // 
         // toolStripMenuICompDNAinLog
         // 
         this.toolStripMenuICompDNAinLog.Name = "toolStripMenuICompDNAinLog";
         this.toolStripMenuICompDNAinLog.Size = new System.Drawing.Size(234, 22);
         this.toolStripMenuICompDNAinLog.Text = "Porównaj DNA";
         this.toolStripMenuICompDNAinLog.Click += new System.EventHandler(this.contextMenu_DGV_PCSmall_CompDNA_Click);
         // 
         // toolStripMenuItemCompProtsInLog
         // 
         this.toolStripMenuItemCompProtsInLog.Name = "toolStripMenuItemCompProtsInLog";
         this.toolStripMenuItemCompProtsInLog.Size = new System.Drawing.Size(234, 22);
         this.toolStripMenuItemCompProtsInLog.Text = "Porównaj sekw. białkowe";
         this.toolStripMenuItemCompProtsInLog.Click += new System.EventHandler(this.contextMenu_DGV_PCSmall_CompProtSeq_Click);
         // 
         // toolStripMenuItemCompBothInLog
         // 
         this.toolStripMenuItemCompBothInLog.Name = "toolStripMenuItemCompBothInLog";
         this.toolStripMenuItemCompBothInLog.Size = new System.Drawing.Size(234, 22);
         this.toolStripMenuItemCompBothInLog.Text = "Porównaj DNA i białka";
         this.toolStripMenuItemCompBothInLog.Click += new System.EventHandler(this.contextMenu_DGV_PCSmall_CompDNAandProtSeqs_Click);
         // 
         // toolStripMenuAddToList
         // 
         this.toolStripMenuAddToList.Name = "toolStripMenuAddToList";
         this.toolStripMenuAddToList.Size = new System.Drawing.Size(234, 22);
         this.toolStripMenuAddToList.Text = "Ignoruj sekwencję";
         this.toolStripMenuAddToList.Click += new System.EventHandler(this.contextMenu_DGV_PCSmall_IgnoreSequence_Click);
         // 
         // toolStripMenuRemoveFromList
         // 
         this.toolStripMenuRemoveFromList.Name = "toolStripMenuRemoveFromList";
         this.toolStripMenuRemoveFromList.Size = new System.Drawing.Size(234, 22);
         this.toolStripMenuRemoveFromList.Text = "Przestań ignorować sekwencję";
         this.toolStripMenuRemoveFromList.Click += new System.EventHandler(this.contextMenu_DGV_PCSmall_StopIgnoring_Click);
         // 
         // panel_tabProt_tab22__Right_Internal1
         // 
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.groupBox1);
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.label_tabProt_LastRemovedNumber);
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.button_tabProt_removeDuplicates);
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.label10);
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.numericUpDown_tabProt_minCzValue);
         this.panel_tabProt_tab22__Right_Internal1.Controls.Add(this.button_tabProt_ReScanProteins);
         this.panel_tabProt_tab22__Right_Internal1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabProt_tab22__Right_Internal1.Location = new System.Drawing.Point(0, 0);
         this.panel_tabProt_tab22__Right_Internal1.Name = "panel_tabProt_tab22__Right_Internal1";
         this.panel_tabProt_tab22__Right_Internal1.Size = new System.Drawing.Size(540, 111);
         this.panel_tabProt_tab22__Right_Internal1.TabIndex = 2;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButton3);
         this.groupBox1.Controls.Add(this.radioButton4);
         this.groupBox1.Location = new System.Drawing.Point(110, 53);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox1.Size = new System.Drawing.Size(146, 51);
         this.groupBox1.TabIndex = 11;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Szukanie duplikatów";
         // 
         // radioButton3
         // 
         this.radioButton3.AutoSize = true;
         this.radioButton3.Checked = true;
         this.radioButton3.Location = new System.Drawing.Point(5, 15);
         this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton3.Name = "radioButton3";
         this.radioButton3.Size = new System.Drawing.Size(142, 17);
         this.radioButton3.TabIndex = 9;
         this.radioButton3.TabStop = true;
         this.radioButton3.Text = "Porównuj kodujące DNA";
         this.radioButton3.UseVisualStyleBackColor = true;
         // 
         // radioButton4
         // 
         this.radioButton4.AutoSize = true;
         this.radioButton4.Location = new System.Drawing.Point(5, 32);
         this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton4.Name = "radioButton4";
         this.radioButton4.Size = new System.Drawing.Size(134, 17);
         this.radioButton4.TabIndex = 10;
         this.radioButton4.Text = "Porównuj główne DNA";
         this.radioButton4.UseVisualStyleBackColor = true;
         // 
         // label_tabProt_LastRemovedNumber
         // 
         this.label_tabProt_LastRemovedNumber.AutoSize = true;
         this.label_tabProt_LastRemovedNumber.Location = new System.Drawing.Point(262, 87);
         this.label_tabProt_LastRemovedNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label_tabProt_LastRemovedNumber.Name = "label_tabProt_LastRemovedNumber";
         this.label_tabProt_LastRemovedNumber.Size = new System.Drawing.Size(112, 13);
         this.label_tabProt_LastRemovedNumber.TabIndex = 7;
         this.label_tabProt_LastRemovedNumber.Text = "Ostatnio usuniętych: 0";
         // 
         // button_tabProt_removeDuplicates
         // 
         this.button_tabProt_removeDuplicates.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_removeDuplicates.Image")));
         this.button_tabProt_removeDuplicates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabProt_removeDuplicates.Location = new System.Drawing.Point(110, 3);
         this.button_tabProt_removeDuplicates.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabProt_removeDuplicates.Name = "button_tabProt_removeDuplicates";
         this.button_tabProt_removeDuplicates.Size = new System.Drawing.Size(99, 46);
         this.button_tabProt_removeDuplicates.TabIndex = 5;
         this.button_tabProt_removeDuplicates.Text = "Usuń   \r\nduplikaty";
         this.button_tabProt_removeDuplicates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_removeDuplicates.UseVisualStyleBackColor = true;
         this.button_tabProt_removeDuplicates.Click += new System.EventHandler(this.button_tabProt_removeDuplicates_Click);
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(5, 67);
         this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(32, 13);
         this.label10.TabIndex = 4;
         this.label10.Text = "Próg:";
         // 
         // numericUpDown_tabProt_minCzValue
         // 
         this.numericUpDown_tabProt_minCzValue.Location = new System.Drawing.Point(8, 81);
         this.numericUpDown_tabProt_minCzValue.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabProt_minCzValue.Name = "numericUpDown_tabProt_minCzValue";
         this.numericUpDown_tabProt_minCzValue.Size = new System.Drawing.Size(57, 20);
         this.numericUpDown_tabProt_minCzValue.TabIndex = 3;
         this.numericUpDown_tabProt_minCzValue.Value = new decimal(new int[] {
            94,
            0,
            0,
            0});
         // 
         // button_tabProt_ReScanProteins
         // 
         this.button_tabProt_ReScanProteins.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_ReScanProteins.Image")));
         this.button_tabProt_ReScanProteins.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabProt_ReScanProteins.Location = new System.Drawing.Point(5, 3);
         this.button_tabProt_ReScanProteins.Name = "button_tabProt_ReScanProteins";
         this.button_tabProt_ReScanProteins.Size = new System.Drawing.Size(99, 46);
         this.button_tabProt_ReScanProteins.TabIndex = 0;
         this.button_tabProt_ReScanProteins.Text = "Odśwież\r\ntabelę  ";
         this.button_tabProt_ReScanProteins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_ReScanProteins.UseVisualStyleBackColor = true;
         this.button_tabProt_ReScanProteins.Click += new System.EventHandler(this.button_tabProt_ReScanProteins_Click);
         // 
         // panel_tabProt_tab22_Left
         // 
         this.panel_tabProt_tab22_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProt_tab22_Left.Controls.Add(this.DGV_ProtsComp_Big);
         this.panel_tabProt_tab22_Left.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel_tabProt_tab22_Left.Location = new System.Drawing.Point(3, 3);
         this.panel_tabProt_tab22_Left.Name = "panel_tabProt_tab22_Left";
         this.panel_tabProt_tab22_Left.Size = new System.Drawing.Size(593, 393);
         this.panel_tabProt_tab22_Left.TabIndex = 0;
         // 
         // DGV_ProtsComp_Big
         // 
         this.DGV_ProtsComp_Big.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_ProtsComp_Big.ContextMenuStrip = this.contextMenu_DGV_BigComp;
         this.DGV_ProtsComp_Big.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_ProtsComp_Big.Location = new System.Drawing.Point(0, 0);
         this.DGV_ProtsComp_Big.Name = "DGV_ProtsComp_Big";
         this.DGV_ProtsComp_Big.ReadOnly = true;
         this.DGV_ProtsComp_Big.Size = new System.Drawing.Size(591, 391);
         this.DGV_ProtsComp_Big.TabIndex = 0;
         this.DGV_ProtsComp_Big.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ProtsComp_Big_CellClick);
         this.DGV_ProtsComp_Big.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DGV_ProtsComp_Big_RowPrePaint);
         this.DGV_ProtsComp_Big.SelectionChanged += new System.EventHandler(this.DGV_ProtsComp_Big_SelectionChanged);
         this.DGV_ProtsComp_Big.Sorted += new System.EventHandler(this.DGV_ProtsComp_Big_Sorted);
         this.DGV_ProtsComp_Big.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV_ProtsComp_Big_MouseClick);
         // 
         // contextMenu_DGV_BigComp
         // 
         this.contextMenu_DGV_BigComp.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.contextMenu_DGV_BigComp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignorujSekwencjęToolStripMenuItem,
            this.przestańIgnorowaćSekwencjęToolStripMenuItem});
         this.contextMenu_DGV_BigComp.Name = "contextMenuStrip3";
         this.contextMenu_DGV_BigComp.Size = new System.Drawing.Size(235, 48);
         // 
         // ignorujSekwencjęToolStripMenuItem
         // 
         this.ignorujSekwencjęToolStripMenuItem.Name = "ignorujSekwencjęToolStripMenuItem";
         this.ignorujSekwencjęToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
         this.ignorujSekwencjęToolStripMenuItem.Text = "Ignoruj sekwencję";
         this.ignorujSekwencjęToolStripMenuItem.Click += new System.EventHandler(this.contextMenu_DGV_BigComp_IgnoreSequence_Click);
         // 
         // przestańIgnorowaćSekwencjęToolStripMenuItem
         // 
         this.przestańIgnorowaćSekwencjęToolStripMenuItem.Name = "przestańIgnorowaćSekwencjęToolStripMenuItem";
         this.przestańIgnorowaćSekwencjęToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
         this.przestańIgnorowaćSekwencjęToolStripMenuItem.Text = "Przestań ignorować sekwencję";
         this.przestańIgnorowaćSekwencjęToolStripMenuItem.Click += new System.EventHandler(this.contextMenu_DGV_BigComp_StopIgnoring_Click);
         // 
         // panel_tabProt_top
         // 
         this.panel_tabProt_top.Controls.Add(this.panel_tabProt_Top_Exp1);
         this.panel_tabProt_top.Controls.Add(this.groupBox_tabProt_top_left);
         this.panel_tabProt_top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabProt_top.Location = new System.Drawing.Point(0, 0);
         this.panel_tabProt_top.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabProt_top.Name = "panel_tabProt_top";
         this.panel_tabProt_top.Size = new System.Drawing.Size(1147, 183);
         this.panel_tabProt_top.TabIndex = 0;
         // 
         // panel_tabProt_Top_Exp1
         // 
         this.panel_tabProt_Top_Exp1.Controls.Add(this.panel_tabProt_Top_Exp2);
         this.panel_tabProt_Top_Exp1.Controls.Add(this.groupBox_tabProt_saveOptions);
         this.panel_tabProt_Top_Exp1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabProt_Top_Exp1.Location = new System.Drawing.Point(489, 0);
         this.panel_tabProt_Top_Exp1.Name = "panel_tabProt_Top_Exp1";
         this.panel_tabProt_Top_Exp1.Size = new System.Drawing.Size(658, 183);
         this.panel_tabProt_Top_Exp1.TabIndex = 3;
         // 
         // panel_tabProt_Top_Exp2
         // 
         this.panel_tabProt_Top_Exp2.Controls.Add(this.groupBox_tabProt_top_chart);
         this.panel_tabProt_Top_Exp2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabProt_Top_Exp2.Location = new System.Drawing.Point(134, 0);
         this.panel_tabProt_Top_Exp2.Name = "panel_tabProt_Top_Exp2";
         this.panel_tabProt_Top_Exp2.Size = new System.Drawing.Size(524, 183);
         this.panel_tabProt_Top_Exp2.TabIndex = 3;
         // 
         // groupBox_tabProt_top_chart
         // 
         this.groupBox_tabProt_top_chart.Controls.Add(this.chart_tabProt_1);
         this.groupBox_tabProt_top_chart.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox_tabProt_top_chart.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabProt_top_chart.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_tabProt_top_chart.Name = "groupBox_tabProt_top_chart";
         this.groupBox_tabProt_top_chart.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_tabProt_top_chart.Size = new System.Drawing.Size(524, 183);
         this.groupBox_tabProt_top_chart.TabIndex = 2;
         this.groupBox_tabProt_top_chart.TabStop = false;
         this.groupBox_tabProt_top_chart.Text = "Aminokwasy";
         // 
         // chart_tabProt_1
         // 
         chartArea1.Name = "ChartArea1";
         this.chart_tabProt_1.ChartAreas.Add(chartArea1);
         this.chart_tabProt_1.Dock = System.Windows.Forms.DockStyle.Fill;
         legend1.Enabled = false;
         legend1.Name = "Legend1";
         this.chart_tabProt_1.Legends.Add(legend1);
         this.chart_tabProt_1.Location = new System.Drawing.Point(2, 15);
         this.chart_tabProt_1.Margin = new System.Windows.Forms.Padding(2);
         this.chart_tabProt_1.Name = "chart_tabProt_1";
         series1.ChartArea = "ChartArea1";
         series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         series1.IsVisibleInLegend = false;
         series1.Legend = "Legend1";
         series1.Name = "Series1";
         this.chart_tabProt_1.Series.Add(series1);
         this.chart_tabProt_1.Size = new System.Drawing.Size(520, 166);
         this.chart_tabProt_1.TabIndex = 2;
         this.chart_tabProt_1.Text = "chart1";
         // 
         // groupBox_tabProt_saveOptions
         // 
         this.groupBox_tabProt_saveOptions.Controls.Add(this.button_tabProt_LoadXML);
         this.groupBox_tabProt_saveOptions.Controls.Add(this.button_tabProt_SaveXML);
         this.groupBox_tabProt_saveOptions.Controls.Add(this.button_tabProt_SaveProteinToFile);
         this.groupBox_tabProt_saveOptions.Controls.Add(this.checkBox_tabProt_WriteAlsoDNAFile);
         this.groupBox_tabProt_saveOptions.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabProt_saveOptions.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabProt_saveOptions.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_tabProt_saveOptions.Name = "groupBox_tabProt_saveOptions";
         this.groupBox_tabProt_saveOptions.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_tabProt_saveOptions.Size = new System.Drawing.Size(134, 183);
         this.groupBox_tabProt_saveOptions.TabIndex = 1;
         this.groupBox_tabProt_saveOptions.TabStop = false;
         this.groupBox_tabProt_saveOptions.Text = "Zapis danych";
         // 
         // button_tabProt_LoadXML
         // 
         this.button_tabProt_LoadXML.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_LoadXML.Image")));
         this.button_tabProt_LoadXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabProt_LoadXML.Location = new System.Drawing.Point(5, 142);
         this.button_tabProt_LoadXML.Name = "button_tabProt_LoadXML";
         this.button_tabProt_LoadXML.Size = new System.Drawing.Size(115, 38);
         this.button_tabProt_LoadXML.TabIndex = 21;
         this.button_tabProt_LoadXML.Text = "Odczyt danych  ";
         this.button_tabProt_LoadXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_LoadXML.UseVisualStyleBackColor = true;
         this.button_tabProt_LoadXML.Click += new System.EventHandler(this.button_tabProt_LoadXML_Click);
         // 
         // button_tabProt_SaveXML
         // 
         this.button_tabProt_SaveXML.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_SaveXML.Image")));
         this.button_tabProt_SaveXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabProt_SaveXML.Location = new System.Drawing.Point(5, 102);
         this.button_tabProt_SaveXML.Name = "button_tabProt_SaveXML";
         this.button_tabProt_SaveXML.Size = new System.Drawing.Size(115, 38);
         this.button_tabProt_SaveXML.TabIndex = 20;
         this.button_tabProt_SaveXML.Text = "Zapis danych    ";
         this.button_tabProt_SaveXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_SaveXML.UseVisualStyleBackColor = true;
         this.button_tabProt_SaveXML.Click += new System.EventHandler(this.button_tabProt_SaveXML_Click);
         // 
         // button_tabProt_SaveProteinToFile
         // 
         this.button_tabProt_SaveProteinToFile.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_SaveProteinToFile.Image")));
         this.button_tabProt_SaveProteinToFile.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
         this.button_tabProt_SaveProteinToFile.Location = new System.Drawing.Point(5, 18);
         this.button_tabProt_SaveProteinToFile.Name = "button_tabProt_SaveProteinToFile";
         this.button_tabProt_SaveProteinToFile.Size = new System.Drawing.Size(115, 50);
         this.button_tabProt_SaveProteinToFile.TabIndex = 18;
         this.button_tabProt_SaveProteinToFile.Text = "Zapisz jako\r\nFASTA   ";
         this.button_tabProt_SaveProteinToFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_SaveProteinToFile.UseVisualStyleBackColor = true;
         this.button_tabProt_SaveProteinToFile.Click += new System.EventHandler(this.button_tabProt_SaveProteinToFile_Click);
         // 
         // checkBox_tabProt_WriteAlsoDNAFile
         // 
         this.checkBox_tabProt_WriteAlsoDNAFile.AutoSize = true;
         this.checkBox_tabProt_WriteAlsoDNAFile.Checked = true;
         this.checkBox_tabProt_WriteAlsoDNAFile.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabProt_WriteAlsoDNAFile.Location = new System.Drawing.Point(5, 73);
         this.checkBox_tabProt_WriteAlsoDNAFile.Margin = new System.Windows.Forms.Padding(2);
         this.checkBox_tabProt_WriteAlsoDNAFile.Name = "checkBox_tabProt_WriteAlsoDNAFile";
         this.checkBox_tabProt_WriteAlsoDNAFile.Size = new System.Drawing.Size(119, 17);
         this.checkBox_tabProt_WriteAlsoDNAFile.TabIndex = 19;
         this.checkBox_tabProt_WriteAlsoDNAFile.Text = "Zapisz też plik DNA";
         this.checkBox_tabProt_WriteAlsoDNAFile.UseVisualStyleBackColor = true;
         // 
         // groupBox_tabProt_top_left
         // 
         this.groupBox_tabProt_top_left.Controls.Add(this.groupBox_tabProt_proteinViewer);
         this.groupBox_tabProt_top_left.Controls.Add(this.panel_tabProt_top_protSizeToRead);
         this.groupBox_tabProt_top_left.Controls.Add(this.panel_tabProt_top_53or35);
         this.groupBox_tabProt_top_left.Controls.Add(this.button_tabProt_SearchProteinsInDNAs);
         this.groupBox_tabProt_top_left.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabProt_top_left.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabProt_top_left.Name = "groupBox_tabProt_top_left";
         this.groupBox_tabProt_top_left.Size = new System.Drawing.Size(489, 183);
         this.groupBox_tabProt_top_left.TabIndex = 0;
         this.groupBox_tabProt_top_left.TabStop = false;
         this.groupBox_tabProt_top_left.Text = "Wyszukiwanie i przeglądanie sekwencji białkowych";
         // 
         // groupBox_tabProt_proteinViewer
         // 
         this.groupBox_tabProt_proteinViewer.Controls.Add(this.radioButton_tabProts_comboUnsort);
         this.groupBox_tabProt_proteinViewer.Controls.Add(this.radioButton_tabProts_comboSortAlfa);
         this.groupBox_tabProt_proteinViewer.Controls.Add(this.checkBox_tabProt_ShowBlastData);
         this.groupBox_tabProt_proteinViewer.Controls.Add(this.checkBox_tabProt_ShowDNA);
         this.groupBox_tabProt_proteinViewer.Controls.Add(this.comboBox_tabProt_ProteinsList);
         this.groupBox_tabProt_proteinViewer.Location = new System.Drawing.Point(5, 114);
         this.groupBox_tabProt_proteinViewer.Name = "groupBox_tabProt_proteinViewer";
         this.groupBox_tabProt_proteinViewer.Size = new System.Drawing.Size(480, 67);
         this.groupBox_tabProt_proteinViewer.TabIndex = 22;
         this.groupBox_tabProt_proteinViewer.TabStop = false;
         this.groupBox_tabProt_proteinViewer.Text = "Lista sekwencji białkowych";
         // 
         // radioButton_tabProts_comboUnsort
         // 
         this.radioButton_tabProts_comboUnsort.AutoSize = true;
         this.radioButton_tabProts_comboUnsort.Checked = true;
         this.radioButton_tabProts_comboUnsort.Location = new System.Drawing.Point(196, 43);
         this.radioButton_tabProts_comboUnsort.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton_tabProts_comboUnsort.Name = "radioButton_tabProts_comboUnsort";
         this.radioButton_tabProts_comboUnsort.Size = new System.Drawing.Size(121, 17);
         this.radioButton_tabProts_comboUnsort.TabIndex = 23;
         this.radioButton_tabProts_comboUnsort.TabStop = true;
         this.radioButton_tabProts_comboUnsort.Text = "Kolejność wczytania";
         this.radioButton_tabProts_comboUnsort.UseVisualStyleBackColor = true;
         this.radioButton_tabProts_comboUnsort.CheckedChanged += new System.EventHandler(this.radioButton_tabProts_comboUnsort_CheckedChanged);
         // 
         // radioButton_tabProts_comboSortAlfa
         // 
         this.radioButton_tabProts_comboSortAlfa.AutoSize = true;
         this.radioButton_tabProts_comboSortAlfa.Location = new System.Drawing.Point(317, 43);
         this.radioButton_tabProts_comboSortAlfa.Margin = new System.Windows.Forms.Padding(2);
         this.radioButton_tabProts_comboSortAlfa.Name = "radioButton_tabProts_comboSortAlfa";
         this.radioButton_tabProts_comboSortAlfa.Size = new System.Drawing.Size(88, 17);
         this.radioButton_tabProts_comboSortAlfa.TabIndex = 22;
         this.radioButton_tabProts_comboSortAlfa.Text = "Alfabetycznie";
         this.radioButton_tabProts_comboSortAlfa.UseVisualStyleBackColor = true;
         this.radioButton_tabProts_comboSortAlfa.CheckedChanged += new System.EventHandler(this.radioButton_tabProts_comboUnsort_CheckedChanged);
         // 
         // checkBox_tabProt_ShowBlastData
         // 
         this.checkBox_tabProt_ShowBlastData.AutoSize = true;
         this.checkBox_tabProt_ShowBlastData.Checked = true;
         this.checkBox_tabProt_ShowBlastData.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabProt_ShowBlastData.Location = new System.Drawing.Point(5, 43);
         this.checkBox_tabProt_ShowBlastData.Margin = new System.Windows.Forms.Padding(2);
         this.checkBox_tabProt_ShowBlastData.Name = "checkBox_tabProt_ShowBlastData";
         this.checkBox_tabProt_ShowBlastData.Size = new System.Drawing.Size(56, 17);
         this.checkBox_tabProt_ShowBlastData.TabIndex = 20;
         this.checkBox_tabProt_ShowBlastData.Text = "BlastP";
         this.checkBox_tabProt_ShowBlastData.UseVisualStyleBackColor = true;
         // 
         // checkBox_tabProt_ShowDNA
         // 
         this.checkBox_tabProt_ShowDNA.AutoSize = true;
         this.checkBox_tabProt_ShowDNA.Location = new System.Drawing.Point(63, 43);
         this.checkBox_tabProt_ShowDNA.Margin = new System.Windows.Forms.Padding(2);
         this.checkBox_tabProt_ShowDNA.Name = "checkBox_tabProt_ShowDNA";
         this.checkBox_tabProt_ShowDNA.Size = new System.Drawing.Size(119, 17);
         this.checkBox_tabProt_ShowDNA.TabIndex = 21;
         this.checkBox_tabProt_ShowDNA.Text = "Pokazuj także DNA";
         this.checkBox_tabProt_ShowDNA.UseVisualStyleBackColor = true;
         // 
         // comboBox_tabProt_ProteinsList
         // 
         this.comboBox_tabProt_ProteinsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabProt_ProteinsList.FormattingEnabled = true;
         this.comboBox_tabProt_ProteinsList.Location = new System.Drawing.Point(5, 18);
         this.comboBox_tabProt_ProteinsList.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_tabProt_ProteinsList.Name = "comboBox_tabProt_ProteinsList";
         this.comboBox_tabProt_ProteinsList.Size = new System.Drawing.Size(471, 21);
         this.comboBox_tabProt_ProteinsList.TabIndex = 0;
         this.comboBox_tabProt_ProteinsList.SelectedIndexChanged += new System.EventHandler(this.comboBox_tabProt_ProteinsList_SelectedIndexChanged);
         // 
         // panel_tabProt_top_protSizeToRead
         // 
         this.panel_tabProt_top_protSizeToRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.label_tabProtMinLength);
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.numericUpDown_tabProt_minLength);
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.radioButton_tabProt_only1Longest);
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.radioButton_tabProt_allLongerThan);
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.checkBox_tabProt_onlyWithSTOP);
         this.panel_tabProt_top_protSizeToRead.Controls.Add(this.checkBox_tabProt_startFromMET);
         this.panel_tabProt_top_protSizeToRead.Location = new System.Drawing.Point(150, 17);
         this.panel_tabProt_top_protSizeToRead.Name = "panel_tabProt_top_protSizeToRead";
         this.panel_tabProt_top_protSizeToRead.Size = new System.Drawing.Size(334, 67);
         this.panel_tabProt_top_protSizeToRead.TabIndex = 17;
         // 
         // label_tabProtMinLength
         // 
         this.label_tabProtMinLength.AutoSize = true;
         this.label_tabProtMinLength.Location = new System.Drawing.Point(3, 24);
         this.label_tabProtMinLength.Name = "label_tabProtMinLength";
         this.label_tabProtMinLength.Size = new System.Drawing.Size(99, 13);
         this.label_tabProtMinLength.TabIndex = 12;
         this.label_tabProtMinLength.Text = "Minimalna długość:";
         // 
         // numericUpDown_tabProt_minLength
         // 
         this.numericUpDown_tabProt_minLength.Location = new System.Drawing.Point(108, 22);
         this.numericUpDown_tabProt_minLength.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
         this.numericUpDown_tabProt_minLength.Name = "numericUpDown_tabProt_minLength";
         this.numericUpDown_tabProt_minLength.Size = new System.Drawing.Size(88, 20);
         this.numericUpDown_tabProt_minLength.TabIndex = 11;
         // 
         // radioButton_tabProt_only1Longest
         // 
         this.radioButton_tabProt_only1Longest.AutoSize = true;
         this.radioButton_tabProt_only1Longest.Checked = true;
         this.radioButton_tabProt_only1Longest.Location = new System.Drawing.Point(6, 43);
         this.radioButton_tabProt_only1Longest.Name = "radioButton_tabProt_only1Longest";
         this.radioButton_tabProt_only1Longest.Size = new System.Drawing.Size(168, 17);
         this.radioButton_tabProt_only1Longest.TabIndex = 13;
         this.radioButton_tabProt_only1Longest.TabStop = true;
         this.radioButton_tabProt_only1Longest.Text = "Tylko 1 najdłuższa sekwencja";
         this.radioButton_tabProt_only1Longest.UseVisualStyleBackColor = true;
         // 
         // radioButton_tabProt_allLongerThan
         // 
         this.radioButton_tabProt_allLongerThan.AutoSize = true;
         this.radioButton_tabProt_allLongerThan.Location = new System.Drawing.Point(178, 43);
         this.radioButton_tabProt_allLongerThan.Name = "radioButton_tabProt_allLongerThan";
         this.radioButton_tabProt_allLongerThan.Size = new System.Drawing.Size(146, 17);
         this.radioButton_tabProt_allLongerThan.TabIndex = 14;
         this.radioButton_tabProt_allLongerThan.Text = "Wszystkie > min. długość";
         this.radioButton_tabProt_allLongerThan.UseVisualStyleBackColor = true;
         // 
         // checkBox_tabProt_onlyWithSTOP
         // 
         this.checkBox_tabProt_onlyWithSTOP.AutoSize = true;
         this.checkBox_tabProt_onlyWithSTOP.Location = new System.Drawing.Point(131, 3);
         this.checkBox_tabProt_onlyWithSTOP.Name = "checkBox_tabProt_onlyWithSTOP";
         this.checkBox_tabProt_onlyWithSTOP.Size = new System.Drawing.Size(139, 17);
         this.checkBox_tabProt_onlyWithSTOP.TabIndex = 10;
         this.checkBox_tabProt_onlyWithSTOP.Text = "Tylko z kodonem STOP";
         this.checkBox_tabProt_onlyWithSTOP.UseVisualStyleBackColor = true;
         // 
         // checkBox_tabProt_startFromMET
         // 
         this.checkBox_tabProt_startFromMET.AutoSize = true;
         this.checkBox_tabProt_startFromMET.Checked = true;
         this.checkBox_tabProt_startFromMET.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBox_tabProt_startFromMET.Location = new System.Drawing.Point(4, 3);
         this.checkBox_tabProt_startFromMET.Name = "checkBox_tabProt_startFromMET";
         this.checkBox_tabProt_startFromMET.Size = new System.Drawing.Size(121, 17);
         this.checkBox_tabProt_startFromMET.TabIndex = 9;
         this.checkBox_tabProt_startFromMET.Text = "Tylko białka od Met";
         this.checkBox_tabProt_startFromMET.UseVisualStyleBackColor = true;
         // 
         // panel_tabProt_top_53or35
         // 
         this.panel_tabProt_top_53or35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabProt_top_53or35.Controls.Add(this.radioButton_tabProt_BothDirections);
         this.panel_tabProt_top_53or35.Controls.Add(this.radioButton_tabProt_3to5);
         this.panel_tabProt_top_53or35.Controls.Add(this.radioButton_tabProt_5to3);
         this.panel_tabProt_top_53or35.Location = new System.Drawing.Point(150, 87);
         this.panel_tabProt_top_53or35.Name = "panel_tabProt_top_53or35";
         this.panel_tabProt_top_53or35.Size = new System.Drawing.Size(334, 26);
         this.panel_tabProt_top_53or35.TabIndex = 16;
         // 
         // radioButton_tabProt_BothDirections
         // 
         this.radioButton_tabProt_BothDirections.AutoSize = true;
         this.radioButton_tabProt_BothDirections.Checked = true;
         this.radioButton_tabProt_BothDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.radioButton_tabProt_BothDirections.Location = new System.Drawing.Point(178, 3);
         this.radioButton_tabProt_BothDirections.Name = "radioButton_tabProt_BothDirections";
         this.radioButton_tabProt_BothDirections.Size = new System.Drawing.Size(97, 17);
         this.radioButton_tabProt_BothDirections.TabIndex = 2;
         this.radioButton_tabProt_BothDirections.TabStop = true;
         this.radioButton_tabProt_BothDirections.Text = "Oba kierunki";
         this.radioButton_tabProt_BothDirections.UseVisualStyleBackColor = true;
         // 
         // radioButton_tabProt_3to5
         // 
         this.radioButton_tabProt_3to5.AutoSize = true;
         this.radioButton_tabProt_3to5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.radioButton_tabProt_3to5.Location = new System.Drawing.Point(93, 3);
         this.radioButton_tabProt_3to5.Name = "radioButton_tabProt_3to5";
         this.radioButton_tabProt_3to5.Size = new System.Drawing.Size(64, 17);
         this.radioButton_tabProt_3to5.TabIndex = 1;
         this.radioButton_tabProt_3to5.Text = "3\' -> 5\'";
         this.radioButton_tabProt_3to5.UseVisualStyleBackColor = true;
         // 
         // radioButton_tabProt_5to3
         // 
         this.radioButton_tabProt_5to3.AutoSize = true;
         this.radioButton_tabProt_5to3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.radioButton_tabProt_5to3.Location = new System.Drawing.Point(6, 3);
         this.radioButton_tabProt_5to3.Name = "radioButton_tabProt_5to3";
         this.radioButton_tabProt_5to3.Size = new System.Drawing.Size(64, 17);
         this.radioButton_tabProt_5to3.TabIndex = 0;
         this.radioButton_tabProt_5to3.Text = "5\' -> 3\'";
         this.radioButton_tabProt_5to3.UseVisualStyleBackColor = true;
         // 
         // button_tabProt_SearchProteinsInDNAs
         // 
         this.button_tabProt_SearchProteinsInDNAs.Image = ((System.Drawing.Image)(resources.GetObject("button_tabProt_SearchProteinsInDNAs.Image")));
         this.button_tabProt_SearchProteinsInDNAs.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
         this.button_tabProt_SearchProteinsInDNAs.Location = new System.Drawing.Point(6, 19);
         this.button_tabProt_SearchProteinsInDNAs.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabProt_SearchProteinsInDNAs.Name = "button_tabProt_SearchProteinsInDNAs";
         this.button_tabProt_SearchProteinsInDNAs.Size = new System.Drawing.Size(122, 48);
         this.button_tabProt_SearchProteinsInDNAs.TabIndex = 0;
         this.button_tabProt_SearchProteinsInDNAs.Text = "Szukaj białek  ";
         this.button_tabProt_SearchProteinsInDNAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabProt_SearchProteinsInDNAs.UseVisualStyleBackColor = true;
         this.button_tabProt_SearchProteinsInDNAs.Click += new System.EventHandler(this.button_tabProt_SearchProteinsInDNAs_Click);
         // 
         // tabPageMain_BlastP
         // 
         this.tabPageMain_BlastP.Controls.Add(this.panel_tabBlastP_bottom);
         this.tabPageMain_BlastP.Controls.Add(this.panel_tabBlastP_top);
         this.tabPageMain_BlastP.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_BlastP.Name = "tabPageMain_BlastP";
         this.tabPageMain_BlastP.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageMain_BlastP.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_BlastP.TabIndex = 1;
         this.tabPageMain_BlastP.Text = "Analiza BlastP";
         this.tabPageMain_BlastP.UseVisualStyleBackColor = true;
         // 
         // panel_tabBlastP_bottom
         // 
         this.panel_tabBlastP_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabBlastP_bottom.Controls.Add(this.splitContainer_tabBlast);
         this.panel_tabBlastP_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabBlastP_bottom.Location = new System.Drawing.Point(3, 161);
         this.panel_tabBlastP_bottom.Name = "panel_tabBlastP_bottom";
         this.panel_tabBlastP_bottom.Size = new System.Drawing.Size(1141, 444);
         this.panel_tabBlastP_bottom.TabIndex = 1;
         // 
         // splitContainer_tabBlast
         // 
         this.splitContainer_tabBlast.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer_tabBlast.Location = new System.Drawing.Point(0, 0);
         this.splitContainer_tabBlast.Name = "splitContainer_tabBlast";
         // 
         // splitContainer_tabBlast.Panel1
         // 
         this.splitContainer_tabBlast.Panel1.Controls.Add(this.DGV_Blast);
         // 
         // splitContainer_tabBlast.Panel2
         // 
         this.splitContainer_tabBlast.Panel2.Controls.Add(this.richTextBox_tabBlastP_blastView);
         this.splitContainer_tabBlast.Size = new System.Drawing.Size(1139, 442);
         this.splitContainer_tabBlast.SplitterDistance = 666;
         this.splitContainer_tabBlast.TabIndex = 0;
         // 
         // DGV_Blast
         // 
         this.DGV_Blast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_Blast.ContextMenuStrip = this.contextMenu_DGV_Blast;
         this.DGV_Blast.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_Blast.Location = new System.Drawing.Point(0, 0);
         this.DGV_Blast.Name = "DGV_Blast";
         this.DGV_Blast.ReadOnly = true;
         this.DGV_Blast.Size = new System.Drawing.Size(666, 442);
         this.DGV_Blast.TabIndex = 0;
         this.DGV_Blast.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Blast_CellClick);
         this.DGV_Blast.SelectionChanged += new System.EventHandler(this.DGV_Blast_SelectionChanged);
         this.DGV_Blast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DGV_Blast_MouseClick);
         // 
         // contextMenu_DGV_Blast
         // 
         this.contextMenu_DGV_Blast.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.contextMenu_DGV_Blast.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuńWynikToolStripMenuItem});
         this.contextMenu_DGV_Blast.Name = "contextMenuStrip2";
         this.contextMenu_DGV_Blast.Size = new System.Drawing.Size(136, 26);
         // 
         // usuńWynikToolStripMenuItem
         // 
         this.usuńWynikToolStripMenuItem.Name = "usuńWynikToolStripMenuItem";
         this.usuńWynikToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
         this.usuńWynikToolStripMenuItem.Text = "Usuń wynik";
         this.usuńWynikToolStripMenuItem.Click += new System.EventHandler(this.contextMenu_DGV_Blast_RemoveRow_Click);
         // 
         // richTextBox_tabBlastP_blastView
         // 
         this.richTextBox_tabBlastP_blastView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabBlastP_blastView.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabBlastP_blastView.Name = "richTextBox_tabBlastP_blastView";
         this.richTextBox_tabBlastP_blastView.Size = new System.Drawing.Size(469, 442);
         this.richTextBox_tabBlastP_blastView.TabIndex = 0;
         this.richTextBox_tabBlastP_blastView.Text = "";
         // 
         // panel_tabBlastP_top
         // 
         this.panel_tabBlastP_top.Controls.Add(this.groupBox_tabBlastP_TopChart);
         this.panel_tabBlastP_top.Controls.Add(this.groupBox_tabBlastP_top_SaveToFile);
         this.panel_tabBlastP_top.Controls.Add(this.groupBox_tabBlastP_top_scanOptions);
         this.panel_tabBlastP_top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabBlastP_top.Location = new System.Drawing.Point(3, 3);
         this.panel_tabBlastP_top.Name = "panel_tabBlastP_top";
         this.panel_tabBlastP_top.Size = new System.Drawing.Size(1141, 158);
         this.panel_tabBlastP_top.TabIndex = 0;
         // 
         // groupBox_tabBlastP_TopChart
         // 
         this.groupBox_tabBlastP_TopChart.Controls.Add(this.chart2);
         this.groupBox_tabBlastP_TopChart.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox_tabBlastP_TopChart.Location = new System.Drawing.Point(591, 0);
         this.groupBox_tabBlastP_TopChart.Name = "groupBox_tabBlastP_TopChart";
         this.groupBox_tabBlastP_TopChart.Size = new System.Drawing.Size(550, 158);
         this.groupBox_tabBlastP_TopChart.TabIndex = 8;
         this.groupBox_tabBlastP_TopChart.TabStop = false;
         this.groupBox_tabBlastP_TopChart.Text = "Skład";
         // 
         // chart2
         // 
         chartArea2.Name = "ChartArea1";
         this.chart2.ChartAreas.Add(chartArea2);
         this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
         legend2.Enabled = false;
         legend2.Name = "Legend1";
         this.chart2.Legends.Add(legend2);
         this.chart2.Location = new System.Drawing.Point(3, 16);
         this.chart2.Margin = new System.Windows.Forms.Padding(2);
         this.chart2.Name = "chart2";
         series2.ChartArea = "ChartArea1";
         series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         series2.IsVisibleInLegend = false;
         series2.Legend = "Legend1";
         series2.Name = "Series1";
         this.chart2.Series.Add(series2);
         this.chart2.Size = new System.Drawing.Size(544, 139);
         this.chart2.TabIndex = 7;
         this.chart2.Text = "chart2";
         // 
         // groupBox_tabBlastP_top_SaveToFile
         // 
         this.groupBox_tabBlastP_top_SaveToFile.Controls.Add(this.button_tabBlastP_Save1);
         this.groupBox_tabBlastP_top_SaveToFile.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabBlastP_top_SaveToFile.Location = new System.Drawing.Point(458, 0);
         this.groupBox_tabBlastP_top_SaveToFile.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_tabBlastP_top_SaveToFile.Name = "groupBox_tabBlastP_top_SaveToFile";
         this.groupBox_tabBlastP_top_SaveToFile.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_tabBlastP_top_SaveToFile.Size = new System.Drawing.Size(133, 158);
         this.groupBox_tabBlastP_top_SaveToFile.TabIndex = 6;
         this.groupBox_tabBlastP_top_SaveToFile.TabStop = false;
         this.groupBox_tabBlastP_top_SaveToFile.Text = "Zapis białek do pliku";
         // 
         // button_tabBlastP_Save1
         // 
         this.button_tabBlastP_Save1.Image = ((System.Drawing.Image)(resources.GetObject("button_tabBlastP_Save1.Image")));
         this.button_tabBlastP_Save1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabBlastP_Save1.Location = new System.Drawing.Point(4, 17);
         this.button_tabBlastP_Save1.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabBlastP_Save1.Name = "button_tabBlastP_Save1";
         this.button_tabBlastP_Save1.Size = new System.Drawing.Size(115, 50);
         this.button_tabBlastP_Save1.TabIndex = 0;
         this.button_tabBlastP_Save1.Text = "Zapisz jako\r\nFASTA   ";
         this.button_tabBlastP_Save1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabBlastP_Save1.UseVisualStyleBackColor = true;
         this.button_tabBlastP_Save1.Click += new System.EventHandler(this.button_tabBlastP_Save1_Click);
         // 
         // groupBox_tabBlastP_top_scanOptions
         // 
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.button_tabBlastP_RefreshDGV);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.numericUpDown_tabBlastP_CompSet);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.numericUpDown_tabBlastP_minCoverage);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.button_tabBlastP_ActivateBlastPscan);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.label4);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.label1);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.textBox_tabBlastP_maxEvalue);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.comboBox_tabBlastP_BlastDBname);
         this.groupBox_tabBlastP_top_scanOptions.Controls.Add(this.label3);
         this.groupBox_tabBlastP_top_scanOptions.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabBlastP_top_scanOptions.Location = new System.Drawing.Point(0, 0);
         this.groupBox_tabBlastP_top_scanOptions.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_tabBlastP_top_scanOptions.Name = "groupBox_tabBlastP_top_scanOptions";
         this.groupBox_tabBlastP_top_scanOptions.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_tabBlastP_top_scanOptions.Size = new System.Drawing.Size(458, 158);
         this.groupBox_tabBlastP_top_scanOptions.TabIndex = 5;
         this.groupBox_tabBlastP_top_scanOptions.TabStop = false;
         this.groupBox_tabBlastP_top_scanOptions.Text = "Opcje skanowania";
         // 
         // button_tabBlastP_RefreshDGV
         // 
         this.button_tabBlastP_RefreshDGV.Location = new System.Drawing.Point(386, 87);
         this.button_tabBlastP_RefreshDGV.Name = "button_tabBlastP_RefreshDGV";
         this.button_tabBlastP_RefreshDGV.Size = new System.Drawing.Size(59, 43);
         this.button_tabBlastP_RefreshDGV.TabIndex = 5;
         this.button_tabBlastP_RefreshDGV.Text = "Odśwież tabelę";
         this.button_tabBlastP_RefreshDGV.UseVisualStyleBackColor = true;
         this.button_tabBlastP_RefreshDGV.Click += new System.EventHandler(this.button_tabBlastP_RefreshDGV_Click);
         // 
         // numericUpDown_tabBlastP_CompSet
         // 
         this.numericUpDown_tabBlastP_CompSet.Location = new System.Drawing.Point(4, 132);
         this.numericUpDown_tabBlastP_CompSet.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabBlastP_CompSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDown_tabBlastP_CompSet.Name = "numericUpDown_tabBlastP_CompSet";
         this.numericUpDown_tabBlastP_CompSet.Size = new System.Drawing.Size(90, 20);
         this.numericUpDown_tabBlastP_CompSet.TabIndex = 4;
         this.numericUpDown_tabBlastP_CompSet.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // numericUpDown_tabBlastP_minCoverage
         // 
         this.numericUpDown_tabBlastP_minCoverage.Location = new System.Drawing.Point(309, 110);
         this.numericUpDown_tabBlastP_minCoverage.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabBlastP_minCoverage.Name = "numericUpDown_tabBlastP_minCoverage";
         this.numericUpDown_tabBlastP_minCoverage.Size = new System.Drawing.Size(72, 20);
         this.numericUpDown_tabBlastP_minCoverage.TabIndex = 4;
         this.numericUpDown_tabBlastP_minCoverage.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
         // 
         // button_tabBlastP_ActivateBlastPscan
         // 
         this.button_tabBlastP_ActivateBlastPscan.Image = ((System.Drawing.Image)(resources.GetObject("button_tabBlastP_ActivateBlastPscan.Image")));
         this.button_tabBlastP_ActivateBlastPscan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabBlastP_ActivateBlastPscan.Location = new System.Drawing.Point(5, 18);
         this.button_tabBlastP_ActivateBlastPscan.Name = "button_tabBlastP_ActivateBlastPscan";
         this.button_tabBlastP_ActivateBlastPscan.Size = new System.Drawing.Size(129, 48);
         this.button_tabBlastP_ActivateBlastPscan.TabIndex = 0;
         this.button_tabBlastP_ActivateBlastPscan.Text = "Uruchom\r\nBlastP ";
         this.button_tabBlastP_ActivateBlastPscan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabBlastP_ActivateBlastPscan.UseVisualStyleBackColor = true;
         this.button_tabBlastP_ActivateBlastPscan.Click += new System.EventHandler(this.button_tabBlastP_ActivateBlastPscan_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(194, 112);
         this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(106, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Min pokrycie (cover):";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(192, 20);
         this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Baza BlastP:";
         // 
         // textBox_tabBlastP_maxEvalue
         // 
         this.textBox_tabBlastP_maxEvalue.ForeColor = System.Drawing.SystemColors.WindowText;
         this.textBox_tabBlastP_maxEvalue.Location = new System.Drawing.Point(309, 87);
         this.textBox_tabBlastP_maxEvalue.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_tabBlastP_maxEvalue.Name = "textBox_tabBlastP_maxEvalue";
         this.textBox_tabBlastP_maxEvalue.Size = new System.Drawing.Size(72, 20);
         this.textBox_tabBlastP_maxEvalue.TabIndex = 2;
         this.textBox_tabBlastP_maxEvalue.Text = "0";
         this.textBox_tabBlastP_maxEvalue.TextChanged += new System.EventHandler(this.textBox_tabBlastP_maxEvalue_TextChanged);
         this.textBox_tabBlastP_maxEvalue.Leave += new System.EventHandler(this.textBox_tabBlastP_maxEvalue_Leave);
         // 
         // comboBox_tabBlastP_BlastDBname
         // 
         this.comboBox_tabBlastP_BlastDBname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabBlastP_BlastDBname.FormattingEnabled = true;
         this.comboBox_tabBlastP_BlastDBname.Items.AddRange(new object[] {
            "Pełna baza sekwencji",
            "Baza sekwencji PDR",
            "Baza sekwencji MDR",
            "Baza sekwencji MRP",
            "Baza sekwencji WBC",
            "Testowa baza danych"});
         this.comboBox_tabBlastP_BlastDBname.Location = new System.Drawing.Point(262, 15);
         this.comboBox_tabBlastP_BlastDBname.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_tabBlastP_BlastDBname.Name = "comboBox_tabBlastP_BlastDBname";
         this.comboBox_tabBlastP_BlastDBname.Size = new System.Drawing.Size(180, 21);
         this.comboBox_tabBlastP_BlastDBname.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(194, 89);
         this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(65, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Max evalue:";
         // 
         // tabPageMain_TX
         // 
         this.tabPageMain_TX.Controls.Add(this.panel_tabTX_BottomForTabControl);
         this.tabPageMain_TX.Controls.Add(this.panel_tabTX_Top);
         this.tabPageMain_TX.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_TX.Margin = new System.Windows.Forms.Padding(2);
         this.tabPageMain_TX.Name = "tabPageMain_TX";
         this.tabPageMain_TX.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_TX.TabIndex = 6;
         this.tabPageMain_TX.Text = "TranslatorX";
         this.tabPageMain_TX.UseVisualStyleBackColor = true;
         // 
         // panel_tabTX_BottomForTabControl
         // 
         this.panel_tabTX_BottomForTabControl.Controls.Add(this.tabControl_tabTX);
         this.panel_tabTX_BottomForTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabTX_BottomForTabControl.Location = new System.Drawing.Point(0, 135);
         this.panel_tabTX_BottomForTabControl.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabTX_BottomForTabControl.Name = "panel_tabTX_BottomForTabControl";
         this.panel_tabTX_BottomForTabControl.Size = new System.Drawing.Size(1147, 473);
         this.panel_tabTX_BottomForTabControl.TabIndex = 1;
         // 
         // tabControl_tabTX
         // 
         this.tabControl_tabTX.Controls.Add(this.tabPage_tabTX_tabAlign);
         this.tabControl_tabTX.Controls.Add(this.tabPage_tabTX_tabSequences);
         this.tabControl_tabTX.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl_tabTX.Location = new System.Drawing.Point(0, 0);
         this.tabControl_tabTX.Name = "tabControl_tabTX";
         this.tabControl_tabTX.SelectedIndex = 0;
         this.tabControl_tabTX.Size = new System.Drawing.Size(1147, 473);
         this.tabControl_tabTX.TabIndex = 3;
         // 
         // tabPage_tabTX_tabAlign
         // 
         this.tabPage_tabTX_tabAlign.Controls.Add(this.panel_tabTX_tabAlign_BottomP);
         this.tabPage_tabTX_tabAlign.Controls.Add(this.panel_tabTX_tabAlign_Top);
         this.tabPage_tabTX_tabAlign.Location = new System.Drawing.Point(4, 22);
         this.tabPage_tabTX_tabAlign.Name = "tabPage_tabTX_tabAlign";
         this.tabPage_tabTX_tabAlign.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_tabTX_tabAlign.Size = new System.Drawing.Size(1139, 447);
         this.tabPage_tabTX_tabAlign.TabIndex = 0;
         this.tabPage_tabTX_tabAlign.Text = "Alignment";
         this.tabPage_tabTX_tabAlign.UseVisualStyleBackColor = true;
         // 
         // panel_tabTX_tabAlign_BottomP
         // 
         this.panel_tabTX_tabAlign_BottomP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tabAlign_BottomP.Controls.Add(this.richTextBox_tabTX_results);
         this.panel_tabTX_tabAlign_BottomP.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabTX_tabAlign_BottomP.Location = new System.Drawing.Point(3, 79);
         this.panel_tabTX_tabAlign_BottomP.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabTX_tabAlign_BottomP.Name = "panel_tabTX_tabAlign_BottomP";
         this.panel_tabTX_tabAlign_BottomP.Size = new System.Drawing.Size(1133, 365);
         this.panel_tabTX_tabAlign_BottomP.TabIndex = 1;
         // 
         // richTextBox_tabTX_results
         // 
         this.richTextBox_tabTX_results.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabTX_results.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabTX_results.Margin = new System.Windows.Forms.Padding(2);
         this.richTextBox_tabTX_results.Name = "richTextBox_tabTX_results";
         this.richTextBox_tabTX_results.Size = new System.Drawing.Size(1131, 363);
         this.richTextBox_tabTX_results.TabIndex = 0;
         this.richTextBox_tabTX_results.Text = "";
         this.richTextBox_tabTX_results.WordWrap = false;
         this.richTextBox_tabTX_results.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox_tabTX_results_ContentsResized);
         this.richTextBox_tabTX_results.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox_tabTX_results_MouseUp);
         // 
         // panel_tabTX_tabAlign_Top
         // 
         this.panel_tabTX_tabAlign_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.comboBox_tabTX_comboSelectAlignForShowAll);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.button1);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.numericUpDown2);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.label16);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.numericUpDown1);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.label2);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.checkBox1);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.panel1);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.label15);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.label14);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.hScrollBar_tabTX);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.numericUpDown_tabTX_frameSize);
         this.panel_tabTX_tabAlign_Top.Controls.Add(this.numericUpDown_tabTX_font);
         this.panel_tabTX_tabAlign_Top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabTX_tabAlign_Top.Location = new System.Drawing.Point(3, 3);
         this.panel_tabTX_tabAlign_Top.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabTX_tabAlign_Top.Name = "panel_tabTX_tabAlign_Top";
         this.panel_tabTX_tabAlign_Top.Size = new System.Drawing.Size(1133, 76);
         this.panel_tabTX_tabAlign_Top.TabIndex = 2;
         // 
         // comboBox_tabTX_comboSelectAlignForShowAll
         // 
         this.comboBox_tabTX_comboSelectAlignForShowAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabTX_comboSelectAlignForShowAll.FormattingEnabled = true;
         this.comboBox_tabTX_comboSelectAlignForShowAll.Items.AddRange(new object[] {
            "Muscle",
            "ClustalW",
            "Mafft",
            "T-Coffee",
            "Prank"});
         this.comboBox_tabTX_comboSelectAlignForShowAll.Location = new System.Drawing.Point(74, 6);
         this.comboBox_tabTX_comboSelectAlignForShowAll.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_tabTX_comboSelectAlignForShowAll.Name = "comboBox_tabTX_comboSelectAlignForShowAll";
         this.comboBox_tabTX_comboSelectAlignForShowAll.Size = new System.Drawing.Size(97, 21);
         this.comboBox_tabTX_comboSelectAlignForShowAll.TabIndex = 14;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(74, 30);
         this.button1.Margin = new System.Windows.Forms.Padding(2);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(96, 23);
         this.button1.TabIndex = 12;
         this.button1.Text = "Pokaż całość";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // numericUpDown2
         // 
         this.numericUpDown2.Location = new System.Drawing.Point(621, 2);
         this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown2.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
         this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDown2.Name = "numericUpDown2";
         this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
         this.numericUpDown2.TabIndex = 13;
         this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label16
         // 
         this.label16.AutoSize = true;
         this.label16.Location = new System.Drawing.Point(583, 2);
         this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(34, 13);
         this.label16.TabIndex = 13;
         this.label16.Text = "do nr:";
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.Location = new System.Drawing.Point(518, 2);
         this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown1.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
         this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDown1.Name = "numericUpDown1";
         this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
         this.numericUpDown1.TabIndex = 12;
         this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(409, 2);
         this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(110, 13);
         this.label2.TabIndex = 12;
         this.label2.Text = "Od białka/kodonu nr:";
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(411, 18);
         this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(142, 17);
         this.checkBox1.TabIndex = 11;
         this.checkBox1.Text = "Zapisz wybrane kolumny";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.radioButton_tabTX_showProts);
         this.panel1.Controls.Add(this.radioButton_tabTX_showDNA);
         this.panel1.Location = new System.Drawing.Point(175, 6);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(102, 47);
         this.panel1.TabIndex = 8;
         // 
         // radioButton_tabTX_showProts
         // 
         this.radioButton_tabTX_showProts.AutoSize = true;
         this.radioButton_tabTX_showProts.Location = new System.Drawing.Point(3, 24);
         this.radioButton_tabTX_showProts.Name = "radioButton_tabTX_showProts";
         this.radioButton_tabTX_showProts.Size = new System.Drawing.Size(84, 17);
         this.radioButton_tabTX_showProts.TabIndex = 1;
         this.radioButton_tabTX_showProts.Text = "Aminokwasy";
         this.radioButton_tabTX_showProts.UseVisualStyleBackColor = true;
         // 
         // radioButton_tabTX_showDNA
         // 
         this.radioButton_tabTX_showDNA.AutoSize = true;
         this.radioButton_tabTX_showDNA.Checked = true;
         this.radioButton_tabTX_showDNA.Location = new System.Drawing.Point(3, 3);
         this.radioButton_tabTX_showDNA.Name = "radioButton_tabTX_showDNA";
         this.radioButton_tabTX_showDNA.Size = new System.Drawing.Size(61, 17);
         this.radioButton_tabTX_showDNA.TabIndex = 0;
         this.radioButton_tabTX_showDNA.TabStop = true;
         this.radioButton_tabTX_showDNA.Text = "Kodony";
         this.radioButton_tabTX_showDNA.UseVisualStyleBackColor = true;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(3, 36);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(43, 13);
         this.label15.TabIndex = 6;
         this.label15.Text = "Zakres:";
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(2, 3);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(54, 13);
         this.label14.TabIndex = 5;
         this.label14.Text = "Czcionka:";
         // 
         // hScrollBar_tabTX
         // 
         this.hScrollBar_tabTX.Location = new System.Drawing.Point(120, 57);
         this.hScrollBar_tabTX.Name = "hScrollBar_tabTX";
         this.hScrollBar_tabTX.Size = new System.Drawing.Size(842, 21);
         this.hScrollBar_tabTX.TabIndex = 3;
         this.hScrollBar_tabTX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_tabTX_Scroll);
         this.hScrollBar_tabTX.ValueChanged += new System.EventHandler(this.hScrollBar_tabTX_ValueChanged);
         this.hScrollBar_tabTX.MouseCaptureChanged += new System.EventHandler(this.hScrollBar_tabTX_MouseCaptureChanged);
         // 
         // numericUpDown_tabTX_frameSize
         // 
         this.numericUpDown_tabTX_frameSize.Location = new System.Drawing.Point(5, 51);
         this.numericUpDown_tabTX_frameSize.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabTX_frameSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
         this.numericUpDown_tabTX_frameSize.Name = "numericUpDown_tabTX_frameSize";
         this.numericUpDown_tabTX_frameSize.Size = new System.Drawing.Size(47, 20);
         this.numericUpDown_tabTX_frameSize.TabIndex = 4;
         this.numericUpDown_tabTX_frameSize.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
         this.numericUpDown_tabTX_frameSize.ValueChanged += new System.EventHandler(this.numericUpDown_tabTX_frameSize_ValueChanged);
         // 
         // numericUpDown_tabTX_font
         // 
         this.numericUpDown_tabTX_font.Location = new System.Drawing.Point(4, 17);
         this.numericUpDown_tabTX_font.Margin = new System.Windows.Forms.Padding(2);
         this.numericUpDown_tabTX_font.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
         this.numericUpDown_tabTX_font.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this.numericUpDown_tabTX_font.Name = "numericUpDown_tabTX_font";
         this.numericUpDown_tabTX_font.Size = new System.Drawing.Size(40, 20);
         this.numericUpDown_tabTX_font.TabIndex = 4;
         this.numericUpDown_tabTX_font.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
         this.numericUpDown_tabTX_font.ValueChanged += new System.EventHandler(this.numericUpDown_tabTX_font_ValueChanged);
         // 
         // tabPage_tabTX_tabSequences
         // 
         this.tabPage_tabTX_tabSequences.Controls.Add(this.splitContainer_tabTX_tab2);
         this.tabPage_tabTX_tabSequences.Location = new System.Drawing.Point(4, 22);
         this.tabPage_tabTX_tabSequences.Name = "tabPage_tabTX_tabSequences";
         this.tabPage_tabTX_tabSequences.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage_tabTX_tabSequences.Size = new System.Drawing.Size(1139, 447);
         this.tabPage_tabTX_tabSequences.TabIndex = 1;
         this.tabPage_tabTX_tabSequences.Text = "Tabela sekwencji";
         this.tabPage_tabTX_tabSequences.UseVisualStyleBackColor = true;
         // 
         // splitContainer_tabTX_tab2
         // 
         this.splitContainer_tabTX_tab2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer_tabTX_tab2.Location = new System.Drawing.Point(3, 3);
         this.splitContainer_tabTX_tab2.Name = "splitContainer_tabTX_tab2";
         // 
         // splitContainer_tabTX_tab2.Panel1
         // 
         this.splitContainer_tabTX_tab2.Panel1.Controls.Add(this.panel_tabTX_tab2_LeftBottom);
         this.splitContainer_tabTX_tab2.Panel1.Controls.Add(this.panel_tabTX_tab2_LeftTop);
         // 
         // splitContainer_tabTX_tab2.Panel2
         // 
         this.splitContainer_tabTX_tab2.Panel2.Controls.Add(this.panel_tabTX_tab2_RightBottom);
         this.splitContainer_tabTX_tab2.Panel2.Controls.Add(this.panel_tabTX_tab2_RightTop);
         this.splitContainer_tabTX_tab2.Size = new System.Drawing.Size(1133, 441);
         this.splitContainer_tabTX_tab2.SplitterDistance = 522;
         this.splitContainer_tabTX_tab2.TabIndex = 0;
         // 
         // panel_tabTX_tab2_LeftBottom
         // 
         this.panel_tabTX_tab2_LeftBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tab2_LeftBottom.Controls.Add(this.DGV_tabTX_Main);
         this.panel_tabTX_tab2_LeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabTX_tab2_LeftBottom.Location = new System.Drawing.Point(0, 100);
         this.panel_tabTX_tab2_LeftBottom.Name = "panel_tabTX_tab2_LeftBottom";
         this.panel_tabTX_tab2_LeftBottom.Size = new System.Drawing.Size(522, 341);
         this.panel_tabTX_tab2_LeftBottom.TabIndex = 1;
         // 
         // DGV_tabTX_Main
         // 
         this.DGV_tabTX_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_tabTX_Main.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_tabTX_Main.Location = new System.Drawing.Point(0, 0);
         this.DGV_tabTX_Main.Name = "DGV_tabTX_Main";
         this.DGV_tabTX_Main.ReadOnly = true;
         this.DGV_tabTX_Main.Size = new System.Drawing.Size(520, 339);
         this.DGV_tabTX_Main.TabIndex = 0;
         // 
         // panel_tabTX_tab2_LeftTop
         // 
         this.panel_tabTX_tab2_LeftTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tab2_LeftTop.Controls.Add(this.textBox2);
         this.panel_tabTX_tab2_LeftTop.Controls.Add(this.button_tabTX_getTXdata);
         this.panel_tabTX_tab2_LeftTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabTX_tab2_LeftTop.Location = new System.Drawing.Point(0, 0);
         this.panel_tabTX_tab2_LeftTop.Name = "panel_tabTX_tab2_LeftTop";
         this.panel_tabTX_tab2_LeftTop.Size = new System.Drawing.Size(522, 100);
         this.panel_tabTX_tab2_LeftTop.TabIndex = 0;
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(303, 14);
         this.textBox2.Multiline = true;
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(184, 79);
         this.textBox2.TabIndex = 1;
         // 
         // button_tabTX_getTXdata
         // 
         this.button_tabTX_getTXdata.Location = new System.Drawing.Point(222, 14);
         this.button_tabTX_getTXdata.Name = "button_tabTX_getTXdata";
         this.button_tabTX_getTXdata.Size = new System.Drawing.Size(75, 36);
         this.button_tabTX_getTXdata.TabIndex = 0;
         this.button_tabTX_getTXdata.Text = "Skopiuj dane";
         this.button_tabTX_getTXdata.UseVisualStyleBackColor = true;
         this.button_tabTX_getTXdata.Click += new System.EventHandler(this.button_tabTX_getTXdata_Click);
         // 
         // panel_tabTX_tab2_RightBottom
         // 
         this.panel_tabTX_tab2_RightBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tab2_RightBottom.Controls.Add(this.DGV_tabTX_Ignored);
         this.panel_tabTX_tab2_RightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabTX_tab2_RightBottom.Location = new System.Drawing.Point(0, 100);
         this.panel_tabTX_tab2_RightBottom.Name = "panel_tabTX_tab2_RightBottom";
         this.panel_tabTX_tab2_RightBottom.Size = new System.Drawing.Size(607, 341);
         this.panel_tabTX_tab2_RightBottom.TabIndex = 1;
         // 
         // DGV_tabTX_Ignored
         // 
         this.DGV_tabTX_Ignored.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_tabTX_Ignored.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_tabTX_Ignored.Location = new System.Drawing.Point(0, 0);
         this.DGV_tabTX_Ignored.Name = "DGV_tabTX_Ignored";
         this.DGV_tabTX_Ignored.ReadOnly = true;
         this.DGV_tabTX_Ignored.Size = new System.Drawing.Size(605, 339);
         this.DGV_tabTX_Ignored.TabIndex = 0;
         // 
         // panel_tabTX_tab2_RightTop
         // 
         this.panel_tabTX_tab2_RightTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_tab2_RightTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabTX_tab2_RightTop.Location = new System.Drawing.Point(0, 0);
         this.panel_tabTX_tab2_RightTop.Name = "panel_tabTX_tab2_RightTop";
         this.panel_tabTX_tab2_RightTop.Size = new System.Drawing.Size(607, 100);
         this.panel_tabTX_tab2_RightTop.TabIndex = 0;
         // 
         // panel_tabTX_Top
         // 
         this.panel_tabTX_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabTX_Top.Controls.Add(this.groupBox_tabTX_saveAlign);
         this.panel_tabTX_Top.Controls.Add(this.groupBox_tabTX_selAminos);
         this.panel_tabTX_Top.Controls.Add(this.groupBox_tabTX_Results);
         this.panel_tabTX_Top.Controls.Add(this.groupBox_tabTX_runTX);
         this.panel_tabTX_Top.Controls.Add(this.groupBox3);
         this.panel_tabTX_Top.Controls.Add(this.button_tabTX_ShowFull);
         this.panel_tabTX_Top.Controls.Add(this.button_tabTX_ShowAlignment);
         this.panel_tabTX_Top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabTX_Top.Location = new System.Drawing.Point(0, 0);
         this.panel_tabTX_Top.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabTX_Top.Name = "panel_tabTX_Top";
         this.panel_tabTX_Top.Size = new System.Drawing.Size(1147, 135);
         this.panel_tabTX_Top.TabIndex = 0;
         // 
         // groupBox_tabTX_saveAlign
         // 
         this.groupBox_tabTX_saveAlign.Controls.Add(this.button_tabTX_savePrank);
         this.groupBox_tabTX_saveAlign.Controls.Add(this.button_tabTX_saveTCoffee);
         this.groupBox_tabTX_saveAlign.Controls.Add(this.button_tabTX_saveMafft);
         this.groupBox_tabTX_saveAlign.Controls.Add(this.button_tabTX_saveMuscle);
         this.groupBox_tabTX_saveAlign.Controls.Add(this.button_tabTX_saveClustalW);
         this.groupBox_tabTX_saveAlign.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabTX_saveAlign.Location = new System.Drawing.Point(600, 0);
         this.groupBox_tabTX_saveAlign.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox_tabTX_saveAlign.Name = "groupBox_tabTX_saveAlign";
         this.groupBox_tabTX_saveAlign.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox_tabTX_saveAlign.Size = new System.Drawing.Size(116, 133);
         this.groupBox_tabTX_saveAlign.TabIndex = 11;
         this.groupBox_tabTX_saveAlign.TabStop = false;
         this.groupBox_tabTX_saveAlign.Text = "Zapisz wyniki";
         // 
         // button_tabTX_savePrank
         // 
         this.button_tabTX_savePrank.Location = new System.Drawing.Point(4, 109);
         this.button_tabTX_savePrank.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_savePrank.Name = "button_tabTX_savePrank";
         this.button_tabTX_savePrank.Size = new System.Drawing.Size(92, 19);
         this.button_tabTX_savePrank.TabIndex = 13;
         this.button_tabTX_savePrank.Text = "Zapis Prank";
         this.button_tabTX_savePrank.UseVisualStyleBackColor = true;
         this.button_tabTX_savePrank.Click += new System.EventHandler(this.button_tabTX_savePrank_Click);
         // 
         // button_tabTX_saveTCoffee
         // 
         this.button_tabTX_saveTCoffee.Location = new System.Drawing.Point(4, 85);
         this.button_tabTX_saveTCoffee.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_saveTCoffee.Name = "button_tabTX_saveTCoffee";
         this.button_tabTX_saveTCoffee.Size = new System.Drawing.Size(92, 19);
         this.button_tabTX_saveTCoffee.TabIndex = 12;
         this.button_tabTX_saveTCoffee.Text = "Zapis T-Coffee";
         this.button_tabTX_saveTCoffee.UseVisualStyleBackColor = true;
         this.button_tabTX_saveTCoffee.Click += new System.EventHandler(this.button_tabTX_saveTCoffee_Click);
         // 
         // button_tabTX_saveMafft
         // 
         this.button_tabTX_saveMafft.Location = new System.Drawing.Point(4, 62);
         this.button_tabTX_saveMafft.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_saveMafft.Name = "button_tabTX_saveMafft";
         this.button_tabTX_saveMafft.Size = new System.Drawing.Size(92, 19);
         this.button_tabTX_saveMafft.TabIndex = 11;
         this.button_tabTX_saveMafft.Text = "Zapis Mafft";
         this.button_tabTX_saveMafft.UseVisualStyleBackColor = true;
         this.button_tabTX_saveMafft.Click += new System.EventHandler(this.button_tabTX_saveMafft_Click);
         // 
         // button_tabTX_saveMuscle
         // 
         this.button_tabTX_saveMuscle.Location = new System.Drawing.Point(4, 16);
         this.button_tabTX_saveMuscle.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_saveMuscle.Name = "button_tabTX_saveMuscle";
         this.button_tabTX_saveMuscle.Size = new System.Drawing.Size(92, 19);
         this.button_tabTX_saveMuscle.TabIndex = 9;
         this.button_tabTX_saveMuscle.Text = "Zapis Muscle";
         this.button_tabTX_saveMuscle.UseVisualStyleBackColor = true;
         this.button_tabTX_saveMuscle.Click += new System.EventHandler(this.button_tabTX_saveMuscle_Click);
         // 
         // button_tabTX_saveClustalW
         // 
         this.button_tabTX_saveClustalW.Location = new System.Drawing.Point(4, 38);
         this.button_tabTX_saveClustalW.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_saveClustalW.Name = "button_tabTX_saveClustalW";
         this.button_tabTX_saveClustalW.Size = new System.Drawing.Size(92, 19);
         this.button_tabTX_saveClustalW.TabIndex = 10;
         this.button_tabTX_saveClustalW.Text = "Zapis ClustalW";
         this.button_tabTX_saveClustalW.UseVisualStyleBackColor = true;
         this.button_tabTX_saveClustalW.Click += new System.EventHandler(this.button_tabTX_saveClustalW_Click);
         // 
         // groupBox_tabTX_selAminos
         // 
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_ColorTrigger);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoV);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoY);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoW);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoT);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoS);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoR);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoQ);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoG);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoP);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoN);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoM);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoL);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoK);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoI);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoH);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoF);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoE);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoD);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoC);
         this.groupBox_tabTX_selAminos.Controls.Add(this.checkBox_aminoA);
         this.groupBox_tabTX_selAminos.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabTX_selAminos.Location = new System.Drawing.Point(330, 0);
         this.groupBox_tabTX_selAminos.Name = "groupBox_tabTX_selAminos";
         this.groupBox_tabTX_selAminos.Size = new System.Drawing.Size(270, 133);
         this.groupBox_tabTX_selAminos.TabIndex = 8;
         this.groupBox_tabTX_selAminos.TabStop = false;
         this.groupBox_tabTX_selAminos.Text = "Aminokwasy do kolorowania";
         // 
         // checkBox_ColorTrigger
         // 
         this.checkBox_ColorTrigger.AutoSize = true;
         this.checkBox_ColorTrigger.Location = new System.Drawing.Point(6, 15);
         this.checkBox_ColorTrigger.Name = "checkBox_ColorTrigger";
         this.checkBox_ColorTrigger.Size = new System.Drawing.Size(162, 17);
         this.checkBox_ColorTrigger.TabIndex = 20;
         this.checkBox_ColorTrigger.Text = "Koloruj wybrane aminokwasy";
         this.checkBox_ColorTrigger.UseVisualStyleBackColor = true;
         this.checkBox_ColorTrigger.CheckedChanged += new System.EventHandler(this.checkBox_ColorTrigger_CheckedChanged);
         // 
         // checkBox_aminoV
         // 
         this.checkBox_aminoV.AutoSize = true;
         this.checkBox_aminoV.Location = new System.Drawing.Point(201, 106);
         this.checkBox_aminoV.Name = "checkBox_aminoV";
         this.checkBox_aminoV.Size = new System.Drawing.Size(57, 17);
         this.checkBox_aminoV.TabIndex = 19;
         this.checkBox_aminoV.Text = "V - Val";
         this.checkBox_aminoV.UseVisualStyleBackColor = true;
         this.checkBox_aminoV.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoY
         // 
         this.checkBox_aminoY.AutoSize = true;
         this.checkBox_aminoY.Location = new System.Drawing.Point(201, 89);
         this.checkBox_aminoY.Name = "checkBox_aminoY";
         this.checkBox_aminoY.Size = new System.Drawing.Size(57, 17);
         this.checkBox_aminoY.TabIndex = 18;
         this.checkBox_aminoY.Text = "Y - Tyr";
         this.checkBox_aminoY.UseVisualStyleBackColor = true;
         this.checkBox_aminoY.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoW
         // 
         this.checkBox_aminoW.AutoSize = true;
         this.checkBox_aminoW.Location = new System.Drawing.Point(201, 72);
         this.checkBox_aminoW.Name = "checkBox_aminoW";
         this.checkBox_aminoW.Size = new System.Drawing.Size(62, 17);
         this.checkBox_aminoW.TabIndex = 17;
         this.checkBox_aminoW.Text = "W - Trp";
         this.checkBox_aminoW.UseVisualStyleBackColor = true;
         this.checkBox_aminoW.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoT
         // 
         this.checkBox_aminoT.AutoSize = true;
         this.checkBox_aminoT.Location = new System.Drawing.Point(201, 55);
         this.checkBox_aminoT.Name = "checkBox_aminoT";
         this.checkBox_aminoT.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoT.TabIndex = 16;
         this.checkBox_aminoT.Text = "T - Thr";
         this.checkBox_aminoT.UseVisualStyleBackColor = true;
         this.checkBox_aminoT.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoS
         // 
         this.checkBox_aminoS.AutoSize = true;
         this.checkBox_aminoS.Location = new System.Drawing.Point(201, 38);
         this.checkBox_aminoS.Name = "checkBox_aminoS";
         this.checkBox_aminoS.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoS.TabIndex = 15;
         this.checkBox_aminoS.Text = "S - Ser";
         this.checkBox_aminoS.UseVisualStyleBackColor = true;
         this.checkBox_aminoS.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoR
         // 
         this.checkBox_aminoR.AutoSize = true;
         this.checkBox_aminoR.Location = new System.Drawing.Point(133, 106);
         this.checkBox_aminoR.Name = "checkBox_aminoR";
         this.checkBox_aminoR.Size = new System.Drawing.Size(59, 17);
         this.checkBox_aminoR.TabIndex = 14;
         this.checkBox_aminoR.Text = "R - Arg";
         this.checkBox_aminoR.UseVisualStyleBackColor = true;
         this.checkBox_aminoR.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoQ
         // 
         this.checkBox_aminoQ.AutoSize = true;
         this.checkBox_aminoQ.Location = new System.Drawing.Point(133, 89);
         this.checkBox_aminoQ.Name = "checkBox_aminoQ";
         this.checkBox_aminoQ.Size = new System.Drawing.Size(59, 17);
         this.checkBox_aminoQ.TabIndex = 13;
         this.checkBox_aminoQ.Text = "Q - Gln";
         this.checkBox_aminoQ.UseVisualStyleBackColor = true;
         this.checkBox_aminoQ.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoG
         // 
         this.checkBox_aminoG.AutoSize = true;
         this.checkBox_aminoG.Location = new System.Drawing.Point(69, 38);
         this.checkBox_aminoG.Name = "checkBox_aminoG";
         this.checkBox_aminoG.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoG.TabIndex = 5;
         this.checkBox_aminoG.Text = "G - Gly";
         this.checkBox_aminoG.UseVisualStyleBackColor = true;
         this.checkBox_aminoG.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoP
         // 
         this.checkBox_aminoP.AutoSize = true;
         this.checkBox_aminoP.Location = new System.Drawing.Point(133, 72);
         this.checkBox_aminoP.Name = "checkBox_aminoP";
         this.checkBox_aminoP.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoP.TabIndex = 12;
         this.checkBox_aminoP.Text = "P - Pro";
         this.checkBox_aminoP.UseVisualStyleBackColor = true;
         this.checkBox_aminoP.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoN
         // 
         this.checkBox_aminoN.AutoSize = true;
         this.checkBox_aminoN.Location = new System.Drawing.Point(133, 55);
         this.checkBox_aminoN.Name = "checkBox_aminoN";
         this.checkBox_aminoN.Size = new System.Drawing.Size(61, 17);
         this.checkBox_aminoN.TabIndex = 11;
         this.checkBox_aminoN.Text = "N - Asn";
         this.checkBox_aminoN.UseVisualStyleBackColor = true;
         this.checkBox_aminoN.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoM
         // 
         this.checkBox_aminoM.AutoSize = true;
         this.checkBox_aminoM.Location = new System.Drawing.Point(133, 38);
         this.checkBox_aminoM.Name = "checkBox_aminoM";
         this.checkBox_aminoM.Size = new System.Drawing.Size(62, 17);
         this.checkBox_aminoM.TabIndex = 10;
         this.checkBox_aminoM.Text = "M - Met";
         this.checkBox_aminoM.UseVisualStyleBackColor = true;
         this.checkBox_aminoM.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoL
         // 
         this.checkBox_aminoL.AutoSize = true;
         this.checkBox_aminoL.Location = new System.Drawing.Point(69, 106);
         this.checkBox_aminoL.Name = "checkBox_aminoL";
         this.checkBox_aminoL.Size = new System.Drawing.Size(59, 17);
         this.checkBox_aminoL.TabIndex = 9;
         this.checkBox_aminoL.Text = "L - Leu";
         this.checkBox_aminoL.UseVisualStyleBackColor = true;
         this.checkBox_aminoL.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoK
         // 
         this.checkBox_aminoK.AutoSize = true;
         this.checkBox_aminoK.Location = new System.Drawing.Point(69, 89);
         this.checkBox_aminoK.Name = "checkBox_aminoK";
         this.checkBox_aminoK.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoK.TabIndex = 8;
         this.checkBox_aminoK.Text = "K - Lys";
         this.checkBox_aminoK.UseVisualStyleBackColor = true;
         this.checkBox_aminoK.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoI
         // 
         this.checkBox_aminoI.AutoSize = true;
         this.checkBox_aminoI.Location = new System.Drawing.Point(69, 72);
         this.checkBox_aminoI.Name = "checkBox_aminoI";
         this.checkBox_aminoI.Size = new System.Drawing.Size(49, 17);
         this.checkBox_aminoI.TabIndex = 7;
         this.checkBox_aminoI.Text = "I - Ile";
         this.checkBox_aminoI.UseVisualStyleBackColor = true;
         this.checkBox_aminoI.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoH
         // 
         this.checkBox_aminoH.AutoSize = true;
         this.checkBox_aminoH.Location = new System.Drawing.Point(69, 55);
         this.checkBox_aminoH.Name = "checkBox_aminoH";
         this.checkBox_aminoH.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoH.TabIndex = 6;
         this.checkBox_aminoH.Text = "H - His";
         this.checkBox_aminoH.UseVisualStyleBackColor = true;
         this.checkBox_aminoH.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoF
         // 
         this.checkBox_aminoF.AutoSize = true;
         this.checkBox_aminoF.Location = new System.Drawing.Point(6, 106);
         this.checkBox_aminoF.Name = "checkBox_aminoF";
         this.checkBox_aminoF.Size = new System.Drawing.Size(60, 17);
         this.checkBox_aminoF.TabIndex = 4;
         this.checkBox_aminoF.Text = "F - Phe";
         this.checkBox_aminoF.UseVisualStyleBackColor = true;
         this.checkBox_aminoF.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoE
         // 
         this.checkBox_aminoE.AutoSize = true;
         this.checkBox_aminoE.Location = new System.Drawing.Point(6, 89);
         this.checkBox_aminoE.Name = "checkBox_aminoE";
         this.checkBox_aminoE.Size = new System.Drawing.Size(58, 17);
         this.checkBox_aminoE.TabIndex = 3;
         this.checkBox_aminoE.Text = "E - Glu";
         this.checkBox_aminoE.UseVisualStyleBackColor = true;
         this.checkBox_aminoE.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoD
         // 
         this.checkBox_aminoD.AutoSize = true;
         this.checkBox_aminoD.Location = new System.Drawing.Point(6, 72);
         this.checkBox_aminoD.Name = "checkBox_aminoD";
         this.checkBox_aminoD.Size = new System.Drawing.Size(61, 17);
         this.checkBox_aminoD.TabIndex = 2;
         this.checkBox_aminoD.Text = "D - Asp";
         this.checkBox_aminoD.UseVisualStyleBackColor = true;
         this.checkBox_aminoD.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoC
         // 
         this.checkBox_aminoC.AutoSize = true;
         this.checkBox_aminoC.Location = new System.Drawing.Point(6, 55);
         this.checkBox_aminoC.Name = "checkBox_aminoC";
         this.checkBox_aminoC.Size = new System.Drawing.Size(59, 17);
         this.checkBox_aminoC.TabIndex = 1;
         this.checkBox_aminoC.Text = "C - Cys";
         this.checkBox_aminoC.UseVisualStyleBackColor = true;
         this.checkBox_aminoC.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // checkBox_aminoA
         // 
         this.checkBox_aminoA.AutoSize = true;
         this.checkBox_aminoA.Location = new System.Drawing.Point(6, 38);
         this.checkBox_aminoA.Name = "checkBox_aminoA";
         this.checkBox_aminoA.Size = new System.Drawing.Size(57, 17);
         this.checkBox_aminoA.TabIndex = 0;
         this.checkBox_aminoA.Text = "A - Ala";
         this.checkBox_aminoA.UseVisualStyleBackColor = true;
         this.checkBox_aminoA.CheckedChanged += new System.EventHandler(this.checkBox_aminoAnyone_CheckedChanged);
         // 
         // groupBox_tabTX_Results
         // 
         this.groupBox_tabTX_Results.Controls.Add(this.checkBoxP);
         this.groupBox_tabTX_Results.Controls.Add(this.checkBoxT);
         this.groupBox_tabTX_Results.Controls.Add(this.checkBoxF);
         this.groupBox_tabTX_Results.Controls.Add(this.checkBoxC);
         this.groupBox_tabTX_Results.Controls.Add(this.checkBoxM);
         this.groupBox_tabTX_Results.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabTX_Results.Location = new System.Drawing.Point(251, 0);
         this.groupBox_tabTX_Results.Name = "groupBox_tabTX_Results";
         this.groupBox_tabTX_Results.Size = new System.Drawing.Size(79, 133);
         this.groupBox_tabTX_Results.TabIndex = 7;
         this.groupBox_tabTX_Results.TabStop = false;
         this.groupBox_tabTX_Results.Text = "Wyniki";
         // 
         // checkBoxP
         // 
         this.checkBoxP.AutoSize = true;
         this.checkBoxP.Enabled = false;
         this.checkBoxP.Location = new System.Drawing.Point(6, 98);
         this.checkBoxP.Name = "checkBoxP";
         this.checkBoxP.Size = new System.Drawing.Size(54, 17);
         this.checkBoxP.TabIndex = 6;
         this.checkBoxP.Text = "Prank";
         this.checkBoxP.UseVisualStyleBackColor = true;
         this.checkBoxP.CheckedChanged += new System.EventHandler(this.checkBoxP_CheckedChanged);
         // 
         // checkBoxT
         // 
         this.checkBoxT.AutoSize = true;
         this.checkBoxT.Enabled = false;
         this.checkBoxT.Location = new System.Drawing.Point(6, 78);
         this.checkBoxT.Name = "checkBoxT";
         this.checkBoxT.Size = new System.Drawing.Size(67, 17);
         this.checkBoxT.TabIndex = 5;
         this.checkBoxT.Text = "T-Coffee";
         this.checkBoxT.UseVisualStyleBackColor = true;
         this.checkBoxT.CheckedChanged += new System.EventHandler(this.checkBoxT_CheckedChanged);
         // 
         // checkBoxF
         // 
         this.checkBoxF.AutoSize = true;
         this.checkBoxF.Enabled = false;
         this.checkBoxF.Location = new System.Drawing.Point(6, 58);
         this.checkBoxF.Name = "checkBoxF";
         this.checkBoxF.Size = new System.Drawing.Size(61, 17);
         this.checkBoxF.TabIndex = 4;
         this.checkBoxF.Text = "MAFFT";
         this.checkBoxF.UseVisualStyleBackColor = true;
         this.checkBoxF.CheckedChanged += new System.EventHandler(this.checkBoxF_CheckedChanged);
         // 
         // checkBoxC
         // 
         this.checkBoxC.AutoSize = true;
         this.checkBoxC.Enabled = false;
         this.checkBoxC.Location = new System.Drawing.Point(6, 38);
         this.checkBoxC.Name = "checkBoxC";
         this.checkBoxC.Size = new System.Drawing.Size(68, 17);
         this.checkBoxC.TabIndex = 3;
         this.checkBoxC.Text = "ClustalW";
         this.checkBoxC.UseVisualStyleBackColor = true;
         this.checkBoxC.CheckedChanged += new System.EventHandler(this.checkBoxC_CheckedChanged);
         // 
         // checkBoxM
         // 
         this.checkBoxM.AutoSize = true;
         this.checkBoxM.Enabled = false;
         this.checkBoxM.Location = new System.Drawing.Point(6, 18);
         this.checkBoxM.Name = "checkBoxM";
         this.checkBoxM.Size = new System.Drawing.Size(60, 17);
         this.checkBoxM.TabIndex = 2;
         this.checkBoxM.Text = "Muscle";
         this.checkBoxM.UseVisualStyleBackColor = true;
         this.checkBoxM.CheckedChanged += new System.EventHandler(this.checkBoxM_CheckedChanged);
         // 
         // groupBox_tabTX_runTX
         // 
         this.groupBox_tabTX_runTX.Controls.Add(this.button_tabTX_loadFromFile);
         this.groupBox_tabTX_runTX.Controls.Add(this.button_tabTX_runTX);
         this.groupBox_tabTX_runTX.Controls.Add(this.comboBox_tabTX_alignMethod);
         this.groupBox_tabTX_runTX.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox_tabTX_runTX.Location = new System.Drawing.Point(142, 0);
         this.groupBox_tabTX_runTX.Name = "groupBox_tabTX_runTX";
         this.groupBox_tabTX_runTX.Size = new System.Drawing.Size(109, 133);
         this.groupBox_tabTX_runTX.TabIndex = 6;
         this.groupBox_tabTX_runTX.TabStop = false;
         this.groupBox_tabTX_runTX.Text = "TranslatorX";
         // 
         // button_tabTX_loadFromFile
         // 
         this.button_tabTX_loadFromFile.Location = new System.Drawing.Point(6, 87);
         this.button_tabTX_loadFromFile.Name = "button_tabTX_loadFromFile";
         this.button_tabTX_loadFromFile.Size = new System.Drawing.Size(95, 37);
         this.button_tabTX_loadFromFile.TabIndex = 7;
         this.button_tabTX_loadFromFile.Text = "Wczytaj plik z alignmentem";
         this.button_tabTX_loadFromFile.UseVisualStyleBackColor = true;
         this.button_tabTX_loadFromFile.Click += new System.EventHandler(this.button_tabTX_loadFromFile_Click);
         // 
         // button_tabTX_runTX
         // 
         this.button_tabTX_runTX.Location = new System.Drawing.Point(6, 18);
         this.button_tabTX_runTX.Name = "button_tabTX_runTX";
         this.button_tabTX_runTX.Size = new System.Drawing.Size(95, 37);
         this.button_tabTX_runTX.TabIndex = 2;
         this.button_tabTX_runTX.Text = "Uruchom TranslatorX";
         this.button_tabTX_runTX.UseVisualStyleBackColor = true;
         this.button_tabTX_runTX.Click += new System.EventHandler(this.button_tabTX_runTX_Click);
         // 
         // comboBox_tabTX_alignMethod
         // 
         this.comboBox_tabTX_alignMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabTX_alignMethod.FormattingEnabled = true;
         this.comboBox_tabTX_alignMethod.Items.AddRange(new object[] {
            "Muscle",
            "ClustalW",
            "MAFFT"});
         this.comboBox_tabTX_alignMethod.Location = new System.Drawing.Point(6, 58);
         this.comboBox_tabTX_alignMethod.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_tabTX_alignMethod.Name = "comboBox_tabTX_alignMethod";
         this.comboBox_tabTX_alignMethod.Size = new System.Drawing.Size(95, 21);
         this.comboBox_tabTX_alignMethod.TabIndex = 1;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.button_tabTX_alignFromBlast);
         this.groupBox3.Controls.Add(this.button_tabTX_alignFromProts);
         this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox3.Location = new System.Drawing.Point(0, 0);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(142, 133);
         this.groupBox3.TabIndex = 5;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Wczytywanie sekwencji";
         // 
         // button_tabTX_alignFromBlast
         // 
         this.button_tabTX_alignFromBlast.Location = new System.Drawing.Point(5, 18);
         this.button_tabTX_alignFromBlast.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_alignFromBlast.Name = "button_tabTX_alignFromBlast";
         this.button_tabTX_alignFromBlast.Size = new System.Drawing.Size(95, 37);
         this.button_tabTX_alignFromBlast.TabIndex = 0;
         this.button_tabTX_alignFromBlast.Text = "Pobierz z wyników BlastP";
         this.button_tabTX_alignFromBlast.UseVisualStyleBackColor = true;
         this.button_tabTX_alignFromBlast.Click += new System.EventHandler(this.button_tabTX_alignFromBlast_Click);
         // 
         // button_tabTX_alignFromProts
         // 
         this.button_tabTX_alignFromProts.Location = new System.Drawing.Point(5, 58);
         this.button_tabTX_alignFromProts.Name = "button_tabTX_alignFromProts";
         this.button_tabTX_alignFromProts.Size = new System.Drawing.Size(95, 37);
         this.button_tabTX_alignFromProts.TabIndex = 4;
         this.button_tabTX_alignFromProts.Text = "Pobierz z bazy białek";
         this.button_tabTX_alignFromProts.UseVisualStyleBackColor = true;
         this.button_tabTX_alignFromProts.Click += new System.EventHandler(this.button_tabTX_alignFromProts_Click);
         // 
         // button_tabTX_ShowFull
         // 
         this.button_tabTX_ShowFull.Location = new System.Drawing.Point(967, 16);
         this.button_tabTX_ShowFull.Name = "button_tabTX_ShowFull";
         this.button_tabTX_ShowFull.Size = new System.Drawing.Size(95, 23);
         this.button_tabTX_ShowFull.TabIndex = 7;
         this.button_tabTX_ShowFull.Text = "Pokaż całość";
         this.button_tabTX_ShowFull.UseVisualStyleBackColor = true;
         this.button_tabTX_ShowFull.Click += new System.EventHandler(this.button_tabTX_ShowFull_Click);
         // 
         // button_tabTX_ShowAlignment
         // 
         this.button_tabTX_ShowAlignment.Location = new System.Drawing.Point(894, 15);
         this.button_tabTX_ShowAlignment.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabTX_ShowAlignment.Name = "button_tabTX_ShowAlignment";
         this.button_tabTX_ShowAlignment.Size = new System.Drawing.Size(68, 37);
         this.button_tabTX_ShowAlignment.TabIndex = 2;
         this.button_tabTX_ShowAlignment.Text = "Reset - Clear";
         this.button_tabTX_ShowAlignment.UseVisualStyleBackColor = true;
         this.button_tabTX_ShowAlignment.Click += new System.EventHandler(this.button_tabTX_ShowAlignment_Click);
         // 
         // tabPageMain_Notepad
         // 
         this.tabPageMain_Notepad.Controls.Add(this.panel_tabOther_1);
         this.tabPageMain_Notepad.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_Notepad.Name = "tabPageMain_Notepad";
         this.tabPageMain_Notepad.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_Notepad.TabIndex = 5;
         this.tabPageMain_Notepad.Text = "Notatnik";
         this.tabPageMain_Notepad.UseVisualStyleBackColor = true;
         // 
         // panel_tabOther_1
         // 
         this.panel_tabOther_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabOther_1.Controls.Add(this.panel_tabOther_Bottom);
         this.panel_tabOther_1.Controls.Add(this.panel_tabOthers_Top);
         this.panel_tabOther_1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabOther_1.Location = new System.Drawing.Point(0, 0);
         this.panel_tabOther_1.Name = "panel_tabOther_1";
         this.panel_tabOther_1.Size = new System.Drawing.Size(1147, 608);
         this.panel_tabOther_1.TabIndex = 0;
         // 
         // panel_tabOther_Bottom
         // 
         this.panel_tabOther_Bottom.Controls.Add(this.splitContainer_tabNotepad);
         this.panel_tabOther_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabOther_Bottom.Location = new System.Drawing.Point(0, 110);
         this.panel_tabOther_Bottom.Name = "panel_tabOther_Bottom";
         this.panel_tabOther_Bottom.Size = new System.Drawing.Size(1145, 496);
         this.panel_tabOther_Bottom.TabIndex = 5;
         // 
         // splitContainer_tabNotepad
         // 
         this.splitContainer_tabNotepad.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer_tabNotepad.Location = new System.Drawing.Point(0, 0);
         this.splitContainer_tabNotepad.Margin = new System.Windows.Forms.Padding(2);
         this.splitContainer_tabNotepad.Name = "splitContainer_tabNotepad";
         // 
         // splitContainer_tabNotepad.Panel1
         // 
         this.splitContainer_tabNotepad.Panel1.Controls.Add(this.richTextBox_tabNotepad_Left);
         // 
         // splitContainer_tabNotepad.Panel2
         // 
         this.splitContainer_tabNotepad.Panel2.Controls.Add(this.richTextBox_tabNotepad_Right);
         this.splitContainer_tabNotepad.Size = new System.Drawing.Size(1145, 496);
         this.splitContainer_tabNotepad.SplitterDistance = 625;
         this.splitContainer_tabNotepad.SplitterWidth = 3;
         this.splitContainer_tabNotepad.TabIndex = 1;
         // 
         // richTextBox_tabNotepad_Left
         // 
         this.richTextBox_tabNotepad_Left.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabNotepad_Left.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabNotepad_Left.Name = "richTextBox_tabNotepad_Left";
         this.richTextBox_tabNotepad_Left.Size = new System.Drawing.Size(625, 496);
         this.richTextBox_tabNotepad_Left.TabIndex = 0;
         this.richTextBox_tabNotepad_Left.Text = "";
         // 
         // richTextBox_tabNotepad_Right
         // 
         this.richTextBox_tabNotepad_Right.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabNotepad_Right.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabNotepad_Right.Margin = new System.Windows.Forms.Padding(2);
         this.richTextBox_tabNotepad_Right.Name = "richTextBox_tabNotepad_Right";
         this.richTextBox_tabNotepad_Right.Size = new System.Drawing.Size(517, 496);
         this.richTextBox_tabNotepad_Right.TabIndex = 0;
         this.richTextBox_tabNotepad_Right.Text = "";
         // 
         // panel_tabOthers_Top
         // 
         this.panel_tabOthers_Top.Controls.Add(this.groupBox_tabOtherAlignments);
         this.panel_tabOthers_Top.Controls.Add(this.groupBox2);
         this.panel_tabOthers_Top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabOthers_Top.Location = new System.Drawing.Point(0, 0);
         this.panel_tabOthers_Top.Name = "panel_tabOthers_Top";
         this.panel_tabOthers_Top.Size = new System.Drawing.Size(1145, 110);
         this.panel_tabOthers_Top.TabIndex = 4;
         // 
         // groupBox_tabOtherAlignments
         // 
         this.groupBox_tabOtherAlignments.Controls.Add(this.label13);
         this.groupBox_tabOtherAlignments.Controls.Add(this.label12);
         this.groupBox_tabOtherAlignments.Controls.Add(this.button_tabNotepad_AlignNW);
         this.groupBox_tabOtherAlignments.Controls.Add(this.textBox_tabOther_Seq2);
         this.groupBox_tabOtherAlignments.Controls.Add(this.panel_tabOther_NWorSW);
         this.groupBox_tabOtherAlignments.Controls.Add(this.textBox_tabOther_Seq1);
         this.groupBox_tabOtherAlignments.Controls.Add(this.button_tabNotepad_ClearTBoxes);
         this.groupBox_tabOtherAlignments.Controls.Add(this.button_tabNotepad_BlastN);
         this.groupBox_tabOtherAlignments.Location = new System.Drawing.Point(4, 0);
         this.groupBox_tabOtherAlignments.Name = "groupBox_tabOtherAlignments";
         this.groupBox_tabOtherAlignments.Size = new System.Drawing.Size(659, 105);
         this.groupBox_tabOtherAlignments.TabIndex = 14;
         this.groupBox_tabOtherAlignments.TabStop = false;
         this.groupBox_tabOtherAlignments.Text = "Dopasowanie";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(460, 14);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(79, 13);
         this.label13.TabIndex = 15;
         this.label13.Text = "Sekwencja #2:";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(265, 14);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(79, 13);
         this.label12.TabIndex = 14;
         this.label12.Text = "Sekwencja #1:";
         // 
         // button_tabNotepad_AlignNW
         // 
         this.button_tabNotepad_AlignNW.Location = new System.Drawing.Point(6, 19);
         this.button_tabNotepad_AlignNW.Name = "button_tabNotepad_AlignNW";
         this.button_tabNotepad_AlignNW.Size = new System.Drawing.Size(75, 23);
         this.button_tabNotepad_AlignNW.TabIndex = 8;
         this.button_tabNotepad_AlignNW.Text = "Align";
         this.button_tabNotepad_AlignNW.UseVisualStyleBackColor = true;
         this.button_tabNotepad_AlignNW.Click += new System.EventHandler(this.button_tabNotepad_AlignNW_Click);
         // 
         // textBox_tabOther_Seq2
         // 
         this.textBox_tabOther_Seq2.Location = new System.Drawing.Point(463, 29);
         this.textBox_tabOther_Seq2.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_tabOther_Seq2.Multiline = true;
         this.textBox_tabOther_Seq2.Name = "textBox_tabOther_Seq2";
         this.textBox_tabOther_Seq2.Size = new System.Drawing.Size(192, 69);
         this.textBox_tabOther_Seq2.TabIndex = 10;
         // 
         // panel_tabOther_NWorSW
         // 
         this.panel_tabOther_NWorSW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabOther_NWorSW.Controls.Add(this.radioButton_tabNotepad_SW);
         this.panel_tabOther_NWorSW.Controls.Add(this.radioButton_tabNotepad_NW);
         this.panel_tabOther_NWorSW.Location = new System.Drawing.Point(6, 48);
         this.panel_tabOther_NWorSW.Name = "panel_tabOther_NWorSW";
         this.panel_tabOther_NWorSW.Size = new System.Drawing.Size(134, 50);
         this.panel_tabOther_NWorSW.TabIndex = 11;
         // 
         // radioButton_tabNotepad_SW
         // 
         this.radioButton_tabNotepad_SW.AutoSize = true;
         this.radioButton_tabNotepad_SW.Enabled = false;
         this.radioButton_tabNotepad_SW.Location = new System.Drawing.Point(3, 26);
         this.radioButton_tabNotepad_SW.Name = "radioButton_tabNotepad_SW";
         this.radioButton_tabNotepad_SW.Size = new System.Drawing.Size(103, 17);
         this.radioButton_tabNotepad_SW.TabIndex = 1;
         this.radioButton_tabNotepad_SW.Text = "Smith-Waterman";
         this.radioButton_tabNotepad_SW.UseVisualStyleBackColor = true;
         // 
         // radioButton_tabNotepad_NW
         // 
         this.radioButton_tabNotepad_NW.AutoSize = true;
         this.radioButton_tabNotepad_NW.Checked = true;
         this.radioButton_tabNotepad_NW.Location = new System.Drawing.Point(3, 3);
         this.radioButton_tabNotepad_NW.Name = "radioButton_tabNotepad_NW";
         this.radioButton_tabNotepad_NW.Size = new System.Drawing.Size(122, 17);
         this.radioButton_tabNotepad_NW.TabIndex = 0;
         this.radioButton_tabNotepad_NW.TabStop = true;
         this.radioButton_tabNotepad_NW.Text = "Needleman-Wunsch";
         this.radioButton_tabNotepad_NW.UseVisualStyleBackColor = true;
         // 
         // textBox_tabOther_Seq1
         // 
         this.textBox_tabOther_Seq1.Location = new System.Drawing.Point(267, 29);
         this.textBox_tabOther_Seq1.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_tabOther_Seq1.Multiline = true;
         this.textBox_tabOther_Seq1.Name = "textBox_tabOther_Seq1";
         this.textBox_tabOther_Seq1.Size = new System.Drawing.Size(192, 69);
         this.textBox_tabOther_Seq1.TabIndex = 9;
         // 
         // button_tabNotepad_ClearTBoxes
         // 
         this.button_tabNotepad_ClearTBoxes.Location = new System.Drawing.Point(168, 19);
         this.button_tabNotepad_ClearTBoxes.Name = "button_tabNotepad_ClearTBoxes";
         this.button_tabNotepad_ClearTBoxes.Size = new System.Drawing.Size(75, 23);
         this.button_tabNotepad_ClearTBoxes.TabIndex = 12;
         this.button_tabNotepad_ClearTBoxes.Text = "Clear";
         this.button_tabNotepad_ClearTBoxes.UseVisualStyleBackColor = true;
         this.button_tabNotepad_ClearTBoxes.Click += new System.EventHandler(this.button_tabNotepad_ClearTBoxes_Click);
         // 
         // button_tabNotepad_BlastN
         // 
         this.button_tabNotepad_BlastN.Location = new System.Drawing.Point(87, 19);
         this.button_tabNotepad_BlastN.Name = "button_tabNotepad_BlastN";
         this.button_tabNotepad_BlastN.Size = new System.Drawing.Size(75, 23);
         this.button_tabNotepad_BlastN.TabIndex = 13;
         this.button_tabNotepad_BlastN.Text = "BlastN";
         this.button_tabNotepad_BlastN.UseVisualStyleBackColor = true;
         this.button_tabNotepad_BlastN.Click += new System.EventHandler(this.button_tabNotepad_BlastN_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.textBox6);
         this.groupBox2.Controls.Add(this.textBox5);
         this.groupBox2.Controls.Add(this.textBox4);
         this.groupBox2.Controls.Add(this.label9);
         this.groupBox2.Controls.Add(this.textBox1);
         this.groupBox2.Controls.Add(this.button_tabNotepad_RemoveDuplicates);
         this.groupBox2.Location = new System.Drawing.Point(668, 0);
         this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
         this.groupBox2.Size = new System.Drawing.Size(406, 80);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Usuwanie duplikatów";
         // 
         // textBox6
         // 
         this.textBox6.Location = new System.Drawing.Point(270, 52);
         this.textBox6.Margin = new System.Windows.Forms.Padding(2);
         this.textBox6.Name = "textBox6";
         this.textBox6.Size = new System.Drawing.Size(123, 20);
         this.textBox6.TabIndex = 5;
         // 
         // textBox5
         // 
         this.textBox5.Location = new System.Drawing.Point(143, 52);
         this.textBox5.Margin = new System.Windows.Forms.Padding(2);
         this.textBox5.Name = "textBox5";
         this.textBox5.Size = new System.Drawing.Size(123, 20);
         this.textBox5.TabIndex = 4;
         // 
         // textBox4
         // 
         this.textBox4.Location = new System.Drawing.Point(270, 30);
         this.textBox4.Margin = new System.Windows.Forms.Padding(2);
         this.textBox4.Name = "textBox4";
         this.textBox4.Size = new System.Drawing.Size(123, 20);
         this.textBox4.TabIndex = 3;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(145, 15);
         this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(121, 13);
         this.label9.TabIndex = 2;
         this.label9.Text = "Działaj na plikach fasta:";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(143, 30);
         this.textBox1.Margin = new System.Windows.Forms.Padding(2);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(123, 20);
         this.textBox1.TabIndex = 1;
         this.textBox1.Text = "blastout";
         // 
         // button_tabNotepad_RemoveDuplicates
         // 
         this.button_tabNotepad_RemoveDuplicates.Location = new System.Drawing.Point(5, 18);
         this.button_tabNotepad_RemoveDuplicates.Name = "button_tabNotepad_RemoveDuplicates";
         this.button_tabNotepad_RemoveDuplicates.Size = new System.Drawing.Size(128, 54);
         this.button_tabNotepad_RemoveDuplicates.TabIndex = 0;
         this.button_tabNotepad_RemoveDuplicates.Text = "Usuń powtarzające się sekwencje z katalogu";
         this.button_tabNotepad_RemoveDuplicates.UseVisualStyleBackColor = true;
         this.button_tabNotepad_RemoveDuplicates.Click += new System.EventHandler(this.button_tabNotepad_RemoveDuplicates_Click);
         // 
         // tabPageMain_BlastDB
         // 
         this.tabPageMain_BlastDB.Controls.Add(this.panel_tabRefDB_bottom);
         this.tabPageMain_BlastDB.Controls.Add(this.panel_tabRefDB_top);
         this.tabPageMain_BlastDB.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_BlastDB.Margin = new System.Windows.Forms.Padding(2);
         this.tabPageMain_BlastDB.Name = "tabPageMain_BlastDB";
         this.tabPageMain_BlastDB.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_BlastDB.TabIndex = 4;
         this.tabPageMain_BlastDB.Text = "Sekwencje Referencyjne";
         this.tabPageMain_BlastDB.UseVisualStyleBackColor = true;
         // 
         // panel_tabRefDB_bottom
         // 
         this.panel_tabRefDB_bottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabRefDB_bottom.Controls.Add(this.splitContainer_tabRefDB);
         this.panel_tabRefDB_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabRefDB_bottom.Location = new System.Drawing.Point(0, 49);
         this.panel_tabRefDB_bottom.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_bottom.Name = "panel_tabRefDB_bottom";
         this.panel_tabRefDB_bottom.Size = new System.Drawing.Size(1147, 559);
         this.panel_tabRefDB_bottom.TabIndex = 1;
         // 
         // splitContainer_tabRefDB
         // 
         this.splitContainer_tabRefDB.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer_tabRefDB.Location = new System.Drawing.Point(0, 0);
         this.splitContainer_tabRefDB.Margin = new System.Windows.Forms.Padding(2);
         this.splitContainer_tabRefDB.Name = "splitContainer_tabRefDB";
         // 
         // splitContainer_tabRefDB.Panel1
         // 
         this.splitContainer_tabRefDB.Panel1.Controls.Add(this.DGV_blastDBs);
         // 
         // splitContainer_tabRefDB.Panel2
         // 
         this.splitContainer_tabRefDB.Panel2.Controls.Add(this.panel_tabRefDB_bottom_rightFill);
         this.splitContainer_tabRefDB.Panel2.Controls.Add(this.panel_tabRefDB_bottom_right);
         this.splitContainer_tabRefDB.Size = new System.Drawing.Size(1145, 557);
         this.splitContainer_tabRefDB.SplitterDistance = 490;
         this.splitContainer_tabRefDB.SplitterWidth = 3;
         this.splitContainer_tabRefDB.TabIndex = 0;
         // 
         // DGV_blastDBs
         // 
         this.DGV_blastDBs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.DGV_blastDBs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DGV_blastDBs.Location = new System.Drawing.Point(0, 0);
         this.DGV_blastDBs.Margin = new System.Windows.Forms.Padding(2);
         this.DGV_blastDBs.Name = "DGV_blastDBs";
         this.DGV_blastDBs.ReadOnly = true;
         this.DGV_blastDBs.RowTemplate.Height = 24;
         this.DGV_blastDBs.Size = new System.Drawing.Size(490, 557);
         this.DGV_blastDBs.TabIndex = 0;
         this.DGV_blastDBs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_blastDBs_CellContentClick);
         this.DGV_blastDBs.SelectionChanged += new System.EventHandler(this.DGV_blastDBs_SelectionChanged);
         // 
         // panel_tabRefDB_bottom_rightFill
         // 
         this.panel_tabRefDB_bottom_rightFill.Controls.Add(this.panel_tabRefDB_tmp2);
         this.panel_tabRefDB_bottom_rightFill.Controls.Add(this.panel_tabRefDB_tmp1);
         this.panel_tabRefDB_bottom_rightFill.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabRefDB_bottom_rightFill.Location = new System.Drawing.Point(0, 55);
         this.panel_tabRefDB_bottom_rightFill.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_bottom_rightFill.Name = "panel_tabRefDB_bottom_rightFill";
         this.panel_tabRefDB_bottom_rightFill.Size = new System.Drawing.Size(652, 502);
         this.panel_tabRefDB_bottom_rightFill.TabIndex = 1;
         // 
         // panel_tabRefDB_tmp2
         // 
         this.panel_tabRefDB_tmp2.Controls.Add(this.textBox_tabRefDB_sequence);
         this.panel_tabRefDB_tmp2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabRefDB_tmp2.Location = new System.Drawing.Point(0, 53);
         this.panel_tabRefDB_tmp2.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_tmp2.Name = "panel_tabRefDB_tmp2";
         this.panel_tabRefDB_tmp2.Size = new System.Drawing.Size(652, 449);
         this.panel_tabRefDB_tmp2.TabIndex = 6;
         // 
         // textBox_tabRefDB_sequence
         // 
         this.textBox_tabRefDB_sequence.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBox_tabRefDB_sequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
         this.textBox_tabRefDB_sequence.Location = new System.Drawing.Point(0, 0);
         this.textBox_tabRefDB_sequence.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_tabRefDB_sequence.Multiline = true;
         this.textBox_tabRefDB_sequence.Name = "textBox_tabRefDB_sequence";
         this.textBox_tabRefDB_sequence.Size = new System.Drawing.Size(652, 449);
         this.textBox_tabRefDB_sequence.TabIndex = 3;
         // 
         // panel_tabRefDB_tmp1
         // 
         this.panel_tabRefDB_tmp1.Controls.Add(this.label6);
         this.panel_tabRefDB_tmp1.Controls.Add(this.button_tabRefDB_ClearFields);
         this.panel_tabRefDB_tmp1.Controls.Add(this.label7);
         this.panel_tabRefDB_tmp1.Controls.Add(this.textBox_tabRefDB_seqID);
         this.panel_tabRefDB_tmp1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabRefDB_tmp1.Location = new System.Drawing.Point(0, 0);
         this.panel_tabRefDB_tmp1.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_tmp1.Name = "panel_tabRefDB_tmp1";
         this.panel_tabRefDB_tmp1.Size = new System.Drawing.Size(652, 53);
         this.panel_tabRefDB_tmp1.TabIndex = 5;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(11, 8);
         this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(68, 13);
         this.label6.TabIndex = 0;
         this.label6.Text = "Identyfikator:";
         // 
         // button_tabRefDB_ClearFields
         // 
         this.button_tabRefDB_ClearFields.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_ClearFields.Image")));
         this.button_tabRefDB_ClearFields.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_ClearFields.Location = new System.Drawing.Point(358, 6);
         this.button_tabRefDB_ClearFields.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_ClearFields.Name = "button_tabRefDB_ClearFields";
         this.button_tabRefDB_ClearFields.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_ClearFields.TabIndex = 4;
         this.button_tabRefDB_ClearFields.Text = "Wyczyść  \r\npola    ";
         this.button_tabRefDB_ClearFields.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_ClearFields.UseVisualStyleBackColor = true;
         this.button_tabRefDB_ClearFields.Click += new System.EventHandler(this.button_tabRefDB_ClearFields_Click);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(11, 31);
         this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(63, 13);
         this.label7.TabIndex = 1;
         this.label7.Text = "Sekwencja:";
         // 
         // textBox_tabRefDB_seqID
         // 
         this.textBox_tabRefDB_seqID.Location = new System.Drawing.Point(82, 6);
         this.textBox_tabRefDB_seqID.Margin = new System.Windows.Forms.Padding(2);
         this.textBox_tabRefDB_seqID.Name = "textBox_tabRefDB_seqID";
         this.textBox_tabRefDB_seqID.Size = new System.Drawing.Size(273, 20);
         this.textBox_tabRefDB_seqID.TabIndex = 2;
         // 
         // panel_tabRefDB_bottom_right
         // 
         this.panel_tabRefDB_bottom_right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabRefDB_bottom_right.Controls.Add(this.button_tabRefDB_RemoveSeq);
         this.panel_tabRefDB_bottom_right.Controls.Add(this.button_tabRefDB_AddFastaFile);
         this.panel_tabRefDB_bottom_right.Controls.Add(this.button_tabRefDB_CompileDB);
         this.panel_tabRefDB_bottom_right.Controls.Add(this.button_tabRefDB_EditRow);
         this.panel_tabRefDB_bottom_right.Controls.Add(this.button_tabRefDB_AddNewProt);
         this.panel_tabRefDB_bottom_right.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabRefDB_bottom_right.Location = new System.Drawing.Point(0, 0);
         this.panel_tabRefDB_bottom_right.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_bottom_right.Name = "panel_tabRefDB_bottom_right";
         this.panel_tabRefDB_bottom_right.Size = new System.Drawing.Size(652, 55);
         this.panel_tabRefDB_bottom_right.TabIndex = 0;
         // 
         // button_tabRefDB_RemoveSeq
         // 
         this.button_tabRefDB_RemoveSeq.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_RemoveSeq.Image")));
         this.button_tabRefDB_RemoveSeq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_RemoveSeq.Location = new System.Drawing.Point(108, 6);
         this.button_tabRefDB_RemoveSeq.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_RemoveSeq.Name = "button_tabRefDB_RemoveSeq";
         this.button_tabRefDB_RemoveSeq.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_RemoveSeq.TabIndex = 4;
         this.button_tabRefDB_RemoveSeq.Text = "Usuń     \r\nsekwencję";
         this.button_tabRefDB_RemoveSeq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_RemoveSeq.UseVisualStyleBackColor = true;
         this.button_tabRefDB_RemoveSeq.Click += new System.EventHandler(this.button_tabRefDB_RemoveSeq_Click);
         // 
         // button_tabRefDB_AddFastaFile
         // 
         this.button_tabRefDB_AddFastaFile.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_AddFastaFile.Image")));
         this.button_tabRefDB_AddFastaFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_AddFastaFile.Location = new System.Drawing.Point(320, 6);
         this.button_tabRefDB_AddFastaFile.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_AddFastaFile.Name = "button_tabRefDB_AddFastaFile";
         this.button_tabRefDB_AddFastaFile.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_AddFastaFile.TabIndex = 3;
         this.button_tabRefDB_AddFastaFile.Text = "Wczytaj z\r\nFASTA  ";
         this.button_tabRefDB_AddFastaFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_AddFastaFile.UseVisualStyleBackColor = true;
         this.button_tabRefDB_AddFastaFile.Click += new System.EventHandler(this.button_tabRefDB_AddFastaFile_Click);
         // 
         // button_tabRefDB_CompileDB
         // 
         this.button_tabRefDB_CompileDB.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_CompileDB.Image")));
         this.button_tabRefDB_CompileDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_CompileDB.Location = new System.Drawing.Point(426, 6);
         this.button_tabRefDB_CompileDB.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_CompileDB.Name = "button_tabRefDB_CompileDB";
         this.button_tabRefDB_CompileDB.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_CompileDB.TabIndex = 2;
         this.button_tabRefDB_CompileDB.Text = "Kompiluj  \r\nbazę    ";
         this.button_tabRefDB_CompileDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_CompileDB.UseVisualStyleBackColor = true;
         this.button_tabRefDB_CompileDB.Click += new System.EventHandler(this.button_tabRefDB_CompileDB_Click);
         // 
         // button_tabRefDB_EditRow
         // 
         this.button_tabRefDB_EditRow.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_EditRow.Image")));
         this.button_tabRefDB_EditRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_EditRow.Location = new System.Drawing.Point(214, 6);
         this.button_tabRefDB_EditRow.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_EditRow.Name = "button_tabRefDB_EditRow";
         this.button_tabRefDB_EditRow.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_EditRow.TabIndex = 1;
         this.button_tabRefDB_EditRow.Text = "Aktualizuj \r\nsekwencję";
         this.button_tabRefDB_EditRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_EditRow.UseVisualStyleBackColor = true;
         this.button_tabRefDB_EditRow.Click += new System.EventHandler(this.button_tabRefDB_EditRow_Click);
         // 
         // button_tabRefDB_AddNewProt
         // 
         this.button_tabRefDB_AddNewProt.Image = ((System.Drawing.Image)(resources.GetObject("button_tabRefDB_AddNewProt.Image")));
         this.button_tabRefDB_AddNewProt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.button_tabRefDB_AddNewProt.Location = new System.Drawing.Point(2, 6);
         this.button_tabRefDB_AddNewProt.Margin = new System.Windows.Forms.Padding(2);
         this.button_tabRefDB_AddNewProt.Name = "button_tabRefDB_AddNewProt";
         this.button_tabRefDB_AddNewProt.Size = new System.Drawing.Size(102, 44);
         this.button_tabRefDB_AddNewProt.TabIndex = 0;
         this.button_tabRefDB_AddNewProt.Text = "Dodaj jako\r\nnową    ";
         this.button_tabRefDB_AddNewProt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.button_tabRefDB_AddNewProt.UseVisualStyleBackColor = true;
         this.button_tabRefDB_AddNewProt.Click += new System.EventHandler(this.button_tabRefDB_AddNewProt_Click);
         // 
         // panel_tabRefDB_top
         // 
         this.panel_tabRefDB_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabRefDB_top.Controls.Add(this.label8);
         this.panel_tabRefDB_top.Controls.Add(this.comboBox_tabDB_BaseSelection);
         this.panel_tabRefDB_top.Controls.Add(this.label5);
         this.panel_tabRefDB_top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabRefDB_top.Location = new System.Drawing.Point(0, 0);
         this.panel_tabRefDB_top.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabRefDB_top.Name = "panel_tabRefDB_top";
         this.panel_tabRefDB_top.Size = new System.Drawing.Size(1147, 49);
         this.panel_tabRefDB_top.TabIndex = 0;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(6, 30);
         this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(163, 13);
         this.label8.TabIndex = 2;
         this.label8.Text = "Liczba sekwencji referencyjnych:";
         // 
         // comboBox_tabDB_BaseSelection
         // 
         this.comboBox_tabDB_BaseSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_tabDB_BaseSelection.FormattingEnabled = true;
         this.comboBox_tabDB_BaseSelection.Items.AddRange(new object[] {
            "Pełna baza sekwencji",
            "Baza sekwencji PDR",
            "Baza sekwencji MDR",
            "Baza sekwencji MRP",
            "Baza sekwencji WBC",
            "Testowa baza danych"});
         this.comboBox_tabDB_BaseSelection.Location = new System.Drawing.Point(164, 7);
         this.comboBox_tabDB_BaseSelection.Margin = new System.Windows.Forms.Padding(2);
         this.comboBox_tabDB_BaseSelection.Name = "comboBox_tabDB_BaseSelection";
         this.comboBox_tabDB_BaseSelection.Size = new System.Drawing.Size(222, 21);
         this.comboBox_tabDB_BaseSelection.TabIndex = 1;
         this.comboBox_tabDB_BaseSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox_tabDB_BaseSelection_SelectedIndexChanged);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(5, 10);
         this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(156, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Baza sekwencji referencyjnych:";
         // 
         // tabPageMain_Log
         // 
         this.tabPageMain_Log.Controls.Add(this.panel_tabLog_bottom);
         this.tabPageMain_Log.Controls.Add(this.panel_tabLog_top);
         this.tabPageMain_Log.Location = new System.Drawing.Point(4, 22);
         this.tabPageMain_Log.Margin = new System.Windows.Forms.Padding(2);
         this.tabPageMain_Log.Name = "tabPageMain_Log";
         this.tabPageMain_Log.Size = new System.Drawing.Size(1147, 608);
         this.tabPageMain_Log.TabIndex = 3;
         this.tabPageMain_Log.Text = "Raporty programu";
         this.tabPageMain_Log.UseVisualStyleBackColor = true;
         // 
         // panel_tabLog_bottom
         // 
         this.panel_tabLog_bottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel_tabLog_bottom.Controls.Add(this.richTextBox_tabLog);
         this.panel_tabLog_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel_tabLog_bottom.Location = new System.Drawing.Point(0, 52);
         this.panel_tabLog_bottom.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabLog_bottom.Name = "panel_tabLog_bottom";
         this.panel_tabLog_bottom.Size = new System.Drawing.Size(1147, 556);
         this.panel_tabLog_bottom.TabIndex = 1;
         // 
         // richTextBox_tabLog
         // 
         this.richTextBox_tabLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBox_tabLog.Location = new System.Drawing.Point(0, 0);
         this.richTextBox_tabLog.Margin = new System.Windows.Forms.Padding(2);
         this.richTextBox_tabLog.Name = "richTextBox_tabLog";
         this.richTextBox_tabLog.Size = new System.Drawing.Size(1143, 552);
         this.richTextBox_tabLog.TabIndex = 0;
         this.richTextBox_tabLog.Text = "";
         // 
         // panel_tabLog_top
         // 
         this.panel_tabLog_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel_tabLog_top.Controls.Add(this.label11);
         this.panel_tabLog_top.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel_tabLog_top.Location = new System.Drawing.Point(0, 0);
         this.panel_tabLog_top.Margin = new System.Windows.Forms.Padding(2);
         this.panel_tabLog_top.Name = "panel_tabLog_top";
         this.panel_tabLog_top.Size = new System.Drawing.Size(1147, 52);
         this.panel_tabLog_top.TabIndex = 0;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(16, 19);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(285, 13);
         this.label11.TabIndex = 0;
         this.label11.Text = "Tylko log, inne elementy przeniesione do zakładki Notatnik";
         // 
         // toolStripContainer1
         // 
         // 
         // toolStripContainer1.BottomToolStripPanel
         // 
         this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
         // 
         // toolStripContainer1.ContentPanel
         // 
         this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
         this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1155, 634);
         this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
         this.toolStripContainer1.Name = "toolStripContainer1";
         this.toolStripContainer1.Size = new System.Drawing.Size(1155, 687);
         this.toolStripContainer1.TabIndex = 2;
         this.toolStripContainer1.Text = "toolStripContainer1";
         // 
         // toolStrip1
         // 
         this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripSeparator1});
         this.toolStrip1.Location = new System.Drawing.Point(3, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(820, 28);
         this.toolStrip1.TabIndex = 0;
         // 
         // toolStripProgressBar1
         // 
         this.toolStripProgressBar1.Name = "toolStripProgressBar1";
         this.toolStripProgressBar1.Size = new System.Drawing.Size(800, 25);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1155, 687);
         this.Controls.Add(this.toolStripContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Form1";
         this.Text = "ABC Reader";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
         this.tabControl1.ResumeLayout(false);
         this.tabPageMain_DNA.ResumeLayout(false);
         this.panel_tabDNA_bottom.ResumeLayout(false);
         this.groupBox_tabDNA_bottomViewDNA.ResumeLayout(false);
         this.panel_tabDNA_top.ResumeLayout(false);
         this.groupBox_tabDNA_top_writeWindow.ResumeLayout(false);
         this.groupBox_tabDNA_top_viewOptions.ResumeLayout(false);
         this.groupBox_tabDNA_top_viewOptions.PerformLayout();
         this.panel_tabDNA_top_ORFs.ResumeLayout(false);
         this.panel_tabDNA_top_ORFs.PerformLayout();
         this.panel_tabDNA_top_53or35.ResumeLayout(false);
         this.panel_tabDNA_top_53or35.PerformLayout();
         this.groupBox_tabDNA_top_readDNA.ResumeLayout(false);
         this.groupBox_tabDNA_top_readDNA.PerformLayout();
         this.tabPageMain_Prots.ResumeLayout(false);
         this.tabControl_tabProtsBottom.ResumeLayout(false);
         this.tabPage_21.ResumeLayout(false);
         this.splitContainer_tabProts.Panel1.ResumeLayout(false);
         this.splitContainer_tabProts.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabProts)).EndInit();
         this.splitContainer_tabProts.ResumeLayout(false);
         this.panel_tabProts_tab1_RightFill_RichTBRight.ResumeLayout(false);
         this.panel_tabProts_tab1_RightTop.ResumeLayout(false);
         this.panel_tabProts_tab1_RightTop.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProts_MaxHitsForBlastP)).EndInit();
         this.tabPage_22.ResumeLayout(false);
         this.panel_tabProt_tab22_Right.ResumeLayout(false);
         this.panel_tabProt_tab22__Right_Internal2.ResumeLayout(false);
         this.panel_tabProt_tab22__Right_Internal3.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_ProtsComp_Small)).EndInit();
         this.contextMenu_DGV_SmallComp.ResumeLayout(false);
         this.panel_tabProt_tab22__Right_Internal1.ResumeLayout(false);
         this.panel_tabProt_tab22__Right_Internal1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProt_minCzValue)).EndInit();
         this.panel_tabProt_tab22_Left.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_ProtsComp_Big)).EndInit();
         this.contextMenu_DGV_BigComp.ResumeLayout(false);
         this.panel_tabProt_top.ResumeLayout(false);
         this.panel_tabProt_Top_Exp1.ResumeLayout(false);
         this.panel_tabProt_Top_Exp2.ResumeLayout(false);
         this.groupBox_tabProt_top_chart.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chart_tabProt_1)).EndInit();
         this.groupBox_tabProt_saveOptions.ResumeLayout(false);
         this.groupBox_tabProt_saveOptions.PerformLayout();
         this.groupBox_tabProt_top_left.ResumeLayout(false);
         this.groupBox_tabProt_proteinViewer.ResumeLayout(false);
         this.groupBox_tabProt_proteinViewer.PerformLayout();
         this.panel_tabProt_top_protSizeToRead.ResumeLayout(false);
         this.panel_tabProt_top_protSizeToRead.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabProt_minLength)).EndInit();
         this.panel_tabProt_top_53or35.ResumeLayout(false);
         this.panel_tabProt_top_53or35.PerformLayout();
         this.tabPageMain_BlastP.ResumeLayout(false);
         this.panel_tabBlastP_bottom.ResumeLayout(false);
         this.splitContainer_tabBlast.Panel1.ResumeLayout(false);
         this.splitContainer_tabBlast.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabBlast)).EndInit();
         this.splitContainer_tabBlast.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_Blast)).EndInit();
         this.contextMenu_DGV_Blast.ResumeLayout(false);
         this.panel_tabBlastP_top.ResumeLayout(false);
         this.groupBox_tabBlastP_TopChart.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
         this.groupBox_tabBlastP_top_SaveToFile.ResumeLayout(false);
         this.groupBox_tabBlastP_top_scanOptions.ResumeLayout(false);
         this.groupBox_tabBlastP_top_scanOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabBlastP_CompSet)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabBlastP_minCoverage)).EndInit();
         this.tabPageMain_TX.ResumeLayout(false);
         this.panel_tabTX_BottomForTabControl.ResumeLayout(false);
         this.tabControl_tabTX.ResumeLayout(false);
         this.tabPage_tabTX_tabAlign.ResumeLayout(false);
         this.panel_tabTX_tabAlign_BottomP.ResumeLayout(false);
         this.panel_tabTX_tabAlign_Top.ResumeLayout(false);
         this.panel_tabTX_tabAlign_Top.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabTX_frameSize)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tabTX_font)).EndInit();
         this.tabPage_tabTX_tabSequences.ResumeLayout(false);
         this.splitContainer_tabTX_tab2.Panel1.ResumeLayout(false);
         this.splitContainer_tabTX_tab2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabTX_tab2)).EndInit();
         this.splitContainer_tabTX_tab2.ResumeLayout(false);
         this.panel_tabTX_tab2_LeftBottom.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_tabTX_Main)).EndInit();
         this.panel_tabTX_tab2_LeftTop.ResumeLayout(false);
         this.panel_tabTX_tab2_LeftTop.PerformLayout();
         this.panel_tabTX_tab2_RightBottom.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_tabTX_Ignored)).EndInit();
         this.panel_tabTX_Top.ResumeLayout(false);
         this.groupBox_tabTX_saveAlign.ResumeLayout(false);
         this.groupBox_tabTX_selAminos.ResumeLayout(false);
         this.groupBox_tabTX_selAminos.PerformLayout();
         this.groupBox_tabTX_Results.ResumeLayout(false);
         this.groupBox_tabTX_Results.PerformLayout();
         this.groupBox_tabTX_runTX.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.tabPageMain_Notepad.ResumeLayout(false);
         this.panel_tabOther_1.ResumeLayout(false);
         this.panel_tabOther_Bottom.ResumeLayout(false);
         this.splitContainer_tabNotepad.Panel1.ResumeLayout(false);
         this.splitContainer_tabNotepad.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabNotepad)).EndInit();
         this.splitContainer_tabNotepad.ResumeLayout(false);
         this.panel_tabOthers_Top.ResumeLayout(false);
         this.groupBox_tabOtherAlignments.ResumeLayout(false);
         this.groupBox_tabOtherAlignments.PerformLayout();
         this.panel_tabOther_NWorSW.ResumeLayout(false);
         this.panel_tabOther_NWorSW.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.tabPageMain_BlastDB.ResumeLayout(false);
         this.panel_tabRefDB_bottom.ResumeLayout(false);
         this.splitContainer_tabRefDB.Panel1.ResumeLayout(false);
         this.splitContainer_tabRefDB.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer_tabRefDB)).EndInit();
         this.splitContainer_tabRefDB.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.DGV_blastDBs)).EndInit();
         this.panel_tabRefDB_bottom_rightFill.ResumeLayout(false);
         this.panel_tabRefDB_tmp2.ResumeLayout(false);
         this.panel_tabRefDB_tmp2.PerformLayout();
         this.panel_tabRefDB_tmp1.ResumeLayout(false);
         this.panel_tabRefDB_tmp1.PerformLayout();
         this.panel_tabRefDB_bottom_right.ResumeLayout(false);
         this.panel_tabRefDB_top.ResumeLayout(false);
         this.panel_tabRefDB_top.PerformLayout();
         this.tabPageMain_Log.ResumeLayout(false);
         this.panel_tabLog_bottom.ResumeLayout(false);
         this.panel_tabLog_top.ResumeLayout(false);
         this.panel_tabLog_top.PerformLayout();
         this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
         this.toolStripContainer1.ContentPanel.ResumeLayout(false);
         this.toolStripContainer1.ResumeLayout(false);
         this.toolStripContainer1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_tabDNA_ReadFastaDNA;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain_DNA;
        private System.Windows.Forms.TabPage tabPageMain_BlastP;
        private System.Windows.Forms.GroupBox groupBox_tabDNA_bottomViewDNA;
        private System.Windows.Forms.RichTextBox richTextBox_tabDNA_DNAview;
        private System.Windows.Forms.GroupBox groupBox_tabDNA_top_readDNA;
        private System.Windows.Forms.CheckBox checkBox_tabDNA_realProteins;
        private System.Windows.Forms.ComboBox comboBox_tabDNA_DNAlist;
        private System.Windows.Forms.Panel panel_tabDNA_bottom;
        private System.Windows.Forms.Panel panel_tabDNA_top;
        private System.Windows.Forms.GroupBox groupBox_tabDNA_top_viewOptions;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_showFrame2;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_showFrame1;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_showFrame0;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_ShowAllFrames;
        private System.Windows.Forms.Button button_tabDNA_SaveCodingDNAfile;
        private System.Windows.Forms.TabPage tabPageMain_Prots;
        private System.Windows.Forms.SplitContainer splitContainer_tabProts;
        private System.Windows.Forms.RichTextBox richTextBox_tabProts_protView1;
        private System.Windows.Forms.RichTextBox richTextBox_tabProts_proteinBlastView;
        private System.Windows.Forms.Panel panel_tabProt_top;
        private System.Windows.Forms.GroupBox groupBox_tabProt_top_chart;
        private System.Windows.Forms.GroupBox groupBox_tabProt_top_left;
        private System.Windows.Forms.Button button_tabProt_SearchProteinsInDNAs;
        private System.Windows.Forms.RadioButton radioButton_tabProt_allLongerThan;
        private System.Windows.Forms.RadioButton radioButton_tabProt_only1Longest;
        private System.Windows.Forms.Label label_tabProtMinLength;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabProt_minLength;
        private System.Windows.Forms.CheckBox checkBox_tabProt_onlyWithSTOP;
        private System.Windows.Forms.CheckBox checkBox_tabProt_startFromMET;
        private System.Windows.Forms.ComboBox comboBox_tabProt_ProteinsList;
        private System.Windows.Forms.CheckBox checkBox_tabDNA_SortDNAbyLength;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_tabProt_1;
        private System.Windows.Forms.GroupBox groupBox_tabDNA_top_writeWindow;
        private System.Windows.Forms.Button button_tabDNA_ShowSaveDataWindow;
        private System.Windows.Forms.Panel panel_tabDNA_top_53or35;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_BothDirections;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_3to5;
        private System.Windows.Forms.RadioButton radioButton_tabDNA_5to3;
        private System.Windows.Forms.CheckBox checkBox_tabDNA_ShowAlsoDNA;
        private System.Windows.Forms.Panel panel_tabProt_top_53or35;
        private System.Windows.Forms.RadioButton radioButton_tabProt_BothDirections;
        private System.Windows.Forms.RadioButton radioButton_tabProt_3to5;
        private System.Windows.Forms.RadioButton radioButton_tabProt_5to3;
        private System.Windows.Forms.Panel panel_tabDNA_top_ORFs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel_tabProt_top_protSizeToRead;
        private System.Windows.Forms.Button button_tabProt_SaveProteinToFile;
        private System.Windows.Forms.CheckBox checkBox_tabProt_WriteAlsoDNAFile;
        private System.Windows.Forms.CheckBox checkBox_tabProt_ShowBlastData;
        private System.Windows.Forms.TabPage tabPageMain_Log;
        private System.Windows.Forms.Panel panel_tabLog_bottom;
        private System.Windows.Forms.RichTextBox richTextBox_tabLog;
        private System.Windows.Forms.Panel panel_tabLog_top;
        private System.Windows.Forms.CheckBox checkBox_tabProt_ShowDNA;
        private System.Windows.Forms.GroupBox groupBox_tabProt_proteinViewer;
        private System.Windows.Forms.Panel panel_tabBlastP_top;
        private System.Windows.Forms.Panel panel_tabBlastP_bottom;
        private System.Windows.Forms.SplitContainer splitContainer_tabBlast;
        private System.Windows.Forms.DataGridView DGV_Blast;
        private System.Windows.Forms.Button button_tabBlastP_ActivateBlastPscan;
        private System.Windows.Forms.RichTextBox richTextBox_tabBlastP_blastView;
        private System.Windows.Forms.GroupBox groupBox_tabBlastP_top_scanOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tabBlastP_BlastDBname;
        private System.Windows.Forms.GroupBox groupBox_tabBlastP_top_SaveToFile;
        private System.Windows.Forms.Button button_tabBlastP_Save1;
        private System.Windows.Forms.GroupBox groupBox_tabProt_saveOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_tabBlastP_maxEvalue;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabBlastP_minCoverage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl_tabProtsBottom;
        private System.Windows.Forms.TabPage tabPage_21;
        private System.Windows.Forms.TabPage tabPage_22;
        private System.Windows.Forms.Panel panel_tabProt_tab22_Right;
        private System.Windows.Forms.Panel panel_tabProt_tab22_Left;
        private System.Windows.Forms.DataGridView DGV_ProtsComp_Big;
        private System.Windows.Forms.Button button_tabProt_ReScanProteins;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.RichTextBox richTextBox_tabProt_SimiliarInfo;
        private System.Windows.Forms.TabPage tabPageMain_BlastDB;
        private System.Windows.Forms.Panel panel_tabRefDB_bottom;
        private System.Windows.Forms.SplitContainer splitContainer_tabRefDB;
        private System.Windows.Forms.DataGridView DGV_blastDBs;
        private System.Windows.Forms.Panel panel_tabRefDB_top;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox comboBox_tabDB_BaseSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel_tabRefDB_bottom_rightFill;
        private System.Windows.Forms.Button button_tabRefDB_ClearFields;
        private System.Windows.Forms.TextBox textBox_tabRefDB_sequence;
        private System.Windows.Forms.TextBox textBox_tabRefDB_seqID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_tabRefDB_bottom_right;
        private System.Windows.Forms.Button button_tabRefDB_EditRow;
        private System.Windows.Forms.Button button_tabRefDB_AddNewProt;
        private System.Windows.Forms.Button button_tabRefDB_AddFastaFile;
        private System.Windows.Forms.Button button_tabRefDB_CompileDB;
        private System.Windows.Forms.Panel panel_tabRefDB_tmp2;
        private System.Windows.Forms.Panel panel_tabRefDB_tmp1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_tabRefDB_RemoveSeq;
        private System.Windows.Forms.TabPage tabPageMain_Notepad;
        private System.Windows.Forms.Panel panel_tabOther_1;
        private System.Windows.Forms.Button button_tabNotepad_RemoveDuplicates;
        private System.Windows.Forms.Panel panel_tabProt_tab22__Right_Internal1;
        private System.Windows.Forms.Panel panel_tabProt_tab22__Right_Internal2;
        private System.Windows.Forms.Panel panel_tabProt_tab22__Right_Internal3;
        private System.Windows.Forms.DataGridView DGV_ProtsComp_Small;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenu_DGV_SmallComp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddToList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRemoveFromList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuICompDNAinLog;
        private System.Windows.Forms.Button button_tabProt_LoadXML;
        private System.Windows.Forms.Button button_tabProt_SaveXML;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompProtsInLog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompBothInLog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabProt_minCzValue;
        private System.Windows.Forms.Button button_tabProt_removeDuplicates;
        private System.Windows.Forms.Label label_tabProt_LastRemovedNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBox_tabBlastP_TopChart;
        private System.Windows.Forms.Panel panel_tabOther_Bottom;
        private System.Windows.Forms.RichTextBox richTextBox_tabNotepad_Left;
        private System.Windows.Forms.Panel panel_tabOthers_Top;
        private System.Windows.Forms.Button button_tabNotepad_BlastN;
        private System.Windows.Forms.Button button_tabNotepad_ClearTBoxes;
        private System.Windows.Forms.Panel panel_tabOther_NWorSW;
        private System.Windows.Forms.RadioButton radioButton_tabNotepad_SW;
        private System.Windows.Forms.RadioButton radioButton_tabNotepad_NW;
        private System.Windows.Forms.TextBox textBox_tabOther_Seq2;
        private System.Windows.Forms.TextBox textBox_tabOther_Seq1;
        private System.Windows.Forms.Button button_tabNotepad_AlignNW;
        private System.Windows.Forms.GroupBox groupBox_tabOtherAlignments;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel_tabProt_Top_Exp1;
        private System.Windows.Forms.Panel panel_tabProt_Top_Exp2;
        private System.Windows.Forms.ContextMenuStrip contextMenu_DGV_Blast;
        private System.Windows.Forms.ToolStripMenuItem usuńWynikToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabBlastP_CompSet;
        private System.Windows.Forms.SplitContainer splitContainer_tabNotepad;
        private System.Windows.Forms.RichTextBox richTextBox_tabNotepad_Right;
        private System.Windows.Forms.RadioButton radioButton_tabProts_comboUnsort;
        private System.Windows.Forms.RadioButton radioButton_tabProts_comboSortAlfa;
        private System.Windows.Forms.Panel panel_tabProts_tab1_RightTop;
        private System.Windows.Forms.Panel panel_tabProts_tab1_RightFill_RichTBRight;
        private System.Windows.Forms.Label label_tabProts_1;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabProts_MaxHitsForBlastP;
        private System.Windows.Forms.ContextMenuStrip contextMenu_DGV_BigComp;
        private System.Windows.Forms.ToolStripMenuItem ignorujSekwencjęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przestańIgnorowaćSekwencjęToolStripMenuItem;
        private System.Windows.Forms.Button button_tabBlastP_RefreshDGV;
        private System.Windows.Forms.TabPage tabPageMain_TX;
        private System.Windows.Forms.Panel panel_tabTX_BottomForTabControl;
        private System.Windows.Forms.Panel panel_tabTX_Top;
        private System.Windows.Forms.Button button_tabTX_alignFromBlast;
        private System.Windows.Forms.ComboBox comboBox_tabTX_alignMethod;
        private System.Windows.Forms.RichTextBox richTextBox_tabTX_results;
        private System.Windows.Forms.Button button_tabTX_ShowAlignment;
        private System.Windows.Forms.HScrollBar hScrollBar_tabTX;
        private System.Windows.Forms.Panel panel_tabTX_tabAlign_Top;
        private System.Windows.Forms.Panel panel_tabTX_tabAlign_BottomP;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabTX_frameSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_tabTX_font;
        private System.Windows.Forms.Button button_tabTX_alignFromProts;
        private System.Windows.Forms.TabControl tabControl_tabTX;
        private System.Windows.Forms.TabPage tabPage_tabTX_tabAlign;
        private System.Windows.Forms.TabPage tabPage_tabTX_tabSequences;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_tabTX_ShowFull;
        private System.Windows.Forms.SplitContainer splitContainer_tabTX_tab2;
        private System.Windows.Forms.Panel panel_tabTX_tab2_LeftBottom;
        private System.Windows.Forms.DataGridView DGV_tabTX_Main;
        private System.Windows.Forms.Panel panel_tabTX_tab2_LeftTop;
        private System.Windows.Forms.Panel panel_tabTX_tab2_RightBottom;
        private System.Windows.Forms.DataGridView DGV_tabTX_Ignored;
        private System.Windows.Forms.Panel panel_tabTX_tab2_RightTop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox_tabTX_runTX;
        private System.Windows.Forms.Button button_tabTX_runTX;
        private System.Windows.Forms.Button button_tabTX_loadFromFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_tabTX_showProts;
        private System.Windows.Forms.RadioButton radioButton_tabTX_showDNA;
        private System.Windows.Forms.GroupBox groupBox_tabTX_Results;
        private System.Windows.Forms.CheckBox checkBoxP;
        private System.Windows.Forms.CheckBox checkBoxT;
        private System.Windows.Forms.CheckBox checkBoxF;
        private System.Windows.Forms.CheckBox checkBoxC;
        private System.Windows.Forms.CheckBox checkBoxM;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_tabTX_getTXdata;
        private System.Windows.Forms.GroupBox groupBox_tabTX_selAminos;
        private System.Windows.Forms.CheckBox checkBox_ColorTrigger;
        private System.Windows.Forms.CheckBox checkBox_aminoV;
        private System.Windows.Forms.CheckBox checkBox_aminoY;
        private System.Windows.Forms.CheckBox checkBox_aminoW;
        private System.Windows.Forms.CheckBox checkBox_aminoT;
        private System.Windows.Forms.CheckBox checkBox_aminoS;
        private System.Windows.Forms.CheckBox checkBox_aminoR;
        private System.Windows.Forms.CheckBox checkBox_aminoQ;
        private System.Windows.Forms.CheckBox checkBox_aminoP;
        private System.Windows.Forms.CheckBox checkBox_aminoN;
        private System.Windows.Forms.CheckBox checkBox_aminoM;
        private System.Windows.Forms.CheckBox checkBox_aminoL;
        private System.Windows.Forms.CheckBox checkBox_aminoK;
        private System.Windows.Forms.CheckBox checkBox_aminoI;
        private System.Windows.Forms.CheckBox checkBox_aminoH;
        private System.Windows.Forms.CheckBox checkBox_aminoG;
        private System.Windows.Forms.CheckBox checkBox_aminoF;
        private System.Windows.Forms.CheckBox checkBox_aminoE;
        private System.Windows.Forms.CheckBox checkBox_aminoD;
        private System.Windows.Forms.CheckBox checkBox_aminoC;
        private System.Windows.Forms.CheckBox checkBox_aminoA;
        private System.Windows.Forms.GroupBox groupBox_tabTX_saveAlign;
        private System.Windows.Forms.Button button_tabTX_saveClustalW;
        private System.Windows.Forms.Button button_tabTX_saveMuscle;
        private System.Windows.Forms.Button button_tabTX_savePrank;
        private System.Windows.Forms.Button button_tabTX_saveTCoffee;
        private System.Windows.Forms.Button button_tabTX_saveMafft;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_tabTX_comboSelectAlignForShowAll;
        public System.Windows.Forms.CheckBox checkBox2Convert;
    }
}

