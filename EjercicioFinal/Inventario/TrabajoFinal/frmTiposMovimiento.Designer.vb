<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTiposMovimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTiposMovimiento))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNomTipoMov = New System.Windows.Forms.TextBox()
        Me.txtCodTipoMov = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lstTipoMovimiento = New System.Windows.Forms.ListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.tsGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsModificar = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusCon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusBase = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblDescripcion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblCodigo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstTipoMovimiento)
        Me.SplitContainer1.Size = New System.Drawing.Size(905, 511)
        Me.SplitContainer1.SplitterDistance = 204
        Me.SplitContainer1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNomTipoMov)
        Me.GroupBox1.Controls.Add(Me.txtCodTipoMov)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 127)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtNomTipoMov
        '
        Me.txtNomTipoMov.Location = New System.Drawing.Point(109, 85)
        Me.txtNomTipoMov.Name = "txtNomTipoMov"
        Me.txtNomTipoMov.Size = New System.Drawing.Size(231, 20)
        Me.txtNomTipoMov.TabIndex = 3
        '
        'txtCodTipoMov
        '
        Me.txtCodTipoMov.Location = New System.Drawing.Point(109, 19)
        Me.txtCodTipoMov.Name = "txtCodTipoMov"
        Me.txtCodTipoMov.Size = New System.Drawing.Size(92, 20)
        Me.txtCodTipoMov.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CódTipoMov"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDescripcion.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblDescripcion.Location = New System.Drawing.Point(123, 27)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(403, 20)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCodigo
        '
        Me.lblCodigo.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblCodigo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblCodigo.Location = New System.Drawing.Point(18, 27)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(99, 20)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lstTipoMovimiento
        '
        Me.lstTipoMovimiento.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTipoMovimiento.FormattingEnabled = True
        Me.lstTipoMovimiento.ItemHeight = 15
        Me.lstTipoMovimiento.Location = New System.Drawing.Point(18, 50)
        Me.lstTipoMovimiento.Name = "lstTipoMovimiento"
        Me.lstTipoMovimiento.Size = New System.Drawing.Size(508, 214)
        Me.lstTipoMovimiento.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLimpiar, Me.tsGuardar, Me.tsEliminar, Me.tsModificar})
        Me.ToolStrip1.Location = New System.Drawing.Point(881, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(24, 180)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsLimpiar
        '
        Me.tsLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsLimpiar.Image = CType(resources.GetObject("tsLimpiar.Image"), System.Drawing.Image)
        Me.tsLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLimpiar.Name = "tsLimpiar"
        Me.tsLimpiar.Size = New System.Drawing.Size(21, 20)
        Me.tsLimpiar.Text = "Limpiar"
        '
        'tsGuardar
        '
        Me.tsGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsGuardar.Image = CType(resources.GetObject("tsGuardar.Image"), System.Drawing.Image)
        Me.tsGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsGuardar.Name = "tsGuardar"
        Me.tsGuardar.Size = New System.Drawing.Size(21, 20)
        Me.tsGuardar.Text = "Guardar"
        '
        'tsEliminar
        '
        Me.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEliminar.Image = CType(resources.GetObject("tsEliminar.Image"), System.Drawing.Image)
        Me.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEliminar.Name = "tsEliminar"
        Me.tsEliminar.Size = New System.Drawing.Size(29, 20)
        Me.tsEliminar.Text = "Eliminar"
        '
        'tsModificar
        '
        Me.tsModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsModificar.Image = CType(resources.GetObject("tsModificar.Image"), System.Drawing.Image)
        Me.tsModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsModificar.Name = "tsModificar"
        Me.tsModificar.Size = New System.Drawing.Size(21, 20)
        Me.tsModificar.Text = "Modificar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(905, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.EliminarToolStripMenuItem, Me.ModificarToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'LimpiarToolStripMenuItem
        '
        Me.LimpiarToolStripMenuItem.Name = "LimpiarToolStripMenuItem"
        Me.LimpiarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LimpiarToolStripMenuItem.Text = "&Limpiar"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GuardarToolStripMenuItem.Text = "&Guardar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarToolStripMenuItem.Text = "&Eliminar"
        '
        'ModificarToolStripMenuItem
        '
        Me.ModificarToolStripMenuItem.Name = "ModificarToolStripMenuItem"
        Me.ModificarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ModificarToolStripMenuItem.Text = "&Modificar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusCon, Me.ToolStripStatusLabel2, Me.statusBase})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 281)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(905, 22)
        Me.StatusStrip1.TabIndex = 3
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
        'frmTiposMovimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 511)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTiposMovimiento"
        Me.Text = "frmTiposMovimiento"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNomTipoMov As TextBox
    Friend WithEvents txtCodTipoMov As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents lstTipoMovimiento As ListBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsLimpiar As ToolStripButton
    Friend WithEvents tsGuardar As ToolStripButton
    Friend WithEvents tsEliminar As ToolStripButton
    Friend WithEvents tsModificar As ToolStripButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimpiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents statusCon As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents statusBase As ToolStripStatusLabel
End Class
