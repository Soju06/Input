namespace InputHook.Test {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._log_clear_timer = new System.Windows.Forms.Timer(this.components);
            this._log = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _log_clear_timer
            // 
            this._log_clear_timer.Enabled = true;
            this._log_clear_timer.Interval = 50;
            this._log_clear_timer.Tick += new System.EventHandler(this.OnOrganize);
            // 
            // _log
            // 
            this._log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._log.FormattingEnabled = true;
            this._log.ItemHeight = 15;
            this._log.Location = new System.Drawing.Point(12, 12);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(429, 334);
            this._log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 362);
            this.Controls.Add(this._log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox _log;
        private System.Windows.Forms.Timer _log_clear_timer;
    }
}