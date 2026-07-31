using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MakarovDev.ExpandCollapsePanel
{
    /// <summary>
    /// The ExpandCollapsePanel control displays a header that has a collapsible window that displays content.
    /// </summary>
    [Designer(typeof(ExpandCollapsePanelDesigner))]
    public partial class ExpandCollapsePanel : Panel
    {
        /// <summary>
        /// Last stored size of panel's parent control
        /// <remarks>used for handling panel's Anchor property sets to Bottom when panel collapsed
        /// in OnSizeChanged method</remarks>
        /// </summary>
        private Size _previousParentSize = Size.Empty;

        /// <summary>
        /// Enable pretty simple animation of panel on expanding or collapsing
        /// </summary>
        private bool _useAnimation = true;

        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        private int _expandedHeight;

        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        private bool _IsSaveVisible;
        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        private bool _IsReloadVisible;

        /// <summary>
        /// Height of panel in collapsed state
        /// </summary>
        private readonly int _collapsedHeight;

        /// <summary>
        /// Height of panel in expanded state
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Height of panel in expanded state.")]
        [Browsable(true)]
        public int ExpandedHeight
        {
            get { return _expandedHeight; }
            set
            {
                _expandedHeight = value;
                if (IsExpanded)
                {
                    Height = _expandedHeight;
                }
            }
        }

        /// <summary>
        /// Set flag for expand or collapse panel content
        /// (true - expanded, false - collapsed)
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Expand or collapse panel content. " +
                     "\r\nAttention, for correct work with resizing child controls," +
                     " please set IsExpanded to \"false\" in code (for example in your Form class constructor after InitializeComponent method) and not in Forms Designer!")]
        [Browsable(true)]
        public bool IsReloadVisible
        {
            get { return _btnExpandCollapse.IsReloadVisible; }
            set 
            { 
                if(_btnExpandCollapse.IsReloadVisible != value)
                    _btnExpandCollapse.IsReloadVisible = value; 
            }
        }

        /// <summary>
        /// Set flag for expand or collapse panel content
        /// (true - expanded, false - collapsed)
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Expand or collapse panel content. " +
                     "\r\nAttention, for correct work with resizing child controls," +
                     " please set IsExpanded to \"false\" in code (for example in your Form class constructor after InitializeComponent method) and not in Forms Designer!")]
        [Browsable(true)]
        public bool IsSaveVisible
        {
            get { return _btnExpandCollapse.IsSaveVisible; }
            set 
            { 
                if(_btnExpandCollapse.IsSaveVisible != value)
                    _btnExpandCollapse.IsSaveVisible = value; 
            }
        }

        /// <summary>
        /// Set flag for expand or collapse panel content
        /// (true - expanded, false - collapsed)
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Expand or collapse panel content. " +
                     "\r\nAttention, for correct work with resizing child controls," +
                     " please set IsExpanded to \"false\" in code (for example in your Form class constructor after InitializeComponent method) and not in Forms Designer!")]
        [Browsable(true)]
        public bool IsExpanded
        {
            get { return _btnExpandCollapse.IsExpanded; }
            set 
            { 
                if(_btnExpandCollapse.IsExpanded != value)
                    _btnExpandCollapse.IsExpanded = value; 
            }
        }

		/// <summary>
		/// Header of panel
		/// </summary>
		[Category("ExpandCollapsePanel")]
        [Description("Header of panel.")]
        [Browsable(true)]
        public override string Text
        {
            get { return _btnExpandCollapse.Text; }
            set { _btnExpandCollapse.Text = value; }
        }

        /// <summary>
        /// Enable pretty simple animation of panel on expanding or collapsing
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Enable pretty simple animation of panel on expanding or collapsing.")]
        [Browsable(true)]
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set { _useAnimation = value; }
        }

        /// <summary>
        /// Visual style of the expand-collapse button.
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Visual style of the expand-collapse button.")]
        [Browsable(true)]
        public ExpandCollapseButton.ExpandButtonStyle ButtonStyle
        {
            get { return _btnExpandCollapse.ButtonStyle; }
            set { _btnExpandCollapse.ButtonStyle = value; }
        }

        /// <summary>
        /// Size preset of the expand-collapse button.
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Size preset of the expand-collapse button.")]
        [Browsable(true)]
        public ExpandCollapseButton.ExpandButtonSize ButtonSize
        {
            get { return _btnExpandCollapse.ButtonSize; }
            set { _btnExpandCollapse.ButtonSize = value; }
        }

        /// <summary>
        /// AutoScroll property
        /// <remarks>Overridden only to hide from designer as mindless and useless</remarks>
        /// </summary>
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>
        /// Font used for displays header text
        /// </summary>
        public override Font Font
        {
            get
            {
                return _btnExpandCollapse.Font;
            }
            set
            {
                _btnExpandCollapse.Font = value;
            }
        }

        /// <summary>
        /// Foreground color used for displays header text
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return _btnExpandCollapse.ForeColor;
            }
            set
            {
				_btnExpandCollapse.ForeColor = Color.Black; 
				//_btnExpandCollapse.ForeColor = value;

			}
		}

        /// <summary>
        /// Occurs when the panel has expanded or collapsed
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Occurs when save button push.")]
        [Browsable(true)]
        public event EventHandler<RefreshEventArgs> PanelSave;

        /// <summary>
        /// Occurs when the panel has expanded or collapsed
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Occurs when reload button push.")]
        [Browsable(true)]
        public event EventHandler<RefreshEventArgs> PanelRefresh;

        /// <summary>
        /// Occurs when the panel has expanded or collapsed
        /// </summary>
        [Category("ExpandCollapsePanel")]
        [Description("Occurs when the panel has expanded or collapsed.")]
        [Browsable(true)]
        public event EventHandler<ExpandCollapseEventArgs> ExpandCollapse;


        /// <summary>
        /// Constructor
        /// </summary>
        public ExpandCollapsePanel()
        {
            InitializeComponent();

            // make collapsed height equals to fit expand-collapse button
            _collapsedHeight = _btnExpandCollapse.Location.Y + _btnExpandCollapse.Size.Height + _btnExpandCollapse.Margin.Bottom;

            // right away manually scale expand-collapse button for filling the horizontal space of panel:
            _btnExpandCollapse.Size = new Size(ClientSize.Width - _btnExpandCollapse.Margin.Left - _btnExpandCollapse.Margin.Right,
                         _btnExpandCollapse.Height);

            // in spite of we always manually scale button, setting Anchor and AutoSize properties provide correct redraw of control in forms designer window
            _btnExpandCollapse.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            _btnExpandCollapse.AutoSize = true;

            // initial state of panel - expanded
            _btnExpandCollapse.IsExpanded = true;
            // subscribe for button expand-collapse state changed event
            _btnExpandCollapse.ExpandCollapse	+= BtnExpandCollapseExpandCollapse;
			_btnExpandCollapse.PanelRefresh		+= BtnExpandCollapsePanelRefresh;
			_btnExpandCollapse.PanelSave		+= BtnExpandCollapsePanelSave;

            // Initialize Resize Handle
            _resizeHandle = new Panel();
            _resizeHandle.Height = 6; // Slightly larger for easier grabbing
            _resizeHandle.Dock = DockStyle.None; // Changed from Bottom to None for Overlay
            _resizeHandle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _resizeHandle.BackColor = SystemColors.Control; // Make it visible
            _resizeHandle.Cursor = Cursors.SizeNS;
            _resizeHandle.MouseDown += ResizeHandle_MouseDown;
            _resizeHandle.MouseMove += ResizeHandle_MouseMove;
            _resizeHandle.MouseUp += ResizeHandle_MouseUp;
            _resizeHandle.Paint += ResizeHandle_Paint; // Add paint handler
            this.Controls.Add(_resizeHandle);
            // Ensure it starts in correct state
            _resizeHandle.Visible = IsExpanded;
            _resizeHandle.BringToFront();
        }

        /// <summary>
        /// Handle button expand-collapse state changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExpandCollapsePanelSave(object sender, RefreshEventArgs e)
        {
            // Retrieve expand-collapse state changed event for panel
            EventHandler<RefreshEventArgs> handler = PanelSave;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Handle button expand-collapse state changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExpandCollapsePanelRefresh(object sender, RefreshEventArgs e)
        {
            // Retrieve expand-collapse state changed event for panel
            EventHandler<RefreshEventArgs> handler = PanelRefresh;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Handle button expand-collapse state changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExpandCollapseExpandCollapse(object sender, ExpandCollapseEventArgs e)
        {
            if (e.IsExpanded) // if button is expanded now
            {
                Expand(); // expand the panel
            }
            else
            {
                Collapse(); // collapse the panel
            }

            // Retrieve expand-collapse state changed event for panel
            EventHandler<ExpandCollapseEventArgs> handler = ExpandCollapse;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Expand panel content
        /// </summary>
        protected virtual void Expand()
        {
            // if animation enabled
            if (UseAnimation)
            {
                // set internal state for Expanding
                _internalPanelState = InternalPanelState.Expanding;
                // start animation now..
                StartAnimation();
            }
            else // no animation, just expand immediately
            {
                // set internal state to Normal
                _internalPanelState = InternalPanelState.Normal;
                // resize panel
                Size = new Size(Size.Width, _expandedHeight);

                // resize panel
                Size = new Size(Size.Width, _expandedHeight);

            }
            if (_resizeHandle != null) _resizeHandle.Visible = true;
        }

        /// <summary>
        /// Collapse panel content
        /// </summary>
        protected virtual void Collapse()
        {
            // if panel is completely expanded (animation on expanding is ended or no animation at all) 
            // *we don't want store half-expanded panel height
            if (_internalPanelState == InternalPanelState.Normal)
            {
                // store current panel height in expanded state
                _expandedHeight = Size.Height;
            }

            // if animation enabled
            if (UseAnimation)
            {
                // set internal state for Collapsing
                _internalPanelState = InternalPanelState.Collapsing;
                // start animation now..
                StartAnimation();
            }
            else // no animation, just collapse immediately
            {
                // set internal state to Normal
                _internalPanelState = InternalPanelState.Normal;
                // resize panel
                Size = new Size(Size.Width, _collapsedHeight);
            }
            if (_resizeHandle != null) _resizeHandle.Visible = false;
        }

        /// <summary>
        /// Handle panel resize event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

			_btnExpandCollapse.SetPanelWidth(this.Width);
			// hyperpros fix
			//Console.WriteLine("ClientSize.Width : {0}, _btnExpandCollapse.Margin.Left : {1}, _btnExpandCollapse.Margin.Right : {2}, _btnExpandCollapse.Height : {3}", 
			//			ClientSize.Width, _btnExpandCollapse.Margin.Left, _btnExpandCollapse.Margin.Right, _btnExpandCollapse.Height);

			try { 
				// we always manually scale expand-collapse button for filling the horizontal space of panel:
				//_btnExpandCollapse.Size = new Size(ClientSize.Width - _btnExpandCollapse.Margin.Left - _btnExpandCollapse.Margin.Right,
                //_btnExpandCollapse.Height);
			} catch(Exception err) { } 

            // ignore height changing from animation timer
            if(_internalPanelState != InternalPanelState.Normal)
                return;

            #region Handling panel's Anchor property sets to Bottom when panel collapsed

            if (!IsExpanded // if panel collapsed
                && ((Anchor & AnchorStyles.Bottom) != 0) //and panel's Anchor property sets to Bottom
                && Size.Height != _collapsedHeight // and panel height is changed (it could happens only if parent control just has resized)
                && Parent != null) // and panel has the parent control
            {
                // main, calculate the parent control resize diff and add it to expandedHeight value:
                _expandedHeight += Parent.Height - _previousParentSize.Height;

                // reset resized height (by base.OnSizeChanged anchor.Bottom handling) to collapsedHeight value:
                Size = new Size(Size.Width, _collapsedHeight);
            }

            // store previous size of parent control (however we need only height)
            if(Parent != null)
                _previousParentSize = Parent.Size;
            #endregion

            // Force Resize Handle to be at the bottom and on top of everything (Overlay)
            if (!this.Disposing && !this.IsDisposed && _resizeHandle != null && !_resizeHandle.IsDisposed)
            {
               try {
                  if(_resizeHandle.IsHandleCreated) 
                  {
                     _resizeHandle.Bounds = new Rectangle(0, this.ClientSize.Height - 6, this.ClientSize.Width, 6);
                     _resizeHandle.BringToFront();
                  }
               } catch { } // Suppress any disposal race conditions
            }
        }

        #region Animation Code
        //	---------------------------------------------------------------------------------------
        //	The original source of this animation technique was written by
        //	Daren May for his Collapsible Panel implementation which can
        //	be found here:
        //		http://www.codeproject.com/cs/miscctrl/xpgroupbox.asp
        //   
        //	Although I found that piece of code in very good XPPanel implementation by Tom Guinther:
        //		http://www.codeproject.com/Articles/7332/Full-featured-XP-Style-Collapsible-Panel
        //  I have simplified things quite a bit, nothing is fundamentally different. 
        //  So I give many thanks to both for solving this problem.
        //	---------------------------------------------------------------------------------------

        // degree to adjust the height of the panel when animating
        private int _animationHeightAdjustment = 0;
        // current opacity level
        private int _animationOpacity = 0;

        /// <summary>
        /// Initialize animation values and start the timer
        /// </summary>
        private void StartAnimation()
        {
            _animationHeightAdjustment = 1;
            _animationOpacity = 5;
            animationTimer.Interval = 50;
            animationTimer.Enabled = true;
        }

        private void animationTimer_Tick(object sender, System.EventArgs e)
        {
            //	---------------------------------------------------------------
            //	Gradually reduce the interval between timer events so that the
            //	animation begins slowly and eventually accelerates to completion
            //	---------------------------------------------------------------
            if (animationTimer.Interval > 15)
            {
                animationTimer.Interval -= 15;
            }
            else
            {
                _animationHeightAdjustment += 30;
            }

            // Increase transparency as we collapse
            if ((_animationOpacity + 15) < byte.MaxValue)
            {
                _animationOpacity += 15;
            }

            int currOpacity = _animationOpacity;

            switch (_internalPanelState)
            {
                case InternalPanelState.Expanding:
                    // still room to expand?
                    if ((Height + _animationHeightAdjustment) < _expandedHeight)
                    {
                        Height += _animationHeightAdjustment;
                    }
                    else
                    {
                        // we are done so we dont want any transparency
                        currOpacity = byte.MaxValue;
                        Height = _expandedHeight;
                        _internalPanelState = InternalPanelState.Normal;
                    }
                    break;

                case InternalPanelState.Collapsing:
                    // still something to collapse
                    if ((Height - _animationHeightAdjustment) > _collapsedHeight)
                    {
                        Height -= _animationHeightAdjustment;
                        // continue decreasing opacity
                        currOpacity = byte.MaxValue - _animationOpacity;
                    }
                    else
                    {
                        // we are done so we dont want any transparency
                        currOpacity = byte.MaxValue;
                        Height = _collapsedHeight;
                        _internalPanelState = InternalPanelState.Normal;
                    }
                    break;

                default:
                    return;
            }

            // set the opacity for all the controls on the XPPanel
            SetControlsOpacity(currOpacity);

            // are we done?
            if (_internalPanelState == InternalPanelState.Normal)
            {
                animationTimer.Enabled = false;
            }

            Invalidate();
        }

        /// <summary>
        /// Changes the transparency of controls based upon the height of the XPPanel
        /// </summary>
        /// <remarks>
        /// Only used during animation
        /// </remarks>
        private void SetControlsOpacity(int opacity)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Visible)
                {
                    try
                    {
                        if (c.BackColor != Color.Transparent)
                        {
                            c.BackColor = Color.FromArgb(opacity, c.BackColor);
                        }
                        // ignore exception from controls that do not support transparent background color
                    }
                    catch
                    {
                    }
                    c.ForeColor = Color.FromArgb(opacity, c.ForeColor);
                }
            }
        }

        /// <summary>
        /// Internal state of panel used for checking that panel is animating now
        /// </summary>
        private InternalPanelState _internalPanelState;

        /// <summary>
        /// Internal state of panel
        /// </summary>
        private enum InternalPanelState
        {
            /// <summary>
            /// No animation, completely expanded or collapsed
            /// </summary>
            Normal,
            /// <summary>
            /// Expanding animation
            /// </summary>
            Expanding,
            /// <summary>
            /// Collapsing animation
            /// </summary>
            Collapsing
        }

        #endregion Animation Code
        #region Resizing Logic
        private Panel _resizeHandle;
        private bool _isResizing = false;
        private int _resizeDragStartY;
        private int _resizeStartHeight;

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (this.Disposing || this.IsDisposed) return;

            // Ensure resize handle stays at the bottom (Top of Z-order = Docked First = Bottom edge reserved first? 
            // Wait, Dock=Bottom with Z-Order 0 means it takes the bottom slither.
            // If other Fill controls are added, they fill the REST. 
            // So ResizeHandle MUST be Index 0 (High Priority).
            if (_resizeHandle != null && !_resizeHandle.IsDisposed && e.Control != _resizeHandle)
            {
                 try {
                    if(_resizeHandle.IsHandleCreated)
                        _resizeHandle.BringToFront();
                 } catch { }
            }
        }

        private void ResizeHandle_Paint(object sender, PaintEventArgs e)
        {
            // Draw a separator line at the top
            using (Pen pen = new Pen(SystemColors.ControlDark, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, _resizeHandle.Width, 0);
            }

            // Draw a grip handle (three small dots in the center)
            int centerX = _resizeHandle.Width / 2;
            int centerY = _resizeHandle.Height / 2;
            using (Brush brush = new SolidBrush(SystemColors.ControlDarkDark))
            {
                e.Graphics.FillRectangle(brush, centerX - 10, centerY - 1, 2, 2);
                e.Graphics.FillRectangle(brush, centerX, centerY - 1, 2, 2);
                e.Graphics.FillRectangle(brush, centerX + 10, centerY - 1, 2, 2);
            }
        }

        private void ResizeHandle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isResizing = true;
                _resizeDragStartY = Cursor.Position.Y;
                _resizeStartHeight = this.Height;
                if (_resizeHandle != null) _resizeHandle.Capture = true;
            }
        }

        private void ResizeHandle_MouseUp(object sender, MouseEventArgs e)
        {
            _isResizing = false;
            if (_resizeHandle != null) _resizeHandle.Capture = false;
        }

        private void ResizeHandle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isResizing)
            {
                int delta = Cursor.Position.Y - _resizeDragStartY;
                int newHeight = _resizeStartHeight + delta;

                // Constrain to collapsed height as minimum
                if (newHeight < _collapsedHeight) newHeight = _collapsedHeight;

                this.ExpandedHeight = newHeight;
                // Note: Setting ExpandedHeight updates Height if IsExpanded is true
            }
        }
        #endregion

    }
}
