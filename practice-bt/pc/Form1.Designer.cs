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
            System.Text.ASCIIEncoding asciiEncodingSealed1 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback1 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback1 = new System.Text.EncoderReplacementFallback();
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
            checkBoxLED3 = new CheckBox();
            checkBoxLED2 = new CheckBox();
            checkBoxLED1 = new CheckBox();
            checkBoxLED0 = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCOM
            // 
            comboBoxCOM.FormattingEnabled = true;
            comboBoxCOM.Location = new Point(6, 26);
            comboBoxCOM.Name = "comboBoxCOM";
            comboBoxCOM.Size = new Size(100, 23);
            comboBoxCOM.TabIndex = 0;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(112, 26);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(100, 23);
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
            serialPort1.Handshake = Handshake.None;
            serialPort1.NewLine = "\n";
            serialPort1.Parity = Parity.None;
            serialPort1.ParityReplace = 63;
            serialPort1.PortName = "COM1";
            serialPort1.ReadBufferSize = 32;
            serialPort1.ReadTimeout = -1;
            serialPort1.ReceivedBytesThreshold = 2;
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
            groupBox1.Location = new Point(12, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 60);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Device Connect";
            // 
            // labelDeviceStatus
            // 
            labelDeviceStatus.AutoSize = true;
            labelDeviceStatus.BackColor = Color.Red;
            labelDeviceStatus.Location = new Point(408, 31);
            labelDeviceStatus.Name = "labelDeviceStatus";
            labelDeviceStatus.Size = new Size(86, 15);
            labelDeviceStatus.TabIndex = 4;
            labelDeviceStatus.Text = "Device Offline";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 31);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 3;
            label1.Text = "Device Status:";
            // 
            // buttonClose
            // 
            buttonClose.Enabled = false;
            buttonClose.Location = new Point(218, 27);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(100, 23);
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
            groupBox3.Controls.Add(checkBoxLED3);
            groupBox3.Controls.Add(checkBoxLED2);
            groupBox3.Controls.Add(checkBoxLED1);
            groupBox3.Controls.Add(checkBoxLED0);
            groupBox3.Enabled = false;
            groupBox3.Location = new Point(12, 82);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(500, 54);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "LED Control";
            // 
            // checkBoxLED7
            // 
            checkBoxLED7.AutoSize = true;
            checkBoxLED7.Location = new Point(13, 22);
            checkBoxLED7.Name = "checkBoxLED7";
            checkBoxLED7.Size = new Size(55, 19);
            checkBoxLED7.TabIndex = 7;
            checkBoxLED7.Text = "LED7";
            checkBoxLED7.UseVisualStyleBackColor = true;
            checkBoxLED7.Click += CheckBoxLED7_Click;
            // 
            // checkBoxLED6
            // 
            checkBoxLED6.AutoSize = true;
            checkBoxLED6.Location = new Point(74, 22);
            checkBoxLED6.Name = "checkBoxLED6";
            checkBoxLED6.Size = new Size(55, 19);
            checkBoxLED6.TabIndex = 6;
            checkBoxLED6.Text = "LED6";
            checkBoxLED6.UseVisualStyleBackColor = true;
            checkBoxLED6.Click += CheckBoxLED6_Click;
            // 
            // checkBoxLED5
            // 
            checkBoxLED5.AutoSize = true;
            checkBoxLED5.Location = new Point(134, 22);
            checkBoxLED5.Name = "checkBoxLED5";
            checkBoxLED5.Size = new Size(55, 19);
            checkBoxLED5.TabIndex = 5;
            checkBoxLED5.Text = "LED5";
            checkBoxLED5.UseVisualStyleBackColor = true;
            checkBoxLED5.Click += CheckBoxLED5_Click;
            // 
            // checkBoxLED4
            // 
            checkBoxLED4.AutoSize = true;
            checkBoxLED4.Location = new Point(195, 22);
            checkBoxLED4.Name = "checkBoxLED4";
            checkBoxLED4.Size = new Size(55, 19);
            checkBoxLED4.TabIndex = 4;
            checkBoxLED4.Text = "LED4";
            checkBoxLED4.UseVisualStyleBackColor = true;
            checkBoxLED4.Click += CheckBoxLED4_Click;
            // 
            // checkBoxLED3
            // 
            checkBoxLED3.AutoSize = true;
            checkBoxLED3.Location = new Point(256, 22);
            checkBoxLED3.Name = "checkBoxLED3";
            checkBoxLED3.Size = new Size(55, 19);
            checkBoxLED3.TabIndex = 3;
            checkBoxLED3.Text = "LED3";
            checkBoxLED3.UseVisualStyleBackColor = true;
            checkBoxLED3.Click += CheckBoxLED3_Click;
            // 
            // checkBoxLED2
            // 
            checkBoxLED2.AutoSize = true;
            checkBoxLED2.Location = new Point(317, 22);
            checkBoxLED2.Name = "checkBoxLED2";
            checkBoxLED2.Size = new Size(55, 19);
            checkBoxLED2.TabIndex = 2;
            checkBoxLED2.Text = "LED2";
            checkBoxLED2.UseVisualStyleBackColor = true;
            checkBoxLED2.Click += CheckBoxLED2_Click;
            // 
            // checkBoxLED1
            // 
            checkBoxLED1.AutoSize = true;
            checkBoxLED1.Location = new Point(378, 22);
            checkBoxLED1.Name = "checkBoxLED1";
            checkBoxLED1.Size = new Size(55, 19);
            checkBoxLED1.TabIndex = 1;
            checkBoxLED1.Text = "LED1";
            checkBoxLED1.UseVisualStyleBackColor = true;
            checkBoxLED1.Click += CheckBoxLED1_Click;
            // 
            // checkBoxLED0
            // 
            checkBoxLED0.AutoSize = true;
            checkBoxLED0.Location = new Point(439, 22);
            checkBoxLED0.Name = "checkBoxLED0";
            checkBoxLED0.Size = new Size(55, 19);
            checkBoxLED0.TabIndex = 0;
            checkBoxLED0.Text = "LED0";
            checkBoxLED0.UseVisualStyleBackColor = true;
            checkBoxLED0.Click += CheckBoxLED0_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 148);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
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
    }
}