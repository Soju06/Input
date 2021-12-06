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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._mouse_set_test_area_box = new System.Windows.Forms.CheckBox();
            this._test_area_box = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this._mouse_input_types_box = new System.Windows.Forms.ComboBox();
            this._mouse_set_current_position = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._mouse_button_types_box = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._mouse_position = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._ispressed_label = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this._is_keypressed_key_types_box = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._test_input_box = new System.Windows.Forms.TextBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._keyboard_hook_chk = new System.Windows.Forms.CheckBox();
            this._log = new System.Windows.Forms.ListBox();
            this._mouse_hook_chk = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._mouse_set_test_area_box);
            this.groupBox5.Controls.Add(this._test_area_box);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this._mouse_input_types_box);
            this.groupBox5.Controls.Add(this._mouse_set_current_position);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this._mouse_button_types_box);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this._mouse_position);
            this.groupBox5.Location = new System.Drawing.Point(918, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 432);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "마우스 시뮬레이션";
            // 
            // _mouse_set_test_area_box
            // 
            this._mouse_set_test_area_box.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._mouse_set_test_area_box.Location = new System.Drawing.Point(6, 355);
            this._mouse_set_test_area_box.Name = "_mouse_set_test_area_box";
            this._mouse_set_test_area_box.Size = new System.Drawing.Size(275, 24);
            this._mouse_set_test_area_box.TabIndex = 11;
            this._mouse_set_test_area_box.Text = "위치를 테스트 공간으로 이동";
            this._mouse_set_test_area_box.UseVisualStyleBackColor = true;
            // 
            // _test_area_box
            // 
            this._test_area_box.BackColor = System.Drawing.SystemColors.ControlDark;
            this._test_area_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._test_area_box.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._test_area_box.ForeColor = System.Drawing.Color.White;
            this._test_area_box.Location = new System.Drawing.Point(6, 135);
            this._test_area_box.Name = "_test_area_box";
            this._test_area_box.Size = new System.Drawing.Size(275, 217);
            this._test_area_box.TabIndex = 10;
            this._test_area_box.Text = "테스트 공간";
            this._test_area_box.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._test_area_box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnTestAreaMouseDown);
            this._test_area_box.MouseEnter += new System.EventHandler(this.OnTestAreaMouseEnter);
            this._test_area_box.MouseLeave += new System.EventHandler(this.OnTestAreaMouseLeave);
            this._test_area_box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTestAreaMouseUp);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(6, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(275, 41);
            this.button3.TabIndex = 7;
            this.button3.Text = "입력";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnMouseSimulation);
            // 
            // _mouse_input_types_box
            // 
            this._mouse_input_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._mouse_input_types_box.FormattingEnabled = true;
            this._mouse_input_types_box.Location = new System.Drawing.Point(160, 107);
            this._mouse_input_types_box.Name = "_mouse_input_types_box";
            this._mouse_input_types_box.Size = new System.Drawing.Size(121, 23);
            this._mouse_input_types_box.TabIndex = 8;
            // 
            // _mouse_set_current_position
            // 
            this._mouse_set_current_position.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._mouse_set_current_position.Location = new System.Drawing.Point(6, 79);
            this._mouse_set_current_position.Name = "_mouse_set_current_position";
            this._mouse_set_current_position.Size = new System.Drawing.Size(275, 24);
            this._mouse_set_current_position.TabIndex = 9;
            this._mouse_set_current_position.Text = "현재 위치에서 이동";
            this._mouse_set_current_position.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "입력 타입:";
            // 
            // _mouse_button_types_box
            // 
            this._mouse_button_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._mouse_button_types_box.FormattingEnabled = true;
            this._mouse_button_types_box.Location = new System.Drawing.Point(160, 22);
            this._mouse_button_types_box.Name = "_mouse_button_types_box";
            this._mouse_button_types_box.Size = new System.Drawing.Size(121, 23);
            this._mouse_button_types_box.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "마우스 버튼:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "이동할 위치:";
            // 
            // _mouse_position
            // 
            this._mouse_position.Location = new System.Drawing.Point(160, 51);
            this._mouse_position.Name = "_mouse_position";
            this._mouse_position.PlaceholderText = "0, 0";
            this._mouse_position.Size = new System.Drawing.Size(121, 23);
            this._mouse_position.TabIndex = 0;
            this._mouse_position.Text = "0, 0";
            this._mouse_position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._ispressed_label);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this._is_keypressed_key_types_box);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(310, 319);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 125);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "키보드 시뮬레이션 (입력)";
            // 
            // _ispressed_label
            // 
            this._ispressed_label.Location = new System.Drawing.Point(156, 89);
            this._ispressed_label.Name = "_ispressed_label";
            this._ispressed_label.Size = new System.Drawing.Size(121, 30);
            this._ispressed_label.TabIndex = 8;
            this._ispressed_label.Text = "False";
            this._ispressed_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(156, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "키 눌림 확인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnCheckIsPressed);
            // 
            // _is_keypressed_key_types_box
            // 
            this._is_keypressed_key_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._is_keypressed_key_types_box.FormattingEnabled = true;
            this._is_keypressed_key_types_box.Location = new System.Drawing.Point(156, 22);
            this._is_keypressed_key_types_box.Name = "_is_keypressed_key_types_box";
            this._is_keypressed_key_types_box.Size = new System.Drawing.Size(121, 23);
            this._is_keypressed_key_types_box.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "키 타입:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this._test_input_box);
            this.groupBox3.Location = new System.Drawing.Point(599, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 432);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "키보드 테스트";
            this.groupBox3.UseWaitCursor = true;
            // 
            // _test_input_box
            // 
            this._test_input_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this._test_input_box.Location = new System.Drawing.Point(3, 19);
            this._test_input_box.Multiline = true;
            this._test_input_box.Name = "_test_input_box";
            this._test_input_box.Size = new System.Drawing.Size(307, 410);
            this._test_input_box.TabIndex = 3;
            this._test_input_box.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.groupBox2.Size = new System.Drawing.Size(283, 301);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "키보드 시뮬레이션";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(156, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "모든 키 떼기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnReleaseAllKeys);
            // 
            // _keyboard_simulation_btn
            // 
            this._keyboard_simulation_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._keyboard_simulation_btn.Location = new System.Drawing.Point(6, 254);
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "입력 타입:";
            // 
            // _keyboard_input_types_box
            // 
            this._keyboard_input_types_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._keyboard_input_types_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._keyboard_input_types_box.FormattingEnabled = true;
            this._keyboard_input_types_box.Location = new System.Drawing.Point(156, 225);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this._keyboard_hook_chk);
            this.groupBox1.Controls.Add(this._log);
            this.groupBox1.Controls.Add(this._mouse_hook_chk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 432);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "인풋 후킹";
            // 
            // _keyboard_hook_chk
            // 
            this._keyboard_hook_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._keyboard_hook_chk.AutoSize = true;
            this._keyboard_hook_chk.Location = new System.Drawing.Point(6, 407);
            this._keyboard_hook_chk.Name = "_keyboard_hook_chk";
            this._keyboard_hook_chk.Size = new System.Drawing.Size(90, 19);
            this._keyboard_hook_chk.TabIndex = 1;
            this._keyboard_hook_chk.Text = "키보드 후킹";
            this._keyboard_hook_chk.UseVisualStyleBackColor = true;
            this._keyboard_hook_chk.CheckedChanged += new System.EventHandler(this.OnKeyboardHook);
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
            this._log.Size = new System.Drawing.Size(280, 379);
            this._log.TabIndex = 0;
            // 
            // _mouse_hook_chk
            // 
            this._mouse_hook_chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._mouse_hook_chk.AutoSize = true;
            this._mouse_hook_chk.Location = new System.Drawing.Point(102, 407);
            this._mouse_hook_chk.Name = "_mouse_hook_chk";
            this._mouse_hook_chk.Size = new System.Drawing.Size(90, 19);
            this._mouse_hook_chk.TabIndex = 2;
            this._mouse_hook_chk.Text = "마우스 후킹";
            this._mouse_hook_chk.UseVisualStyleBackColor = true;
            this._mouse_hook_chk.CheckedChanged += new System.EventHandler(this.OnMouseHookChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 456);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(255, 158);
            this.Name = "Form1";
            this.Text = "Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnTestAreaMouseDown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox5;
        private CheckBox _mouse_set_test_area_box;
        private Label _test_area_box;
        private Button button3;
        private ComboBox _mouse_input_types_box;
        private CheckBox _mouse_set_current_position;
        private Label label6;
        private ComboBox _mouse_button_types_box;
        private Label label5;
        private Label label4;
        private TextBox _mouse_position;
        private GroupBox groupBox4;
        private Label _ispressed_label;
        private Button button2;
        private ComboBox _is_keypressed_key_types_box;
        private Label label3;
        private GroupBox groupBox3;
        private TextBox _test_input_box;
        private GroupBox groupBox2;
        private Button button1;
        private Button _keyboard_simulation_btn;
        private ComboBox _keyboard_key_types_box;
        private Button _add_keyboard_simulation_btn;
        private Button _remove_keyboard_simulation_btn;
        private Label label2;
        private Label label1;
        private ComboBox _keyboard_input_types_box;
        private ListBox _keyboard_simulation_list_box;
        private GroupBox groupBox1;
        private CheckBox _keyboard_hook_chk;
        private ListBox _log;
        private CheckBox _mouse_hook_chk;
    }
}