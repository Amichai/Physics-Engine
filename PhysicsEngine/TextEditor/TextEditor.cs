#region USING
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

using System.Reflection;
#endregion

namespace Best.Editor {
	public class TextEditor : System.Windows.Forms.UserControl {
		#region A. COMPONENT
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblCol;
		private System.Windows.Forms.Label lblRow;
		private System.Windows.Forms.Label lblLine;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblChars;
		private System.Windows.Forms.Label lblRules;
		private System.Windows.Forms.Panel pnlCenter;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lblCorner;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblWord;
		private System.Windows.Forms.ComboBox cmbSize;
		private System.Windows.Forms.Panel pnlStatus;
		private System.Windows.Forms.ComboBox cmbPos;
		private System.Windows.Forms.Button btnFC;
		private System.Windows.Forms.Button btnBC;
		private System.Windows.Forms.Button btnSC;
		private System.Windows.Forms.Label lblStatus;
		private System.ComponentModel.Container components = null;
		#endregion

		#region B. COMPONENT DESIGNER GENERATED CODE
		private void InitializeComponent() {
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.lblRules = new System.Windows.Forms.Label();
			this.lblLine = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblRow = new System.Windows.Forms.Label();
			this.lblCol = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblChars = new System.Windows.Forms.Label();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnSC = new System.Windows.Forms.Button();
			this.btnBC = new System.Windows.Forms.Button();
			this.btnFC = new System.Windows.Forms.Button();
			this.cmbSize = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblWord = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbPos = new System.Windows.Forms.ComboBox();
			this.pnlCenter = new System.Windows.Forms.Panel();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblCorner = new System.Windows.Forms.Label();
			this.pnlStatus.SuspendLayout();
			this.pnlCenter.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.AcceptsTab = true;
			this.richTextBox1.BackColor = System.Drawing.Color.White;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.ForeColor = System.Drawing.Color.Black;
			this.richTextBox1.Location = new System.Drawing.Point(36, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.RightMargin = 630;
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.richTextBox1.Size = new System.Drawing.Size(600, 540);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
			this.richTextBox1.VScroll += new System.EventHandler(this.richTextBox1_VScroll);
			this.richTextBox1.FontChanged += new System.EventHandler(this.richTextBox1_FontChanged);
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
			this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
			this.richTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
			this.richTextBox1.Resize += new System.EventHandler(this.richTextBox1_Resize);
			// 
			// lblRules
			// 
			this.lblRules.BackColor = System.Drawing.Color.White;
			this.lblRules.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblRules.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRules.ForeColor = System.Drawing.Color.Black;
			this.lblRules.Location = new System.Drawing.Point(36, 0);
			this.lblRules.Name = "lblRules";
			this.lblRules.Size = new System.Drawing.Size(600, 20);
			this.lblRules.TabIndex = 1;
			// 
			// lblLine
			// 
			this.lblLine.BackColor = System.Drawing.Color.Silver;
			this.lblLine.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.lblLine.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLine.ForeColor = System.Drawing.Color.Black;
			this.lblLine.Location = new System.Drawing.Point(0, 0);
			this.lblLine.Name = "lblLine";
			this.lblLine.Size = new System.Drawing.Size(36, 540);
			this.lblLine.TabIndex = 1;
			this.lblLine.Text = "1";
			this.lblLine.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Line:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(108, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "Col:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRow
			// 
			this.lblRow.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblRow.Location = new System.Drawing.Point(44, 0);
			this.lblRow.Name = "lblRow";
			this.lblRow.Size = new System.Drawing.Size(64, 20);
			this.lblRow.TabIndex = 5;
			this.lblRow.Text = "1";
			this.lblRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblCol
			// 
			this.lblCol.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblCol.Location = new System.Drawing.Point(148, 0);
			this.lblCol.Name = "lblCol";
			this.lblCol.Size = new System.Drawing.Size(60, 20);
			this.lblCol.TabIndex = 6;
			this.lblCol.Text = "1";
			this.lblCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(208, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Char:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblChars
			// 
			this.lblChars.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblChars.Location = new System.Drawing.Point(260, 0);
			this.lblChars.Name = "lblChars";
			this.lblChars.Size = new System.Drawing.Size(64, 20);
			this.lblChars.TabIndex = 8;
			this.lblChars.Text = "0";
			this.lblChars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlStatus
			// 
			this.pnlStatus.BackColor = System.Drawing.Color.RosyBrown;
			this.pnlStatus.Controls.Add(this.lblStatus);
			this.pnlStatus.Controls.Add(this.btnSC);
			this.pnlStatus.Controls.Add(this.btnBC);
			this.pnlStatus.Controls.Add(this.btnFC);
			this.pnlStatus.Controls.Add(this.cmbSize);
			this.pnlStatus.Controls.Add(this.label1);
			this.pnlStatus.Controls.Add(this.lblWord);
			this.pnlStatus.Controls.Add(this.label5);
			this.pnlStatus.Controls.Add(this.lblChars);
			this.pnlStatus.Controls.Add(this.label2);
			this.pnlStatus.Controls.Add(this.lblCol);
			this.pnlStatus.Controls.Add(this.label4);
			this.pnlStatus.Controls.Add(this.lblRow);
			this.pnlStatus.Controls.Add(this.label3);
			this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlStatus.ForeColor = System.Drawing.Color.Black;
			this.pnlStatus.Location = new System.Drawing.Point(0, 20);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Size = new System.Drawing.Size(756, 20);
			this.pnlStatus.TabIndex = 10;
			// 
			// lblStatus
			// 
			this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStatus.Location = new System.Drawing.Point(700, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(56, 20);
			this.lblStatus.TabIndex = 19;
			this.lblStatus.Text = "...";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSC
			// 
			this.btnSC.BackColor = System.Drawing.SystemColors.Control;
			this.btnSC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSC.ForeColor = System.Drawing.Color.Black;
			this.btnSC.Location = new System.Drawing.Point(660, 0);
			this.btnSC.Name = "btnSC";
			this.btnSC.Size = new System.Drawing.Size(40, 20);
			this.btnSC.TabIndex = 18;
			this.btnSC.Text = "SC";
			this.btnSC.UseVisualStyleBackColor = false;
			this.btnSC.Click += new System.EventHandler(this.btnSC_Click);
			// 
			// btnBC
			// 
			this.btnBC.BackColor = System.Drawing.SystemColors.Control;
			this.btnBC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnBC.ForeColor = System.Drawing.Color.Black;
			this.btnBC.Location = new System.Drawing.Point(620, 0);
			this.btnBC.Name = "btnBC";
			this.btnBC.Size = new System.Drawing.Size(40, 20);
			this.btnBC.TabIndex = 17;
			this.btnBC.Text = "BC";
			this.btnBC.UseVisualStyleBackColor = false;
			this.btnBC.Click += new System.EventHandler(this.btnBC_Click);
			// 
			// btnFC
			// 
			this.btnFC.BackColor = System.Drawing.SystemColors.Control;
			this.btnFC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFC.ForeColor = System.Drawing.Color.Black;
			this.btnFC.Location = new System.Drawing.Point(580, 0);
			this.btnFC.Name = "btnFC";
			this.btnFC.Size = new System.Drawing.Size(40, 20);
			this.btnFC.TabIndex = 16;
			this.btnFC.Text = "FC";
			this.btnFC.UseVisualStyleBackColor = false;
			this.btnFC.Click += new System.EventHandler(this.btnFC_Click);
			// 
			// cmbSize
			// 
			this.cmbSize.Dock = System.Windows.Forms.DockStyle.Left;
			this.cmbSize.Location = new System.Drawing.Point(492, 0);
			this.cmbSize.Name = "cmbSize";
			this.cmbSize.Size = new System.Drawing.Size(88, 22);
			this.cmbSize.TabIndex = 15;
			this.cmbSize.Text = "Small";
			this.cmbSize.SelectedIndexChanged += new System.EventHandler(this.cmbSize_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(440, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 20);
			this.label1.TabIndex = 11;
			this.label1.Text = "Size:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblWord
			// 
			this.lblWord.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblWord.Location = new System.Drawing.Point(376, 0);
			this.lblWord.Name = "lblWord";
			this.lblWord.Size = new System.Drawing.Size(64, 20);
			this.lblWord.TabIndex = 14;
			this.lblWord.Text = "0";
			this.lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(324, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 20);
			this.label5.TabIndex = 13;
			this.label5.Text = "Word:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbPos
			// 
			this.cmbPos.Location = new System.Drawing.Point(648, 8);
			this.cmbPos.Name = "cmbPos";
			this.cmbPos.Size = new System.Drawing.Size(76, 21);
			this.cmbPos.TabIndex = 17;
			this.cmbPos.Text = "Left";
			this.cmbPos.Visible = false;
			this.cmbPos.SelectedIndexChanged += new System.EventHandler(this.cmbPos_SelectedIndexChanged);
			// 
			// pnlCenter
			// 
			this.pnlCenter.BackColor = System.Drawing.Color.Silver;
			this.pnlCenter.Controls.Add(this.richTextBox1);
			this.pnlCenter.Controls.Add(this.lblLine);
			this.pnlCenter.Controls.Add(this.cmbPos);
			this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCenter.Location = new System.Drawing.Point(0, 40);
			this.pnlCenter.Name = "pnlCenter";
			this.pnlCenter.Size = new System.Drawing.Size(756, 540);
			this.pnlCenter.TabIndex = 11;
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.Silver;
			this.pnlTop.Controls.Add(this.lblRules);
			this.pnlTop.Controls.Add(this.lblCorner);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(756, 20);
			this.pnlTop.TabIndex = 13;
			// 
			// lblCorner
			// 
			this.lblCorner.BackColor = System.Drawing.Color.Silver;
			this.lblCorner.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblCorner.Location = new System.Drawing.Point(0, 0);
			this.lblCorner.Name = "lblCorner";
			this.lblCorner.Size = new System.Drawing.Size(36, 20);
			this.lblCorner.TabIndex = 2;
			// 
			// TextEditor
			// 
			this.Controls.Add(this.pnlCenter);
			this.Controls.Add(this.pnlStatus);
			this.Controls.Add(this.pnlTop);
			this.Name = "TextEditor";
			this.Size = new System.Drawing.Size(756, 580);
			this.Resize += new System.EventHandler(this.TextEditor_Resize);
			this.pnlStatus.ResumeLayout(false);
			this.pnlCenter.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region C. CONSTRUCTOR & DESTRUCTOR
		public TextEditor() {
			InitializeComponent();
			lblRules.Text = rulerLeftToRight;
			lblCorner.Width = lblLine.Width;

			defaultContextCombo();
			defaultContextMenu();
			defaultContextSize();
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion

		#region D. VARIABLE
		private ContextMenu popUpMenu;
		private const string rulerLeftToRight = "---------1---------2---------3---------4---------5---------6---------7---------8";
		private const string rulerRightToLeft = "---------8---------7---------6---------5---------4---------3---------2---------1";
		#endregion

		#region E. METHOD
		private void defaultContextCombo() {
			cmbSize.Items.Clear();
			cmbSize.Items.Add("Small");
			cmbSize.Items.Add("Medium");
			cmbSize.Items.Add("Large");
			cmbSize.SelectedIndex = 1;

			cmbPos.Items.Clear();
			cmbPos.Items.Add("Left");
			cmbPos.Items.Add("Right");
			cmbPos.SelectedIndex = 0;
		}
		private void defaultContextMenu() {
			popUpMenu = new ContextMenu();
			popUpMenu.MenuItems.Add("Cu&t", new EventHandler(popup));
			popUpMenu.MenuItems.Add("&Copy", new EventHandler(popup));
			popUpMenu.MenuItems.Add("&Paste", new EventHandler(popup));
			popUpMenu.MenuItems.Add("&Delete", new EventHandler(popup));
			popUpMenu.MenuItems.Add("-", new EventHandler(popup));
			popUpMenu.MenuItems.Add("&Select All", new EventHandler(popup));
			popUpMenu.MenuItems[0].Enabled = false;
			popUpMenu.MenuItems[1].Enabled = false;
			popUpMenu.MenuItems[2].Enabled = true;
			popUpMenu.MenuItems[3].Enabled = false;
			popUpMenu.MenuItems[4].Enabled = false;
			popUpMenu.MenuItems[5].Enabled = false;
			richTextBox1.ContextMenu = popUpMenu;
		}
		private void defaultContextSize() {
			if (cmbSize.SelectedIndex == 0) {
				richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, 9.75f);
				richTextBox1.RightMargin = 645;
				lblRules.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 0.080f);
				lblRules.Width = pnlStatus.Width = richTextBox1.Width = 670;
				lblLine.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size + 0.850f);
			} else if (cmbSize.SelectedIndex == 1) {
				richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, 12.0f);
				richTextBox1.RightMargin = 805;
				lblRules.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size + 0.100f);
				lblRules.Width = pnlStatus.Width = richTextBox1.Width = 820;
				lblLine.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 0.100f);
			} else if (cmbSize.SelectedIndex == 2) {
				richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, 14.25f);
				richTextBox1.RightMargin = 885;
				lblRules.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 0.930f);
				lblRules.Width = pnlStatus.Width = richTextBox1.Width = 910;
				lblLine.Font = new System.Drawing.Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 0.350f);
			}
		}
		private void defaultContextPos() {
			if (cmbPos.SelectedIndex == 0) {
				lblCorner.Dock = DockStyle.Left;
				lblRules.Dock = DockStyle.Left;
				lblRules.RightToLeft = RightToLeft.No;
				lblLine.Dock = DockStyle.Left;
				lblLine.TextAlign = ContentAlignment.TopRight;
				richTextBox1.Dock = DockStyle.Left;
				richTextBox1.RightToLeft = RightToLeft.No;
				richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
			} else if (cmbPos.SelectedIndex == 1) {
				lblCorner.Dock = DockStyle.Right;
				lblRules.Dock = DockStyle.Right;
				lblRules.RightToLeft = RightToLeft.Yes;
				lblLine.Dock = DockStyle.Right;
				lblLine.TextAlign = ContentAlignment.TopLeft;
				richTextBox1.Dock = DockStyle.Right;
				richTextBox1.RightToLeft = RightToLeft.Yes;
				richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
			}
		}
		private void updateNumberLabel() {
			//we get index of first visible char and number of first visible line
			System.Drawing.Point pos = new System.Drawing.Point(0, 0);
			int firstIndex = richTextBox1.GetCharIndexFromPosition(pos);
			int firstLine = richTextBox1.GetLineFromCharIndex(firstIndex);

			//now we get index of last visible char and number of last visible line
			pos.X = ClientRectangle.Width;
			pos.Y = ClientRectangle.Height;
			int lastIndex = richTextBox1.GetCharIndexFromPosition(pos);
			int lastLine = richTextBox1.GetLineFromCharIndex(lastIndex);

			//this is point position of last visible char, we'll use its Y value for calculating numberLabel size
			pos = richTextBox1.GetPositionFromCharIndex(lastIndex);

			//finally, renumber label
			lblLine.Text = "";
			for (int i = firstLine; i <= lastLine + 1; i++) {
				lblLine.Text += i + 1 + "\n";
			}
		}

		private void updateCount() {
			string s = richTextBox1.Text.Replace("\n", "");
			lblChars.Text = s.Length.ToString();
			string[] word = richTextBox1.Text.Split(' ');
			if (richTextBox1.Text.Length == 0)
				lblWord.Text = "0";
			else
				lblWord.Text = word.Length.ToString();
		}
		#endregion

		#region F. POPUP
		private void popup(object sender, EventArgs e) {
			MenuItem miClicked = (MenuItem)sender;

			string item = miClicked.Text;
			if (item == "Cu&t") {
				Clipboard.SetDataObject(richTextBox1.SelectedText);
				richTextBox1.SelectedText = "";
				updateCount();
			}
			if (item == "&Copy") {
				richTextBox1.Copy();
			}
			if (item == "&Paste") {
				if (Clipboard.GetDataObject().GetDataPresent(DataFormats.UnicodeText)) {
					richTextBox1.SelectedText = Clipboard.GetDataObject().GetData(DataFormats.UnicodeText).ToString();
					richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.Font.Name, richTextBox1.Font.Size);
					richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.Name, richTextBox1.Font.Size);
					richTextBox1.ForeColor = Color.Black;
					updateCount();
				}
			}
			if (item == "&Delete") {
				richTextBox1.SelectedText = "";
				updateCount();
			}
			if (item == "&Select All") {
				richTextBox1.SelectAll();
			}
		}
		#endregion

		#region G. EVENT

		#region 1. TEXT EDITOR
		private void TextEditor_Resize(object sender, System.EventArgs e) {
			lblLine.Height = richTextBox1.Height;
		}
		#endregion

		#region 2. RICHTEXTBOX
		private void richTextBox1_VScroll(object sender, System.EventArgs e) {
			//move location of numberLabel for amount of pixels caused by scrollbar
			int d = richTextBox1.GetPositionFromCharIndex(0).Y % (richTextBox1.Font.Height + 1);
			lblLine.Location = new System.Drawing.Point(0, d);

			updateNumberLabel();
		}
		private void richTextBox1_Resize(object sender, System.EventArgs e) {
			richTextBox1_VScroll(null, null);
		}
		private void richTextBox1_TextChanged(object sender, System.EventArgs e) {
			updateNumberLabel();
			//updateCount();
		}
		private void richTextBox1_FontChanged(object sender, System.EventArgs e) {
			updateNumberLabel();
			richTextBox1_VScroll(null, null);
		}
		private void richTextBox1_SelectionChanged(object sender, System.EventArgs e) {
			System.Drawing.Point p = new System.Drawing.Point();
			p.X = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
			lblRow.Text = (p.X + 1).ToString();

			p = richTextBox1.GetPositionFromCharIndex(richTextBox1.SelectionStart);

			System.Drawing.Point p2 = new System.Drawing.Point(0, p.Y);
			int a = richTextBox1.GetCharIndexFromPosition(p2);
			int b = richTextBox1.SelectionStart;
			if (richTextBox1.TextLength == 0) lblCol.Text = "1";
			else if (p.X == 1 && b == richTextBox1.TextLength) lblCol.Text = (b - a).ToString();
			else lblCol.Text = (b - a + 1).ToString();
		}
		private void richTextBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (richTextBox1.Text.Length == 0) {
				popUpMenu.MenuItems[0].Enabled = false;
				popUpMenu.MenuItems[1].Enabled = false;
				popUpMenu.MenuItems[2].Enabled = true;
				popUpMenu.MenuItems[3].Enabled = false;
				popUpMenu.MenuItems[4].Enabled = false;
				popUpMenu.MenuItems[5].Enabled = false;
			} else {
				if (richTextBox1.SelectedText.Length > 0) {
					popUpMenu.MenuItems[0].Enabled = true;
					popUpMenu.MenuItems[1].Enabled = true;
					popUpMenu.MenuItems[2].Enabled = true;
					popUpMenu.MenuItems[3].Enabled = true;
					popUpMenu.MenuItems[4].Enabled = false;
					popUpMenu.MenuItems[5].Enabled = false;
				} else {
					popUpMenu.MenuItems[0].Enabled = false;
					popUpMenu.MenuItems[1].Enabled = false;
					popUpMenu.MenuItems[2].Enabled = true;
					popUpMenu.MenuItems[3].Enabled = false;
					popUpMenu.MenuItems[4].Enabled = false;
					popUpMenu.MenuItems[5].Enabled = true;
				}
			}
		}
		private void richTextBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			// Ctrl + C = 3
			// Ctrl + V = 22
			// Ctrl + X = 24
			if (e.KeyChar == (char)22) {
				if (Clipboard.GetDataObject().GetDataPresent(DataFormats.UnicodeText)) {
					string s = Clipboard.GetDataObject().GetData(DataFormats.UnicodeText).ToString();
					richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.Font.Name, richTextBox1.Font.Size);
					richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.Name, richTextBox1.Font.Size);
					richTextBox1.ForeColor = Color.Black;
					Clipboard.SetDataObject(s);
				}
			} else if (e.KeyChar == (char)9) {
				richTextBox1.SelectionStart = richTextBox1.SelectionStart + 5;
			}
		}
		private void richTextBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
			if (e.KeyValue != (char)32 && e.KeyValue != (char)9) updateCount();
		}
		#endregion

		#region 3. COMBO
		private void cmbSize_SelectedIndexChanged(object sender, System.EventArgs e) {
			defaultContextSize();
			richTextBox1.Font = new System.Drawing.Font(richTextBox1.Font.Name, richTextBox1.Font.Size);
		}
		private void cmbPos_SelectedIndexChanged(object sender, System.EventArgs e) {
			defaultContextPos();
		}
		#endregion

		#endregion

		#region H. PROPERTY
		protected Color foreColor;
		public Color z_ForeColor {

			get {
				return foreColor;
			}
			set {
				foreColor = value;
			}
		}
		protected Color backColor;
		public Color z_BackColor {

			get {
				return backColor;
			}
			set {
				backColor = value;
			}
		}
		public string z_Text {
			get {
				return richTextBox1.Text;
			}
			set {
				richTextBox1.Text = value;
			}
		}
		protected RightToLeft rtl;
		public RightToLeft z_RightToLeft {
			get {
				return richTextBox1.RightToLeft;
			}
			set {
				richTextBox1.RightToLeft = value;
			}
		}
		protected HorizontalAlignment sa;

		private void btnFC_Click(object sender, System.EventArgs e) {
			ColorDialog cd = new ColorDialog();
			cd.Color = richTextBox1.ForeColor;
			cd.ShowDialog();
			richTextBox1.ForeColor = cd.Color;
			lblRules.ForeColor = cd.Color;
		}

		private void btnBC_Click(object sender, System.EventArgs e) {
			ColorDialog cd = new ColorDialog();
			cd.Color = richTextBox1.BackColor;
			cd.ShowDialog();
			richTextBox1.BackColor = cd.Color;
			lblRules.BackColor = cd.Color;
		}

		public HorizontalAlignment z_SelectionAlignment {
			get {
				return richTextBox1.SelectionAlignment;
			}
			set {
				richTextBox1.SelectionAlignment = value;
			}
		}
		#endregion

		#region I. SPELLING CHECKER WORD
		public void fSpellCheck(RichTextBox tBox, Label lLbl) {
			int iErrorCount = 0;
			_Application app = new Microsoft.Office.Interop.Word.Application();
			if (tBox.Text.Length > 0) {
				app.Visible = false;
				// Setting these variables is comparable to passing null to the function. 
				// This is necessary because the C# null cannot be passed by reference.
				object template = Missing.Value;
				object newTemplate = Missing.Value;
				object documentType = Missing.Value;
				object visible = true;
				object optional = Missing.Value;

				_Document doc = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
				doc.Words.First.InsertBefore(tBox.Text);
				ProofreadingErrors we = doc.SpellingErrors;

				iErrorCount = we.Count;

				doc.CheckSpelling(ref optional, ref optional, ref optional, ref optional,
					ref optional, ref optional, ref optional,
					ref optional, ref optional, ref optional, ref optional, ref optional);
				//doc.CheckGrammar();
				if (iErrorCount == 0)
					lLbl.Text = "Spelling OK. No errors corrected ";
				else if (iErrorCount == 1)
					lLbl.Text = "Spelling OK. 1 error corrected ";
				else
					lLbl.Text = "Spelling OK. " + iErrorCount + " errors corrected ";
				object first = 0;
				object last = doc.Characters.Count - 1;

				tBox.Text = doc.Range(ref first, ref last).Text;
			} else
				lLbl.Text = "Textbox is empty";

			object saveChanges = false;
			object originalFormat = Missing.Value;
			object routeDocument = Missing.Value;
			app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
		}
		private void btnSC_Click(object sender, System.EventArgs e) {
			fSpellCheck(richTextBox1, lblStatus);
			richTextBox1.Focus();
		}
		#endregion
	}
}
