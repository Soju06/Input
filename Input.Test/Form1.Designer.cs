namespace Input.Test {
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
            this._keyboard_hook_chk = new System.Windows.Forms.CheckBox();
            this._mouse_hook_chk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this._log.Location = new System.Drawing.Point(10, 17);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(418, 349);
            this._log.TabIndex = 0;
            // 
            // _keyboard_hook_chk
            // 
            this._keyboard_hook_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._keyboard_hook_chk.AutoSize = true;
            this._keyboard_hook_chk.Location = new System.Drawing.Point(12, 371);
            this._keyboard_hook_chk.Name = "_keyboard_hook_chk";
            this._keyboard_hook_chk.Size = new System.Drawing.Size(90, 19);
            this._keyboard_hook_chk.TabIndex = 1;
            this._keyboard_hook_chk.Text = "키보드 후킹";
            this._keyboard_hook_chk.UseVisualStyleBackColor = true;
            this._keyboard_hook_chk.CheckedChanged += new System.EventHandler(this.OnKeyboardHook);
            // 
            // _mouse_hook_chk
            // 
            this._mouse_hook_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._mouse_hook_chk.AutoSize = true;
            this._mouse_hook_chk.Location = new System.Drawing.Point(108, 371);
            this._mouse_hook_chk.Name = "_mouse_hook_chk";
            this._mouse_hook_chk.Size = new System.Drawing.Size(90, 19);
            this._mouse_hook_chk.TabIndex = 2;
            this._mouse_hook_chk.Text = "마우스 후킹";
            this._mouse_hook_chk.UseVisualStyleBackColor = true;
            this._mouse_hook_chk.CheckedChanged += new System.EventHandler(this.OnMouseHookChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(434, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 315);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 402);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._mouse_hook_chk);
            this.Controls.Add(this._keyboard_hook_chk);
            this.Controls.Add(this._log);
            this.MinimumSize = new System.Drawing.Size(255, 158);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox _log;
        private System.Windows.Forms.Timer _log_clear_timer;
        private CheckBox _keyboard_hook_chk;
        private CheckBox _mouse_hook_chk;
        private Button button1;
        private TextBox textBox1;
    }
}