'tabs=4
' --------------------------------------------------------------------------------
' TODO fill in this information for your driver, then remove this line!
'
' ASCOM Focuser driver for EBB42
'
' Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
'				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
'				erat, sed diam voluptua. At vero eos et accusam et justo duo 
'				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
'				sanctus est Lorem ipsum dolor sit amet.
'
' Implements:	ASCOM Focuser interface version: 1.0
' Author:		(XXX) Your N. Here <your@email.here>
'
' Edit Log:
'
' Date			Who	Vers	Description
' -----------	---	-----	-------------------------------------------------------
' dd-mmm-yyyy	XXX	1.0.0	Initial edit, from Focuser template
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.EBB.Focuser
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Focuser
' The ClassInterface/None attribute prevents an empty interface called
' _Focuser from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Focuser"

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

<Guid("3c82329e-5fb7-4a23-8c41-f3c32b291fc3")>
<ClassInterface(ClassInterfaceType.None)>
Public Class Focuser

    ' The Guid attribute sets the CLSID for ASCOM.EBB42.Focuser
    ' The ClassInterface/None attribute prevents an empty interface called
    ' _EBB42 from being created and used as the [default] interface

    ' TODO Replace the not implemented exceptions with code to implement the function or
    ' throw the appropriate ASCOM exception.
    '
    Implements IFocuserV3

    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Friend Shared driverID As String = "ASCOM.EBB.Focuser"
    Private Shared driverDescription As String = "Realta EBB Focuser"

    Friend Shared comPortProfileName As String = "COM Port" 'Constants used for Profile persistence
    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared comPortDefault As String = "COM1"
    Friend Shared traceStateDefault As String = "False"

    Friend Shared comPort As String ' Variables to hold the current device configuration
    Friend Shared traceState As Boolean

    Friend Shared connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)

    Friend Shared objSerial As ASCOM.Utilities.Serial
    Friend Shared isBusy As Boolean = False

    Private MyOtherSetting As OtherSettings = New OtherSettings()

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()

        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("", "EBB")
        TL.Enabled = traceState
        TL.LogMessage("Focuser", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utilities object

        'TODO: Implement your additional construction here

        TL.LogMessage("Focuser", "Completed initialisation")
    End Sub

    '
    ' PUBLIC COM INTERFACE IFocuserV3 IMPLEMENTATION
    '

#Region "Common properties and methods"
    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements IFocuserV3.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        'If IsConnected Then
        'System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        'End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using
    End Sub

    ''' <summary>Returns the list of custom action names supported by this driver.</summary>
    ''' <value>An ArrayList of strings (SafeArray collection) containing the names of supported actions.</value>
    Public ReadOnly Property SupportedActions() As ArrayList Implements IFocuserV3.SupportedActions
        Get
            TL.LogMessage("SupportedActions Get", "Returning empty arraylist")
            Return New ArrayList()
        End Get
    End Property

    ''' <summary>Invokes the specified device-specific custom action.</summary>
    ''' <param name="ActionName">A well known name agreed by interested parties that represents the action to be carried out.</param>
    ''' <param name="ActionParameters">List of required parameters or an <see cref="String.Empty">Empty String</see> if none are required.</param>
    ''' <returns>A string response. The meaning of returned strings is set by the driver author.
    ''' <para>Suppose filter wheels start to appear with automatic wheel changers; new actions could be <c>QueryWheels</c> and <c>SelectWheel</c>. The former returning a formatted list
    ''' of wheel names and the second taking a wheel name and making the change, returning appropriate values to indicate success or failure.</para>
    ''' </returns>
    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements IFocuserV3.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    ''' <summary>
    ''' Transmits an arbitrary string to the device and does not wait for a response.
    ''' Optionally, protocol framing characters may be added to the string before transmission.
    ''' </summary>
    ''' <param name="Command">The literal command string to be transmitted.</param>
    ''' <param name="Raw">
    ''' if set to <c>True</c> the string is transmitted 'as-is'.
    ''' If set to <c>False</c> then protocol framing characters may be added prior to transmission.
    ''' </param>
    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements IFocuserV3.CommandBlind
        CheckConnected("CommandBlind")
        ' TODO The optional CommandBlind method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBlind must send the supplied command to the mount And return immediately without waiting for a response

        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    ''' <summary>
    ''' Transmits an arbitrary string to the device and waits for a boolean response.
    ''' Optionally, protocol framing characters may be added to the string before transmission.
    ''' </summary>
    ''' <param name="Command">The literal command string to be transmitted.</param>
    ''' <param name="Raw">
    ''' if set to <c>True</c> the string is transmitted 'as-is'.
    ''' If set to <c>False</c> then protocol framing characters may be added prior to transmission.
    ''' </param>
    ''' <returns>
    ''' Returns the interpreted boolean response received from the device.
    ''' </returns>
    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements IFocuserV3.CommandBool
        CheckConnected("CommandBool")
        ' TODO The optional CommandBool method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBool must send the supplied command to the mount, wait for a response and parse this to return a True Or False value

        ' Dim retString as String = CommandString(command, raw) ' Send the command And wait for the response
        ' Dim retBool as Boolean = XXXXXXXXXXXXX ' Parse the returned string And create a boolean True / False value
        ' Return retBool ' Return the boolean value to the client

        Throw New MethodNotImplementedException("CommandBool")
    End Function

    ''' <summary>
    ''' Transmits an arbitrary string to the device and waits for a string response.
    ''' Optionally, protocol framing characters may be added to the string before transmission.
    ''' </summary>
    ''' <param name="Command">The literal command string to be transmitted.</param>
    ''' <param name="Raw">
    ''' if set to <c>True</c> the string is transmitted 'as-is'.
    ''' If set to <c>False</c> then protocol framing characters may be added prior to transmission.
    ''' </param>
    ''' <returns>
    ''' Returns the string response received from the device.
    ''' </returns>
    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements IFocuserV3.CommandString
        CheckConnected("CommandString")
        ' TODO The optional CommandString method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandString must send the supplied command to the mount and wait for a response before returning this to the client

        Throw New MethodNotImplementedException("CommandString")
    End Function

    ''' <summary>
    ''' Set True to connect to the device hardware. Set False to disconnect from the device hardware.
    ''' You can also read the property to check whether it is connected. This reports the current hardware state.
    ''' </summary>
    ''' <value><c>True</c> if connected to the hardware; otherwise, <c>False</c>.</value>
    Public Property Connected() As Boolean Implements IFocuserV3.Connected
        Get
            TL.LogMessage("Connected Get", IsConnected.ToString())
            Return IsConnected
        End Get
        Set(value As Boolean)
            TL.LogMessage("Connected Set", value.ToString())
            If value = IsConnected Then
                Return
            End If

            If value Then

                TL.LogMessage("Connected Set", "Connecting to port " + comPort)
                Focuser.objSerial = New ASCOM.Utilities.Serial
                Focuser.objSerial.PortName = comPort
                Focuser.objSerial.Speed = SerialSpeed.ps9600
                Focuser.objSerial.Parity = SerialParity.None
                Focuser.objSerial.DataBits = 8
                Focuser.objSerial.StopBits = SerialStopBits.One
                Focuser.objSerial.Handshake = SerialHandshake.None
                Focuser.objSerial.ReceiveTimeout = 5
                Focuser.objSerial.Connected = True

                Threading.Thread.Sleep(2000)

                'MyOtherSetting.InitUI()
                connectedState = True

                MyOtherSetting.ShowDialog()


            Else
                TL.LogMessage("Connected Set", "Disconnecting from port " + comPort)
                Focuser.objSerial.Connected = False
                connectedState = False
            End If
        End Set

    End Property

    ''' <summary>
    ''' Returns a description of the device, such as manufacturer and modelnumber. Any ASCII characters may be used.
    ''' </summary>
    ''' <value>The description.</value>
    Public ReadOnly Property Description As String Implements IFocuserV3.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            TL.LogMessage("Description Get", d)
            Return d
        End Get
    End Property

    ''' <summary>
    ''' Descriptive and version information about this ASCOM driver.
    ''' </summary>
    Public ReadOnly Property DriverInfo As String Implements IFocuserV3.DriverInfo
        Get
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' TODO customise this driver description
            Dim s_driverInfo As String = "Realta EBB driver by Gerorge Moran. Version: 1.1"
            TL.LogMessage("DriverInfo Get", s_driverInfo)
            Return s_driverInfo
        End Get
    End Property

    ''' <summary>
    ''' A string containing only the major and minor version of the driver formatted as 'm.n'.
    ''' </summary>
    Public ReadOnly Property DriverVersion() As String Implements IFocuserV3.DriverVersion
        Get
            ' Get our own assembly and report its version number
            TL.LogMessage("DriverVersion Get", "1.1")
            Return "1.1"
        End Get
    End Property

    ''' <summary>
    ''' The interface version number that this device supports. 
    ''' </summary>
    Public ReadOnly Property InterfaceVersion() As Short Implements IFocuserV3.InterfaceVersion
        Get
            TL.LogMessage("InterfaceVersion Get", "3")
            Return 3
        End Get
    End Property

    ''' <summary>
    ''' The short name of the driver, for display purposes
    ''' </summary>
    Public ReadOnly Property Name As String Implements IFocuserV3.Name
        Get
            Dim s_name As String = "Realta EBB focuser"
            TL.LogMessage("Name Get", s_name)
            Return s_name
        End Get
    End Property

    ''' <summary>
    ''' Dispose the late-bound interface, if needed. Will release it via COM
    ''' if it is a COM object, else if native .NET will just dereference it
    ''' for GC.
    ''' </summary>
    Public Sub Dispose() Implements IFocuserV3.Dispose
        ' Clean up the trace logger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
        MyOtherSetting.Hide()
    End Sub

#End Region

#Region "IFocuser Implementation"

    Private focuserPosition As Integer = 0 ' Class level variable to hold the current focuser position
    Private Const focuserSteps As Integer = 1000000

    ''' <summary>
    ''' True if the focuser is capable of absolute position; that is, being commanded to a specific step location.
    ''' </summary>
    Public ReadOnly Property Absolute() As Boolean Implements IFocuserV3.Absolute
        Get
            TL.LogMessage("Absolute Get", True.ToString())
            Return True ' This is an absolute focuser
        End Get
    End Property

    ''' <summary>
    ''' Immediately stop any focuser motion due to a previous <see cref="Move" /> method call.
    ''' </summary>
    Public Sub Halt() Implements IFocuserV3.Halt
        While isBusy = True
            Threading.Thread.Sleep(200)
        End While

        isBusy = True
        Focuser.objSerial.Transmit("G2" + "#" + vbCrLf)
        Threading.Thread.Sleep(200)
        isBusy = False
    End Sub

    ''' <summary>
    ''' True if the focuser is currently moving to a new position. False if the focuser is stationary.
    ''' </summary>
    Public ReadOnly Property IsMoving() As Boolean Implements IFocuserV3.IsMoving
        Get
            While isBusy = True
                Threading.Thread.Sleep(200)
            End While

            isBusy = True
            Focuser.objSerial.Transmit("G3" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            Dim s As String
            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            isBusy = False
            Return CShort(s)


        End Get
    End Property

    ''' <summary>
    ''' State of the connection to the focuser.
    ''' </summary>
    Public Property Link() As Boolean Implements IFocuserV3.Link
        Get
            TL.LogMessage("Link Get", Me.Connected.ToString())
            Return Me.Connected ' Direct function to the connected method, the Link method is just here for backwards compatibility
        End Get
        Set(value As Boolean)
            TL.LogMessage("Link Set", value.ToString())
            Me.Connected = value ' Direct function to the connected method, the Link method is just here for backwards compatibility
        End Set
    End Property

    ''' <summary>
    ''' Maximum increment size allowed by the focuser;
    ''' i.e. the maximum number of steps allowed in one move operation.
    ''' </summary>
    Public ReadOnly Property MaxIncrement() As Integer Implements IFocuserV3.MaxIncrement
        Get
            TL.LogMessage("MaxIncrement Get", focuserSteps.ToString())
            Return focuserSteps ' Maximum change in one move
        End Get
    End Property

    ''' <summary>
    ''' Maximum step position permitted.
    ''' </summary>
    Public ReadOnly Property MaxStep() As Integer Implements IFocuserV3.MaxStep
        Get
            TL.LogMessage("MaxStep Get", focuserSteps.ToString())
            Return focuserSteps ' Maximum extent of the focuser, so position range is 0 to 10,000
        End Get
    End Property

    ''' <summary>
    ''' Moves the focuser by the specified amount or to the specified position depending on the value of the <see cref="Absolute" /> property.
    ''' </summary>
    ''' <param name="Position">Step distance or absolute position, depending on the value of the <see cref="Absolute" /> property.</param>
    Public Sub Move(Position As Integer) Implements IFocuserV3.Move
        While isBusy = True
            Threading.Thread.Sleep(200)
        End While

        isBusy = True
        TL.LogMessage("Move", Position.ToString())
        Focuser.objSerial.Transmit("G1" + " " + Position.ToString() + "#" + vbCrLf)
        Threading.Thread.Sleep(200)
        isBusy = False
    End Sub

    ''' <summary>
    ''' Current focuser position, in steps.
    ''' </summary>
    Public ReadOnly Property Position() As Integer Implements IFocuserV3.Position
        Get
            While isBusy = True
                Threading.Thread.Sleep(200)
            End While

            isBusy = True
            Focuser.objSerial.Transmit("G4" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            Dim s As String
            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            isBusy = False
            Return CInt(s)
        End Get
    End Property

    ''' <summary>
    ''' Step size (microns) for the focuser.
    ''' </summary>
    Public ReadOnly Property StepSize() As Double Implements IFocuserV3.StepSize
        Get
            TL.LogMessage("StepSize Get", "Not implemented")
            Throw New ASCOM.PropertyNotImplementedException("StepSize", False)
        End Get
    End Property

    ''' <summary>
    ''' The state of temperature compensation mode (if available), else always False.
    ''' </summary>
    Public Property TempComp() As Boolean Implements IFocuserV3.TempComp
        Get
            TL.LogMessage("TempComp Get", False.ToString())
            Return False
        End Get
        Set(value As Boolean)
            TL.LogMessage("TempComp Set", "Not implemented")
            Throw New ASCOM.PropertyNotImplementedException("TempComp", True)
        End Set
    End Property

    ''' <summary>
    ''' True if focuser has temperature compensation available.
    ''' </summary>
    Public ReadOnly Property TempCompAvailable() As Boolean Implements IFocuserV3.TempCompAvailable
        Get
            TL.LogMessage("TempCompAvailable Get", False.ToString())
            Return False ' Temperature compensation is not available in this driver
        End Get
    End Property

    ''' <summary>
    ''' Current ambient temperature in degrees Celsius as measured by the focuser.
    ''' </summary>
    Public ReadOnly Property Temperature() As Double Implements IFocuserV3.Temperature
        Get
            While isBusy = True
                Threading.Thread.Sleep(200)
            End While

            isBusy = True
            Focuser.objSerial.Transmit("G17" + "#" + vbCrLf)
            Threading.Thread.Sleep(200)

            Dim s As String
            s = Focuser.objSerial.ReceiveTerminated("#")
            s = s.Replace("#", "")
            isBusy = False
            Return Double.Parse(s, CultureInfo.InvariantCulture)
        End Get
    End Property

#End Region

#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Focuser"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()>
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()>
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' TODO check that the driver hardware connection exists and is connected to the hardware
            Return connectedState
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Focuser"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            comPort = driverProfile.GetValue(driverID, comPortProfileName, String.Empty, comPortDefault)
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Public Shared Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Focuser"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            If comPort IsNot Nothing Then
                driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString())
            End If
        End Using

    End Sub

#End Region

End Class
