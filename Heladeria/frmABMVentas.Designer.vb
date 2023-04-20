<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMVentas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNroComprobanteVta = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.lstVentas = New System.Windows.Forms.ListBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N°"
        '
        'lblNroComprobanteVta
        '
        Me.lblNroComprobanteVta.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblNroComprobanteVta.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroComprobanteVta.Location = New System.Drawing.Point(368, 20)
        Me.lblNroComprobanteVta.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNroComprobanteVta.Name = "lblNroComprobanteVta"
        Me.lblNroComprobanteVta.Size = New System.Drawing.Size(75, 19)
        Me.lblNroComprobanteVta.TabIndex = 1
        Me.lblNroComprobanteVta.Text = "1"
        Me.lblNroComprobanteVta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Producto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(298, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Precio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(397, 46)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cantidad"
        '
        'cmbProductos
        '
        Me.cmbProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProductos.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(9, 61)
        Me.cmbProductos.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(236, 21)
        Me.cmbProductos.TabIndex = 5
        Me.cmbProductos.Text = "Seleccione un Item"
        Me.cmbProductos.UseWaitCursor = True
        '
        'lstVentas
        '
        Me.lstVentas.Font = New System.Drawing.Font("Consolas", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstVentas.FormattingEnabled = True
        Me.lstVentas.ItemHeight = 12
        Me.lstVentas.Location = New System.Drawing.Point(16, 107)
        Me.lstVentas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lstVentas.Name = "lstVentas"
        Me.lstVentas.Size = New System.Drawing.Size(428, 196)
        Me.lstVentas.TabIndex = 6
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(36, 325)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(104, 32)
        Me.btnAgregar.TabIndex = 7
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(301, 325)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(104, 32)
        Me.btnLimpiar.TabIndex = 8
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblPrecio.Location = New System.Drawing.Point(275, 61)
        Me.lblPrecio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(73, 20)
        Me.lblPrecio.TabIndex = 9
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(378, 63)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtCantidad.TabIndex = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'frmABMVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lstVentas)
        Me.Controls.Add(Me.cmbProductos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNroComprobanteVta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmABMVentas"
        Me.RightToLeftLayout = True
        Me.Text = "Ventas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblNroComprobanteVta As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbProductos As ComboBox
    Friend WithEvents lstVentas As ListBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblPrecio As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
End Class
