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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this._keyboard_simulation_btn = new System.Windows.Forms.Button();
            this._keyboard_key_types_box = new System.Windows.Forms.ComboBox();
            this._add_keyboard_simulation_btn = new System.Windows.Forms.Button();
            this._remove_keyboard_simulation_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._keyboard_input_types_box = new System.Windows.Forms.ComboBox();
            this._keyboard_simulation_list_box = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._test_input_box = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this._log.Location = new System.Drawing.Point(6, 22);
            this._log.Name = "_log";
            this._log.Size = new System.Drawing.Size(280, 319);
            this._log.TabIndex = 0;
            // 
            // _keyboard_hook_chk
            // 
            this._keyboard_hook_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._keyboard_hook_chk.AutoSize = true;
            this._keyboard_hook_chk.Location = new System.Drawing.Point(6, 353);
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
            this._mouse_hook_chk.Location = new System.Drawing.Point(102, 353);
            this._mouse_hook_chk.Name = "_mouse_hook_chk";
            this._mouse_hook_chk.Size = new System.Drawing.Size(90, 19);
            this._mouse_hook_chk.TabIndex = 2;
            this._mouse_hook_chk.Text = "마우스 후킹";
            this._mouse_hook_chk.UseVisualStyleBackColor = true;
            this._mouse_hook_chk.CheckedChanged += new System.EventHandler(this.OnMouseHookChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._keyboard_hook_chk);
            this.groupBox1.Controls.Add(this._log);
            this.groupBox1.Controls.Add(this._mouse_hook_chk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 378);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "인풋 후킹";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this._keyboard_simulation_btn);
            this.groupBox2.Controls.Add(this._keyboard_key_types_box);
            this.groupBox2.Controls.Add(this._add_keyboard_simulation_btn);
            this.groupBox2.Controls.Add(this._remove_keyboard_simulation_btn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._keyboard_input_types_box);
            this.groupBox2.Controls.Add(this._keyboard_simulation_list_box);
            this.groupBox2.Location = new System.Drawing.Point(310, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 378);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "키보드 시뮬레이션";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "모든 키 떼기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnReleaseAllKeys);
            // 
            // _keyboard_simulation_btn
            // 
            this._keyboard_simulation_btn.Location = new System.Drawing.Point(6, 332);
            this._keyboard_simulation_btn.Name = "_keyboard_simulation_btn";
            this._keyboard_simulation_btn.Size = new System.Drawing.Size(271, 41);
            this._keyboard_simulation_btn.TabIndex = 5;
            this._keyboard_simulation_btn.Text = "입력";
            this._keyboard_simulation_btn.UseVisualStyleBackColor = true;
            this._keyboard_simulation_btn.Click += new System.EventHandler(this.OnKeyboardSimulation);
            // 
            // _keyboard_key_types_box
            // 
            this._keyboard_key_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._keyboard_key_types_box.FormattingEnabled = true;
            this._keyboard_key_types_box.Location = new System.Drawing.Point(156, 22);
            this._keyboard_key_types_box.Name = "_keyboard_key_types_box";
            this._keyboard_key_types_box.Size = new System.Drawing.Size(121, 23);
            this._keyboard_key_types_box.TabIndex = 4;
            // 
            // _add_keyboard_simulation_btn
            // 
            this._add_keyboard_simulation_btn.Location = new System.Drawing.Point(202, 51);
            this._add_keyboard_simulation_btn.Name = "_add_keyboard_simulation_btn";
            this._add_keyboard_simulation_btn.Size = new System.Drawing.Size(75, 23);
            this._add_keyboard_simulation_btn.TabIndex = 3;
            this._add_keyboard_simulation_btn.Text = "추가";
            this._add_keyboard_simulation_btn.UseVisualStyleBackColor = true;
            this._add_keyboard_simulation_btn.Click += new System.EventHandler(this.OnAddKeyboardSimulation);
            // 
            // _remove_keyboard_simulation_btn
            // 
            this._remove_keyboard_simulation_btn.Location = new System.Drawing.Point(6, 51);
            this._remove_keyboard_simulation_btn.Name = "_remove_keyboard_simulation_btn";
            this._remove_keyboard_simulation_btn.Size = new System.Drawing.Size(75, 23);
            this._remove_keyboard_simulation_btn.TabIndex = 3;
            this._remove_keyboard_simulation_btn.Text = "제거";
            this._remove_keyboard_simulation_btn.UseVisualStyleBackColor = true;
            this._remove_keyboard_simulation_btn.Click += new System.EventHandler(this.OnRemoveKeyboardSimulation);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "키 타입:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "인풋 타입:";
            // 
            // _keyboard_input_types_box
            // 
            this._keyboard_input_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._keyboard_input_types_box.FormattingEnabled = true;
            this._keyboard_input_types_box.Location = new System.Drawing.Point(156, 303);
            this._keyboard_input_types_box.Name = "_keyboard_input_types_box";
            this._keyboard_input_types_box.Size = new System.Drawing.Size(121, 23);
            this._keyboard_input_types_box.TabIndex = 1;
            // 
            // _keyboard_simulation_list_box
            // 
            this._keyboard_simulation_list_box.FormattingEnabled = true;
            this._keyboard_simulation_list_box.ItemHeight = 15;
            this._keyboard_simulation_list_box.Location = new System.Drawing.Point(6, 80);
            this._keyboard_simulation_list_box.Name = "_keyboard_simulation_list_box";
            this._keyboard_simulation_list_box.Size = new System.Drawing.Size(271, 94);
            this._keyboard_simulation_list_box.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._test_input_box);
            this.groupBox3.Location = new System.Drawing.Point(599, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 378);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "테스트";
            this.groupBox3.UseWaitCursor = true;
            // 
            // _test_input_box
            // 
            this._test_input_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this._test_input_box.Location = new System.Drawing.Point(3, 19);
            this._test_input_box.Multiline = true;
            this._test_input_box.Name = "_test_input_box";
            this._test_input_box.Size = new System.Drawing.Size(307, 356);
            this._test_input_box.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 402);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(255, 158);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox _log;
        private System.Windows.Forms.Timer _log_clear_timer;
        private CheckBox _keyboard_hook_chk;
        private CheckBox _mouse_hook_chk;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button _keyboard_simulation_btn;
        private ComboBox _keyboard_key_types_box;
        private Button _add_keyboard_simulation_btn;
        private Button _remove_keyboard_simulation_btn;
        private Label label2;
        private Label label1;
        private ComboBox _keyboard_input_types_box;
        private ListBox _keyboard_simulation_list_box;
        private GroupBox groupBox3;
        private Button button1;
        private TextBox _test_input_box;
    }
}