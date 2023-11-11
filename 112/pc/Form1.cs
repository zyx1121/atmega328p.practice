using System.Diagnostics;
using System.IO.Ports;
using System.Text;


namespace pc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckBoxLED = new CheckBox[] { checkBoxLED0, checkBoxLED1, checkBoxLED2, checkBoxLED3, checkBoxLED4, checkBoxLED5, checkBoxLED6, checkBoxLED7 };

            comboBox1.Items.Add("1-鎖定螢幕");
            comboBox1.Items.Add("2-顯示設定");
            comboBox1.Items.Add("3-時間同步");
            comboBox1.Items.Add("4-電腦資訊");
        }

        private readonly CheckBox[] CheckBoxLED;

        private delegate void Receive(byte[] buffer);

        private byte led, date;
        private byte[] l7s = { 0, 0, 0, 0 };

        private void ReceiveData(byte[] buffer)
        {
            char cmd0 = (char)buffer[0];
            byte data0 = buffer[1];
            byte data1 = buffer[2];
            byte data2 = buffer[3];
            byte data3 = buffer[4];
            byte data4 = buffer[5];
            

            if (cmd0 == 'B')
            {
                label2.Text = data0.ToString() + '.' + data1.ToString();
            }
        }

        private void SendData(byte cmd, byte[] data)
        {
            serialPort1.Write(new byte[] { cmd, data[0], data[1], data[2], data[3], data[4], data[5], data[6] }, 0, 8);
        }

        private void UpdateLED(byte data)
        {
            led = data;
            for (byte i = 0; i < 8; i++)
                CheckBoxLED[i].Checked = (((data >> i) & 0x01) == 1);
        }

        private void DateMode(byte data)
        {
            DateTime currentTime = DateTime.Now;

            int year = currentTime.Year;
            int year1 = year - 2000;
            int month = currentTime.Month;
            int day = currentTime.Day;
            int hour = currentTime.Hour;
            int minute = currentTime.Minute;
            int second = currentTime.Second;

            switch (data)
            {
                case 0:
                    label3.Text = "1";
                    SendData((byte)'D', new byte[] { 1, (byte)hour, (byte)minute, (byte)second, 0, 0, 0 });
                    break;
                case 1:
                    label3.Text = "2";
                    SendData((byte)'D', new byte[] { 2, (byte)year1, (byte)month, (byte)day, 0, 0, 0 });
                    break;
                case 2:
                    label3.Text = "3";
                    SendData((byte)'D', new byte[] { 3, (byte)hour, (byte)minute, (byte)second, (byte)month, (byte)day, 0 });
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Enabled = true;

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxCOM.Items.Add(port);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[6];
            SerialPort sp = (SerialPort)sender;
            int lenght = sp.Read(buffer, 0, 6);
            Invoke(new Receive(ReceiveData), new object[] { buffer });
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            string x = (string)comboBoxCOM.SelectedItem;
            serialPort1.PortName = x;
            serialPort1.BaudRate = 9600;
            serialPort1.ReceivedBytesThreshold = 2;
            serialPort1.Encoding = Encoding.ASCII;

            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("連線失敗");
            }

            if (serialPort1.IsOpen)
            {
                buttonOpen.Enabled = false;
                buttonClose.Enabled = true;
                labelDeviceStatus.Text = "Device Online";
                labelDeviceStatus.BackColor = Color.Green;
                groupBox3.Enabled = true;
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
                comboBox1.Enabled = true;

                SendData((byte)'Z', new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });

            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                buttonOpen.Enabled = true;
                buttonClose.Enabled = false;
                labelDeviceStatus.Text = "Device Offline";
                labelDeviceStatus.BackColor = Color.Red;
                groupBox3.Enabled = false;
                groupBox2.Enabled = false;
                groupBox4.Enabled = false;
                groupBox3.Enabled = false;
                comboBox1.Enabled = false;
                button1.Enabled = false;
            }
        }


        private void CheckBoxLED0_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 1), 0, 0, 0, 0, 0 });
        }

        private void CheckBoxLED1_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 2), 0, 0, 0, 0, 0 });
        }

        private void CheckBoxLED2_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 4), 0, 0, 0, 0, 0 });
        }

        private void CheckBoxLED3_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 8), 0, 0, 0, 0, 0 });
        }

        private void CheckBoxLED4_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 16), 0, 0, 0, 0, 0 });
        }

        private void CheckBoxLED5_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 32), 0, 0, 0, 0 });
        }

        private void CheckBoxLED6_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 64), 0, 0, 0, 0 });
        }

        private void CheckBoxLED7_Click(object sender, EventArgs e)
        {
            //SendData((byte)'A', new byte[] { (byte)(led ^ 128), 0, 0, 0, 0 });
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label_Current_Time.Text = "Current Time：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            /*+ DateTime.Now.Year.ToString() +
         "/" + DateTime.Now.Month.ToString() +
         "/" + DateTime.Now.Day.ToString() +
         " " + DateTime.Now.Hour.ToString() +
         ":" + DateTime.Now.Minute.ToString() +
         ":" + DateTime.Now.Second.ToString();*/
        }

        private void button_write_Click(object sender, EventArgs e)
        {
            byte[] test = new byte[] { (byte) Convert.ToInt16(textBox_password.Text.ElementAt(0)),
                                             (byte) Convert.ToInt16(textBox_password.Text.ElementAt(1)),
                                             (byte) Convert.ToInt16(textBox_password.Text.ElementAt(2)),
                                             (byte) Convert.ToInt16(textBox_password.Text.ElementAt(3)) };
            SendData((byte)'B', test);

            label3.Text = BitConverter.ToString(test);

        }

        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void ShowOSInfoButton_Click(object sender, EventArgs e)
        {
            string osVersion = Environment.OSVersion.VersionString;
            string osPlatform = Environment.OSVersion.Platform.ToString();
            string osServicePack = Environment.OSVersion.ServicePack;
            string osVersionString = Environment.OSVersion.Version.ToString();

            string osInfo = $"作業系統版本: {osVersion}\n" +
                           $"作業系統平台: {osPlatform}\n" +
                           $"作業系統Service Pack: {osServicePack}\n" +
                           $"作業系統版本號: {osVersionString}";

            MessageBox.Show(osInfo, "作業系統信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowMemoryInfoButton_Click(object sender, EventArgs e)
        {
            long memorySize = 0;

            using (Process currentProcess = Process.GetCurrentProcess())
            {
                memorySize = currentProcess.PrivateMemorySize64;
            }

            double memorySizeMB = memorySize / (1024.0 * 1024.0); // 將位元組轉換為MB

            string memoryInfo = $"系統記憶體使用: {memorySizeMB:F2} MB";

            MessageBox.Show(memoryInfo, "記憶體資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowCDriveSpaceButton_Click(object sender, EventArgs e)
        {
            DriveInfo cDrive = new DriveInfo("C");

            long totalSpaceBytes = cDrive.TotalSize;
            double totalSpaceGB = totalSpaceBytes / (1024.0 * 1024.0 * 1024.0); // 將位元組轉換為GB

            string spaceInfo = $"C槽總容量: {totalSpaceGB:F2} GB";

            MessageBox.Show(spaceInfo, "C槽容量", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string computerName = Environment.MachineName;

            MessageBox.Show("電腦名稱: " + computerName, "電腦名稱", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedFunction = comboBox1.SelectedItem.ToString();
            label5.Text = selectedFunction;
            // 根據選擇的功能執行相應的操作
            switch (selectedFunction)
            {
                case "1-鎖定螢幕":
                    SendData((byte)'C', new byte[] { 1, 0, 0, 0, 0, 0, 0 });
                    button1.Enabled = false;
                    break;
                case "2-顯示設定":
                    SendData((byte)'C', new byte[] { 2, 0, 0, 0, 0, 0, 0 });
                    label6.Text = "00001";
                    button1.Enabled = false;
                    break;
                case "3-時間同步":
                    SendData((byte)'C', new byte[] { 3, 0, 0, 0, 0, 0, 0 });
                    button1.Enabled = true;
                    break;
                case "4-電腦資訊":
                    SendData((byte)'C', new byte[] { 5, 0, 0, 0, 0, 0, 0 });
                    button1.Enabled = false;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendData((byte)'C', new byte[] { 4, 0, 0, 0, 0, 0, 0 });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            int year = currentTime.Year;
            int year1 = year - 2000;
            int month = currentTime.Month;
            int day = currentTime.Day;
            int hour = currentTime.Hour;
            int minute = currentTime.Minute;
            int second = currentTime.Second;

            SendData((byte)'D', new byte[] { (byte)second, (byte)minute, (byte)hour, (byte)day, (byte)month, (byte)year1, 0 });
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}