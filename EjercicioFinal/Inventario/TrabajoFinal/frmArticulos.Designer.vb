<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulos))
        Me.ModificarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.txtNomArticulo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.cmbAgrupacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstArticulos = New System.Windows.Forms.ListBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.tsGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tsEliminar = New System.Windows.Forms.ToolStripButton()
        Me.tsModificar = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblDescripcion.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblDescripcion.Location = New System.Drawing.Point(164, 33)
        Me.lblDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(849, 25)
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
        Me.lblCodigo.Location = New System.Drawing.Point(24, 33)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(132, 25)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombe art."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 81)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Precio"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1207, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'txtNomArticulo
        '
        Me.txtNomArticulo.Location = New System.Drawing.Point(144, 34)
        Me.txtNomArticulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNomArticulo.Name = "txtNomArticulo"
        Me.txtNomArticulo.Size = New System.Drawing.Size(307, 22)
        Me.txtNomArticulo.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.cmbAgrupacion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNomArticulo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 66)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(465, 156)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(144, 81)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(172, 22)
        Me.txtPrecio.TabIndex = 6
        '
        'cmbAgrupacion
        '
        Me.cmbAgrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgrupacion.FormattingEnabled = True
        Me.cmbAgrupacion.Location = New System.Drawing.Point(144, 122)
        Me.cmbAgrupacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbAgrupacion.Name = "cmbAgrupacion"
        Me.cmbAgrupacion.Size = New System.Drawing.Size(307, 24)
        Me.cmbAgrupacion.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 122)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Agrupación"
        '
        'lstArticulos
        '
        Me.lstArticulos.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstArticulos.FormattingEnabled = True
        Me.lstArticulos.ItemHeight = 15
        Me.lstArticulos.Location = New System.Drawing.Point(24, 62)
        Me.lstArticulos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstArticulos.Name = "lstArticulos"
        Me.lstArticulos.Size = New System.Drawing.Size(989, 244)
        Me.lstArticulos.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 1)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblDescripcion)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblCodigo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lstArticulos)
        Me.SplitContainer1.Size = New System.Drawing.Size(1207, 629)
        Me.SplitContainer1.SplitterDistance = 249
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLimpiar, Me.tsGuardar, Me.tsEliminar, Me.tsModificar})
        Me.ToolStrip1.Location = New System.Drawing.Point(1171, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(36, 225)
        Me.ToolStrip1.TabIndex = 8
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
        'frmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 629)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmArticulos"
        Me.Text = "frmArticulos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ModificarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LimpiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents txtNomArticulo As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstArticulos As ListBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cmbAgrupacion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsLimpiar As ToolStripButton
    Friend WithEvents tsGuardar As ToolStripButton
    Friend WithEvents tsEliminar As ToolStripButton
    Friend WithEvents tsModificar As ToolStripButton
    Friend WithEvents txtPrecio As TextBox
End Class
