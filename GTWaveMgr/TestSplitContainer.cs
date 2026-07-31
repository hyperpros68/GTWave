using System;
using System.Drawing;
using System.Windows.Forms;

namespace SplitContainerTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try {
                using (var form = new MainFormV1_Test()) {
                    Console.WriteLine("Successfully initialized.");
                }
            } catch (Exception ex) {
                Console.WriteLine("EXCEPTION: " + ex.ToString());
            }
        }
    }

    public class MainFormV1_Test : Form
    {
        private SplitContainer sc_main;
        private SplitContainer sc_context;
        private SplitContainer sc_left;
        private SplitContainer sc_mem_list;
        private SplitContainer sc_body;

        public MainFormV1_Test()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.sc_main = new System.Windows.Forms.SplitContainer();
            this.sc_context = new System.Windows.Forms.SplitContainer();
            this.sc_left = new System.Windows.Forms.SplitContainer();
            this.sc_mem_list = new System.Windows.Forms.SplitContainer();
            this.sc_body = new System.Windows.Forms.SplitContainer();

            ((System.ComponentModel.ISupportInitialize)(this.sc_main)).BeginInit();
            this.sc_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_context)).BeginInit();
            this.sc_context.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_left)).BeginInit();
            this.sc_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_mem_list)).BeginInit();
            this.sc_mem_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_body)).BeginInit();
            this.sc_body.SuspendLayout();
            this.SuspendLayout();

            // sc_main
            this.sc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_main.Name = "sc_main";
            this.sc_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sc_main.Panel1MinSize = 32;
            this.sc_main.SplitterDistance = 32;
            this.sc_main.TabIndex = 2;

            // sc_context
            this.sc_context.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_context.Size = new System.Drawing.Size(1922, 529);
            this.sc_context.SplitterDistance = 237;

            // sc_left
            this.sc_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_left.Size = new System.Drawing.Size(237, 529);
            this.sc_left.SplitterDistance = 180;

            // sc_mem_list
            this.sc_mem_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_mem_list.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.sc_mem_list.Size = new System.Drawing.Size(235, 343);
            this.sc_mem_list.SplitterDistance = 28;

            // sc_body
            this.sc_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_body.Size = new System.Drawing.Size(1681, 529);
            this.sc_body.SplitterDistance = 1306;
            this.sc_body.SplitterWidth = 5; // Simulating the scaled width or previous value

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 598);

            ((System.ComponentModel.ISupportInitialize)(this.sc_main)).EndInit();
            this.sc_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_context)).EndInit();
            this.sc_context.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_left)).EndInit();
            this.sc_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_mem_list)).EndInit();
            this.sc_mem_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_body)).EndInit();
            this.sc_body.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
