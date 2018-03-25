using System.Windows.Forms;

namespace Scribe.Interface
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
            this.consolePanel = new System.Windows.Forms.GroupBox();
            this.consoleSend = new System.Windows.Forms.Button();
            this.consoleInput = new System.Windows.Forms.TextBox();
            this.consoleOutput = new System.Windows.Forms.TextBox();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optionsPanel = new System.Windows.Forms.TabControl();
            this.scriptsPage = new System.Windows.Forms.TabPage();
            this.asyncCheckbox = new System.Windows.Forms.CheckBox();
            this.scriptRun = new System.Windows.Forms.Button();
            this.scriptListBox = new System.Windows.Forms.ListBox();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.asyncTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.consolePanel.SuspendLayout();
            this.layoutPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.scriptsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // consolePanel
            // 
            this.consolePanel.Controls.Add(this.consoleSend);
            this.consolePanel.Controls.Add(this.consoleInput);
            this.consolePanel.Controls.Add(this.consoleOutput);
            this.consolePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.consolePanel.Location = new System.Drawing.Point(3, 3);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Padding = new System.Windows.Forms.Padding(5);
            this.consolePanel.Size = new System.Drawing.Size(281, 346);
            this.consolePanel.TabIndex = 0;
            this.consolePanel.TabStop = false;
            this.consolePanel.Text = "Console";
            // 
            // consoleSend
            // 
            this.consoleSend.Location = new System.Drawing.Point(202, 316);
            this.consoleSend.Name = "consoleSend";
            this.consoleSend.Size = new System.Drawing.Size(70, 20);
            this.consoleSend.TabIndex = 2;
            this.consoleSend.Text = "Send";
            this.consoleSend.UseVisualStyleBackColor = true;
            // 
            // consoleInput
            // 
            this.consoleInput.Location = new System.Drawing.Point(8, 316);
            this.consoleInput.Name = "consoleInput";
            this.consoleInput.Size = new System.Drawing.Size(188, 20);
            this.consoleInput.TabIndex = 1;
            // 
            // consoleOutput
            // 
            this.consoleOutput.BackColor = System.Drawing.SystemColors.Window;
            this.consoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleOutput.Location = new System.Drawing.Point(8, 21);
            this.consoleOutput.Multiline = true;
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleOutput.Size = new System.Drawing.Size(264, 289);
            this.consoleOutput.TabIndex = 0;
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.Controls.Add(this.consolePanel, 0, 0);
            this.layoutPanel.Controls.Add(this.optionsPanel, 1, 0);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(5, 5);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 1;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.Size = new System.Drawing.Size(574, 352);
            this.layoutPanel.TabIndex = 1;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.scriptsPage);
            this.optionsPanel.Controls.Add(this.settingsPage);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(292, 5);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.SelectedIndex = 0;
            this.optionsPanel.Size = new System.Drawing.Size(277, 342);
            this.optionsPanel.TabIndex = 1;
            // 
            // scriptsPage
            // 
            this.scriptsPage.Controls.Add(this.asyncCheckbox);
            this.scriptsPage.Controls.Add(this.scriptRun);
            this.scriptsPage.Controls.Add(this.scriptListBox);
            this.scriptsPage.Location = new System.Drawing.Point(4, 22);
            this.scriptsPage.Name = "scriptsPage";
            this.scriptsPage.Padding = new System.Windows.Forms.Padding(5);
            this.scriptsPage.Size = new System.Drawing.Size(269, 316);
            this.scriptsPage.TabIndex = 0;
            this.scriptsPage.Text = "Scripts";
            this.scriptsPage.UseVisualStyleBackColor = true;
            // 
            // asyncCheckbox
            // 
            this.asyncCheckbox.AutoSize = true;
            this.asyncCheckbox.Location = new System.Drawing.Point(10, 259);
            this.asyncCheckbox.Margin = new System.Windows.Forms.Padding(5);
            this.asyncCheckbox.Name = "asyncCheckbox";
            this.asyncCheckbox.Size = new System.Drawing.Size(93, 17);
            this.asyncCheckbox.TabIndex = 2;
            this.asyncCheckbox.Text = "Asynchronous";
            this.asyncCheckbox.UseVisualStyleBackColor = true;
            // 
            // scriptRun
            // 
            this.scriptRun.Location = new System.Drawing.Point(10, 286);
            this.scriptRun.Margin = new System.Windows.Forms.Padding(5);
            this.scriptRun.Name = "scriptRun";
            this.scriptRun.Size = new System.Drawing.Size(249, 20);
            this.scriptRun.TabIndex = 1;
            this.scriptRun.Text = "Run";
            this.scriptRun.UseVisualStyleBackColor = true;
            // 
            // scriptListBox
            // 
            this.scriptListBox.FormattingEnabled = true;
            this.scriptListBox.Location = new System.Drawing.Point(10, 10);
            this.scriptListBox.Margin = new System.Windows.Forms.Padding(5);
            this.scriptListBox.Name = "scriptListBox";
            this.scriptListBox.Size = new System.Drawing.Size(249, 238);
            this.scriptListBox.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(269, 316);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // Window
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.layoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Window";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Scribe";
            this.consolePanel.ResumeLayout(false);
            this.consolePanel.PerformLayout();
            this.layoutPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.scriptsPage.ResumeLayout(false);
            this.scriptsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox consolePanel;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.TextBox consoleInput;
        private System.Windows.Forms.TabControl optionsPanel;
        private System.Windows.Forms.TabPage scriptsPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.Button consoleSend;
        private System.Windows.Forms.ListBox scriptListBox;
        private TextBox consoleOutput;
        private Button scriptRun;
        private CheckBox asyncCheckbox;
        private ToolTip asyncTooltip;

        public ListBox ScriptListBox { get => scriptListBox; set => scriptListBox = value; }
        public TextBox ConsoleOutput { get => consoleOutput; set => consoleOutput = value; }
        public Button ScriptRun { get => scriptRun; set => scriptRun = value; }
        public CheckBox AsyncCheckbox { get => asyncCheckbox; set => asyncCheckbox = value; }
    }
}