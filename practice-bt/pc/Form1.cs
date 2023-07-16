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
        }

        private readonly CheckBox[] CheckBoxLED;

        private delegate void Receive(byte[] buffer);

        private byte led;

        private void ReceiveData(byte[] buffer)
        {
            char cmd0 = (char)buffer[0];
            byte data = buffer[1];

            Text = BitConverter.ToString(buffer);

            switch (cmd0)
            {
                case 'A': UpdateLED(data); break;
                case 'B': break;
                case 'C': break;
                case 'D': break;
            }
        }

        private void SendData(byte cmd, byte data)
        {
            serialPort1.Write(new byte[] { cmd, data }, 0, 2);
        }

        private void UpdateLED(byte data)
        {
            led = data;
            for (byte i = 0; i < 8; i++)
                CheckBoxLED[i].Checked = (((data >> i) & 0x01) == 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxCOM.Items.Add(port);
            }
            comboBoxCOM.SelectedIndex = 1;
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[2];
            SerialPort sp = (SerialPort)sender;
            int lenght = sp.Read(buffer, 0, 2);
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
                MessageBox.Show("³s½u¥¢±Ñ");
            }

            if (serialPort1.IsOpen)
            {
                buttonOpen.Enabled = false;
                buttonClose.Enabled = true;
                labelDeviceStatus.Text = "Device Online";
                labelDeviceStatus.BackColor = Color.Green;
                groupBox3.Enabled = true;

                SendData((byte)'Z', 0);
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
            }
        }

        private void CheckBoxLED0_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 1));
        }

        private void CheckBoxLED1_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 2));
        }

        private void CheckBoxLED2_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 4));
        }

        private void CheckBoxLED3_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 8));
        }

        private void CheckBoxLED4_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 16));
        }

        private void CheckBoxLED5_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 32));
        }

        private void CheckBoxLED6_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 64));
        }

        private void CheckBoxLED7_Click(object sender, EventArgs e)
        {
            SendData((byte)'A', (byte)(led ^ 128));
        }
    }
}