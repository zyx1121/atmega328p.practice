Imports System.IO.Ports
Public Class Form1
    Const usbVID As Integer = &H1234
    Const usbPID As Integer = &H6789


    Dim dataBuffer(10) As Byte
    Dim connectDevice As String = "none"

    Dim led(8) As CheckBox

    Dim mainIndex As Integer
    Dim ledBuffer As Integer
    Dim vr As Integer
    Dim serialPortNum As Integer
    Dim button(4) As Boolean

    Dim rgbSelected(3) As Integer



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        led(0) = CheckBox1
        led(1) = CheckBox2
        led(2) = CheckBox3
        led(3) = CheckBox4
        led(4) = CheckBox5
        led(5) = CheckBox6
        led(6) = CheckBox7
        led(7) = CheckBox8


        serialPortNum = SerialPort.GetPortNames.Length
        For Each sp In SerialPort.GetPortNames
            ComboBox_COM.Items.Add(sp)
        Next

        Timer1.Enabled = True
    End Sub

    Sub CLEAN()
        connectDevice = "none"
        Label_Device.Text = "Device Offline"
        Label_Device.BackColor = Color.FromArgb(255, 0, 0)
        For i = 0 To 7
            led(i).Checked = False
        Next

        mainIndex = 0
        ledBuffer = 0
    End Sub
    Function HEX_TO_INT(h) As Integer
        Dim s = "0123456789ABCDEF"
        Dim byteH, byteL

        byteH = s.IndexOf(Mid(h, 1, 1))
        byteL = s.IndexOf(Mid(h, 2, 1))

        Return byteH * 16 + byteL
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label_Current_Time.Text = "Current Time：" & TimeString

        Select Case connectDevice
            Case "none"

            Case "bt"
                BT_RECEIVE()
        End Select

        If serialPortNum <> SerialPort.GetPortNames.Length Then
            ComboBox_COM.Items.Clear()
            For Each sp In SerialPort.GetPortNames
                ComboBox_COM.Items.Add(sp)
            Next
            serialPortNum = SerialPort.GetPortNames.Length
        End If

    End Sub


    Sub DATA_SEND(d0, d1, d2, d3, d4, d5, d6, d7, usbClose)
        dataBuffer(0) = d0
        dataBuffer(1) = d1
        dataBuffer(2) = d2
        dataBuffer(3) = d3
        dataBuffer(4) = d4
        dataBuffer(5) = d5
        dataBuffer(6) = d6
        dataBuffer(7) = d7


        If Bluetooth.IsOpen Then
            Dim sendStr As String = ""
            For i = 0 To 7
                sendStr = sendStr & dataBuffer(i) & ","
            Next
            Bluetooth.Write(sendStr)
        Else
            CLEAN()
        End If

    End Sub

    Sub TIME_SEND()
        DATA_SEND(0, 0, DatePart(Microsoft.VisualBasic.DateInterval.Second, Now),
                        DatePart(Microsoft.VisualBasic.DateInterval.Minute, Now),
                        DatePart(Microsoft.VisualBasic.DateInterval.Hour, Now),
                        DatePart(Microsoft.VisualBasic.DateInterval.Day, Now),
                        DatePart(Microsoft.VisualBasic.DateInterval.Month, Now), 0, True)
    End Sub

    Private Sub Button_Open_Click(sender As Object, e As EventArgs) Handles Button_Open.Click
        Bluetooth.Close()
        Bluetooth.PortName = ComboBox_COM.Text
        Bluetooth.BaudRate = 9600
        Bluetooth.DataBits = 8
        Bluetooth.Parity = Parity.None
        Bluetooth.StopBits = StopBits.One
        Bluetooth.Handshake = Handshake.None
        Bluetooth.Encoding = System.Text.Encoding.Default
        Bluetooth.ReadTimeout = 10000

        Bluetooth.Open()

        Button_Open.Enabled = False
        GroupBox_Device_Password.Enabled = True
        GroupBox_LED_Control.Enabled = True

        connectDevice = "bt"
        Label_Device.Text = "Device Online"
        Label_Device.BackColor = Color.FromArgb(0, 255, 0)

        REM DATA_SEND(1, 2, 0, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub Button_Close_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        Bluetooth.Close()

        Button_Open.Enabled = True
        GroupBox_Device_Password.Enabled = False
        GroupBox_LED_Control.Enabled = False

        CLEAN()
    End Sub

    Sub BT_RECEIVE()
        Dim fromAvr As String
        Try
            fromAvr = Bluetooth.ReadExisting
            If fromAvr IsNot Nothing Then
                If fromAvr.Contains("<") And fromAvr.Contains(">") Then
                    CHECK_DATA(fromAvr)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub CHECK_DATA(receiveData)
        Dim msg, data, cmdH, cmdL
        Dim p1, p2

        REM <xxx><xxx>
        While True
            p1 = receiveData.Indexof("<", 0) + 1
            p2 = receiveData.Indexof(">", 0) + 1

            If p2 < p1 Then Exit Sub


            data = Mid(receiveData, p1 + 1, p2 - p1 - 1)

            ledBuffer = data
            CHECK_LED()

            'cmdH = Mid(msg, 1, 1)
            'cmdL = Mid(msg, 2, 1)
            'data = Mid(msg, 3)

            'Select Case cmdH
            'Case "z"
            REM BTTime = 0
            'Case "a"
            'mainIndex = data
            'Case "b"
            'ledBuffer = data
            'CHECK_LED()
            'Case "c"
            'l7sBuffer = data
            'Case "d"
            '
            'Case "e"

            'End Select

            receiveData = Mid(receiveData, p2 + 1)
        End While
    End Sub

    Sub CHECK_LED()
        Dim temp As Integer = ledBuffer
        For i = 0 To 7
            ' 7 mod 2 = 1
            If temp Mod 2 = 1 Then
                led(i).Checked = True
            Else
                led(i).Checked = False
            End If
            temp = temp \ 2
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click
        DATA_SEND(0, 0, 1, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click
        DATA_SEND(0, 0, 2, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click
        DATA_SEND(0, 0, 4, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click
        DATA_SEND(0, 0, 8, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.Click
        DATA_SEND(0, 0, 16, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.Click
        DATA_SEND(0, 0, 32, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.Click
        DATA_SEND(0, 0, 64, 0, 0, 0, 0, 0, True)
    End Sub
    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.Click
        DATA_SEND(0, 0, 128, 0, 0, 0, 0, 0, True)
    End Sub

    Private Sub TextBox_EEPROM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_EEPROM.KeyPress
        If e.KeyChar = Chr(48) Or e.KeyChar = Chr(49) Or e.KeyChar = Chr(50) Or e.KeyChar = Chr(51) Or e.KeyChar = Chr(52) Or e.KeyChar = Chr(53) Or e.KeyChar = Chr(54) Or e.KeyChar = Chr(55) Or e.KeyChar = Chr(56) Or e.KeyChar = Chr(57) Or e.KeyChar = Chr(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button_Write_Click(sender As Object, e As EventArgs) Handles Button_Write.Click
        If TextBox_EEPROM.TextLength = 4 Then
            DATA_SEND(1, Mid(TextBox_EEPROM.Text, 4, 1), Mid(TextBox_EEPROM.Text, 3, 1), Mid(TextBox_EEPROM.Text, 2, 1), Mid(TextBox_EEPROM.Text, 1, 1), 0, 0, 0, True)
            DATA_SEND(1, 5, 5, 5, 5, 0, 0, 0, True)
        Else
            TextBox_EEPROM.Text = ""
        End If

    End Sub

    Private Sub Button_All_Lights_OFF_Click(sender As Object, e As EventArgs) Handles Button_All_Lights_OFF.Click
        DATA_SEND(0, 1, 0, 0, 0, 0, 0, 0, True)
    End Sub

    Private Sub Button_All_Lights_ON_Click(sender As Object, e As EventArgs) Handles Button_All_Lights_ON.Click
        DATA_SEND(0, 2, 0, 0, 0, 0, 0, 0, True)
    End Sub

    Private Sub Button_EXIT_Click(sender As Object, e As EventArgs) Handles Button_EXIT.Click
        End
    End Sub

End Class
