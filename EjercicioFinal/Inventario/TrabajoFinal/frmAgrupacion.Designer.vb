﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgrupacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgrupacion))
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblAgrupacion = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.lstAgrupacion = New System.Windows.Forms.ListBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.tsGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsModificar = New System.Windows.Forms.ToolStripButton()
        Me.txtNombreAgrupacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusCon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusBase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ModificarToolStripMenuItem.Text = "&Modificar"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.GuardarToolStripMenuItem.Text = "&Guardar"
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.LimpiarToolStripMenuItem.Text = "&Limpiar"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.ModificarToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.EliminarToolStripMenuItem.Text = "&Eliminar"
        '
        'lblAgrupacion
        '
        Me.lblAgrupacion.BackColor = System.Drawing.Color.SteelBlue
        Me.lblAgrupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgrupacion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblAgrupacion.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblAgrupacion.Location = New System.Drawing.Point(37, 17)
        Me.lblAgrupacion.Name = "lblAgrupacion"
        Me.lblAgrupacion.Size = New System.Drawing.Size(482, 20)
        Me.lblAgrupacion.TabIndex = 2
        Me.lblAgrupacion.Text = "Descripción"
        Me.lblAgrupacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblId
        '
        Me.lblId.BackColor = System.Drawing.Color.SteelBlue
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblId.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblId.Location = New System.Drawing.Point(11, 17)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(20, 20)
        Me.lblId.TabIndex = 1
        Me.lblId.Text = "Id"
        Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'lstAgrupacion
        '
        Me.lstAgrupacion.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAgrupacion.FormattingEnabled = True
        Me.lstAgrupacion.ItemHeight = 15
        Me.lstAgrupacion.Location = New System.Drawing.Point(11, 40)
        Me.lstAgrupacion.Name = "lstAgrupacion"
        Me.lstAgrupacion.Size = New System.Drawing.Size(508, 184)
        Me.lstAgrupacion.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNombreAgrupacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.BackgroundImage = Global.TrabajoFinal.My.Resources.Resources.Fondo2
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblAgrupacion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblId)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstAgrupacion)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainer1.SplitterDistance = 181
        Me.SplitContainer1.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLimpiar, Me.tsGuardar, Me.tsEliminar, Me.tsModificar})
        Me.ToolStrip1.Location = New System.Drawing.Point(764, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(36, 157)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsLimpiar
        '
        Me.tsLimpiar.AutoSize = False
        Me.tsLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLimpiar.Image = CType(resources.GetObject("tsLimpiar.Image"), System.Drawing.Image)
        Me.tsLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLimpiar.Margin = New System.Windows.Forms.Padding(0, 1, 0, 3)
        Me.tsLimpiar.Name = "tsLimpiar"
        Me.tsLimpiar.Size = New System.Drawing.Size(35, 35)
        Me.tsLimpiar.Text = "Limpiar"
        '
        'tsGuardar
        '
        Me.tsGuardar.AutoSize = False
        Me.tsGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsGuardar.Image = CType(resources.GetObject("tsGuardar.Image"), System.Drawing.Image)
        Me.tsGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGuardar.Margin = New System.Windows.Forms.Padding(0, 1, 0, 3)
        Me.tsGuardar.Name = "tsGuardar"
        Me.tsGuardar.Size = New System.Drawing.Size(35, 35)
        Me.tsGuardar.Text = "Guardar"
        '
        'tsEliminar
        '
        Me.tsEliminar.AutoSize = False
        Me.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEliminar.Image = CType(resources.GetObject("tsEliminar.Image"), System.Drawing.Image)
        Me.tsEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEliminar.Margin = New System.Windows.Forms.Padding(0, 1, 0, 3)
        Me.tsEliminar.Name = "tsEliminar"
        Me.tsEliminar.Size = New System.Drawing.Size(35, 35)
        Me.tsEliminar.Text = "Eliminar"
        '
        'tsModificar
        '
        Me.tsModificar.AutoSize = False
        Me.tsModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsModificar.Image = CType(resources.GetObject("tsModificar.Image"), System.Drawing.Image)
        Me.tsModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsModificar.Margin = New System.Windows.Forms.Padding(0, 1, 0, 3)
        Me.tsModificar.Name = "tsModificar"
        Me.tsModificar.Size = New System.Drawing.Size(35, 35)
        Me.tsModificar.Text = "Modificar"
        '
        'txtNombreAgrupacion
        '
        Me.txtNombreAgrupacion.Location = New System.Drawing.Point(108, 78)
        Me.txtNombreAgrupacion.Name = "txtNombreAgrupacion"
        Me.txtNombreAgrupacion.Size = New System.Drawing.Size(231, 20)
        Me.txtNombreAgrupacion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Agrupación"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusCon, Me.ToolStripStatusLabel2, Me.statusBase})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 243)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel1.Text = "Conección:"
        '
        'statusCon
        '
        Me.statusCon.Name = "statusCon"
        Me.statusCon.Size = New System.Drawing.Size(43, 17)
        Me.statusCon.Text = "xxxxxx"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatusLabel2.Text = "Base"
        '
        'statusBase
        '
        Me.statusBase.Name = "statusBase"
        Me.statusBase.Size = New System.Drawing.Size(55, 17)
        Me.statusBase.Text = "xxxxxxxx"
        '
        'frmAgrupacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAgrupacion"
        Me.Text = "frmAgrupacion"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimpiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblAgrupacion As Label
    Friend WithEvents lblId As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents lstAgrupacion As ListBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents txtNombreAgrupacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsLimpiar As ToolStripButton
    Friend WithEvents tsGuardar As ToolStripButton
    Friend WithEvents tsEliminar As ToolStripButton
    Friend WithEvents tsModificar As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents statusCon As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents statusBase As ToolStripStatusLabel
End Class
