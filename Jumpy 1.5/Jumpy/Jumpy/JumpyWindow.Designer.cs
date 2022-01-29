namespace Jumpy
{
	partial class JumpyWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override  void Dispose(bool disposing)
		{
			SaveSettings();
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
			this.tabContainer = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbWalkingRoutines = new System.Windows.Forms.ListBox();
			this.lbMountedRoutines = new System.Windows.Forms.ListBox();
			this.lbCombatRoutines = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.nudPlayerRange = new System.Windows.Forms.NumericUpDown();
			this.chkUsePlayerRange = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkStandJumpInCombat = new System.Windows.Forms.CheckBox();
			this.chkStandJumpOutCombat = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.nudRandMountJumpSpan = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.nudBaseMountJumpSpan = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nudRandWalkJumpSpan = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.nudBaseWalkJumpSpan = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tbLog = new System.Windows.Forms.RichTextBox();
			this.tabContainer.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlayerRange)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRandMountJumpSpan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBaseMountJumpSpan)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRandWalkJumpSpan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBaseWalkJumpSpan)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabContainer
			// 
			this.tabContainer.Controls.Add(this.tabPage1);
			this.tabContainer.Controls.Add(this.tabPage2);
			this.tabContainer.Controls.Add(this.tabPage3);
			this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabContainer.Location = new System.Drawing.Point(0, 0);
			this.tabContainer.Margin = new System.Windows.Forms.Padding(0);
			this.tabContainer.Name = "tabContainer";
			this.tabContainer.SelectedIndex = 0;
			this.tabContainer.Size = new System.Drawing.Size(284, 262);
			this.tabContainer.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.AliceBlue;
			this.tabPage1.Controls.Add(this.btnRefresh);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.lbWalkingRoutines);
			this.tabPage1.Controls.Add(this.lbMountedRoutines);
			this.tabPage1.Controls.Add(this.lbCombatRoutines);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(276, 236);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Profiles";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(197, 190);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(60, 36);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(198, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Walking";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(117, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mounted";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(36, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Combat";
			// 
			// lbWalkingRoutines
			// 
			this.lbWalkingRoutines.FormattingEnabled = true;
			this.lbWalkingRoutines.Location = new System.Drawing.Point(182, 59);
			this.lbWalkingRoutines.Name = "lbWalkingRoutines";
			this.lbWalkingRoutines.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbWalkingRoutines.Size = new System.Drawing.Size(75, 121);
			this.lbWalkingRoutines.Sorted = true;
			this.lbWalkingRoutines.TabIndex = 0;
			// 
			// lbMountedRoutines
			// 
			this.lbMountedRoutines.FormattingEnabled = true;
			this.lbMountedRoutines.Location = new System.Drawing.Point(101, 59);
			this.lbMountedRoutines.Name = "lbMountedRoutines";
			this.lbMountedRoutines.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbMountedRoutines.Size = new System.Drawing.Size(75, 121);
			this.lbMountedRoutines.Sorted = true;
			this.lbMountedRoutines.TabIndex = 0;
			// 
			// lbCombatRoutines
			// 
			this.lbCombatRoutines.FormattingEnabled = true;
			this.lbCombatRoutines.Location = new System.Drawing.Point(20, 59);
			this.lbCombatRoutines.Name = "lbCombatRoutines";
			this.lbCombatRoutines.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbCombatRoutines.Size = new System.Drawing.Size(75, 121);
			this.lbCombatRoutines.Sorted = true;
			this.lbCombatRoutines.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.MintCream;
			this.tabPage2.Controls.Add(this.groupBox4);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(276, 236);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Misc";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.nudPlayerRange);
			this.groupBox4.Controls.Add(this.chkUsePlayerRange);
			this.groupBox4.Location = new System.Drawing.Point(36, 33);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(99, 64);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Player Range";
			// 
			// nudPlayerRange
			// 
			this.nudPlayerRange.Location = new System.Drawing.Point(40, 25);
			this.nudPlayerRange.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.nudPlayerRange.Name = "nudPlayerRange";
			this.nudPlayerRange.Size = new System.Drawing.Size(44, 20);
			this.nudPlayerRange.TabIndex = 1;
			// 
			// chkUsePlayerRange
			// 
			this.chkUsePlayerRange.AutoSize = true;
			this.chkUsePlayerRange.Location = new System.Drawing.Point(15, 27);
			this.chkUsePlayerRange.Name = "chkUsePlayerRange";
			this.chkUsePlayerRange.Size = new System.Drawing.Size(15, 14);
			this.chkUsePlayerRange.TabIndex = 0;
			this.chkUsePlayerRange.UseVisualStyleBackColor = true;
			this.chkUsePlayerRange.CheckedChanged += new System.EventHandler(this.UsePlayerRange_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkStandJumpInCombat);
			this.groupBox3.Controls.Add(this.chkStandJumpOutCombat);
			this.groupBox3.Location = new System.Drawing.Point(141, 33);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(99, 64);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Standing Jump";
			// 
			// chkStandJumpInCombat
			// 
			this.chkStandJumpInCombat.AutoSize = true;
			this.chkStandJumpInCombat.Location = new System.Drawing.Point(15, 21);
			this.chkStandJumpInCombat.Name = "chkStandJumpInCombat";
			this.chkStandJumpInCombat.Size = new System.Drawing.Size(72, 17);
			this.chkStandJumpInCombat.TabIndex = 7;
			this.chkStandJumpInCombat.Text = "in combat";
			this.chkStandJumpInCombat.UseVisualStyleBackColor = true;
			// 
			// chkStandJumpOutCombat
			// 
			this.chkStandJumpOutCombat.AutoSize = true;
			this.chkStandJumpOutCombat.Location = new System.Drawing.Point(15, 37);
			this.chkStandJumpOutCombat.Name = "chkStandJumpOutCombat";
			this.chkStandJumpOutCombat.Size = new System.Drawing.Size(79, 17);
			this.chkStandJumpOutCombat.TabIndex = 7;
			this.chkStandJumpOutCombat.Text = "out combat";
			this.chkStandJumpOutCombat.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.nudRandMountJumpSpan);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.nudBaseMountJumpSpan);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(141, 108);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(124, 88);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mounted Jump Span";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(76, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "+ Rand";
			// 
			// nudRandMountJumpSpan
			// 
			this.nudRandMountJumpSpan.Location = new System.Drawing.Point(16, 54);
			this.nudRandMountJumpSpan.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudRandMountJumpSpan.Name = "nudRandMountJumpSpan";
			this.nudRandMountJumpSpan.Size = new System.Drawing.Size(55, 20);
			this.nudRandMountJumpSpan.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(78, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(31, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "Base";
			// 
			// nudBaseMountJumpSpan
			// 
			this.nudBaseMountJumpSpan.Location = new System.Drawing.Point(16, 26);
			this.nudBaseMountJumpSpan.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudBaseMountJumpSpan.Name = "nudBaseMountJumpSpan";
			this.nudBaseMountJumpSpan.Size = new System.Drawing.Size(55, 20);
			this.nudBaseMountJumpSpan.TabIndex = 2;
			this.nudBaseMountJumpSpan.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Location = new System.Drawing.Point(27, 42);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(20, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "ms";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.nudRandWalkJumpSpan);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nudBaseWalkJumpSpan);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(12, 108);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(124, 88);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Walking Jump Span";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(76, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "+ Rand";
			// 
			// nudRandWalkJumpSpan
			// 
			this.nudRandWalkJumpSpan.Location = new System.Drawing.Point(16, 54);
			this.nudRandWalkJumpSpan.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudRandWalkJumpSpan.Name = "nudRandWalkJumpSpan";
			this.nudRandWalkJumpSpan.Size = new System.Drawing.Size(55, 20);
			this.nudRandWalkJumpSpan.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(78, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Base";
			// 
			// nudBaseWalkJumpSpan
			// 
			this.nudBaseWalkJumpSpan.Location = new System.Drawing.Point(16, 26);
			this.nudBaseWalkJumpSpan.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudBaseWalkJumpSpan.Name = "nudBaseWalkJumpSpan";
			this.nudBaseWalkJumpSpan.Size = new System.Drawing.Size(55, 20);
			this.nudBaseWalkJumpSpan.TabIndex = 2;
			this.nudBaseWalkJumpSpan.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label6.Location = new System.Drawing.Point(27, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "ms";
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.Transparent;
			this.tabPage3.Controls.Add(this.tbLog);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(276, 236);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Log";
			// 
			// tbLog
			// 
			this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbLog.BackColor = System.Drawing.Color.White;
			this.tbLog.Location = new System.Drawing.Point(0, 0);
			this.tbLog.Margin = new System.Windows.Forms.Padding(0);
			this.tbLog.Name = "tbLog";
			this.tbLog.ReadOnly = true;
			this.tbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.tbLog.Size = new System.Drawing.Size(276, 236);
			this.tbLog.TabIndex = 0;
			this.tbLog.Text = "";
			this.tbLog.WordWrap = false;
			// 
			// JumpyWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.tabContainer);
			this.Name = "JumpyWindow";
			this.Text = "Jumpy";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JumpyWindow_FormClosing);
			this.Shown += new System.EventHandler(this.JumpyWindow_Shown);
			this.VisibleChanged += new System.EventHandler(this.JumpyWindow_VisibleChanged);
			this.tabContainer.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPlayerRange)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRandMountJumpSpan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBaseMountJumpSpan)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRandWalkJumpSpan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBaseWalkJumpSpan)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabContainer;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.ListBox lbWalkingRoutines;
		public System.Windows.Forms.ListBox lbMountedRoutines;
		public System.Windows.Forms.ListBox lbCombatRoutines;
		public System.Windows.Forms.NumericUpDown nudRandMountJumpSpan;
		public System.Windows.Forms.NumericUpDown nudBaseMountJumpSpan;
		public System.Windows.Forms.NumericUpDown nudRandWalkJumpSpan;
		public System.Windows.Forms.NumericUpDown nudBaseWalkJumpSpan;
		public System.Windows.Forms.NumericUpDown nudPlayerRange;
		public System.Windows.Forms.CheckBox chkUsePlayerRange;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.RichTextBox tbLog;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkStandJumpInCombat;
		private System.Windows.Forms.CheckBox chkStandJumpOutCombat;

		public int RandMountJumpSpan { get { return (int)nudRandMountJumpSpan.Value; } }
		public int BaseMountJumpSpan { get { return (int)nudBaseMountJumpSpan.Value; } }
		public int RandWalkJumpSpan { get { return (int)nudRandWalkJumpSpan.Value; } }
		public int BaseWalkJumpSpan { get { return (int)nudBaseWalkJumpSpan.Value; } }
		public double PlayerRange { get { return (double)nudPlayerRange.Value; } }
		public bool UsePlayerRange { get { return chkUsePlayerRange.Checked; } }
		public bool StandJumpInCombat { get { return chkStandJumpInCombat.Checked; } }
		public bool StandJumpOutCombat { get { return chkStandJumpOutCombat.Checked; } }

	}
}

