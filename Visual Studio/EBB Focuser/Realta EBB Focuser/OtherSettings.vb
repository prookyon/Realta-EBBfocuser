Public Class OtherSettings

    Dim vCurrent As String
    Dim vMSteps As String
    Dim vHeater As String
    Dim vEngaged As Boolean
    Dim vMotorPosition As String
    Dim vPulseLen As String


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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
                ' MsgBox("Motor positon changed")
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

        Me.Close()

    End Sub

    Private Sub OtherSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        InitUI()
    End Sub

    Public Sub InitUI()

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

    End Sub

End Class