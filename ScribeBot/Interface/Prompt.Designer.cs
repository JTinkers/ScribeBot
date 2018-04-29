using System.Windows.Forms;

namespace ScribeBot.Interface
{
    partial class Prompt
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
            this.promptMessage = new System.Windows.Forms.Label();
            this.promptEntryBox = new System.Windows.Forms.TextBox();
            this.promptSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // promptMessage
            // 
            this.promptMessage.AutoSize = true;
            this.promptMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.promptMessage.Location = new System.Drawing.Point(3, 3);
            this.promptMessage.Margin = new System.Windows.Forms.Padding(3);
            this.promptMessage.Name = "promptMessage";
            this.promptMessage.Size = new System.Drawing.Size(202, 13);
            this.promptMessage.TabIndex = 0;
            this.promptMessage.Text = "Message";
            this.promptMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // promptEntryBox
            // 
            this.promptEntryBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.promptEntryBox.Location = new System.Drawing.Point(3, 22);
            this.promptEntryBox.Name = "promptEntryBox";
            this.promptEntryBox.Size = new System.Drawing.Size(202, 20);
            this.promptEntryBox.TabIndex = 1;
            // 
            // promptSubmit
            // 
            this.promptSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.promptSubmit.Location = new System.Drawing.Point(3, 48);
            this.promptSubmit.Name = "promptSubmit";
            this.promptSubmit.Size = new System.Drawing.Size(202, 30);
            this.promptSubmit.TabIndex = 2;
            this.promptSubmit.Text = "Submit";
            this.promptSubmit.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.promptMessage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.promptSubmit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.promptEntryBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 81);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(214, 87);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prompt";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "ScribeBot - Prompt";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label promptMessage;
        private System.Windows.Forms.TextBox promptEntryBox;
        private Button promptSubmit;
        private TableLayoutPanel tableLayoutPanel1;

        public Label PromptMessage { get => promptMessage; set => promptMessage = value; }
        public TextBox PromptEntryBox { get => promptEntryBox; set => promptEntryBox = value; }
        public Button PromptSubmit { get => promptSubmit; set => promptSubmit = value; }
    }
}