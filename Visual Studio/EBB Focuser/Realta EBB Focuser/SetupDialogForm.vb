Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ASCOM.EBB
Imports ASCOM.Utilities

<ComVisible(False)>
Public Class SetupDialogForm

    Dim vCurrent As String
    Dim vMSteps As String
    Dim vHeater As String
    Dim vEngaged As Boolean
    Dim vMotorPosition As String
    Dim vPulseLen As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        Try
            Focuser.comPort = ComboBoxComPort.SelectedItem ' Update the state variables with results from the dialogue
        Catch
            ' Ignore any errors here in case the PC does not have any COM ports that can be selected
        End Try
        Focuser.traceState = chkTrace.Checked
        If Focuser.connectedState = True Then
            While Focuser.isBusy = True
                Threading.Thread.Sleep(200)
            End While

            Focuser.isBusy = True

            If CurrentBox.Value.ToString <> vCurrent Then
                'MsgBox("Current changed")
                Focuser.objSerial.Transmit("G6" + " " + CurrentBox.Value.ToString + "#")
                Threading.Thread.Sleep(200)
            End If

            If PulseLen.Value.ToString <> vPulseLen Then
                'MsgBox("Pulse length changed")
                Focuser.objSerial.Transmit("G15" + " " + PulseLen.Value.ToString + "#")
                Threading.Thread.Sleep(200)
            End If

            If MotorPos.Value.ToString <> vMotorPosition Then
                'MsgBox("Motor positon changed")
                Focuser.objSerial.Transmit("G5" + " " + MotorPos.Value.ToString + "#")
                Threading.Thread.Sleep(200)
            End If

            If NoSteps.SelectedItem.ToString() <> vMSteps Then
                'MsgBox("MSteps changed")
                Focuser.objSerial.Transmit("G8" + " " + NoSteps.SelectedItem.ToString() + "#")
                Threading.Thread.Sleep(200)
            End If

            If HeaterVal.Value.ToString <> vHeater Then
                'MsgBox("Heater changed")
                Focuser.objSerial.Transmit("G10" + " " + HeaterVal.Value.ToString + "#")
                Threading.Thread.Sleep(200)
            End If

            If vEngaged <> MotorEngaged.Checked Then
                'MsgBox("Engaged changed")
                If MotorEngaged.Checked = True Then
                    Focuser.objSerial.Transmit("G12 1#")
                Else
                    Focuser.objSerial.Transmit("G12 0#")
                End If
                Threading.Thread.Sleep(200)
            End If

            Focuser.isBusy = False

        End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click 'Cancel button event handler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick, PictureBox1.Click
        ' Click on ASCOM logo event handler
        Try
            System.Diagnostics.Process.Start("https://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub SetupDialogForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        InitUI()
    End Sub

    Private Sub InitUI()
        chkTrace.Checked = Focuser.traceState
        ' set the list of com ports to those that are currently available
        ComboBoxComPort.Items.Clear()
        ComboBoxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames())       ' use System.IO because it's static
        ' select the current port if possible
        If ComboBoxComPort.Items.Contains(Focuser.comPort) Then
            ComboBoxComPort.SelectedItem = Focuser.comPort
        End If

        If Focuser.connectedState = True Then

            While Focuser.isBusy = True
                Threading.Thread.Sleep(200)
            End While

            Focuser.isBusy = True

            Focuser.objSerial.Transmit("G7" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            Dim s As String
            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            CurrentBox.Enabled = True
            vCurrent = s
            CurrentBox.Value = vCurrent

            Focuser.objSerial.Transmit("G16" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            PulseLen.Enabled = True
            vPulseLen = s
            PulseLen.Value = vPulseLen

            Focuser.objSerial.Transmit("G4" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            MotorPos.Enabled = True
            vMotorPosition = s
            MotorPos.Value = vMotorPosition

            Focuser.objSerial.Transmit("G9" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            NoSteps.Enabled = True
            vMSteps = s
            NoSteps.SelectedItem = vMSteps

            Focuser.objSerial.Transmit("G11" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            HeaterVal.Enabled = True
            vHeater = s
            HeaterVal.Value = vHeater


            Focuser.objSerial.Transmit("G13" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            MotorEngaged.Enabled = True
            If s = "1" Then
                MotorEngaged.Checked = True
                vEngaged = True
            Else
                MotorEngaged.Checked = False
                vEngaged = False
            End If

            Focuser.isBusy = False

        Else
            CurrentBox.Enabled = False
            MotorPos.Enabled = False
            NoSteps.Enabled = False
            MotorEngaged.Enabled = False
            HeaterVal.Enabled = False
        End If

    End Sub

End Class
