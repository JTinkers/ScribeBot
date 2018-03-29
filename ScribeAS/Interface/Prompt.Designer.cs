using System.Windows.Forms;

namespace Scribe.Interface
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
            this.PromptSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // promptMessage
            // 
            this.promptMessage.AutoSize = true;
            this.promptMessage.Location = new System.Drawing.Point(5, 5);
            this.promptMessage.Name = "promptMessage";
            this.promptMessage.Size = new System.Drawing.Size(50, 13);
            this.promptMessage.TabIndex = 0;
            this.promptMessage.Text = "Message";
            this.promptMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // promptEntryBox
            // 
            this.promptEntryBox.Location = new System.Drawing.Point(8, 24);
            this.promptEntryBox.Name = "promptEntryBox";
            this.promptEntryBox.Size = new System.Drawing.Size(197, 20);
            this.promptEntryBox.TabIndex = 1;
            // 
            // PromptSubmit
            // 
            this.PromptSubmit.Location = new System.Drawing.Point(8, 53);
            this.PromptSubmit.Name = "PromptSubmit";
            this.PromptSubmit.Size = new System.Drawing.Size(197, 20);
            this.PromptSubmit.TabIndex = 2;
            this.PromptSubmit.Text = "Submit";
            this.PromptSubmit.UseVisualStyleBackColor = true;
            // 
            // Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 87);
            this.Controls.Add(this.PromptSubmit);
            this.Controls.Add(this.promptEntryBox);
            this.Controls.Add(this.promptMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prompt";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Scribe - Prompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label promptMessage;
        private System.Windows.Forms.TextBox promptEntryBox;
        private Button promptSubmit;

        public Label PromptMessage { get => promptMessage; set => promptMessage = value; }
        public TextBox PromptEntryBox { get => promptEntryBox; set => promptEntryBox = value; }
        public Button PromptSubmit { get => promptSubmit; set => promptSubmit = value; }
    }
}