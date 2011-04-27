using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Best.Main {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form {
		private Best.Editor.TextEditor textEditor1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.textEditor1 = new Best.Editor.TextEditor();
			this.SuspendLayout();
			// 
			// textEditor1
			// 
			this.textEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditor1.Location = new System.Drawing.Point(0, 0);
			this.textEditor1.Name = "textEditor1";
			this.textEditor1.Size = new System.Drawing.Size(863, 521);
			this.textEditor1.TabIndex = 0;
			this.textEditor1.z_BackColor = System.Drawing.Color.Empty;
			this.textEditor1.z_ForeColor = System.Drawing.Color.Empty;
			this.textEditor1.z_RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.textEditor1.z_SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			this.textEditor1.z_Text = "";
			this.textEditor1.Load += new System.EventHandler(this.textEditor1_Load);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(863, 521);
			this.Controls.Add(this.textEditor1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Text Editor";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new Form1());
		}

		private void textEditor1_Load(object sender, EventArgs e) {

		}
	}
}
