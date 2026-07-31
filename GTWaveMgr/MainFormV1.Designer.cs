namespace Awool
{
    partial class MainFormV1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormV1));
			System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("노드0");
			System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("노드5");
			System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("노드7");
			System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("노드8");
			System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("노드6", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31});
			System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("노드3", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode32});
			System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("노드4");
			System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("노드1", new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode34});
			System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("노드2");
			this.sc_main = new System.Windows.Forms.SplitContainer();
			this.bt_group_save = new System.Windows.Forms.Button();
			this.pb_panel_right = new System.Windows.Forms.PictureBox();
			this.pb_panel_left = new System.Windows.Forms.PictureBox();
			this.pb_drawer = new System.Windows.Forms.PictureBox();
			this.pn_top_info = new System.Windows.Forms.Panel();
			this.pb_full_screen = new System.Windows.Forms.Button();
			this.bt_finder = new System.Windows.Forms.Button();
			this.bt_status_mon = new System.Windows.Forms.Button();
			this.sc_context = new System.Windows.Forms.SplitContainer();
			this.sc_left = new System.Windows.Forms.SplitContainer();
			this.tv_group = new System.Windows.Forms.TreeView();
			this.sc_mem_list = new System.Windows.Forms.SplitContainer();
			this.tb_group_title = new System.Windows.Forms.Label();
			this.lv_device_list = new System.Windows.Forms.ListView();
			this.ch_dev_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_dumy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_check_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_dev_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sc_body = new System.Windows.Forms.SplitContainer();
			this.aflp_manage = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
			this.advancedFlowLayoutPanel1 = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
			this.ecp_diagram = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.bt_redo = new System.Windows.Forms.Button();
			this.bt_undo = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label24 = new System.Windows.Forms.Label();
			this.cb_line_direct = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cb_link_segment = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cb_link_style = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.cb_line_thick = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.bt_link_color = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cb_view_mode = new System.Windows.Forms.ComboBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.tb_diagram_h = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_diagram_w = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bt_load_ncd = new System.Windows.Forms.Button();
			this.bt_save_ncd = new System.Windows.Forms.Button();
			this.bt_cls_bk_image = new System.Windows.Forms.Button();
			this.bt_set_bk_image = new System.Windows.Forms.Button();
			this.overview1 = new MindFusion.Diagramming.WinForms.Overview();
			this.dv_netview = new MindFusion.Diagramming.WinForms.DiagramView();
			this.main_diagram = new MindFusion.Diagramming.Diagram();
			this.panel_zoom = new System.Windows.Forms.Panel();
			this.btn_zoom_out = new System.Windows.Forms.Button();
			this.track_zoom = new System.Windows.Forms.TrackBar();
			this.btn_zoom_in = new System.Windows.Forms.Button();
			this.lbl_zoom = new System.Windows.Forms.Label();
			this.main_ruler = new MindFusion.Diagramming.WinForms.Ruler();
			this.ecp_scan_info = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
			this.lv_scan_list = new System.Windows.Forms.ListView();
			this.SSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Signal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SigChain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.RxRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TxCCQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gb_device1 = new System.Windows.Forms.GroupBox();
			this.lb_g_mode_1 = new System.Windows.Forms.Label();
			this.lb_g_freq_1 = new System.Windows.Forms.Label();
			this.lb_g_sec_1 = new System.Windows.Forms.Label();
			this.lb_g_ssid_1 = new System.Windows.Forms.Label();
			this.lb_g_bssid_1 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cb_auto_save = new System.Windows.Forms.CheckBox();
			this.bt_stop = new System.Windows.Forms.Button();
			this.bt_print = new System.Windows.Forms.Button();
			this.gb_device0 = new System.Windows.Forms.GroupBox();
			this.lb_g_mode_0 = new System.Windows.Forms.Label();
			this.lb_g_freq_0 = new System.Windows.Forms.Label();
			this.lb_g_sec_0 = new System.Windows.Forms.Label();
			this.lb_g_ssid_0 = new System.Windows.Forms.Label();
			this.lb_g_bssid_0 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tb_port = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.lb_uptime = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.bt_close = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.cb_ip = new System.Windows.Forms.ComboBox();
			this.bt_scan = new System.Windows.Forms.Button();
			this.aflp_state = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
			this.ecp_system_kind = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
			this.lv_system = new System.Windows.Forms.ListView();
			this.ch_system_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_system_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_system_spec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_system_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tb_system_image_path = new System.Windows.Forms.TextBox();
			this.bt_system_del = new System.Windows.Forms.Button();
			this.bt_system_add = new System.Windows.Forms.Button();
			this.bt_system_apply = new System.Windows.Forms.Button();
			this.bt_system_image = new System.Windows.Forms.Button();
			this.pb_system_image = new System.Windows.Forms.PictureBox();
			this.b = new System.Windows.Forms.Label();
			this.tb_system_spec = new System.Windows.Forms.TextBox();
			this.tb_system_desc = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.tb_system_name = new System.Windows.Forms.TextBox();
			this.ecp_device_log = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
			this.nud_sales = new System.Windows.Forms.NumericUpDown();
			this.lv_device_log = new System.Windows.Forms.ListView();
			this.ch_log_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_log_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_log_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_log_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_log_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_log_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lb_sale_nums = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lb_sale_total = new System.Windows.Forms.Label();
			this.bt_member_yesterday = new System.Windows.Forms.Button();
			this.bt_member_today = new System.Windows.Forms.Button();
			this.bt_member_3_month = new System.Windows.Forms.Button();
			this.bt_member_one_month = new System.Windows.Forms.Button();
			this.bt_member_excel = new System.Windows.Forms.Button();
			this.bt_member_one_week = new System.Windows.Forms.Button();
			this.pb_search_member = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtp_member_e_date = new System.Windows.Forms.DateTimePicker();
			this.dtp_member_s_date = new System.Windows.Forms.DateTimePicker();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
			this.pbStatusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblEncoding = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.새로운구성도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.구성도열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.구성도저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.구성도잠금수정불가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.로그보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.로그저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.보고서출력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.모니터링중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.장비검색ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.로그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.시스템ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.시스템추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.시스템수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.시스템삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.그룹추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.그룹수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.그룹삭ㅈToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.설정ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.이름으로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iP주소로ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.구성도배경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.sNMPOIDTempleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.무선연결선그리기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.환경세팅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.사용자관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diagram1 = new MindFusion.Diagramming.Diagram();
			this.label4 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.sc_main)).BeginInit();
			this.sc_main.Panel1.SuspendLayout();
			this.sc_main.Panel2.SuspendLayout();
			this.sc_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_panel_right)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_panel_left)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_drawer)).BeginInit();
			this.pn_top_info.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sc_context)).BeginInit();
			this.sc_context.Panel1.SuspendLayout();
			this.sc_context.Panel2.SuspendLayout();
			this.sc_context.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sc_left)).BeginInit();
			this.sc_left.Panel1.SuspendLayout();
			this.sc_left.Panel2.SuspendLayout();
			this.sc_left.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sc_mem_list)).BeginInit();
			this.sc_mem_list.Panel1.SuspendLayout();
			this.sc_mem_list.Panel2.SuspendLayout();
			this.sc_mem_list.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sc_body)).BeginInit();
			this.sc_body.Panel1.SuspendLayout();
			this.sc_body.Panel2.SuspendLayout();
			this.sc_body.SuspendLayout();
			this.aflp_manage.SuspendLayout();
			this.ecp_diagram.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel_zoom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.track_zoom)).BeginInit();
			this.main_ruler.SuspendLayout();
			this.ecp_scan_info.SuspendLayout();
			this.gb_device1.SuspendLayout();
			this.gb_device0.SuspendLayout();
			this.aflp_state.SuspendLayout();
			this.ecp_system_kind.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_system_image)).BeginInit();
			this.ecp_device_log.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_sales)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_search_member)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sc_main
			// 
			this.sc_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sc_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sc_main.Location = new System.Drawing.Point(0, 28);
			this.sc_main.Name = "sc_main";
			this.sc_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sc_main.Panel1
			// 
			this.sc_main.Panel1.Controls.Add(this.bt_group_save);
			this.sc_main.Panel1.Controls.Add(this.pb_panel_right);
			this.sc_main.Panel1.Controls.Add(this.pb_panel_left);
			this.sc_main.Panel1.Controls.Add(this.pb_drawer);
			this.sc_main.Panel1.Controls.Add(this.pn_top_info);
			// 
			// sc_main.Panel2
			// 
			this.sc_main.Panel2.Controls.Add(this.sc_context);
			this.sc_main.Size = new System.Drawing.Size(1944, 1004);
			this.sc_main.SplitterDistance = 52;
			this.sc_main.TabIndex = 2;
			this.sc_main.Resize += new System.EventHandler(this.sc_main_Resize);
			// 
			// bt_group_save
			// 
			this.bt_group_save.Location = new System.Drawing.Point(40, 6);
			this.bt_group_save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bt_group_save.Name = "bt_group_save";
			this.bt_group_save.Size = new System.Drawing.Size(46, 21);
			this.bt_group_save.TabIndex = 257;
			this.bt_group_save.Text = "저장";
			this.bt_group_save.UseVisualStyleBackColor = true;
			this.bt_group_save.Visible = false;
			this.bt_group_save.Click += new System.EventHandler(this.bt_group_save_Click);
			// 
			// pb_panel_right
			// 
			this.pb_panel_right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_panel_right.Image = ((System.Drawing.Image)(resources.GetObject("pb_panel_right.Image")));
			this.pb_panel_right.Location = new System.Drawing.Point(1899, 6);
			this.pb_panel_right.Name = "pb_panel_right";
			this.pb_panel_right.Size = new System.Drawing.Size(37, 43);
			this.pb_panel_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_panel_right.TabIndex = 256;
			this.pb_panel_right.TabStop = false;
			this.pb_panel_right.Click += new System.EventHandler(this.pb_panel_right_Click);
			// 
			// pb_panel_left
			// 
			this.pb_panel_left.Image = ((System.Drawing.Image)(resources.GetObject("pb_panel_left.Image")));
			this.pb_panel_left.Location = new System.Drawing.Point(163, 7);
			this.pb_panel_left.Name = "pb_panel_left";
			this.pb_panel_left.Size = new System.Drawing.Size(29, 23);
			this.pb_panel_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_panel_left.TabIndex = 247;
			this.pb_panel_left.TabStop = false;
			this.pb_panel_left.Click += new System.EventHandler(this.pb_panel_left_Click);
			// 
			// pb_drawer
			// 
			this.pb_drawer.Image = ((System.Drawing.Image)(resources.GetObject("pb_drawer.Image")));
			this.pb_drawer.Location = new System.Drawing.Point(5, 7);
			this.pb_drawer.Name = "pb_drawer";
			this.pb_drawer.Size = new System.Drawing.Size(29, 23);
			this.pb_drawer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_drawer.TabIndex = 246;
			this.pb_drawer.TabStop = false;
			this.pb_drawer.Click += new System.EventHandler(this.pb_drawer_Click);
			// 
			// pn_top_info
			// 
			this.pn_top_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pn_top_info.Controls.Add(this.pb_full_screen);
			this.pn_top_info.Controls.Add(this.bt_finder);
			this.pn_top_info.Controls.Add(this.bt_status_mon);
			this.pn_top_info.Location = new System.Drawing.Point(198, -1);
			this.pn_top_info.Name = "pn_top_info";
			this.pn_top_info.Size = new System.Drawing.Size(1517, 53);
			this.pn_top_info.TabIndex = 249;
			// 
			// pb_full_screen
			// 
			this.pb_full_screen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_full_screen.BackgroundImage")));
			this.pb_full_screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_full_screen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_full_screen.FlatAppearance.BorderSize = 0;
			this.pb_full_screen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
			this.pb_full_screen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
			this.pb_full_screen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pb_full_screen.Location = new System.Drawing.Point(41, 6);
			this.pb_full_screen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pb_full_screen.Name = "pb_full_screen";
			this.pb_full_screen.Size = new System.Drawing.Size(30, 21);
			this.pb_full_screen.TabIndex = 255;
			this.pb_full_screen.UseVisualStyleBackColor = false;
			this.pb_full_screen.Click += new System.EventHandler(this.pb_full_screen_Click);
			// 
			// bt_finder
			// 
			this.bt_finder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_finder.BackgroundImage")));
			this.bt_finder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_finder.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bt_finder.FlatAppearance.BorderSize = 0;
			this.bt_finder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
			this.bt_finder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
			this.bt_finder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_finder.Location = new System.Drawing.Point(5, 6);
			this.bt_finder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bt_finder.Name = "bt_finder";
			this.bt_finder.Size = new System.Drawing.Size(32, 21);
			this.bt_finder.TabIndex = 254;
			this.bt_finder.UseVisualStyleBackColor = false;
			this.bt_finder.Click += new System.EventHandler(this.bt_finder_Click);
			// 
			// bt_status_mon
			// 
			this.bt_status_mon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_status_mon.BackgroundImage")));
			this.bt_status_mon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_status_mon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.bt_status_mon.FlatAppearance.BorderSize = 0;
			this.bt_status_mon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
			this.bt_status_mon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
			this.bt_status_mon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_status_mon.Location = new System.Drawing.Point(81, 6);
			this.bt_status_mon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.bt_status_mon.Name = "bt_status_mon";
			this.bt_status_mon.Size = new System.Drawing.Size(50, 21);
			this.bt_status_mon.TabIndex = 256;
			this.bt_status_mon.UseVisualStyleBackColor = false;
			this.bt_status_mon.Click += new System.EventHandler(this.bt_status_mon_Click);
			// 
			// sc_context
			// 
			this.sc_context.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sc_context.Location = new System.Drawing.Point(0, 0);
			this.sc_context.Name = "sc_context";
			// 
			// sc_context.Panel1
			// 
			this.sc_context.Panel1.Controls.Add(this.sc_left);
			this.sc_context.Panel1.Resize += new System.EventHandler(this.sc_context_Panel1_Resize);
			// 
			// sc_context.Panel2
			// 
			this.sc_context.Panel2.Controls.Add(this.sc_body);
			this.sc_context.Size = new System.Drawing.Size(1942, 946);
			this.sc_context.SplitterDistance = 239;
			this.sc_context.TabIndex = 0;
			// 
			// sc_left
			// 
			this.sc_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sc_left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sc_left.Location = new System.Drawing.Point(0, 0);
			this.sc_left.Name = "sc_left";
			this.sc_left.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sc_left.Panel1
			// 
			this.sc_left.Panel1.Controls.Add(this.tv_group);
			// 
			// sc_left.Panel2
			// 
			this.sc_left.Panel2.Controls.Add(this.sc_mem_list);
			this.sc_left.Size = new System.Drawing.Size(239, 946);
			this.sc_left.SplitterDistance = 320;
			this.sc_left.TabIndex = 113;
			// 
			// tv_group
			// 
			this.tv_group.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tv_group.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tv_group.ItemHeight = 22;
			this.tv_group.Location = new System.Drawing.Point(0, 0);
			this.tv_group.Name = "tv_group";
			treeNode28.Name = "노드0";
			treeNode28.Text = "노드0";
			treeNode29.Name = "노드5";
			treeNode29.Text = "노드5";
			treeNode30.Name = "노드7";
			treeNode30.Text = "노드7";
			treeNode31.Name = "노드8";
			treeNode31.Text = "노드8";
			treeNode32.Name = "노드6";
			treeNode32.Text = "노드6";
			treeNode33.Name = "노드3";
			treeNode33.Text = "노드3";
			treeNode34.Name = "노드4";
			treeNode34.Text = "노드4";
			treeNode35.Name = "노드1";
			treeNode35.Text = "노드1";
			treeNode36.Name = "노드2";
			treeNode36.Text = "노드2";
			this.tv_group.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode35,
            treeNode36});
			this.tv_group.ShowNodeToolTips = true;
			this.tv_group.Size = new System.Drawing.Size(237, 318);
			this.tv_group.TabIndex = 0;
			this.tv_group.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_group_AfterSelect);
			this.tv_group.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_group_MouseDown);
			// 
			// sc_mem_list
			// 
			this.sc_mem_list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sc_mem_list.Location = new System.Drawing.Point(0, 0);
			this.sc_mem_list.Name = "sc_mem_list";
			this.sc_mem_list.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sc_mem_list.Panel1
			// 
			this.sc_mem_list.Panel1.Controls.Add(this.tb_group_title);
			// 
			// sc_mem_list.Panel2
			// 
			this.sc_mem_list.Panel2.Controls.Add(this.lv_device_list);
			this.sc_mem_list.Size = new System.Drawing.Size(237, 620);
			this.sc_mem_list.SplitterDistance = 35;
			this.sc_mem_list.TabIndex = 113;
			// 
			// tb_group_title
			// 
			this.tb_group_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_group_title.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_group_title.Location = new System.Drawing.Point(0, 0);
			this.tb_group_title.Name = "tb_group_title";
			this.tb_group_title.Size = new System.Drawing.Size(237, 35);
			this.tb_group_title.TabIndex = 13;
			this.tb_group_title.Text = "jhgjhgjhgjhgjhgjhgjhgjhgjhgjhgjhgjhg";
			this.tb_group_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lv_device_list
			// 
			this.lv_device_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_device_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_device_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_dev_no,
            this.ch_dev_type,
            this.ch_dev_name,
            this.ch_dev_dumy,
            this.ch_dev_ip,
            this.ch_dev_check_type,
            this.ch_dev_desc});
			this.lv_device_list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv_device_list.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_device_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_device_list.FullRowSelect = true;
			this.lv_device_list.GridLines = true;
			this.lv_device_list.HideSelection = false;
			this.lv_device_list.Location = new System.Drawing.Point(0, 0);
			this.lv_device_list.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
			this.lv_device_list.Name = "lv_device_list";
			this.lv_device_list.Size = new System.Drawing.Size(237, 581);
			this.lv_device_list.TabIndex = 113;
			this.lv_device_list.UseCompatibleStateImageBehavior = false;
			this.lv_device_list.View = System.Windows.Forms.View.Details;
			this.lv_device_list.SelectedIndexChanged += new System.EventHandler(this.lv_device_list_SelectedIndexChanged);
			this.lv_device_list.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_device_list_MouseDoubleClick);
			// 
			// ch_dev_no
			// 
			this.ch_dev_no.Text = "No";
			this.ch_dev_no.Width = 0;
			// 
			// ch_dev_type
			// 
			this.ch_dev_type.Text = "Type";
			this.ch_dev_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ch_dev_name
			// 
			this.ch_dev_name.Text = "이름";
			this.ch_dev_name.Width = 80;
			// 
			// ch_dev_dumy
			// 
			this.ch_dev_dumy.Text = "Dumy";
			this.ch_dev_dumy.Width = 20;
			// 
			// ch_dev_ip
			// 
			this.ch_dev_ip.Text = "IP";
			this.ch_dev_ip.Width = 100;
			// 
			// ch_dev_check_type
			// 
			this.ch_dev_check_type.Text = "Check Type";
			// 
			// ch_dev_desc
			// 
			this.ch_dev_desc.Text = "Comment";
			this.ch_dev_desc.Width = 1000;
			// 
			// sc_body
			// 
			this.sc_body.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sc_body.Location = new System.Drawing.Point(0, 0);
			this.sc_body.Margin = new System.Windows.Forms.Padding(2);
			this.sc_body.Name = "sc_body";
			// 
			// sc_body.Panel1
			// 
			this.sc_body.Panel1.Controls.Add(this.aflp_manage);
			// 
			// sc_body.Panel2
			// 
			this.sc_body.Panel2.Controls.Add(this.aflp_state);
			this.sc_body.Size = new System.Drawing.Size(1699, 946);
			this.sc_body.SplitterDistance = 1340;
			this.sc_body.TabIndex = 0;
			// 
			// aflp_manage
			// 
			this.aflp_manage.AutoScroll = true;
			this.aflp_manage.BackColor = System.Drawing.Color.White;
			this.aflp_manage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.aflp_manage.Controls.Add(this.advancedFlowLayoutPanel1);
			this.aflp_manage.Controls.Add(this.ecp_diagram);
			this.aflp_manage.Controls.Add(this.ecp_scan_info);
			this.aflp_manage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aflp_manage.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.aflp_manage.Location = new System.Drawing.Point(0, 0);
			this.aflp_manage.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.aflp_manage.Name = "aflp_manage";
			this.aflp_manage.Size = new System.Drawing.Size(1340, 946);
			this.aflp_manage.TabIndex = 12;
			this.aflp_manage.WrapContents = false;
			// 
			// advancedFlowLayoutPanel1
			// 
			this.advancedFlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.advancedFlowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.advancedFlowLayoutPanel1.Name = "advancedFlowLayoutPanel1";
			this.advancedFlowLayoutPanel1.Size = new System.Drawing.Size(1311, 41);
			this.advancedFlowLayoutPanel1.TabIndex = 12;
			this.advancedFlowLayoutPanel1.Visible = false;
			this.advancedFlowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.advancedFlowLayoutPanel1_Paint);
			// 
			// ecp_diagram
			// 
			this.ecp_diagram.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
			this.ecp_diagram.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
			this.ecp_diagram.Controls.Add(this.panel7);
			this.ecp_diagram.Controls.Add(this.panel6);
			this.ecp_diagram.Controls.Add(this.panel4);
			this.ecp_diagram.Controls.Add(this.panel5);
			this.ecp_diagram.Controls.Add(this.panel3);
			this.ecp_diagram.Controls.Add(this.main_ruler);
			this.ecp_diagram.ExpandedHeight = 636;
			this.ecp_diagram.IsExpanded = true;
			this.ecp_diagram.IsReloadVisible = true;
			this.ecp_diagram.IsSaveVisible = true;
			this.ecp_diagram.Location = new System.Drawing.Point(3, 51);
			this.ecp_diagram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ecp_diagram.Name = "ecp_diagram";
			this.ecp_diagram.Size = new System.Drawing.Size(1311, 854);
			this.ecp_diagram.TabIndex = 9;
			this.ecp_diagram.Text = "네트웍 Diagram 관리";
			this.ecp_diagram.UseAnimation = true;
			// 
			// panel7
			// 
			this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.bt_redo);
			this.panel7.Controls.Add(this.bt_undo);
			this.panel7.Location = new System.Drawing.Point(1111, 321);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(194, 36);
			this.panel7.TabIndex = 69;
			// 
			// bt_redo
			// 
			this.bt_redo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_redo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_redo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_redo.Location = new System.Drawing.Point(100, 4);
			this.bt_redo.Name = "bt_redo";
			this.bt_redo.Size = new System.Drawing.Size(75, 23);
			this.bt_redo.TabIndex = 62;
			this.bt_redo.Text = "reDo";
			this.bt_redo.UseVisualStyleBackColor = false;
			this.bt_redo.Click += new System.EventHandler(this.bt_redo_Click);
			// 
			// bt_undo
			// 
			this.bt_undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_undo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_undo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_undo.Location = new System.Drawing.Point(15, 5);
			this.bt_undo.Name = "bt_undo";
			this.bt_undo.Size = new System.Drawing.Size(75, 23);
			this.bt_undo.TabIndex = 61;
			this.bt_undo.Text = "unDo";
			this.bt_undo.UseVisualStyleBackColor = false;
			this.bt_undo.Click += new System.EventHandler(this.bt_undo_Click);
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.label24);
			this.panel6.Controls.Add(this.cb_line_direct);
			this.panel6.Controls.Add(this.label7);
			this.panel6.Controls.Add(this.cb_link_segment);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Controls.Add(this.cb_link_style);
			this.panel6.Controls.Add(this.label23);
			this.panel6.Controls.Add(this.cb_line_thick);
			this.panel6.Controls.Add(this.label14);
			this.panel6.Controls.Add(this.bt_link_color);
			this.panel6.Location = new System.Drawing.Point(1111, 505);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(194, 160);
			this.panel6.TabIndex = 66;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label24.Location = new System.Drawing.Point(37, 98);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(44, 23);
			this.label24.TabIndex = 82;
			this.label24.Text = "방향";
			// 
			// cb_line_direct
			// 
			this.cb_line_direct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_line_direct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_line_direct.FormattingEnabled = true;
			this.cb_line_direct.Items.AddRange(new object[] {
            "None",
            "Only",
            "Both"});
			this.cb_line_direct.Location = new System.Drawing.Point(88, 95);
			this.cb_line_direct.Name = "cb_line_direct";
			this.cb_line_direct.Size = new System.Drawing.Size(71, 23);
			this.cb_line_direct.TabIndex = 81;
			this.cb_line_direct.Text = "None";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label7.Location = new System.Drawing.Point(9, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 23);
			this.label7.TabIndex = 80;
			this.label7.Text = "Segment";
			// 
			// cb_link_segment
			// 
			this.cb_link_segment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_link_segment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_link_segment.FormattingEnabled = true;
			this.cb_link_segment.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
			this.cb_link_segment.Location = new System.Drawing.Point(89, 68);
			this.cb_link_segment.Name = "cb_link_segment";
			this.cb_link_segment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cb_link_segment.Size = new System.Drawing.Size(38, 23);
			this.cb_link_segment.TabIndex = 79;
			this.cb_link_segment.Text = "2";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label6.Location = new System.Drawing.Point(6, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 23);
			this.label6.TabIndex = 78;
			this.label6.Text = "Link Style";
			// 
			// cb_link_style
			// 
			this.cb_link_style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_link_style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_link_style.FormattingEnabled = true;
			this.cb_link_style.Items.AddRange(new object[] {
            "Solid",
            "Dot",
            "DashDot",
            "DashDotDot",
            "Dash"});
			this.cb_link_style.Location = new System.Drawing.Point(88, 124);
			this.cb_link_style.Name = "cb_link_style";
			this.cb_link_style.Size = new System.Drawing.Size(97, 23);
			this.cb_link_style.TabIndex = 77;
			this.cb_link_style.Text = "DashDotDot";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label23.Location = new System.Drawing.Point(36, 43);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(44, 23);
			this.label23.TabIndex = 76;
			this.label23.Text = "두께";
			// 
			// cb_line_thick
			// 
			this.cb_line_thick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_line_thick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_line_thick.FormattingEnabled = true;
			this.cb_line_thick.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
			this.cb_line_thick.Location = new System.Drawing.Point(89, 41);
			this.cb_line_thick.Name = "cb_line_thick";
			this.cb_line_thick.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cb_line_thick.Size = new System.Drawing.Size(38, 23);
			this.cb_line_thick.TabIndex = 75;
			this.cb_line_thick.Text = "2";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label14.Location = new System.Drawing.Point(4, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 23);
			this.label14.TabIndex = 73;
			this.label14.Text = "Link Color";
			// 
			// bt_link_color
			// 
			this.bt_link_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_link_color.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_link_color.Location = new System.Drawing.Point(87, 13);
			this.bt_link_color.Name = "bt_link_color";
			this.bt_link_color.Size = new System.Drawing.Size(42, 23);
			this.bt_link_color.TabIndex = 72;
			this.bt_link_color.UseVisualStyleBackColor = false;
			this.bt_link_color.Click += new System.EventHandler(this.bt_link_color_Click);
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.cb_view_mode);
			this.panel4.Location = new System.Drawing.Point(1111, 363);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(194, 44);
			this.panel4.TabIndex = 64;
			// 
			// cb_view_mode
			// 
			this.cb_view_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_view_mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_view_mode.FormattingEnabled = true;
			this.cb_view_mode.Items.AddRange(new object[] {
            "이름으로 보기",
            "IP 로 보기"});
			this.cb_view_mode.Location = new System.Drawing.Point(36, 10);
			this.cb_view_mode.Name = "cb_view_mode";
			this.cb_view_mode.Size = new System.Drawing.Size(120, 23);
			this.cb_view_mode.TabIndex = 73;
			this.cb_view_mode.SelectedIndexChanged += new System.EventHandler(this.cb_view_mode_SelectedIndexChanged);
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.label25);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.tb_diagram_h);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.tb_diagram_w);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Location = new System.Drawing.Point(1111, 412);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(194, 90);
			this.panel5.TabIndex = 65;
			// 
			// tb_diagram_h
			// 
			this.tb_diagram_h.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.tb_diagram_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_diagram_h.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tb_diagram_h.Location = new System.Drawing.Point(95, 51);
			this.tb_diagram_h.Name = "tb_diagram_h";
			this.tb_diagram_h.Size = new System.Drawing.Size(42, 29);
			this.tb_diagram_h.TabIndex = 78;
			this.tb_diagram_h.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(64, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 23);
			this.label1.TabIndex = 77;
			this.label1.Text = "H :";
			// 
			// tb_diagram_w
			// 
			this.tb_diagram_w.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.tb_diagram_w.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_diagram_w.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tb_diagram_w.Location = new System.Drawing.Point(94, 16);
			this.tb_diagram_w.Name = "tb_diagram_w";
			this.tb_diagram_w.Size = new System.Drawing.Size(42, 29);
			this.tb_diagram_w.TabIndex = 76;
			this.tb_diagram_w.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(24, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 75;
			this.label3.Text = "Size W :";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Controls.Add(this.bt_cls_bk_image);
			this.panel3.Controls.Add(this.bt_set_bk_image);
			this.panel3.Controls.Add(this.overview1);
			this.panel3.Controls.Add(this.panel_zoom);
			this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.panel3.Location = new System.Drawing.Point(1104, 35);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(207, 832);
			this.panel3.TabIndex = 64;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.bt_load_ncd);
			this.panel2.Controls.Add(this.bt_save_ncd);
			this.panel2.Location = new System.Drawing.Point(7, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(194, 34);
			this.panel2.TabIndex = 68;
			// 
			// bt_load_ncd
			// 
			this.bt_load_ncd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_load_ncd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_load_ncd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_load_ncd.Location = new System.Drawing.Point(3, 3);
			this.bt_load_ncd.Name = "bt_load_ncd";
			this.bt_load_ncd.Size = new System.Drawing.Size(89, 23);
			this.bt_load_ncd.TabIndex = 60;
			this.bt_load_ncd.Text = "구성도 Load";
			this.bt_load_ncd.UseVisualStyleBackColor = false;
			this.bt_load_ncd.Click += new System.EventHandler(this.bt_load_ncd_Click);
			// 
			// bt_save_ncd
			// 
			this.bt_save_ncd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_save_ncd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_save_ncd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_save_ncd.Location = new System.Drawing.Point(93, 3);
			this.bt_save_ncd.Name = "bt_save_ncd";
			this.bt_save_ncd.Size = new System.Drawing.Size(89, 23);
			this.bt_save_ncd.TabIndex = 59;
			this.bt_save_ncd.Text = "구성도 Save";
			this.bt_save_ncd.UseVisualStyleBackColor = false;
			this.bt_save_ncd.Click += new System.EventHandler(this.bt_save_ncd_Click);
			// 
			// bt_cls_bk_image
			// 
			this.bt_cls_bk_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_cls_bk_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_cls_bk_image.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_cls_bk_image.Location = new System.Drawing.Point(53, 257);
			this.bt_cls_bk_image.Name = "bt_cls_bk_image";
			this.bt_cls_bk_image.Size = new System.Drawing.Size(108, 23);
			this.bt_cls_bk_image.TabIndex = 67;
			this.bt_cls_bk_image.Text = "배경 제거하기";
			this.bt_cls_bk_image.UseVisualStyleBackColor = false;
			this.bt_cls_bk_image.Click += new System.EventHandler(this.bt_cls_bk_image_Click);
			// 
			// bt_set_bk_image
			// 
			this.bt_set_bk_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_set_bk_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_set_bk_image.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_set_bk_image.Location = new System.Drawing.Point(53, 231);
			this.bt_set_bk_image.Name = "bt_set_bk_image";
			this.bt_set_bk_image.Size = new System.Drawing.Size(107, 23);
			this.bt_set_bk_image.TabIndex = 66;
			this.bt_set_bk_image.Text = "배경 불러오기";
			this.bt_set_bk_image.UseVisualStyleBackColor = false;
			this.bt_set_bk_image.Click += new System.EventHandler(this.bt_set_bk_image_Click);
			// 
			// overview1
			// 
			this.overview1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.overview1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.overview1.BackgroundImage = global::GTWave.Properties.Resources.refresh;
			this.overview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.overview1.DiagramView = this.dv_netview;
			this.overview1.FitAll = true;
			this.overview1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.overview1.Location = new System.Drawing.Point(8, 36);
			this.overview1.Name = "overview1";
			this.overview1.ScaleFactor = 10.54882F;
			this.overview1.Size = new System.Drawing.Size(192, 149);
			this.overview1.TabIndex = 47;
			this.overview1.Text = "overview1";
			// 
			// dv_netview
			// 
			this.dv_netview.AllowDrop = true;
			this.dv_netview.AllowInplaceEdit = true;
			this.dv_netview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.dv_netview.ControlHandlesStyle = MindFusion.Diagramming.HandlesStyle.DashFrame;
			this.dv_netview.Diagram = this.main_diagram;
			this.dv_netview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dv_netview.LicenseKey = null;
			this.dv_netview.Location = new System.Drawing.Point(18, 18);
			this.dv_netview.Name = "dv_netview";
			this.dv_netview.Size = new System.Drawing.Size(1086, 795);
			this.dv_netview.TabIndex = 3;
			this.dv_netview.Text = "dv_netview";
			this.dv_netview.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.dv_netview_ControlRemoved);
			// 
			// main_diagram
			// 
			this.main_diagram.BackgroundImageAlign = MindFusion.Drawing.ImageAlign.Fit;
			this.main_diagram.ShadowsStyle = MindFusion.Diagramming.ShadowsStyle.None;
			this.main_diagram.TouchHitDistance = null;
			this.main_diagram.LinkCreated += new System.EventHandler<MindFusion.Diagramming.LinkEventArgs>(this.main_diagram_LinkCreated);
			this.main_diagram.NodeDeleted += new System.EventHandler<MindFusion.Diagramming.NodeEventArgs>(this.main_diagram_NodeDeleted);
			this.main_diagram.NodeDeleting += new System.EventHandler<MindFusion.Diagramming.NodeValidationEventArgs>(this.main_diagram_NodeDeleting);
			// 
			// panel_zoom
			// 
			this.panel_zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_zoom.BackColor = System.Drawing.Color.Transparent;
			this.panel_zoom.Controls.Add(this.btn_zoom_out);
			this.panel_zoom.Controls.Add(this.track_zoom);
			this.panel_zoom.Controls.Add(this.btn_zoom_in);
			this.panel_zoom.Controls.Add(this.lbl_zoom);
			this.panel_zoom.Location = new System.Drawing.Point(9, 191);
			this.panel_zoom.Name = "panel_zoom";
			this.panel_zoom.Size = new System.Drawing.Size(191, 30);
			this.panel_zoom.TabIndex = 46;
			// 
			// btn_zoom_out
			// 
			this.btn_zoom_out.BackColor = System.Drawing.Color.White;
			this.btn_zoom_out.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btn_zoom_out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_zoom_out.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.btn_zoom_out.Location = new System.Drawing.Point(5, 4);
			this.btn_zoom_out.Name = "btn_zoom_out";
			this.btn_zoom_out.Size = new System.Drawing.Size(22, 22);
			this.btn_zoom_out.TabIndex = 0;
			this.btn_zoom_out.Text = "-";
			this.btn_zoom_out.UseVisualStyleBackColor = false;
			this.btn_zoom_out.Click += new System.EventHandler(this.btn_zoom_out_Click);
			// 
			// track_zoom
			// 
			this.track_zoom.BackColor = System.Drawing.Color.White;
			this.track_zoom.Location = new System.Drawing.Point(26, 4);
			this.track_zoom.Maximum = 200;
			this.track_zoom.Minimum = 10;
			this.track_zoom.Name = "track_zoom";
			this.track_zoom.Size = new System.Drawing.Size(90, 56);
			this.track_zoom.TabIndex = 1;
			this.track_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
			this.track_zoom.Value = 100;
			this.track_zoom.Scroll += new System.EventHandler(this.track_zoom_Scroll);
			// 
			// btn_zoom_in
			// 
			this.btn_zoom_in.BackColor = System.Drawing.Color.White;
			this.btn_zoom_in.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btn_zoom_in.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_zoom_in.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.btn_zoom_in.Location = new System.Drawing.Point(115, 4);
			this.btn_zoom_in.Name = "btn_zoom_in";
			this.btn_zoom_in.Size = new System.Drawing.Size(22, 22);
			this.btn_zoom_in.TabIndex = 2;
			this.btn_zoom_in.Text = "+";
			this.btn_zoom_in.UseVisualStyleBackColor = false;
			this.btn_zoom_in.Click += new System.EventHandler(this.btn_zoom_in_Click);
			// 
			// lbl_zoom
			// 
			this.lbl_zoom.ForeColor = System.Drawing.Color.DimGray;
			this.lbl_zoom.Location = new System.Drawing.Point(141, 7);
			this.lbl_zoom.Name = "lbl_zoom";
			this.lbl_zoom.Size = new System.Drawing.Size(47, 15);
			this.lbl_zoom.TabIndex = 3;
			this.lbl_zoom.Text = "100%";
			this.lbl_zoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// main_ruler
			// 
			this.main_ruler.AllowDrop = true;
			this.main_ruler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.main_ruler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
			this.main_ruler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.main_ruler.Controls.Add(this.dv_netview);
			this.main_ruler.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.main_ruler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.main_ruler.Location = new System.Drawing.Point(1, 30);
			this.main_ruler.Name = "main_ruler";
			this.main_ruler.ShowIcon = false;
			this.main_ruler.Size = new System.Drawing.Size(1104, 813);
			this.main_ruler.TabIndex = 44;
			this.main_ruler.Text = "ruler1";
			this.main_ruler.TextColor = System.Drawing.SystemColors.ControlText;
			// 
			// ecp_scan_info
			// 
			this.ecp_scan_info.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
			this.ecp_scan_info.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
			this.ecp_scan_info.Controls.Add(this.lv_scan_list);
			this.ecp_scan_info.Controls.Add(this.gb_device1);
			this.ecp_scan_info.Controls.Add(this.cb_auto_save);
			this.ecp_scan_info.Controls.Add(this.bt_stop);
			this.ecp_scan_info.Controls.Add(this.bt_print);
			this.ecp_scan_info.Controls.Add(this.gb_device0);
			this.ecp_scan_info.Controls.Add(this.tb_port);
			this.ecp_scan_info.Controls.Add(this.label19);
			this.ecp_scan_info.Controls.Add(this.lb_uptime);
			this.ecp_scan_info.Controls.Add(this.label20);
			this.ecp_scan_info.Controls.Add(this.bt_close);
			this.ecp_scan_info.Controls.Add(this.label21);
			this.ecp_scan_info.Controls.Add(this.cb_ip);
			this.ecp_scan_info.Controls.Add(this.bt_scan);
			this.ecp_scan_info.ExpandedHeight = 534;
			this.ecp_scan_info.IsExpanded = true;
			this.ecp_scan_info.IsReloadVisible = true;
			this.ecp_scan_info.IsSaveVisible = true;
			this.ecp_scan_info.Location = new System.Drawing.Point(3, 913);
			this.ecp_scan_info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ecp_scan_info.Name = "ecp_scan_info";
			this.ecp_scan_info.Size = new System.Drawing.Size(1311, 534);
			this.ecp_scan_info.TabIndex = 11;
			this.ecp_scan_info.Text = "시스템 정보 관리";
			this.ecp_scan_info.UseAnimation = true;
			// 
			// lv_scan_list
			// 
			this.lv_scan_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_scan_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_scan_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_scan_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SSID,
            this.MAC,
            this.Signal,
            this.SigChain,
            this.RxRate,
            this.TxRate,
            this.TxCCQ});
			this.lv_scan_list.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
			this.lv_scan_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_scan_list.FullRowSelect = true;
			this.lv_scan_list.GridLines = true;
			this.lv_scan_list.HideSelection = false;
			this.lv_scan_list.Location = new System.Drawing.Point(0, 218);
			this.lv_scan_list.Name = "lv_scan_list";
			this.lv_scan_list.Size = new System.Drawing.Size(1311, 316);
			this.lv_scan_list.TabIndex = 45;
			this.lv_scan_list.UseCompatibleStateImageBehavior = false;
			this.lv_scan_list.View = System.Windows.Forms.View.Details;
			this.lv_scan_list.SelectedIndexChanged += new System.EventHandler(this.lv_scan_list_SelectedIndexChanged);
			// 
			// SSID
			// 
			this.SSID.Text = "SSID";
			this.SSID.Width = 120;
			// 
			// MAC
			// 
			this.MAC.Text = "MAC Addr";
			this.MAC.Width = 140;
			// 
			// Signal
			// 
			this.Signal.Text = "Signal";
			this.Signal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Signal.Width = 70;
			// 
			// SigChain
			// 
			this.SigChain.Text = "Signal Chain";
			this.SigChain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SigChain.Width = 180;
			// 
			// RxRate
			// 
			this.RxRate.Text = "RxRate";
			this.RxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RxRate.Width = 100;
			// 
			// TxRate
			// 
			this.TxRate.Text = "TxRate";
			this.TxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxRate.Width = 100;
			// 
			// TxCCQ
			// 
			this.TxCCQ.Text = "TxCCQ";
			this.TxCCQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxCCQ.Width = 80;
			// 
			// gb_device1
			// 
			this.gb_device1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.gb_device1.Controls.Add(this.lb_g_mode_1);
			this.gb_device1.Controls.Add(this.lb_g_freq_1);
			this.gb_device1.Controls.Add(this.lb_g_sec_1);
			this.gb_device1.Controls.Add(this.lb_g_ssid_1);
			this.gb_device1.Controls.Add(this.lb_g_bssid_1);
			this.gb_device1.Controls.Add(this.label13);
			this.gb_device1.Controls.Add(this.label8);
			this.gb_device1.Controls.Add(this.label15);
			this.gb_device1.Controls.Add(this.label16);
			this.gb_device1.Controls.Add(this.label9);
			this.gb_device1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.gb_device1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gb_device1.Location = new System.Drawing.Point(344, 77);
			this.gb_device1.Name = "gb_device1";
			this.gb_device1.Size = new System.Drawing.Size(311, 122);
			this.gb_device1.TabIndex = 44;
			this.gb_device1.TabStop = false;
			this.gb_device1.Text = "wifi0";
			// 
			// lb_g_mode_1
			// 
			this.lb_g_mode_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_mode_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_mode_1.Location = new System.Drawing.Point(117, 11);
			this.lb_g_mode_1.Name = "lb_g_mode_1";
			this.lb_g_mode_1.Size = new System.Drawing.Size(178, 20);
			this.lb_g_mode_1.TabIndex = 38;
			this.lb_g_mode_1.Text = "BSSID:";
			// 
			// lb_g_freq_1
			// 
			this.lb_g_freq_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_freq_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_freq_1.Location = new System.Drawing.Point(117, 33);
			this.lb_g_freq_1.Name = "lb_g_freq_1";
			this.lb_g_freq_1.Size = new System.Drawing.Size(178, 20);
			this.lb_g_freq_1.TabIndex = 37;
			this.lb_g_freq_1.Text = "BSSID:";
			// 
			// lb_g_sec_1
			// 
			this.lb_g_sec_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_sec_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_sec_1.Location = new System.Drawing.Point(117, 99);
			this.lb_g_sec_1.Name = "lb_g_sec_1";
			this.lb_g_sec_1.Size = new System.Drawing.Size(178, 20);
			this.lb_g_sec_1.TabIndex = 36;
			this.lb_g_sec_1.Text = "BSSID:";
			// 
			// lb_g_ssid_1
			// 
			this.lb_g_ssid_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_ssid_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_ssid_1.Location = new System.Drawing.Point(117, 77);
			this.lb_g_ssid_1.Name = "lb_g_ssid_1";
			this.lb_g_ssid_1.Size = new System.Drawing.Size(178, 20);
			this.lb_g_ssid_1.TabIndex = 35;
			this.lb_g_ssid_1.Text = "BSSID:";
			// 
			// lb_g_bssid_1
			// 
			this.lb_g_bssid_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_bssid_1.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_bssid_1.Location = new System.Drawing.Point(117, 55);
			this.lb_g_bssid_1.Name = "lb_g_bssid_1";
			this.lb_g_bssid_1.Size = new System.Drawing.Size(178, 20);
			this.lb_g_bssid_1.TabIndex = 34;
			this.lb_g_bssid_1.Text = "BSSID:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label13.Location = new System.Drawing.Point(26, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(76, 17);
			this.label13.TabIndex = 33;
			this.label13.Text = "동작모드";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label8.Location = new System.Drawing.Point(28, 101);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 17);
			this.label8.TabIndex = 32;
			this.label8.Text = "SECURTY";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label15.Location = new System.Drawing.Point(28, 36);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(16, 18);
			this.label15.TabIndex = 31;
			this.label15.Text = "FREQ";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label16.Location = new System.Drawing.Point(28, 80);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(41, 17);
			this.label16.TabIndex = 30;
			this.label16.Text = "SSID";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label9.Location = new System.Drawing.Point(28, 58);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(51, 17);
			this.label9.TabIndex = 29;
			this.label9.Text = "BSSID";
			// 
			// cb_auto_save
			// 
			this.cb_auto_save.AutoSize = true;
			this.cb_auto_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_auto_save.Checked = true;
			this.cb_auto_save.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_auto_save.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.cb_auto_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_auto_save.Location = new System.Drawing.Point(670, 89);
			this.cb_auto_save.Name = "cb_auto_save";
			this.cb_auto_save.Size = new System.Drawing.Size(114, 32);
			this.cb_auto_save.TabIndex = 43;
			this.cb_auto_save.Text = "자동저장";
			this.cb_auto_save.UseVisualStyleBackColor = false;
			// 
			// bt_stop
			// 
			this.bt_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_stop.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_stop.Location = new System.Drawing.Point(703, 12);
			this.bt_stop.Name = "bt_stop";
			this.bt_stop.Size = new System.Drawing.Size(88, 25);
			this.bt_stop.TabIndex = 42;
			this.bt_stop.Text = "정지";
			this.bt_stop.UseVisualStyleBackColor = false;
			this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
			// 
			// bt_print
			// 
			this.bt_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_print.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_print.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_print.Location = new System.Drawing.Point(670, 144);
			this.bt_print.Name = "bt_print";
			this.bt_print.Size = new System.Drawing.Size(119, 24);
			this.bt_print.TabIndex = 41;
			this.bt_print.Text = "결과보기";
			this.bt_print.UseVisualStyleBackColor = false;
			this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
			// 
			// gb_device0
			// 
			this.gb_device0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.gb_device0.Controls.Add(this.lb_g_mode_0);
			this.gb_device0.Controls.Add(this.lb_g_freq_0);
			this.gb_device0.Controls.Add(this.lb_g_sec_0);
			this.gb_device0.Controls.Add(this.lb_g_ssid_0);
			this.gb_device0.Controls.Add(this.lb_g_bssid_0);
			this.gb_device0.Controls.Add(this.label22);
			this.gb_device0.Controls.Add(this.label11);
			this.gb_device0.Controls.Add(this.label10);
			this.gb_device0.Controls.Add(this.label12);
			this.gb_device0.Controls.Add(this.label18);
			this.gb_device0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.gb_device0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gb_device0.Location = new System.Drawing.Point(3, 75);
			this.gb_device0.Name = "gb_device0";
			this.gb_device0.Size = new System.Drawing.Size(320, 122);
			this.gb_device0.TabIndex = 39;
			this.gb_device0.TabStop = false;
			this.gb_device0.Text = "wifi0";
			// 
			// lb_g_mode_0
			// 
			this.lb_g_mode_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_mode_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_mode_0.Location = new System.Drawing.Point(126, 11);
			this.lb_g_mode_0.Name = "lb_g_mode_0";
			this.lb_g_mode_0.Size = new System.Drawing.Size(182, 20);
			this.lb_g_mode_0.TabIndex = 28;
			this.lb_g_mode_0.Text = "BSSID:";
			// 
			// lb_g_freq_0
			// 
			this.lb_g_freq_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_freq_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_freq_0.Location = new System.Drawing.Point(126, 33);
			this.lb_g_freq_0.Name = "lb_g_freq_0";
			this.lb_g_freq_0.Size = new System.Drawing.Size(182, 20);
			this.lb_g_freq_0.TabIndex = 27;
			this.lb_g_freq_0.Text = "BSSID:";
			// 
			// lb_g_sec_0
			// 
			this.lb_g_sec_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_sec_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_sec_0.Location = new System.Drawing.Point(126, 99);
			this.lb_g_sec_0.Name = "lb_g_sec_0";
			this.lb_g_sec_0.Size = new System.Drawing.Size(182, 20);
			this.lb_g_sec_0.TabIndex = 26;
			this.lb_g_sec_0.Text = "BSSID:";
			// 
			// lb_g_ssid_0
			// 
			this.lb_g_ssid_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_ssid_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_ssid_0.Location = new System.Drawing.Point(126, 77);
			this.lb_g_ssid_0.Name = "lb_g_ssid_0";
			this.lb_g_ssid_0.Size = new System.Drawing.Size(182, 20);
			this.lb_g_ssid_0.TabIndex = 25;
			this.lb_g_ssid_0.Text = "BSSID:";
			// 
			// lb_g_bssid_0
			// 
			this.lb_g_bssid_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.lb_g_bssid_0.Font = new System.Drawing.Font("굴림", 9.75F);
			this.lb_g_bssid_0.Location = new System.Drawing.Point(126, 55);
			this.lb_g_bssid_0.Name = "lb_g_bssid_0";
			this.lb_g_bssid_0.Size = new System.Drawing.Size(182, 20);
			this.lb_g_bssid_0.TabIndex = 24;
			this.lb_g_bssid_0.Text = "BSSID:";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label22.Location = new System.Drawing.Point(35, 13);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(76, 17);
			this.label22.TabIndex = 23;
			this.label22.Text = "동작모드";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label11.Location = new System.Drawing.Point(37, 101);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 17);
			this.label11.TabIndex = 22;
			this.label11.Text = "SECURTY";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label10.Location = new System.Drawing.Point(37, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(82, 18);
			this.label10.TabIndex = 21;
			this.label10.Text = "FREQ";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label12.Location = new System.Drawing.Point(37, 80);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 17);
			this.label12.TabIndex = 20;
			this.label12.Text = "SSID";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label18.Location = new System.Drawing.Point(37, 58);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(51, 17);
			this.label18.TabIndex = 19;
			this.label18.Text = "BSSID";
			// 
			// tb_port
			// 
			this.tb_port.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.tb_port.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.tb_port.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.tb_port.Location = new System.Drawing.Point(345, 40);
			this.tb_port.Name = "tb_port";
			this.tb_port.Size = new System.Drawing.Size(76, 29);
			this.tb_port.TabIndex = 38;
			this.tb_port.Text = "8081";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label19.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label19.Location = new System.Drawing.Point(300, 46);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(43, 17);
			this.label19.TabIndex = 37;
			this.label19.Text = "Port:";
			// 
			// lb_uptime
			// 
			this.lb_uptime.AutoSize = true;
			this.lb_uptime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lb_uptime.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Bold);
			this.lb_uptime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lb_uptime.Location = new System.Drawing.Point(515, 46);
			this.lb_uptime.Name = "lb_uptime";
			this.lb_uptime.Size = new System.Drawing.Size(68, 17);
			this.lb_uptime.TabIndex = 36;
			this.lb_uptime.Text = "uptime";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label20.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label20.Location = new System.Drawing.Point(451, 47);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(67, 17);
			this.label20.TabIndex = 35;
			this.label20.Text = "UpTime:";
			// 
			// bt_close
			// 
			this.bt_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_close.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_close.Location = new System.Drawing.Point(670, 172);
			this.bt_close.Name = "bt_close";
			this.bt_close.Size = new System.Drawing.Size(119, 23);
			this.bt_close.TabIndex = 31;
			this.bt_close.Text = "종료하기";
			this.bt_close.UseVisualStyleBackColor = false;
			this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label21.Font = new System.Drawing.Font("굴림", 9.75F);
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label21.Location = new System.Drawing.Point(27, 47);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(26, 17);
			this.label21.TabIndex = 34;
			this.label21.Text = "IP:";
			// 
			// cb_ip
			// 
			this.cb_ip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.cb_ip.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold);
			this.cb_ip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.cb_ip.FormattingEnabled = true;
			this.cb_ip.Location = new System.Drawing.Point(56, 44);
			this.cb_ip.Name = "cb_ip";
			this.cb_ip.Size = new System.Drawing.Size(219, 24);
			this.cb_ip.TabIndex = 33;
			this.cb_ip.Text = "192.168.10.6";
			// 
			// bt_scan
			// 
			this.bt_scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.bt_scan.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Bold);
			this.bt_scan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.bt_scan.Location = new System.Drawing.Point(672, 45);
			this.bt_scan.Name = "bt_scan";
			this.bt_scan.Size = new System.Drawing.Size(86, 25);
			this.bt_scan.TabIndex = 32;
			this.bt_scan.Text = "스캔";
			this.bt_scan.UseVisualStyleBackColor = false;
			this.bt_scan.Click += new System.EventHandler(this.bt_scan_Click);
			// 
			// aflp_state
			// 
			this.aflp_state.AutoScroll = true;
			this.aflp_state.AutoSize = true;
			this.aflp_state.BackColor = System.Drawing.Color.White;
			this.aflp_state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.aflp_state.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.aflp_state.Controls.Add(this.ecp_system_kind);
			this.aflp_state.Controls.Add(this.ecp_device_log);
			this.aflp_state.Dock = System.Windows.Forms.DockStyle.Fill;
			this.aflp_state.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.aflp_state.Location = new System.Drawing.Point(0, 0);
			this.aflp_state.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
			this.aflp_state.Name = "aflp_state";
			this.aflp_state.Size = new System.Drawing.Size(355, 946);
			this.aflp_state.TabIndex = 12;
			this.aflp_state.WrapContents = false;
			// 
			// ecp_system_kind
			// 
			this.ecp_system_kind.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
			this.ecp_system_kind.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
			this.ecp_system_kind.Controls.Add(this.lv_system);
			this.ecp_system_kind.Controls.Add(this.tb_system_image_path);
			this.ecp_system_kind.Controls.Add(this.bt_system_del);
			this.ecp_system_kind.Controls.Add(this.bt_system_add);
			this.ecp_system_kind.Controls.Add(this.bt_system_apply);
			this.ecp_system_kind.Controls.Add(this.bt_system_image);
			this.ecp_system_kind.Controls.Add(this.pb_system_image);
			this.ecp_system_kind.Controls.Add(this.b);
			this.ecp_system_kind.Controls.Add(this.tb_system_spec);
			this.ecp_system_kind.Controls.Add(this.tb_system_desc);
			this.ecp_system_kind.Controls.Add(this.label17);
			this.ecp_system_kind.Controls.Add(this.label26);
			this.ecp_system_kind.Controls.Add(this.tb_system_name);
			this.ecp_system_kind.ExpandedHeight = 364;
			this.ecp_system_kind.IsExpanded = true;
			this.ecp_system_kind.IsReloadVisible = true;
			this.ecp_system_kind.IsSaveVisible = true;
			this.ecp_system_kind.Location = new System.Drawing.Point(3, 4);
			this.ecp_system_kind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.ecp_system_kind.Name = "ecp_system_kind";
			this.ecp_system_kind.Size = new System.Drawing.Size(347, 388);
			this.ecp_system_kind.TabIndex = 5;
			this.ecp_system_kind.Text = "Device 종류 관리";
			this.ecp_system_kind.UseAnimation = true;
			// 
			// lv_system
			// 
			this.lv_system.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_system.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_system.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_system.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_system_no,
            this.ch_system_name,
            this.ch_system_spec,
            this.ch_system_desc});
			this.lv_system.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_system.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_system.FullRowSelect = true;
			this.lv_system.GridLines = true;
			this.lv_system.HideSelection = false;
			this.lv_system.Location = new System.Drawing.Point(0, 155);
			this.lv_system.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.lv_system.Name = "lv_system";
			this.lv_system.Size = new System.Drawing.Size(976, 223);
			this.lv_system.TabIndex = 139;
			this.lv_system.UseCompatibleStateImageBehavior = false;
			this.lv_system.View = System.Windows.Forms.View.Details;
			this.lv_system.SelectedIndexChanged += new System.EventHandler(this.lv_system_SelectedIndexChanged);
			// 
			// ch_system_no
			// 
			this.ch_system_no.Text = "No";
			this.ch_system_no.Width = 28;
			// 
			// ch_system_name
			// 
			this.ch_system_name.Text = "이름";
			this.ch_system_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ch_system_name.Width = 120;
			// 
			// ch_system_spec
			// 
			this.ch_system_spec.Text = "규 격";
			this.ch_system_spec.Width = 120;
			// 
			// ch_system_desc
			// 
			this.ch_system_desc.Text = "설명";
			this.ch_system_desc.Width = 200;
			// 
			// tb_system_image_path
			// 
			this.tb_system_image_path.Location = new System.Drawing.Point(9, 121);
			this.tb_system_image_path.Name = "tb_system_image_path";
			this.tb_system_image_path.Size = new System.Drawing.Size(34, 29);
			this.tb_system_image_path.TabIndex = 138;
			this.tb_system_image_path.Visible = false;
			// 
			// bt_system_del
			// 
			this.bt_system_del.Location = new System.Drawing.Point(170, 127);
			this.bt_system_del.Name = "bt_system_del";
			this.bt_system_del.Size = new System.Drawing.Size(46, 23);
			this.bt_system_del.TabIndex = 125;
			this.bt_system_del.Text = "삭제";
			this.bt_system_del.UseVisualStyleBackColor = true;
			this.bt_system_del.Click += new System.EventHandler(this.bt_system_del_Click);
			// 
			// bt_system_add
			// 
			this.bt_system_add.Location = new System.Drawing.Point(119, 127);
			this.bt_system_add.Name = "bt_system_add";
			this.bt_system_add.Size = new System.Drawing.Size(46, 23);
			this.bt_system_add.TabIndex = 124;
			this.bt_system_add.Text = "추가";
			this.bt_system_add.UseVisualStyleBackColor = true;
			this.bt_system_add.Click += new System.EventHandler(this.bt_system_add_Click);
			// 
			// bt_system_apply
			// 
			this.bt_system_apply.Location = new System.Drawing.Point(66, 127);
			this.bt_system_apply.Name = "bt_system_apply";
			this.bt_system_apply.Size = new System.Drawing.Size(46, 23);
			this.bt_system_apply.TabIndex = 123;
			this.bt_system_apply.Text = "적용";
			this.bt_system_apply.UseVisualStyleBackColor = true;
			this.bt_system_apply.Click += new System.EventHandler(this.bt_system_apply_Click);
			// 
			// bt_system_image
			// 
			this.bt_system_image.Location = new System.Drawing.Point(243, 34);
			this.bt_system_image.Name = "bt_system_image";
			this.bt_system_image.Size = new System.Drawing.Size(112, 23);
			this.bt_system_image.TabIndex = 122;
			this.bt_system_image.Text = "이미지 설정";
			this.bt_system_image.UseVisualStyleBackColor = true;
			this.bt_system_image.Click += new System.EventHandler(this.bt_system_image_Click);
			// 
			// pb_system_image
			// 
			this.pb_system_image.Image = global::GTWave.Properties.Resources.no_image;
			this.pb_system_image.Location = new System.Drawing.Point(249, 63);
			this.pb_system_image.Name = "pb_system_image";
			this.pb_system_image.Size = new System.Drawing.Size(91, 85);
			this.pb_system_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pb_system_image.TabIndex = 137;
			this.pb_system_image.TabStop = false;
			// 
			// b
			// 
			this.b.AutoSize = true;
			this.b.Location = new System.Drawing.Point(9, 69);
			this.b.Name = "b";
			this.b.Size = new System.Drawing.Size(44, 23);
			this.b.TabIndex = 136;
			this.b.Text = "규격";
			// 
			// tb_system_spec
			// 
			this.tb_system_spec.Location = new System.Drawing.Point(49, 65);
			this.tb_system_spec.Name = "tb_system_spec";
			this.tb_system_spec.Size = new System.Drawing.Size(188, 29);
			this.tb_system_spec.TabIndex = 120;
			// 
			// tb_system_desc
			// 
			this.tb_system_desc.Location = new System.Drawing.Point(49, 97);
			this.tb_system_desc.Multiline = true;
			this.tb_system_desc.Name = "tb_system_desc";
			this.tb_system_desc.Size = new System.Drawing.Size(188, 26);
			this.tb_system_desc.TabIndex = 121;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(9, 95);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(44, 23);
			this.label17.TabIndex = 124;
			this.label17.Text = "설명";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(9, 38);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(44, 23);
			this.label26.TabIndex = 121;
			this.label26.Text = "이름";
			// 
			// tb_system_name
			// 
			this.tb_system_name.Location = new System.Drawing.Point(49, 34);
			this.tb_system_name.Name = "tb_system_name";
			this.tb_system_name.Size = new System.Drawing.Size(188, 29);
			this.tb_system_name.TabIndex = 119;
			// 
			// ecp_device_log
			// 
			this.ecp_device_log.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ecp_device_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ecp_device_log.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
			this.ecp_device_log.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
			this.ecp_device_log.Controls.Add(this.nud_sales);
			this.ecp_device_log.Controls.Add(this.lv_device_log);
			this.ecp_device_log.Controls.Add(this.panel1);
			this.ecp_device_log.ExpandedHeight = 460;
			this.ecp_device_log.IsExpanded = true;
			this.ecp_device_log.IsReloadVisible = true;
			this.ecp_device_log.IsSaveVisible = true;
			this.ecp_device_log.Location = new System.Drawing.Point(3, 399);
			this.ecp_device_log.Name = "ecp_device_log";
			this.ecp_device_log.Size = new System.Drawing.Size(347, 460);
			this.ecp_device_log.TabIndex = 13;
			this.ecp_device_log.Text = "Device Log 정보";
			this.ecp_device_log.UseAnimation = true;
			// 
			// nud_sales
			// 
			this.nud_sales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nud_sales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.nud_sales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.nud_sales.Location = new System.Drawing.Point(3374, 40);
			this.nud_sales.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.nud_sales.Name = "nud_sales";
			this.nud_sales.Size = new System.Drawing.Size(52, 29);
			this.nud_sales.TabIndex = 272;
			// 
			// lv_device_log
			// 
			this.lv_device_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lv_device_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lv_device_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lv_device_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_log_no,
            this.ch_log_time,
            this.ch_log_ip,
            this.ch_log_name,
            this.ch_log_level,
            this.ch_log_message});
			this.lv_device_log.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lv_device_log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.lv_device_log.FullRowSelect = true;
			this.lv_device_log.GridLines = true;
			this.lv_device_log.HideSelection = false;
			this.lv_device_log.Location = new System.Drawing.Point(-67, -2);
			this.lv_device_log.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.lv_device_log.Name = "lv_device_log";
			this.lv_device_log.Size = new System.Drawing.Size(3418, 432);
			this.lv_device_log.TabIndex = 257;
			this.lv_device_log.UseCompatibleStateImageBehavior = false;
			this.lv_device_log.View = System.Windows.Forms.View.Details;
			// 
			// ch_log_no
			// 
			this.ch_log_no.Text = "No";
			this.ch_log_no.Width = 50;
			// 
			// ch_log_time
			// 
			this.ch_log_time.Text = "일시";
			this.ch_log_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ch_log_time.Width = 130;
			// 
			// ch_log_ip
			// 
			this.ch_log_ip.Text = "장비 IP";
			this.ch_log_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ch_log_ip.Width = 120;
			// 
			// ch_log_name
			// 
			this.ch_log_name.Text = "장비 명";
			this.ch_log_name.Width = 120;
			// 
			// ch_log_level
			// 
			this.ch_log_level.Text = "구분";
			this.ch_log_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ch_log_level.Width = 80;
			// 
			// ch_log_message
			// 
			this.ch_log_message.Text = "내용";
			this.ch_log_message.Width = 400;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel1.Controls.Add(this.lb_sale_nums);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.lb_sale_total);
			this.panel1.Controls.Add(this.bt_member_yesterday);
			this.panel1.Controls.Add(this.bt_member_today);
			this.panel1.Controls.Add(this.bt_member_3_month);
			this.panel1.Controls.Add(this.bt_member_one_month);
			this.panel1.Controls.Add(this.bt_member_excel);
			this.panel1.Controls.Add(this.bt_member_one_week);
			this.panel1.Controls.Add(this.pb_search_member);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dtp_member_e_date);
			this.panel1.Controls.Add(this.dtp_member_s_date);
			this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(3360, 34);
			this.panel1.TabIndex = 256;
			// 
			// lb_sale_nums
			// 
			this.lb_sale_nums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_sale_nums.Location = new System.Drawing.Point(3030, 8);
			this.lb_sale_nums.Name = "lb_sale_nums";
			this.lb_sale_nums.Size = new System.Drawing.Size(96, 18);
			this.lb_sale_nums.TabIndex = 272;
			this.lb_sale_nums.Text = "lb_sale_nums";
			this.lb_sale_nums.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3128, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 23);
			this.label5.TabIndex = 270;
			this.label5.Text = "건, 매출합계";
			// 
			// lb_sale_total
			// 
			this.lb_sale_total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lb_sale_total.Location = new System.Drawing.Point(3212, 7);
			this.lb_sale_total.Name = "lb_sale_total";
			this.lb_sale_total.Size = new System.Drawing.Size(96, 18);
			this.lb_sale_total.TabIndex = 269;
			this.lb_sale_total.Text = "lb_sale_total";
			this.lb_sale_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bt_member_yesterday
			// 
			this.bt_member_yesterday.Location = new System.Drawing.Point(341, 6);
			this.bt_member_yesterday.Name = "bt_member_yesterday";
			this.bt_member_yesterday.Size = new System.Drawing.Size(44, 23);
			this.bt_member_yesterday.TabIndex = 267;
			this.bt_member_yesterday.Text = "어제";
			this.bt_member_yesterday.UseVisualStyleBackColor = true;
			// 
			// bt_member_today
			// 
			this.bt_member_today.Location = new System.Drawing.Point(292, 6);
			this.bt_member_today.Name = "bt_member_today";
			this.bt_member_today.Size = new System.Drawing.Size(44, 23);
			this.bt_member_today.TabIndex = 265;
			this.bt_member_today.Text = "오늘";
			this.bt_member_today.UseVisualStyleBackColor = true;
			// 
			// bt_member_3_month
			// 
			this.bt_member_3_month.Location = new System.Drawing.Point(539, 6);
			this.bt_member_3_month.Name = "bt_member_3_month";
			this.bt_member_3_month.Size = new System.Drawing.Size(87, 23);
			this.bt_member_3_month.TabIndex = 264;
			this.bt_member_3_month.Text = "최근 3개월";
			this.bt_member_3_month.UseVisualStyleBackColor = true;
			// 
			// bt_member_one_month
			// 
			this.bt_member_one_month.Location = new System.Drawing.Point(465, 6);
			this.bt_member_one_month.Name = "bt_member_one_month";
			this.bt_member_one_month.Size = new System.Drawing.Size(75, 23);
			this.bt_member_one_month.TabIndex = 263;
			this.bt_member_one_month.Text = "최근 한달";
			this.bt_member_one_month.UseVisualStyleBackColor = true;
			// 
			// bt_member_excel
			// 
			this.bt_member_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_member_excel.Location = new System.Drawing.Point(3310, 5);
			this.bt_member_excel.Name = "bt_member_excel";
			this.bt_member_excel.Size = new System.Drawing.Size(45, 23);
			this.bt_member_excel.TabIndex = 262;
			this.bt_member_excel.Text = "엑셀";
			this.bt_member_excel.UseVisualStyleBackColor = true;
			// 
			// bt_member_one_week
			// 
			this.bt_member_one_week.Location = new System.Drawing.Point(391, 6);
			this.bt_member_one_week.Name = "bt_member_one_week";
			this.bt_member_one_week.Size = new System.Drawing.Size(75, 23);
			this.bt_member_one_week.TabIndex = 261;
			this.bt_member_one_week.Text = "최근 1주";
			this.bt_member_one_week.UseVisualStyleBackColor = true;
			// 
			// pb_search_member
			// 
			this.pb_search_member.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_search_member.BackgroundImage")));
			this.pb_search_member.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pb_search_member.Location = new System.Drawing.Point(257, 6);
			this.pb_search_member.Name = "pb_search_member";
			this.pb_search_member.Size = new System.Drawing.Size(30, 23);
			this.pb_search_member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_search_member.TabIndex = 260;
			this.pb_search_member.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(118, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 23);
			this.label2.TabIndex = 259;
			this.label2.Text = "~";
			// 
			// dtp_member_e_date
			// 
			this.dtp_member_e_date.Location = new System.Drawing.Point(139, 5);
			this.dtp_member_e_date.Name = "dtp_member_e_date";
			this.dtp_member_e_date.Size = new System.Drawing.Size(114, 29);
			this.dtp_member_e_date.TabIndex = 258;
			// 
			// dtp_member_s_date
			// 
			this.dtp_member_s_date.Location = new System.Drawing.Point(5, 5);
			this.dtp_member_s_date.Name = "dtp_member_s_date";
			this.dtp_member_s_date.Size = new System.Drawing.Size(112, 29);
			this.dtp_member_s_date.TabIndex = 256;
			// 
			// statusStrip1
			// 
			this.statusStrip1.AutoSize = false;
			this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
			this.statusStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusText,
            this.pbStatusProgress,
            this.lblSpring,
            this.lblEncoding,
            this.lblTime});
			this.statusStrip1.Location = new System.Drawing.Point(0, 1032);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1944, 28);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			this.statusStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip1_Paint);
			// 
			// lblStatusText
			// 
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size(39, 22);
			this.lblStatusText.Text = "준비";
			// 
			// pbStatusProgress
			// 
			this.pbStatusProgress.Name = "pbStatusProgress";
			this.pbStatusProgress.Size = new System.Drawing.Size(100, 20);
			this.pbStatusProgress.Visible = false;
			// 
			// lblSpring
			// 
			this.lblSpring.Name = "lblSpring";
			this.lblSpring.Size = new System.Drawing.Size(1778, 22);
			this.lblSpring.Spring = true;
			// 
			// lblEncoding
			// 
			this.lblEncoding.Name = "lblEncoding";
			this.lblEncoding.Size = new System.Drawing.Size(49, 22);
			this.lblEncoding.Text = "UTF-8";
			// 
			// lblTime
			// 
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(63, 22);
			this.lblTime.Text = "00:00:00";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.diagramToolStripMenuItem,
            this.로그ToolStripMenuItem,
            this.toosToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1944, 28);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로운구성도ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.구성도열기ToolStripMenuItem,
            this.구성도저장ToolStripMenuItem,
            this.구성도잠금수정불가ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.로그보기ToolStripMenuItem,
            this.로그저장ToolStripMenuItem,
            this.보고서출력ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.종료ToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeyDisplayString = "(Ctrl+F1)";
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.fileToolStripMenuItem.Text = "파일";
			// 
			// 새로운구성도ToolStripMenuItem
			// 
			this.새로운구성도ToolStripMenuItem.Name = "새로운구성도ToolStripMenuItem";
			this.새로운구성도ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
			this.새로운구성도ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.새로운구성도ToolStripMenuItem.Text = "새로운 구성도";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
			// 
			// 구성도열기ToolStripMenuItem
			// 
			this.구성도열기ToolStripMenuItem.Name = "구성도열기ToolStripMenuItem";
			this.구성도열기ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.구성도열기ToolStripMenuItem.Text = "구성도 열기";
			// 
			// 구성도저장ToolStripMenuItem
			// 
			this.구성도저장ToolStripMenuItem.Name = "구성도저장ToolStripMenuItem";
			this.구성도저장ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.구성도저장ToolStripMenuItem.Text = "구성도 저장";
			// 
			// 구성도잠금수정불가ToolStripMenuItem
			// 
			this.구성도잠금수정불가ToolStripMenuItem.Name = "구성도잠금수정불가ToolStripMenuItem";
			this.구성도잠금수정불가ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.구성도잠금수정불가ToolStripMenuItem.Text = "구성도 잠금(수정불가)";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(243, 6);
			// 
			// 로그보기ToolStripMenuItem
			// 
			this.로그보기ToolStripMenuItem.Name = "로그보기ToolStripMenuItem";
			this.로그보기ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.로그보기ToolStripMenuItem.Text = "로그 보기";
			// 
			// 로그저장ToolStripMenuItem
			// 
			this.로그저장ToolStripMenuItem.Name = "로그저장ToolStripMenuItem";
			this.로그저장ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.로그저장ToolStripMenuItem.Text = "로그 저장";
			// 
			// 보고서출력ToolStripMenuItem
			// 
			this.보고서출력ToolStripMenuItem.Name = "보고서출력ToolStripMenuItem";
			this.보고서출력ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.보고서출력ToolStripMenuItem.Text = "보고서 출력";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(243, 6);
			// 
			// 종료ToolStripMenuItem
			// 
			this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
			this.종료ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.종료ToolStripMenuItem.Text = "종료";
			// 
			// diagramToolStripMenuItem
			// 
			this.diagramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.모니터링중지ToolStripMenuItem,
            this.toolStripMenuItem5,
            this.장비검색ToolStripMenuItem});
			this.diagramToolStripMenuItem.Name = "diagramToolStripMenuItem";
			this.diagramToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
			this.diagramToolStripMenuItem.Text = "모니터링";
			// 
			// optionToolStripMenuItem
			// 
			this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
			this.optionToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.optionToolStripMenuItem.Text = "모니터링 시작";
			// 
			// 모니터링중지ToolStripMenuItem
			// 
			this.모니터링중지ToolStripMenuItem.Name = "모니터링중지ToolStripMenuItem";
			this.모니터링중지ToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.모니터링중지ToolStripMenuItem.Text = "모니터링 중지";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(184, 6);
			// 
			// 장비검색ToolStripMenuItem
			// 
			this.장비검색ToolStripMenuItem.Name = "장비검색ToolStripMenuItem";
			this.장비검색ToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.장비검색ToolStripMenuItem.Text = "장비 검색";
			// 
			// 로그ToolStripMenuItem
			// 
			this.로그ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시스템ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.시스템추가ToolStripMenuItem,
            this.시스템수정ToolStripMenuItem,
            this.시스템삭제ToolStripMenuItem,
            this.toolStripMenuItem7,
            this.그룹추가ToolStripMenuItem,
            this.그룹수정ToolStripMenuItem,
            this.그룹삭ㅈToolStripMenuItem});
			this.로그ToolStripMenuItem.Name = "로그ToolStripMenuItem";
			this.로그ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
			this.로그ToolStripMenuItem.Text = "Device";
			// 
			// 시스템ToolStripMenuItem
			// 
			this.시스템ToolStripMenuItem.Name = "시스템ToolStripMenuItem";
			this.시스템ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.시스템ToolStripMenuItem.Text = "Device 검색";
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(169, 6);
			// 
			// 시스템추가ToolStripMenuItem
			// 
			this.시스템추가ToolStripMenuItem.Name = "시스템추가ToolStripMenuItem";
			this.시스템추가ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.시스템추가ToolStripMenuItem.Text = "Device 추가";
			// 
			// 시스템수정ToolStripMenuItem
			// 
			this.시스템수정ToolStripMenuItem.Name = "시스템수정ToolStripMenuItem";
			this.시스템수정ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.시스템수정ToolStripMenuItem.Text = "Device 수정";
			// 
			// 시스템삭제ToolStripMenuItem
			// 
			this.시스템삭제ToolStripMenuItem.Name = "시스템삭제ToolStripMenuItem";
			this.시스템삭제ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.시스템삭제ToolStripMenuItem.Text = "Device 삭제";
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(169, 6);
			// 
			// 그룹추가ToolStripMenuItem
			// 
			this.그룹추가ToolStripMenuItem.Name = "그룹추가ToolStripMenuItem";
			this.그룹추가ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.그룹추가ToolStripMenuItem.Text = "그룹 추가";
			// 
			// 그룹수정ToolStripMenuItem
			// 
			this.그룹수정ToolStripMenuItem.Name = "그룹수정ToolStripMenuItem";
			this.그룹수정ToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.그룹수정ToolStripMenuItem.Text = "그룹 수정";
			// 
			// 그룹삭ㅈToolStripMenuItem
			// 
			this.그룹삭ㅈToolStripMenuItem.Name = "그룹삭ㅈToolStripMenuItem";
			this.그룹삭ㅈToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.그룹삭ㅈToolStripMenuItem.Text = "그룹 삭제";
			// 
			// toosToolStripMenuItem
			// 
			this.toosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem1,
            this.설정ToolStripMenuItem1,
            this.옵션ToolStripMenuItem,
            this.구성도배경ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.sNMPOIDTempleteToolStripMenuItem,
            this.toolStripMenuItem8,
            this.무선연결선그리기ToolStripMenuItem,
            this.toolStripMenuItem9,
            this.환경세팅ToolStripMenuItem});
			this.toosToolStripMenuItem.Name = "toosToolStripMenuItem";
			this.toosToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.toosToolStripMenuItem.Text = "도구";
			// 
			// optionToolStripMenuItem1
			// 
			this.optionToolStripMenuItem1.Name = "optionToolStripMenuItem1";
			this.optionToolStripMenuItem1.Size = new System.Drawing.Size(234, 26);
			this.optionToolStripMenuItem1.Text = "네트워크 설정";
			// 
			// 설정ToolStripMenuItem1
			// 
			this.설정ToolStripMenuItem1.Name = "설정ToolStripMenuItem1";
			this.설정ToolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
			// 
			// 옵션ToolStripMenuItem
			// 
			this.옵션ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.이름으로ToolStripMenuItem,
            this.iP주소로ToolStripMenuItem});
			this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
			this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
			this.옵션ToolStripMenuItem.Text = "시스템 명칭";
			// 
			// 이름으로ToolStripMenuItem
			// 
			this.이름으로ToolStripMenuItem.Name = "이름으로ToolStripMenuItem";
			this.이름으로ToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
			this.이름으로ToolStripMenuItem.Text = "이름으로";
			// 
			// iP주소로ToolStripMenuItem
			// 
			this.iP주소로ToolStripMenuItem.Name = "iP주소로ToolStripMenuItem";
			this.iP주소로ToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
			this.iP주소로ToolStripMenuItem.Text = "IP 주소로";
			// 
			// 구성도배경ToolStripMenuItem
			// 
			this.구성도배경ToolStripMenuItem.Name = "구성도배경ToolStripMenuItem";
			this.구성도배경ToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
			this.구성도배경ToolStripMenuItem.Text = "구성도 배경";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 6);
			// 
			// sNMPOIDTempleteToolStripMenuItem
			// 
			this.sNMPOIDTempleteToolStripMenuItem.Name = "sNMPOIDTempleteToolStripMenuItem";
			this.sNMPOIDTempleteToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
			this.sNMPOIDTempleteToolStripMenuItem.Text = "SNMP OID Templete";
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(231, 6);
			// 
			// 무선연결선그리기ToolStripMenuItem
			// 
			this.무선연결선그리기ToolStripMenuItem.Name = "무선연결선그리기ToolStripMenuItem";
			this.무선연결선그리기ToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
			this.무선연결선그리기ToolStripMenuItem.Text = "무선연결 선 그리기";
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(231, 6);
			// 
			// 환경세팅ToolStripMenuItem
			// 
			this.환경세팅ToolStripMenuItem.Name = "환경세팅ToolStripMenuItem";
			this.환경세팅ToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
			this.환경세팅ToolStripMenuItem.Text = "환경 세팅";
			this.환경세팅ToolStripMenuItem.Click += new System.EventHandler(this.환경세팅ToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용자관리ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// 사용자관리ToolStripMenuItem
			// 
			this.사용자관리ToolStripMenuItem.Name = "사용자관리ToolStripMenuItem";
			this.사용자관리ToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.사용자관리ToolStripMenuItem.Text = "프로그램 정보";
			this.사용자관리ToolStripMenuItem.Click += new System.EventHandler(this.사용자관리ToolStripMenuItem_Click);
			// 
			// 도움말ToolStripMenuItem
			// 
			this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
			this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.도움말ToolStripMenuItem.Text = "도움말";
			// 
			// diagram1
			// 
			this.diagram1.TouchHitDistance = null;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(142, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 23);
			this.label4.TabIndex = 79;
			this.label4.Text = "pixel";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label25.Location = new System.Drawing.Point(142, 53);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(45, 23);
			this.label25.TabIndex = 80;
			this.label25.Text = "pixel";
			// 
			// MainFormV1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1944, 1060);
			this.Controls.Add(this.sc_main);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainFormV1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GTWave NMS 시스템";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormV1_FormClosed);
			this.Load += new System.EventHandler(this.MainFormV1_Load);
			this.sc_main.Panel1.ResumeLayout(false);
			this.sc_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sc_main)).EndInit();
			this.sc_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_panel_right)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_panel_left)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_drawer)).EndInit();
			this.pn_top_info.ResumeLayout(false);
			this.sc_context.Panel1.ResumeLayout(false);
			this.sc_context.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sc_context)).EndInit();
			this.sc_context.ResumeLayout(false);
			this.sc_left.Panel1.ResumeLayout(false);
			this.sc_left.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sc_left)).EndInit();
			this.sc_left.ResumeLayout(false);
			this.sc_mem_list.Panel1.ResumeLayout(false);
			this.sc_mem_list.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sc_mem_list)).EndInit();
			this.sc_mem_list.ResumeLayout(false);
			this.sc_body.Panel1.ResumeLayout(false);
			this.sc_body.Panel2.ResumeLayout(false);
			this.sc_body.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sc_body)).EndInit();
			this.sc_body.ResumeLayout(false);
			this.aflp_manage.ResumeLayout(false);
			this.ecp_diagram.ResumeLayout(false);
			this.ecp_diagram.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel_zoom.ResumeLayout(false);
			this.panel_zoom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.track_zoom)).EndInit();
			this.main_ruler.ResumeLayout(false);
			this.ecp_scan_info.ResumeLayout(false);
			this.ecp_scan_info.PerformLayout();
			this.gb_device1.ResumeLayout(false);
			this.gb_device1.PerformLayout();
			this.gb_device0.ResumeLayout(false);
			this.gb_device0.PerformLayout();
			this.aflp_state.ResumeLayout(false);
			this.ecp_system_kind.ResumeLayout(false);
			this.ecp_system_kind.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_system_image)).EndInit();
			this.ecp_device_log.ResumeLayout(false);
			this.ecp_device_log.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_sales)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_search_member)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc_main;
        private System.Windows.Forms.SplitContainer sc_context;
        private System.Windows.Forms.SplitContainer sc_left;
        private System.Windows.Forms.SplitContainer sc_mem_list;
        private System.Windows.Forms.ListView lv_device_list;
        private System.Windows.Forms.ColumnHeader ch_dev_no;
        private System.Windows.Forms.ColumnHeader ch_dev_type;
        private System.Windows.Forms.ColumnHeader ch_dev_name;
        private System.Windows.Forms.ColumnHeader ch_dev_ip;
        private System.Windows.Forms.SplitContainer sc_body;
        private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel aflp_manage;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecp_diagram;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecp_system_kind;
        private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel aflp_state;
        private System.Windows.Forms.PictureBox pb_panel_left;
        private System.Windows.Forms.PictureBox pb_drawer;
        private System.Windows.Forms.ColumnHeader ch_dev_dumy;
        private System.Windows.Forms.ColumnHeader ch_dev_check_type;
        private System.Windows.Forms.ColumnHeader ch_dev_desc;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecp_device_log;
        private System.Windows.Forms.NumericUpDown nud_sales;
        private System.Windows.Forms.ListView lv_device_log;
        private System.Windows.Forms.ColumnHeader ch_log_no;
        private System.Windows.Forms.ColumnHeader ch_log_time;
        private System.Windows.Forms.ColumnHeader ch_log_ip;
        private System.Windows.Forms.ColumnHeader ch_log_name;
        private System.Windows.Forms.ColumnHeader ch_log_level;
        private System.Windows.Forms.ColumnHeader ch_log_message;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_sale_nums;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_sale_total;
        private System.Windows.Forms.Button bt_member_yesterday;
        private System.Windows.Forms.Button bt_member_today;
        private System.Windows.Forms.Button bt_member_3_month;
        private System.Windows.Forms.Button bt_member_one_month;
        private System.Windows.Forms.Button bt_member_excel;
        private System.Windows.Forms.Button bt_member_one_week;
        private System.Windows.Forms.PictureBox pb_search_member;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_member_e_date;
        private System.Windows.Forms.DateTimePicker dtp_member_s_date;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tb_system_name;
        private System.Windows.Forms.TextBox tb_system_desc;
        private System.Windows.Forms.Label label17;
		private System.Windows.Forms.PictureBox pb_panel_right;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private MindFusion.Diagramming.WinForms.DiagramView dv_netview;
		private MindFusion.Diagramming.Diagram main_diagram;
		private MindFusion.Diagramming.WinForms.Ruler main_ruler;
		private System.Windows.Forms.TreeView tv_group;
		private System.Windows.Forms.Button bt_group_save;
		private System.Windows.Forms.Button bt_system_image;
		private System.Windows.Forms.PictureBox pb_system_image;
		private System.Windows.Forms.Label b;
		private System.Windows.Forms.TextBox tb_system_spec;
		private System.Windows.Forms.Button bt_system_del;
		private System.Windows.Forms.Button bt_system_add;
		private System.Windows.Forms.Button bt_system_apply;
		private System.Windows.Forms.TextBox tb_system_image_path;
		private System.Windows.Forms.Label tb_group_title;
		private System.Windows.Forms.Panel panel3;
		// [수정] 가로형 커스텀 줌 컨트롤러 멤버 변수 선언
		// private MindFusion.Common.WinForms.ZoomControl zoomControl1;
		private System.Windows.Forms.Panel panel_zoom;
		private System.Windows.Forms.Button btn_zoom_out;
		private System.Windows.Forms.TrackBar track_zoom;
		private System.Windows.Forms.Button btn_zoom_in;
		private System.Windows.Forms.Label lbl_zoom;
		private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel ecp_scan_info;
		private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel advancedFlowLayoutPanel1;
		private System.Windows.Forms.GroupBox gb_device1;
		private System.Windows.Forms.Label lb_g_mode_1;
		private System.Windows.Forms.Label lb_g_freq_1;
		private System.Windows.Forms.Label lb_g_sec_1;
		private System.Windows.Forms.Label lb_g_ssid_1;
		private System.Windows.Forms.Label lb_g_bssid_1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox cb_auto_save;
		private System.Windows.Forms.Button bt_stop;
		private System.Windows.Forms.Button bt_print;
		private System.Windows.Forms.GroupBox gb_device0;
		private System.Windows.Forms.Label lb_g_mode_0;
		private System.Windows.Forms.Label lb_g_freq_0;
		private System.Windows.Forms.Label lb_g_sec_0;
		private System.Windows.Forms.Label lb_g_ssid_0;
		private System.Windows.Forms.Label lb_g_bssid_0;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tb_port;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label lb_uptime;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button bt_close;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cb_ip;
		private System.Windows.Forms.Button bt_scan;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 사용자관리ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem diagramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 로그ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 새로운구성도ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 구성도열기ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 구성도저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 구성도잠금수정불가ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 로그보기ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 로그저장ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 보고서출력ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 모니터링중지ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem 장비검색ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 시스템ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem 시스템추가ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 시스템수정ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 시스템삭제ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem 그룹추가ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 그룹수정ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 그룹삭ㅈToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator 설정ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 이름으로ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iP주소로ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 구성도배경ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem sNMPOIDTempleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem 무선연결선그리기ToolStripMenuItem;
		private System.Windows.Forms.Panel pn_top_info;
		private System.Windows.Forms.Button bt_finder;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem 환경세팅ToolStripMenuItem;
		private System.Windows.Forms.ListView lv_system;
		private System.Windows.Forms.ColumnHeader ch_system_no;
		private System.Windows.Forms.ColumnHeader ch_system_name;
		private System.Windows.Forms.ColumnHeader ch_system_spec;
		private System.Windows.Forms.ColumnHeader ch_system_desc;
		private System.Windows.Forms.ListView lv_scan_list;
		private System.Windows.Forms.ColumnHeader SSID;
		private System.Windows.Forms.ColumnHeader MAC;
		private System.Windows.Forms.ColumnHeader Signal;
		private System.Windows.Forms.ColumnHeader SigChain;
		private System.Windows.Forms.ColumnHeader RxRate;
		private System.Windows.Forms.ColumnHeader TxRate;
		private System.Windows.Forms.ColumnHeader TxCCQ;
		private System.Windows.Forms.Button pb_full_screen;
		private System.Windows.Forms.Button bt_status_mon;
		private MindFusion.Diagramming.Diagram diagram1;
		private System.Windows.Forms.Panel panel4;
		private MindFusion.Diagramming.WinForms.Overview overview1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox tb_diagram_h;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_diagram_w;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.ComboBox cb_line_direct;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cb_link_segment;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cb_link_style;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox cb_line_thick;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button bt_link_color;
		private System.Windows.Forms.Button bt_cls_bk_image;
		private System.Windows.Forms.Button bt_set_bk_image;
		private System.Windows.Forms.ComboBox cb_view_mode;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button bt_redo;
		private System.Windows.Forms.Button bt_undo;
		private System.Windows.Forms.Button bt_load_ncd;
		private System.Windows.Forms.Button bt_save_ncd;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
		private System.Windows.Forms.ToolStripProgressBar pbStatusProgress;
		private System.Windows.Forms.ToolStripStatusLabel lblSpring;
		private System.Windows.Forms.ToolStripStatusLabel lblEncoding;
		private System.Windows.Forms.ToolStripStatusLabel lblTime;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label25;
	}
}