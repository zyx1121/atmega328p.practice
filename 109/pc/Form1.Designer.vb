<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox_LED_Control = New System.Windows.Forms.GroupBox()
        Me.Button_All_Lights_ON = New System.Windows.Forms.Button()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button_All_Lights_OFF = New System.Windows.Forms.Button()
        Me.Button_EXIT = New System.Windows.Forms.Button()
        Me.Label_Current_Time = New System.Windows.Forms.Label()
        Me.Label_Status = New System.Windows.Forms.Label()
        Me.Label_Device = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_Device_Password = New System.Windows.Forms.GroupBox()
        Me.Button_Write = New System.Windows.Forms.Button()
        Me.TextBox_EEPROM = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.Button_Open = New System.Windows.Forms.Button()
        Me.ComboBox_COM = New System.Windows.Forms.ComboBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Bluetooth = New System.IO.Ports.SerialPort(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.GroupBox_LED_Control.SuspendLayout()
        Me.GroupBox_Device_Password.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_LED_Control
        '
        Me.GroupBox_LED_Control.Controls.Add(Me.Button_All_Lights_ON)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox8)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox7)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox6)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox5)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox4)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox3)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox2)
        Me.GroupBox_LED_Control.Controls.Add(Me.CheckBox1)
        Me.GroupBox_LED_Control.Controls.Add(Me.Button_All_Lights_OFF)
        Me.GroupBox_LED_Control.Enabled = False
        Me.GroupBox_LED_Control.Location = New System.Drawing.Point(31, 212)
        Me.GroupBox_LED_Control.Name = "GroupBox_LED_Control"
        Me.GroupBox_LED_Control.Size = New System.Drawing.Size(582, 159)
        Me.GroupBox_LED_Control.TabIndex = 1
        Me.GroupBox_LED_Control.TabStop = False
        Me.GroupBox_LED_Control.Text = "LED Control"
        '
        'Button_All_Lights_ON
        '
        Me.Button_All_Lights_ON.Location = New System.Drawing.Point(130, 82)
        Me.Button_All_Lights_ON.Name = "Button_All_Lights_ON"
        Me.Button_All_Lights_ON.Size = New System.Drawing.Size(120, 40)
        Me.Button_All_Lights_ON.TabIndex = 21
        Me.Button_All_Lights_ON.Text = "All Lights ON"
        Me.Button_All_Lights_ON.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(16, 43)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox8.TabIndex = 20
        Me.CheckBox8.Text = "LED7"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(86, 43)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox7.TabIndex = 19
        Me.CheckBox7.Text = "LED6"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(156, 43)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox6.TabIndex = 18
        Me.CheckBox6.Text = "LED5"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(226, 43)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox5.TabIndex = 17
        Me.CheckBox5.Text = "LED4"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(296, 43)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox4.TabIndex = 16
        Me.CheckBox4.Text = "LED3"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(366, 43)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox3.TabIndex = 15
        Me.CheckBox3.Text = "LED2"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(436, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox2.TabIndex = 14
        Me.CheckBox2.Text = "LED1"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(506, 43)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox1.TabIndex = 13
        Me.CheckBox1.Text = "LED0"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button_All_Lights_OFF
        '
        Me.Button_All_Lights_OFF.Location = New System.Drawing.Point(330, 82)
        Me.Button_All_Lights_OFF.Name = "Button_All_Lights_OFF"
        Me.Button_All_Lights_OFF.Size = New System.Drawing.Size(120, 40)
        Me.Button_All_Lights_OFF.TabIndex = 11
        Me.Button_All_Lights_OFF.Text = "All Lights OFF"
        Me.Button_All_Lights_OFF.UseVisualStyleBackColor = True
        '
        'Button_EXIT
        '
        Me.Button_EXIT.Location = New System.Drawing.Point(258, 392)
        Me.Button_EXIT.Name = "Button_EXIT"
        Me.Button_EXIT.Size = New System.Drawing.Size(120, 40)
        Me.Button_EXIT.TabIndex = 23
        Me.Button_EXIT.Text = "EXIT"
        Me.Button_EXIT.UseVisualStyleBackColor = True
        '
        'Label_Current_Time
        '
        Me.Label_Current_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Current_Time.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label_Current_Time.Location = New System.Drawing.Point(192, 20)
        Me.Label_Current_Time.Name = "Label_Current_Time"
        Me.Label_Current_Time.Size = New System.Drawing.Size(250, 40)
        Me.Label_Current_Time.TabIndex = 26
        Me.Label_Current_Time.Text = "Current Time：HH:MM:SS"
        Me.Label_Current_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.Location = New System.Drawing.Point(12, 82)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(91, 16)
        Me.Label_Status.TabIndex = 25
        Me.Label_Status.Text = "Device Statu:"
        '
        'Label_Device
        '
        Me.Label_Device.BackColor = System.Drawing.Color.Red
        Me.Label_Device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Device.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label_Device.Location = New System.Drawing.Point(102, 77)
        Me.Label_Device.Name = "Label_Device"
        Me.Label_Device.Size = New System.Drawing.Size(166, 26)
        Me.Label_Device.TabIndex = 24
        Me.Label_Device.Text = "Device Offline"
        Me.Label_Device.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'GroupBox_Device_Password
        '
        Me.GroupBox_Device_Password.Controls.Add(Me.Button_Write)
        Me.GroupBox_Device_Password.Controls.Add(Me.TextBox_EEPROM)
        Me.GroupBox_Device_Password.Enabled = False
        Me.GroupBox_Device_Password.Location = New System.Drawing.Point(325, 78)
        Me.GroupBox_Device_Password.Name = "GroupBox_Device_Password"
        Me.GroupBox_Device_Password.Size = New System.Drawing.Size(288, 128)
        Me.GroupBox_Device_Password.TabIndex = 28
        Me.GroupBox_Device_Password.TabStop = False
        Me.GroupBox_Device_Password.Text = "Device Password"
        '
        'Button_Write
        '
        Me.Button_Write.Location = New System.Drawing.Point(153, 50)
        Me.Button_Write.Name = "Button_Write"
        Me.Button_Write.Size = New System.Drawing.Size(100, 40)
        Me.Button_Write.TabIndex = 2
        Me.Button_Write.Text = "Write EEPROM"
        Me.Button_Write.UseVisualStyleBackColor = True
        '
        'TextBox_EEPROM
        '
        Me.TextBox_EEPROM.Location = New System.Drawing.Point(25, 59)
        Me.TextBox_EEPROM.MaxLength = 4
        Me.TextBox_EEPROM.Name = "TextBox_EEPROM"
        Me.TextBox_EEPROM.Size = New System.Drawing.Size(100, 27)
        Me.TextBox_EEPROM.TabIndex = 0
        Me.TextBox_EEPROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button_Close)
        Me.GroupBox4.Controls.Add(Me.Button_Open)
        Me.GroupBox4.Controls.Add(Me.ComboBox_COM)
        Me.GroupBox4.Controls.Add(Me.Label_Device)
        Me.GroupBox4.Controls.Add(Me.Label_Status)
        Me.GroupBox4.Location = New System.Drawing.Point(31, 78)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(288, 128)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Device Connect"
        '
        'Button_Close
        '
        Me.Button_Close.Location = New System.Drawing.Point(188, 30)
        Me.Button_Close.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_Close.Name = "Button_Close"
        Me.Button_Close.Size = New System.Drawing.Size(80, 40)
        Me.Button_Close.TabIndex = 26
        Me.Button_Close.Text = "Close"
        Me.Button_Close.UseVisualStyleBackColor = True
        '
        'Button_Open
        '
        Me.Button_Open.Location = New System.Drawing.Point(102, 30)
        Me.Button_Open.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_Open.Name = "Button_Open"
        Me.Button_Open.Size = New System.Drawing.Size(80, 40)
        Me.Button_Open.TabIndex = 18
        Me.Button_Open.Text = "Open"
        Me.Button_Open.UseVisualStyleBackColor = True
        '
        'ComboBox_COM
        '
        Me.ComboBox_COM.FormattingEnabled = True
        Me.ComboBox_COM.Location = New System.Drawing.Point(16, 39)
        Me.ComboBox_COM.Name = "ComboBox_COM"
        Me.ComboBox_COM.Size = New System.Drawing.Size(80, 24)
        Me.ComboBox_COM.Sorted = True
        Me.ComboBox_COM.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 455)
        Me.Controls.Add(Me.GroupBox_Device_Password)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button_EXIT)
        Me.Controls.Add(Me.Label_Current_Time)
        Me.Controls.Add(Me.GroupBox_LED_Control)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "109學年度　工業類科學生技藝競賽　電腦修護職種　第二站　崗位號碼：68"
        Me.GroupBox_LED_Control.ResumeLayout(False)
        Me.GroupBox_LED_Control.PerformLayout()
        Me.GroupBox_Device_Password.ResumeLayout(False)
        Me.GroupBox_Device_Password.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_LED_Control As GroupBox
    Friend WithEvents Button_All_Lights_OFF As Button
    Friend WithEvents Button_EXIT As Button
    Friend WithEvents Label_Current_Time As Label
    Friend WithEvents Label_Status As Label
    Friend WithEvents Label_Device As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox_Device_Password As GroupBox
    Friend WithEvents Button_Write As Button
    Friend WithEvents TextBox_EEPROM As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button_Open As Button
    Friend WithEvents ComboBox_COM As ComboBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Bluetooth As IO.Ports.SerialPort
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button_All_Lights_ON As Button
    Friend WithEvents Button_Close As Button
End Class
