namespace GTWave.gui {
	partial class NetworkDiagram {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkDiagram));
			this.zoomControl1 = new MindFusion.Common.WinForms.ZoomControl();
			this.dv_netview = new MindFusion.Diagramming.WinForms.DiagramView();
			this.main_diagram = new MindFusion.Diagramming.Diagram();
			this.main_ruler = new MindFusion.Diagramming.WinForms.Ruler();
			this.overview1 = new MindFusion.Diagramming.WinForms.Overview();
			this.shapeList = new MindFusion.Diagramming.WinForms.NodeListView();
			this.bt_load_ncd = new System.Windows.Forms.Button();
			this.bt_close_ncd = new System.Windows.Forms.Button();
			this.bt_save_ncd = new System.Windows.Forms.Button();
			this.bt_undo = new System.Windows.Forms.Button();
			this.bt_redo = new System.Windows.Forms.Button();
			this.shapeListBox1 = new MindFusion.Diagramming.WinForms.ShapeListBox();
			this.bt_link_color = new System.Windows.Forms.Button();
			this.cb_link_segment = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cb_link_style = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_diagram_w = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_diagram_h = new System.Windows.Forms.TextBox();
			this.bt_bk_image = new System.Windows.Forms.Button();
			this.cm_node_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.main_ruler.SuspendLayout();
			this.cm_node_menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// zoomControl1
			// 
			this.zoomControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.zoomControl1.BackColor = System.Drawing.Color.Transparent;
			this.zoomControl1.Location = new System.Drawing.Point(604, 56);
			this.zoomControl1.Name = "zoomControl1";
			this.zoomControl1.Padding = new System.Windows.Forms.Padding(5);
			this.zoomControl1.Size = new System.Drawing.Size(66, 150);
			this.zoomControl1.TabIndex = 0;
			this.zoomControl1.Target = this.dv_netview;
			this.zoomControl1.TickPosition = MindFusion.Common.WinForms.TickPosition.Left;
			// 
			// dv_netview
			// 
			this.dv_netview.AllowDrop = true;
			this.dv_netview.AllowInplaceEdit = true;
			this.dv_netview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dv_netview.BackgroundImage")));
			this.dv_netview.ControlHandlesStyle = MindFusion.Diagramming.HandlesStyle.DashFrame;
			this.dv_netview.Diagram = this.main_diagram;
			this.dv_netview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dv_netview.LicenseKey = null;
			this.dv_netview.Location = new System.Drawing.Point(18, 18);
			this.dv_netview.Name = "dv_netview";
			this.dv_netview.Size = new System.Drawing.Size(550, 432);
			this.dv_netview.TabIndex = 3;
			this.dv_netview.Text = "dv_netview";
			this.dv_netview.CreateEditControl += new System.EventHandler<MindFusion.Diagramming.WinForms.InPlaceEditEventArgs>(this.dv_netview_CreateEditControl);
			this.dv_netview.Click += new System.EventHandler(this.mf_netview_Click);
			this.dv_netview.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.dv_netview_ControlAdded);
			// 
			// main_diagram
			// 
			this.main_diagram.AllowSplitLinks = true;
			this.main_diagram.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("main_diagram.BackgroundImage")));
			this.main_diagram.BackgroundImageAlign = MindFusion.Drawing.ImageAlign.Fit;
			this.main_diagram.Bounds = ((System.Drawing.RectangleF)(resources.GetObject("main_diagram.Bounds")));
			this.main_diagram.DiagramLinkStyle.Brush = new MindFusion.Drawing.SolidBrush("#FF000000");
			this.main_diagram.DiagramLinkStyle.HeadStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
			this.main_diagram.DiagramLinkStyle.HeadStrokeDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			this.main_diagram.DiagramLinkStyle.HeadStrokeThickness = 0.1D;
			this.main_diagram.DiagramLinkStyle.Stroke = new MindFusion.Drawing.SolidBrush("#FFEE82EE");
			this.main_diagram.DiagramLinkStyle.StrokeDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			this.main_diagram.DiagramLinkStyle.StrokeThickness = 1D;
			this.main_diagram.DisabledHandlesStyle.DashPen = new MindFusion.Drawing.Pen("1/#FF000000/0/0/0//0/0/10/");
			this.main_diagram.LinkBaseShape = MindFusion.Diagramming.Shape.FromId("Alternative");
			this.main_diagram.LinkBaseShapeSize = 3F;
			this.main_diagram.LinkBranchIndicator = MindFusion.Diagramming.BranchIndicator.Arrow;
			this.main_diagram.LinkBrush = new MindFusion.Drawing.LinearGradientBrush("38.4537;#FF78DCFF;#FF78DCFF;0;0;0;0;");
			this.main_diagram.LinkCrossings = MindFusion.Diagramming.LinkCrossings.Arcs;
			this.main_diagram.LinkCustomDraw = MindFusion.Diagramming.CustomDraw.ShadowOnly;
			this.main_diagram.LinkHandlesStyle = MindFusion.Diagramming.HandlesStyle.DashFrame;
			this.main_diagram.LinkHeadShape = MindFusion.Diagramming.Shape.FromId("Alternative");
			this.main_diagram.LinkHeadShapeSize = 3F;
			this.main_diagram.LinkPen = new MindFusion.Drawing.Pen("3/#FF646400/0/0/10/0/0.06666667/0.1333333/0.2/0.2666667/0.4666667/0.5333334/0.6/0" +
        ".6666667/1//0/0/10/");
			this.main_diagram.LinkSegments = 4;
			this.main_diagram.ShapePen = new MindFusion.Drawing.Pen("3/#FF640000/0/0/0//0/0/10/");
			this.main_diagram.TouchHitDistance = null;
			this.main_diagram.LinkCreated += new System.EventHandler<MindFusion.Diagramming.LinkEventArgs>(this.main_diagram_LinkCreated);
			this.main_diagram.LinkCreating += new System.EventHandler<MindFusion.Diagramming.LinkValidationEventArgs>(this.main_diagram_LinkCreating);
			this.main_diagram.NodeClicked += new System.EventHandler<MindFusion.Diagramming.NodeEventArgs>(this.main_diagram_NodeClicked);
			this.main_diagram.NodeCreated += new System.EventHandler<MindFusion.Diagramming.NodeEventArgs>(this.main_diagram_NodeCreated);
			// 
			// main_ruler
			// 
			this.main_ruler.AllowDrop = true;
			this.main_ruler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.main_ruler.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.main_ruler.BackgroundImage = global::GTWave.Properties.Resources.icon_delete;
			this.main_ruler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.main_ruler.Controls.Add(this.dv_netview);
			this.main_ruler.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.main_ruler.Location = new System.Drawing.Point(38, 50);
			this.main_ruler.Name = "ruler1";
			this.main_ruler.Size = new System.Drawing.Size(568, 450);
			this.main_ruler.TabIndex = 1;
			this.main_ruler.Text = "ruler1";
			this.main_ruler.TextColor = System.Drawing.SystemColors.ControlText;
			// 
			// overview1
			// 
			this.overview1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.overview1.BackgroundImage = global::GTWave.Properties.Resources.refresh;
			this.overview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.overview1.DiagramView = this.dv_netview;
			this.overview1.Location = new System.Drawing.Point(669, 56);
			this.overview1.Name = "overview1";
			this.overview1.Size = new System.Drawing.Size(119, 150);
			this.overview1.TabIndex = 2;
			this.overview1.Text = "overview1";
			// 
			// shapeList
			// 
			this.shapeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.shapeList.Location = new System.Drawing.Point(613, 212);
			this.shapeList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.shapeList.Name = "shapeList";
			this.shapeList.Size = new System.Drawing.Size(174, 173);
			this.shapeList.TabIndex = 3;
			// 
			// bt_load_ncd
			// 
			this.bt_load_ncd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_load_ncd.Location = new System.Drawing.Point(334, 531);
			this.bt_load_ncd.Name = "bt_load_ncd";
			this.bt_load_ncd.Size = new System.Drawing.Size(115, 23);
			this.bt_load_ncd.TabIndex = 29;
			this.bt_load_ncd.Text = "구성도 불러오기";
			this.bt_load_ncd.UseVisualStyleBackColor = true;
			this.bt_load_ncd.Click += new System.EventHandler(this.bt_load_ncd_Click);
			// 
			// bt_close_ncd
			// 
			this.bt_close_ncd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_close_ncd.Location = new System.Drawing.Point(713, 19);
			this.bt_close_ncd.Name = "bt_close_ncd";
			this.bt_close_ncd.Size = new System.Drawing.Size(75, 23);
			this.bt_close_ncd.TabIndex = 28;
			this.bt_close_ncd.Text = "닫 기";
			this.bt_close_ncd.UseVisualStyleBackColor = true;
			this.bt_close_ncd.Click += new System.EventHandler(this.bt_close_ncd_Click);
			// 
			// bt_save_ncd
			// 
			this.bt_save_ncd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_save_ncd.Location = new System.Drawing.Point(468, 531);
			this.bt_save_ncd.Name = "bt_save_ncd";
			this.bt_save_ncd.Size = new System.Drawing.Size(115, 23);
			this.bt_save_ncd.TabIndex = 27;
			this.bt_save_ncd.Text = "구성도 저장하기";
			this.bt_save_ncd.UseVisualStyleBackColor = true;
			this.bt_save_ncd.Click += new System.EventHandler(this.bt_save_ncd_Click);
			// 
			// bt_undo
			// 
			this.bt_undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_undo.Location = new System.Drawing.Point(149, 531);
			this.bt_undo.Name = "bt_undo";
			this.bt_undo.Size = new System.Drawing.Size(75, 23);
			this.bt_undo.TabIndex = 30;
			this.bt_undo.Text = "unDo";
			this.bt_undo.UseVisualStyleBackColor = true;
			this.bt_undo.Click += new System.EventHandler(this.bt_undo_Click);
			// 
			// bt_redo
			// 
			this.bt_redo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_redo.Location = new System.Drawing.Point(238, 531);
			this.bt_redo.Name = "bt_redo";
			this.bt_redo.Size = new System.Drawing.Size(75, 23);
			this.bt_redo.TabIndex = 31;
			this.bt_redo.Text = "reDo";
			this.bt_redo.UseVisualStyleBackColor = true;
			this.bt_redo.Click += new System.EventHandler(this.bt_redo_Click);
			// 
			// shapeListBox1
			// 
			this.shapeListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.shapeListBox1.FormattingEnabled = true;
			this.shapeListBox1.Location = new System.Drawing.Point(613, 391);
			this.shapeListBox1.Name = "shapeListBox1";
			this.shapeListBox1.Size = new System.Drawing.Size(174, 136);
			this.shapeListBox1.TabIndex = 32;
			// 
			// bt_link_color
			// 
			this.bt_link_color.Location = new System.Drawing.Point(36, 17);
			this.bt_link_color.Name = "bt_link_color";
			this.bt_link_color.Size = new System.Drawing.Size(75, 23);
			this.bt_link_color.TabIndex = 33;
			this.bt_link_color.Text = "link color";
			this.bt_link_color.UseVisualStyleBackColor = true;
			this.bt_link_color.Click += new System.EventHandler(this.bt_link_color_Click);
			// 
			// cb_link_segment
			// 
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
			this.cb_link_segment.Location = new System.Drawing.Point(184, 19);
			this.cb_link_segment.Name = "cb_link_segment";
			this.cb_link_segment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cb_link_segment.Size = new System.Drawing.Size(33, 20);
			this.cb_link_segment.TabIndex = 34;
			this.cb_link_segment.Text = "2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(125, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 12);
			this.label1.TabIndex = 35;
			this.label1.Text = "Segment";
			// 
			// cb_link_style
			// 
			this.cb_link_style.FormattingEnabled = true;
			this.cb_link_style.Items.AddRange(new object[] {
            "Solid",
            "Dot",
            "DashDot",
            "DashDotDot",
            "Dash"});
			this.cb_link_style.Location = new System.Drawing.Point(302, 19);
			this.cb_link_style.Name = "cb_link_style";
			this.cb_link_style.Size = new System.Drawing.Size(97, 20);
			this.cb_link_style.TabIndex = 36;
			this.cb_link_style.Text = "DashDotDot";
			this.cb_link_style.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(236, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 12);
			this.label2.TabIndex = 37;
			this.label2.Text = "Link Style";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(436, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 12);
			this.label3.TabIndex = 38;
			this.label3.Text = "Size W :";
			// 
			// tb_diagram_w
			// 
			this.tb_diagram_w.Location = new System.Drawing.Point(490, 17);
			this.tb_diagram_w.Name = "tb_diagram_w";
			this.tb_diagram_w.Size = new System.Drawing.Size(51, 21);
			this.tb_diagram_w.TabIndex = 39;
			this.tb_diagram_w.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tb_diagram_w.TextChanged += new System.EventHandler(this.tb_diagram_w_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(547, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 12);
			this.label4.TabIndex = 40;
			this.label4.Text = "H :";
			// 
			// tb_diagram_h
			// 
			this.tb_diagram_h.Location = new System.Drawing.Point(570, 18);
			this.tb_diagram_h.Name = "tb_diagram_h";
			this.tb_diagram_h.Size = new System.Drawing.Size(49, 21);
			this.tb_diagram_h.TabIndex = 41;
			this.tb_diagram_h.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tb_diagram_h.TextChanged += new System.EventHandler(this.tb_diagram_h_TextChanged);
			// 
			// bt_bk_image
			// 
			this.bt_bk_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bt_bk_image.Location = new System.Drawing.Point(34, 531);
			this.bt_bk_image.Name = "bt_bk_image";
			this.bt_bk_image.Size = new System.Drawing.Size(109, 23);
			this.bt_bk_image.TabIndex = 42;
			this.bt_bk_image.Text = "백그라운드 변경";
			this.bt_bk_image.UseVisualStyleBackColor = true;
			this.bt_bk_image.Click += new System.EventHandler(this.bt_bk_image_Click);
			// 
			// cm_node_menu
			// 
			this.cm_node_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
			this.cm_node_menu.Name = "cm_node_menu";
			this.cm_node_menu.Size = new System.Drawing.Size(183, 48);
			this.cm_node_menu.Opening += new System.ComponentModel.CancelEventHandler(this.cm_node_menu_Opening);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.toolStripMenuItem1.Text = "toolStripMenuItem1";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
			this.toolStripMenuItem2.Text = "toolStripMenuItem2";
			// 
			// NetworkDiagram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 566);
			this.Controls.Add(this.bt_bk_image);
			this.Controls.Add(this.tb_diagram_h);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tb_diagram_w);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cb_link_style);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cb_link_segment);
			this.Controls.Add(this.bt_link_color);
			this.Controls.Add(this.shapeListBox1);
			this.Controls.Add(this.bt_redo);
			this.Controls.Add(this.bt_undo);
			this.Controls.Add(this.bt_load_ncd);
			this.Controls.Add(this.bt_close_ncd);
			this.Controls.Add(this.bt_save_ncd);
			this.Controls.Add(this.shapeList);
			this.Controls.Add(this.overview1);
			this.Controls.Add(this.main_ruler);
			this.Controls.Add(this.zoomControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NetworkDiagram";
			this.Text = "GTWave Network configuration diagram";
			this.main_ruler.ResumeLayout(false);
			this.cm_node_menu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MindFusion.Common.WinForms.ZoomControl zoomControl1;
		private MindFusion.Diagramming.WinForms.Ruler main_ruler;
		private MindFusion.Diagramming.WinForms.DiagramView dv_netview;
		private MindFusion.Diagramming.Diagram main_diagram;
		private MindFusion.Diagramming.WinForms.Overview overview1;
		private MindFusion.Diagramming.WinForms.NodeListView shapeList;
		private System.Windows.Forms.Button bt_load_ncd;
		private System.Windows.Forms.Button bt_close_ncd;
		private System.Windows.Forms.Button bt_save_ncd;
		private System.Windows.Forms.Button bt_undo;
		private System.Windows.Forms.Button bt_redo;
		private MindFusion.Diagramming.WinForms.ShapeListBox shapeListBox1;
		private System.Windows.Forms.Button bt_link_color;
		private System.Windows.Forms.ComboBox cb_link_segment;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_link_style;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_diagram_w;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_diagram_h;
		private System.Windows.Forms.Button bt_bk_image;
		private System.Windows.Forms.ContextMenuStrip cm_node_menu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
	}
}