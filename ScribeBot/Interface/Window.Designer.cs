using System.Drawing;
using System.Windows.Forms;

namespace ScribeBot.Interface
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.consolePanel = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.consoleInput = new System.Windows.Forms.TextBox();
            this.consoleRun = new System.Windows.Forms.Button();
            this.consoleContainer = new System.Windows.Forms.Panel();
            this.consoleOutput = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.asyncStringCheck = new System.Windows.Forms.CheckBox();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsPanel = new System.Windows.Forms.TabControl();
            this.scriptsPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.asyncCheckbox = new System.Windows.Forms.CheckBox();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptRun = new System.Windows.Forms.Button();
            this.scriptStop = new System.Windows.Forms.Button();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.noticeTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.consolePanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.consoleContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.layoutPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.scriptsPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // consolePanel
            // 
            this.consolePanel.Controls.Add(this.tableLayoutPanel3);
            this.consolePanel.Controls.Add(this.consoleContainer);
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consolePanel.Location = new System.Drawing.Point(3, 3);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Padding = new System.Windows.Forms.Padding(5);
            this.consolePanel.Size = new System.Drawing.Size(486, 556);
            this.consolePanel.TabIndex = 0;
            this.consolePanel.TabStop = false;
            this.consolePanel.Text = "Console";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.Controls.Add(this.consoleInput, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.consoleRun, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 520);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(463, 26);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // consoleInput
            // 
            this.consoleInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleInput.Location = new System.Drawing.Point(3, 3);
            this.consoleInput.Name = "consoleInput";
            this.consoleInput.Size = new System.Drawing.Size(327, 20);
            this.consoleInput.TabIndex = 1;
            // 
            // consoleRun
            // 
            this.consoleRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRun.Location = new System.Drawing.Point(336, 3);
            this.consoleRun.Name = "consoleRun";
            this.consoleRun.Size = new System.Drawing.Size(124, 20);
            this.consoleRun.TabIndex = 2;
            this.consoleRun.Text = "Execute";
            this.noticeTooltip.SetToolTip(this.consoleRun, "Executing a string while other script is running will stop the script.");
            this.consoleRun.UseVisualStyleBackColor = true;
            // 
            // consoleContainer
            // 
            this.consoleContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleContainer.Controls.Add(this.consoleOutput);
            this.consoleContainer.Controls.Add(this.tableLayoutPanel2);
            this.consoleContainer.Location = new System.Drawing.Point(10, 24);
            this.consoleContainer.Margin = new System.Windows.Forms.Padding(5);
            this.consoleContainer.Name = "consoleContainer";
            this.consoleContainer.Size = new System.Drawing.Size(465, 485);
            this.consoleContainer.TabIndex = 3;
            // 
            // consoleOutput
            // 
            this.consoleOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            this.consoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleOutput.DetectUrls = false;
            this.consoleOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.consoleOutput.ForeColor = System.Drawing.Color.White;
            this.consoleOutput.Location = new System.Drawing.Point(0, 0);
            this.consoleOutput.Margin = new System.Windows.Forms.Padding(0);
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consoleOutput.Size = new System.Drawing.Size(463, 456);
            this.consoleOutput.TabIndex = 0;
            this.consoleOutput.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.asyncStringCheck, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 456);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(463, 27);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // asyncStringCheck
            // 
            this.asyncStringCheck.AutoSize = true;
            this.asyncStringCheck.Checked = true;
            this.asyncStringCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.asyncStringCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.asyncStringCheck.ForeColor = System.Drawing.SystemColors.Info;
            this.asyncStringCheck.Location = new System.Drawing.Point(5, 5);
            this.asyncStringCheck.Margin = new System.Windows.Forms.Padding(5);
            this.asyncStringCheck.Name = "asyncStringCheck";
            this.asyncStringCheck.Size = new System.Drawing.Size(52, 17);
            this.asyncStringCheck.TabIndex = 0;
            this.asyncStringCheck.Text = "Async";
            this.noticeTooltip.SetToolTip(this.asyncStringCheck, "Execute string on a separate thread to prevent user interface from freezing durin" +
        "g the execution.\r\nKeep in mind that this might disable syntax debugger.");
            this.asyncStringCheck.UseVisualStyleBackColor = true;
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.Controls.Add(this.consolePanel, 0, 0);
            this.layoutPanel.Controls.Add(this.optionsPanel, 1, 0);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 1;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Size = new System.Drawing.Size(784, 562);
            this.layoutPanel.TabIndex = 1;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.scriptsPage);
            this.optionsPanel.Controls.Add(this.settingsPage);
            this.optionsPanel.Controls.Add(this.tabPage1);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(497, 5);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.SelectedIndex = 0;
            this.optionsPanel.Size = new System.Drawing.Size(282, 552);
            this.optionsPanel.TabIndex = 1;
            // 
            // scriptsPage
            // 
            this.scriptsPage.Controls.Add(this.tableLayoutPanel5);
            this.scriptsPage.Controls.Add(this.tableLayoutPanel4);
            this.scriptsPage.Controls.Add(this.tableLayoutPanel1);
            this.scriptsPage.Location = new System.Drawing.Point(4, 22);
            this.scriptsPage.Margin = new System.Windows.Forms.Padding(0);
            this.scriptsPage.Name = "scriptsPage";
            this.scriptsPage.Padding = new System.Windows.Forms.Padding(5);
            this.scriptsPage.Size = new System.Drawing.Size(274, 526);
            this.scriptsPage.TabIndex = 0;
            this.scriptsPage.Text = "Scripts";
            this.scriptsPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.asyncCheckbox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.logCheckBox, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(10, 464);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(254, 21);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // asyncCheckbox
            // 
            this.asyncCheckbox.AutoSize = true;
            this.asyncCheckbox.Checked = true;
            this.asyncCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.asyncCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asyncCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.asyncCheckbox.Location = new System.Drawing.Point(0, 0);
            this.asyncCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.asyncCheckbox.Name = "asyncCheckbox";
            this.asyncCheckbox.Size = new System.Drawing.Size(127, 21);
            this.asyncCheckbox.TabIndex = 2;
            this.asyncCheckbox.Text = "Async";
            this.noticeTooltip.SetToolTip(this.asyncCheckbox, "Execute script on a separate thread to prevent user interface from freezing durin" +
        "g script\'s routine.\r\nKeep in mind that this might disable syntax debugger.");
            this.asyncCheckbox.UseVisualStyleBackColor = true;
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Checked = true;
            this.logCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logCheckBox.Location = new System.Drawing.Point(127, 0);
            this.logCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(127, 21);
            this.logCheckBox.TabIndex = 3;
            this.logCheckBox.Text = "Log";
            this.noticeTooltip.SetToolTip(this.logCheckBox, "Whether or not program should dump log into a date-signed file.");
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.scriptListBox, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.23207F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(254, 446);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // scriptListBox
            // 
            this.scriptListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptListBox.FormattingEnabled = true;
            this.scriptListBox.Location = new System.Drawing.Point(0, 0);
            this.scriptListBox.Margin = new System.Windows.Forms.Padding(0);
            this.scriptListBox.Name = "scriptListBox";
            this.scriptListBox.Size = new System.Drawing.Size(254, 446);
            this.scriptListBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.scriptRun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scriptStop, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 495);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 21);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // scriptRun
            // 
            this.scriptRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptRun.Location = new System.Drawing.Point(0, 0);
            this.scriptRun.Margin = new System.Windows.Forms.Padding(0);
            this.scriptRun.Name = "scriptRun";
            this.scriptRun.Size = new System.Drawing.Size(127, 21);
            this.scriptRun.TabIndex = 1;
            this.scriptRun.Text = "Run";
            this.scriptRun.UseVisualStyleBackColor = true;
            // 
            // scriptStop
            // 
            this.scriptStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptStop.Location = new System.Drawing.Point(127, 0);
            this.scriptStop.Margin = new System.Windows.Forms.Padding(0);
            this.scriptStop.Name = "scriptStop";
            this.scriptStop.Size = new System.Drawing.Size(127, 21);
            this.scriptStop.TabIndex = 2;
            this.scriptStop.Text = "Stop";
            this.noticeTooltip.SetToolTip(this.scriptStop, "This will force currently running script to stop");
            this.scriptStop.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(274, 526);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(274, 526);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // noticeTooltip
            // 
            this.noticeTooltip.AutoPopDelay = 5000;
            this.noticeTooltip.InitialDelay = 200;
            this.noticeTooltip.ReshowDelay = 100;
            this.noticeTooltip.ShowAlways = true;
            this.noticeTooltip.ToolTipTitle = "Notice";
            this.noticeTooltip.UseAnimation = false;
            this.noticeTooltip.UseFading = false;
            // 
            // Window
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.layoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScribeBot";
            this.consolePanel.ResumeLayout(false);
            this.consolePanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.consoleContainer.ResumeLayout(false);
            this.consoleContainer.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.layoutPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.scriptsPage.ResumeLayout(false);
            this.scriptsPage.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox consolePanel;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.TabControl optionsPanel;
        private System.Windows.Forms.TabPage scriptsPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.ListBox scriptListBox;
        private RichTextBox consoleOutput;
        private Button scriptRun;
        private CheckBox asyncCheckbox;
        private ToolTip noticeTooltip;
        private TextBox consoleInput;
        private Button consoleRun;
        private Panel consoleContainer;
        private TableLayoutPanel tableLayoutPanel1;
        private Button scriptStop;
        private TableLayoutPanel tableLayoutPanel2;
        private CheckBox asyncStringCheck;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel5;
        private CheckBox logCheckBox;
        private TabPage tabPage1;

        public ListBox ScriptListBox { get => scriptListBox; set => scriptListBox = value; }
        public RichTextBox ConsoleOutput { get => consoleOutput; set => consoleOutput = value; }
        public Button ScriptRun { get => scriptRun; set => scriptRun = value; }
        public CheckBox AsyncCheckbox { get => asyncCheckbox; set => asyncCheckbox = value; }
        public TextBox ConsoleInput { get => consoleInput; set => consoleInput = value; }
        public Button ConsoleRun { get => consoleRun; set => consoleRun = value; }
        public Button ScriptStop { get => scriptStop; set => scriptStop = value; }
        public CheckBox AsyncStringCheck { get => asyncStringCheck; set => asyncStringCheck = value; }
        public CheckBox LogCheckBox { get => logCheckBox; set => logCheckBox = value; }
    }
}