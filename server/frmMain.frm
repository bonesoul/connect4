VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmMain 
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txt_comm 
      Height          =   2895
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   0
      Top             =   120
      Width           =   4455
   End
   Begin MSWinsockLib.Winsock sock_listener 
      Left            =   0
      Top             =   2880
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin MSWinsockLib.Winsock sock_player2 
      Left            =   840
      Top             =   2760
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin MSWinsockLib.Winsock sock_player1 
      Left            =   360
      Top             =   2880
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim player1 As Boolean
Dim player2 As Boolean


Private Sub Form_Load()
sock_listener.LocalPort = 4444

player1 = False
player2 = False

sock_listener.Listen

End Sub

Private Sub Form_Unload(Cancel As Integer)
sock_listener.Close
sock_player1.Close
sock_player2.Close

End Sub

Public Sub start_game()
sock_player1.SendData ("White" + vbCrLf)
txt_comm.Text = txt_comm.Text + "[S>>P1]white" + vbCrLf
sock_player2.SendData ("Black" + vbCrLf)
txt_comm.Text = txt_comm.Text + "[S>>P2]black" + vbCrLf
End Sub


Private Sub sock_listener_ConnectionRequest(ByVal requestID As Long)
If player1 = False Then
    sock_player1.Accept (requestID)
    txt_comm.Text = txt_comm.Text + "Player1 connected" + vbCrLf
    player1 = True
ElseIf player2 = False Then
    sock_player2.Accept (requestID)
    txt_comm.Text = txt_comm.Text + "Player2 connected" + vbCrLf
    player2 = True
    If player1 = True Then start_game
Else
    sock_listener.Close
End If
End Sub


Private Sub sock_player1_Close()
    player1 = False
    txt_comm.Text = txt_comm.Text + "Player1 disconnected" + vbCrLf
End Sub

Private Sub sock_player1_DataArrival(ByVal bytesTotal As Long)
    sock_player1.GetData strdata, vbString
    txt_comm.Text = txt_comm.Text + "[S<<P1]" + strdata
    sock_player2.SendData strdata
End Sub

Private Sub sock_player2_Close()
    player2 = False
    txt_comm.Text = txt_comm.Text + "Player2 disconnected" + vbCrLf
End Sub

Private Sub sock_player2_DataArrival(ByVal bytesTotal As Long)
    sock_player2.GetData strdata, vbString
    txt_comm.Text = txt_comm.Text + "[S<<P2]" + strdata
    sock_player1.SendData strdata
End Sub
