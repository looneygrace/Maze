Imports Microsoft.VisualBasic
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Animation

Public Class Class1

    Private Enum Tristate
        Neg = -1
        None = 0
        Pos = 1
    End Enum

    Private newpcam As New Media3D.PerspectiveCamera()
    Private Pos1 As New Media3D.Point3D(-40, 40, 40)
    Private Dir1 As New Media3D.Point3D(40, -40, -40)
    Private timer As System.Windows.Threading.DispatcherTimer
    Private X As Double = -40
    Private Y As Double = 40
    Private Z As Double = 40
    Private XMove As Tristate
    Private YMove As Tristate
    Private ZMove As Tristate

    Private Sub SetX(ByVal Val As Double)
        Pos1.X = Val
        Dir1.X = -Val
    End Sub

    Private Sub SetY(ByVal Val As Double)
        Pos1.Y = Val
        Dir1.Y = -Val
    End Sub

    Private Sub SetZ(ByVal Val As Double)
        Pos1.Z = Val
        Dir1.Z = -Val
    End Sub

    Private Sub Window1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Me.PreviewKeyDown
        Select Case e.Key
            Case Key.Up
                YMove = Tristate.Pos
            Case Key.Down
                YMove = Tristate.Neg
            Case Key.Left
                XMove = Tristate.Neg
            Case Key.Right
                XMove = Tristate.Pos
            Case Key.PageUp
                ZMove = Tristate.Neg
            Case Key.PageDown
                ZMove = Tristate.Pos
        End Select
    End Sub

    Private Sub Window1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles Me.PreviewKeyUp
        Select Case e.Key
            Case Key.Up, Key.Down
                YMove = Tristate.None
            Case Key.Left, Key.Right
                XMove = Tristate.None
            Case Key.PageUp, Key.PageDown
                ZMove = Tristate.None
        End Select
    End Sub

    Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If XMove <> Tristate.None Then
            X += XMove
            SetX(X)
        End If
        If YMove <> Tristate.None Then
            Y += YMove
            SetY(Y)
        End If
        If ZMove <> Tristate.None Then
            Z += ZMove
            SetZ(Z)
        End If
        newpcam.Position = Pos1
        newpcam.LookDirection = Dir1
    End Sub

    Private Sub Window1_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Viewport3D1.Camera = newpcam
        SetX(X)
        SetY(Y)
        SetZ(Z)
        newpcam.Position = Pos1
        newpcam.LookDirection = Dir1

        Dim Cube_ani As New DoubleAnimation(0, 359, TimeSpan.FromSeconds(2))

        Dim Cube_rot As New AxisAngleRotation3D()
        Cube_rot.Axis = New Vector3D(0, 1, 0)

        Viewport3D1.Children.Item(0).Transform = New RotateTransform3D(Cube_rot, 5, 5, 5)
        Viewport3D1.Children.Item(1).Transform = New RotateTransform3D(Cube_rot, 5, -5, -5)
        Viewport3D1.Children.Item(2).Transform = New RotateTransform3D(Cube_rot, -5, -5, 5)
        Viewport3D1.Children.Item(3).Transform = New RotateTransform3D(Cube_rot, -5, 5, -5)

        Cube_rot.BeginAnimation(AxisAngleRotation3D.AngleProperty, Cube_ani)

        timer = New System.Windows.Threading.DispatcherTimer()
        timer.Interval = TimeSpan.FromMilliseconds(16)
        AddHandler timer.Tick, AddressOf timer_Tick
        Me.timer.Start()
    End Sub
End Class
