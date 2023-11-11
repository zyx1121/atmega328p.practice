using System.IO.Ports;

namespace pc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Text.ASCIIEncoding asciiEncoding3 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback3 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback3 = new System.Text.EncoderReplacementFallback();
            comboBoxCOM = new ComboBox();
            buttonOpen = new Button();
            serialPort1 = new SerialPort(components);
            groupBox1 = new GroupBox();
            labelDeviceStatus = new Label();
            label1 = new Label();
            buttonClose = new Button();
            groupBox3 = new GroupBox();
            checkBoxLED7 = new CheckBox();
            checkBoxLED6 = new CheckBox();
            checkBoxLED5 = new CheckBox();
            checkBoxLED4 = new CheckBox();
            B2 = new Button();
            checkBoxLED3 = new CheckBox();
            B1 = new Button();
            checkBoxLED2 = new CheckBox();
            checkBoxLED1 = new CheckBox();
            checkBoxLED0 = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            button_write = new Button();
            textBox_password = new TextBox();
            Label_Current_Time = new Label();
            button_EXIT = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            groupBox4 = new GroupBox();
            textBox1 = new TextBox();
            button4 = new Button();
            ShowCDriveSpaceButton = new Button();
            ShowMemoryInfoButton = new Button();
            ShowOSInfoButton = new Button();
            groupBox5 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label7 = new Label();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCOM
            // 
            comboBoxCOM.FormattingEnabled = true;
            comboBoxCOM.Location = new Point(8, 34);
            comboBoxCOM.Margin = new Padding(4);
            comboBoxCOM.Name = "comboBoxCOM";
            comboBoxCOM.Size = new Size(92, 27);
            comboBoxCOM.TabIndex = 0;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(109, 36);
            buttonOpen.Margin = new Padding(4);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(94, 26);
            buttonOpen.TabIndex = 1;
            buttonOpen.Text = "Open";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += ButtonOpen_Click;
            // 
            // serialPort1
            // 
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.DiscardNull = false;
            serialPort1.DtrEnable = false;
            serialPort1.Encoding = asciiEncoding3;
            serialPort1.Handshake = Handshake.None;
            serialPort1.NewLine = "\n";
            serialPort1.Parity = Parity.None;
            serialPort1.ParityReplace = 63;
            serialPort1.PortName = "COM1";
            serialPort1.ReadBufferSize = 32;
            serialPort1.ReadTimeout = -1;
            serialPort1.ReceivedBytesThreshold = 5;
            serialPort1.RtsEnable = false;
            serialPort1.StopBits = StopBits.One;
            serialPort1.WriteBufferSize = 32;
            serialPort1.WriteTimeout = -1;
            serialPort1.DataReceived += SerialPort1_DataReceived;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelDeviceStatus);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonClose);
            groupBox1.Controls.Add(comboBoxCOM);
            groupBox1.Controls.Add(buttonOpen);
            groupBox1.Location = new Point(12, 117);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(333, 131);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Device Connect";
            // 
            // labelDeviceStatus
            // 
            labelDeviceStatus.AutoSize = true;
            labelDeviceStatus.BackColor = Color.Red;
            labelDeviceStatus.Location = new Point(125, 87);
            labelDeviceStatus.Margin = new Padding(4, 0, 4, 0);
            labelDeviceStatus.Name = "labelDeviceStatus";
            labelDeviceStatus.Size = new Size(106, 19);
            labelDeviceStatus.TabIndex = 4;
            labelDeviceStatus.Text = "Device Offline";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 87);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(105, 19);
            label1.TabIndex = 3;
            label1.Text = "Device Status:";
            // 
            // buttonClose
            // 
            buttonClose.Enabled = false;
            buttonClose.Location = new Point(213, 36);
            buttonClose.Margin = new Padding(4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 26);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBoxLED7);
            groupBox3.Controls.Add(checkBoxLED6);
            groupBox3.Controls.Add(checkBoxLED5);
            groupBox3.Controls.Add(checkBoxLED4);
            groupBox3.Controls.Add(B2);
            groupBox3.Controls.Add(checkBoxLED3);
            groupBox3.Controls.Add(B1);
            groupBox3.Controls.Add(checkBoxLED2);
            groupBox3.Controls.Add(checkBoxLED1);
            groupBox3.Controls.Add(checkBoxLED0);
            groupBox3.Enabled = false;
            groupBox3.Location = new Point(451, 434);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(636, 105);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "LED Control";
            // 
            // checkBoxLED7
            // 
            checkBoxLED7.AutoSize = true;
            checkBoxLED7.Location = new Point(17, 28);
            checkBoxLED7.Margin = new Padding(4);
            checkBoxLED7.Name = "checkBoxLED7";
            checkBoxLED7.Size = new Size(67, 23);
            checkBoxLED7.TabIndex = 7;
            checkBoxLED7.Text = "LED7";
            checkBoxLED7.UseVisualStyleBackColor = true;
            checkBoxLED7.Click += CheckBoxLED7_Click;
            // 
            // checkBoxLED6
            // 
            checkBoxLED6.AutoSize = true;
            checkBoxLED6.Location = new Point(94, 28);
            checkBoxLED6.Margin = new Padding(4);
            checkBoxLED6.Name = "checkBoxLED6";
            checkBoxLED6.Size = new Size(67, 23);
            checkBoxLED6.TabIndex = 6;
            checkBoxLED6.Text = "LED6";
            checkBoxLED6.UseVisualStyleBackColor = true;
            checkBoxLED6.Click += CheckBoxLED6_Click;
            // 
            // checkBoxLED5
            // 
            checkBoxLED5.AutoSize = true;
            checkBoxLED5.Location = new Point(172, 28);
            checkBoxLED5.Margin = new Padding(4);
            checkBoxLED5.Name = "checkBoxLED5";
            checkBoxLED5.Size = new Size(67, 23);
            checkBoxLED5.TabIndex = 5;
            checkBoxLED5.Text = "LED5";
            checkBoxLED5.UseVisualStyleBackColor = true;
            checkBoxLED5.Click += CheckBoxLED5_Click;
            // 
            // checkBoxLED4
            // 
            checkBoxLED4.AutoSize = true;
            checkBoxLED4.Location = new Point(251, 28);
            checkBoxLED4.Margin = new Padding(4);
            checkBoxLED4.Name = "checkBoxLED4";
            checkBoxLED4.Size = new Size(67, 23);
            checkBoxLED4.TabIndex = 4;
            checkBoxLED4.Text = "LED4";
            checkBoxLED4.UseVisualStyleBackColor = true;
            checkBoxLED4.Click += CheckBoxLED4_Click;
            // 
            // B2
            // 
            B2.Location = new Point(398, 68);
            B2.Name = "B2";
            B2.Size = new Size(94, 29);
            B2.TabIndex = 9;
            B2.Text = "B2";
            B2.UseVisualStyleBackColor = true;
            // 
            // checkBoxLED3
            // 
            checkBoxLED3.AutoSize = true;
            checkBoxLED3.Location = new Point(328, 28);
            checkBoxLED3.Margin = new Padding(4);
            checkBoxLED3.Name = "checkBoxLED3";
            checkBoxLED3.Size = new Size(67, 23);
            checkBoxLED3.TabIndex = 3;
            checkBoxLED3.Text = "LED3";
            checkBoxLED3.UseVisualStyleBackColor = true;
            checkBoxLED3.Click += CheckBoxLED3_Click;
            // 
            // B1
            // 
            B1.Location = new Point(123, 68);
            B1.Name = "B1";
            B1.Size = new Size(94, 29);
            B1.TabIndex = 8;
            B1.Text = "B1";
            B1.UseVisualStyleBackColor = true;
            // 
            // checkBoxLED2
            // 
            checkBoxLED2.AutoSize = true;
            checkBoxLED2.Location = new Point(408, 28);
            checkBoxLED2.Margin = new Padding(4);
            checkBoxLED2.Name = "checkBoxLED2";
            checkBoxLED2.Size = new Size(67, 23);
            checkBoxLED2.TabIndex = 2;
            checkBoxLED2.Text = "LED2";
            checkBoxLED2.UseVisualStyleBackColor = true;
            checkBoxLED2.Click += CheckBoxLED2_Click;
            // 
            // checkBoxLED1
            // 
            checkBoxLED1.AutoSize = true;
            checkBoxLED1.Location = new Point(486, 28);
            checkBoxLED1.Margin = new Padding(4);
            checkBoxLED1.Name = "checkBoxLED1";
            checkBoxLED1.Size = new Size(67, 23);
            checkBoxLED1.TabIndex = 1;
            checkBoxLED1.Text = "LED1";
            checkBoxLED1.UseVisualStyleBackColor = true;
            checkBoxLED1.Click += CheckBoxLED1_Click;
            // 
            // checkBoxLED0
            // 
            checkBoxLED0.AutoSize = true;
            checkBoxLED0.Location = new Point(564, 28);
            checkBoxLED0.Margin = new Padding(4);
            checkBoxLED0.Name = "checkBoxLED0";
            checkBoxLED0.Size = new Size(67, 23);
            checkBoxLED0.TabIndex = 0;
            checkBoxLED0.Text = "LED0";
            checkBoxLED0.UseVisualStyleBackColor = true;
            checkBoxLED0.Click += CheckBoxLED0_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 497);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(346, 502);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_write);
            groupBox2.Controls.Add(textBox_password);
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(360, 247);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(318, 131);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Device Password";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // button_write
            // 
            button_write.Location = new Point(159, 40);
            button_write.Name = "button_write";
            button_write.Size = new Size(84, 53);
            button_write.TabIndex = 1;
            button_write.Text = "Write EEPROM";
            button_write.UseVisualStyleBackColor = true;
            button_write.Click += button_write_Click;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(40, 54);
            textBox_password.MaxLength = 4;
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(94, 27);
            textBox_password.TabIndex = 0;
            textBox_password.KeyPress += textBox_password_KeyPress;
            // 
            // Label_Current_Time
            // 
            Label_Current_Time.AutoSize = true;
            Label_Current_Time.BackColor = Color.White;
            Label_Current_Time.BorderStyle = BorderStyle.FixedSingle;
            Label_Current_Time.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Current_Time.Location = new Point(12, 28);
            Label_Current_Time.Name = "Label_Current_Time";
            Label_Current_Time.Size = new Size(385, 27);
            Label_Current_Time.TabIndex = 11;
            Label_Current_Time.Text = "Current Time：yyyy/mm/dd HH:mm:ss  ";
            // 
            // button_EXIT
            // 
            button_EXIT.Location = new Point(121, 303);
            button_EXIT.Name = "button_EXIT";
            button_EXIT.Size = new Size(94, 29);
            button_EXIT.TabIndex = 12;
            button_EXIT.Text = "EXIT";
            button_EXIT.UseVisualStyleBackColor = true;
            button_EXIT.Click += button_EXIT_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 418);
            label4.Name = "label4";
            label4.Size = new Size(51, 19);
            label4.TabIndex = 13;
            label4.Text = "label4";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(ShowCDriveSpaceButton);
            groupBox4.Controls.Add(ShowMemoryInfoButton);
            groupBox4.Controls.Add(ShowOSInfoButton);
            groupBox4.Enabled = false;
            groupBox4.Location = new Point(838, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(250, 423);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "System Data";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 364);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 27);
            textBox1.TabIndex = 4;
            // 
            // button4
            // 
            button4.Location = new Point(17, 283);
            button4.Name = "button4";
            button4.Size = new Size(213, 61);
            button4.TabIndex = 3;
            button4.Text = "電腦名稱";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ShowCDriveSpaceButton
            // 
            ShowCDriveSpaceButton.Location = new Point(17, 193);
            ShowCDriveSpaceButton.Name = "ShowCDriveSpaceButton";
            ShowCDriveSpaceButton.Size = new Size(213, 61);
            ShowCDriveSpaceButton.TabIndex = 2;
            ShowCDriveSpaceButton.Text = "顯示C槽總容量";
            ShowCDriveSpaceButton.UseVisualStyleBackColor = true;
            ShowCDriveSpaceButton.Click += ShowCDriveSpaceButton_Click;
            // 
            // ShowMemoryInfoButton
            // 
            ShowMemoryInfoButton.Location = new Point(17, 107);
            ShowMemoryInfoButton.Name = "ShowMemoryInfoButton";
            ShowMemoryInfoButton.Size = new Size(213, 61);
            ShowMemoryInfoButton.TabIndex = 1;
            ShowMemoryInfoButton.Text = "顯示記憶體大小";
            ShowMemoryInfoButton.UseVisualStyleBackColor = true;
            ShowMemoryInfoButton.Click += ShowMemoryInfoButton_Click;
            // 
            // ShowOSInfoButton
            // 
            ShowOSInfoButton.Location = new Point(17, 26);
            ShowOSInfoButton.Name = "ShowOSInfoButton";
            ShowOSInfoButton.Size = new Size(213, 61);
            ShowOSInfoButton.TabIndex = 0;
            ShowOSInfoButton.Text = "顯示作業系統";
            ShowOSInfoButton.UseVisualStyleBackColor = true;
            ShowOSInfoButton.Click += ShowOSInfoButton_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(label5);
            groupBox5.Location = new Point(360, 117);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(318, 125);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 80);
            label6.Name = "label6";
            label6.Size = new Size(51, 19);
            label6.TabIndex = 1;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 37);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 0;
            label5.Text = "label5";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(403, 30);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 16;
            button1.Text = "Time Sync";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(581, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(123, 27);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(503, 36);
            label7.Name = "label7";
            label7.Size = new Size(72, 19);
            label7.TabIndex = 18;
            label7.Text = "模式選擇:";
            // 
            // button2
            // 
            button2.Location = new Point(697, 84);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 19;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.KeyDown += button2_KeyDown;
            button2.KeyPress += button2_KeyPress;
            button2.KeyUp += button2_KeyUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 538);
            Controls.Add(button2);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Controls.Add(button_EXIT);
            Controls.Add(Label_Current_Time);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "112學年度　工業類科學生技藝競賽　電腦修護職種　第二站　崗位號碼：17";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCOM;
        private Button buttonOpen;
        private SerialPort serialPort1;
        private GroupBox groupBox1;
        private Button buttonClose;
        private Label labelDeviceStatus;
        private Label label1;
        private GroupBox groupBox3;
        private CheckBox checkBoxLED0;
        private CheckBox checkBoxLED3;
        private CheckBox checkBoxLED2;
        private CheckBox checkBoxLED1;
        private CheckBox checkBoxLED7;
        private CheckBox checkBoxLED6;
        private CheckBox checkBoxLED5;
        private CheckBox checkBoxLED4;
        private Label label2;
        private Button B1;
        private Button B2;
        private Label label3;
        private GroupBox groupBox2;
        private Label Label_Current_Time;
        private Button button_write;
        private TextBox textBox_password;
        private Button button_EXIT;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private GroupBox groupBox4;
        private Button ShowCDriveSpaceButton;
        private Button ShowMemoryInfoButton;
        private Button ShowOSInfoButton;
        private TextBox textBox1;
        private Button button4;
        private GroupBox groupBox5;
        private Label label6;
        private Label label5;
        private Button button1;
        private ComboBox comboBox1;
        private Label label7;
        private Button button2;
    }
}