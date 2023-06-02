<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArticulosABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgrupacionABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoMovimientoABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstBalance = New System.Windows.Forms.ListBox()
        Me.statusCon = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusBase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblAgrupacion = New System.Windows.Forms.Label()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.lblImporteTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArtículosToolStripMenuItem, Me.MovimientosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArtículosToolStripMenuItem
        '
        Me.ArtículosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArticulosABMToolStripMenuItem, Me.AgrupacionABMToolStripMenuItem})
        Me.ArtículosToolStripMenuItem.Name = "ArtículosToolStripMenuItem"
        Me.ArtículosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ArtículosToolStripMenuItem.Text = "&Artículos"
        '
        'ArticulosABMToolStripMenuItem
        '
        Me.ArticulosABMToolStripMenuItem.Name = "ArticulosABMToolStripMenuItem"
        Me.ArticulosABMToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ArticulosABMToolStripMenuItem.Text = "&Articulos ABM"
        '
        'AgrupacionABMToolStripMenuItem
        '
        Me.AgrupacionABMToolStripMenuItem.Name = "AgrupacionABMToolStripMenuItem"
        Me.AgrupacionABMToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AgrupacionABMToolStripMenuItem.Text = "A&grupacion ABM"
        '
        'MovimientosToolStripMenuItem
        '
        Me.MovimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovimientosABMToolStripMenuItem, Me.TipoMovimientoABMToolStripMenuItem})
        Me.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        Me.MovimientosToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.MovimientosToolStripMenuItem.Text = "&Movimientos"
        '
        'MovimientosABMToolStripMenuItem
        '
        Me.MovimientosABMToolStripMenuItem.Name = "MovimientosABMToolStripMenuItem"
        Me.MovimientosABMToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.MovimientosABMToolStripMenuItem.Text = "&Movimientos ABM"
        '
        'TipoMovimientoABMToolStripMenuItem
        '
        Me.TipoMovimientoABMToolStripMenuItem.Name = "TipoMovimientoABMToolStripMenuItem"
        Me.TipoMovimientoABMToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.TipoMovimientoABMToolStripMenuItem.Text = "&Tipo Movimiento ABM"
        '
        'lstBalance
        '
        Me.lstBalance.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBalance.FormattingEnabled = True
        Me.lstBalance.ItemHeight = 14
        Me.lstBalance.Location = New System.Drawing.Point(41, 80)
        Me.lstBalance.Name = "lstBalance"
        Me.lstBalance.Size = New System.Drawing.Size(543, 172)
        Me.lstBalance.TabIndex = 1
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusCon, Me.ToolStripStatusLabel2, Me.statusBase})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel1.Text = "Conección:"
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.SteelBlue
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblCantidad.Location = New System.Drawing.Point(316, 62)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(136, 16)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAgrupacion
        '
        Me.lblAgrupacion.BackColor = System.Drawing.Color.SteelBlue
        Me.lblAgrupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgrupacion.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblAgrupacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAgrupacion.Location = New System.Drawing.Point(41, 62)
        Me.lblAgrupacion.Name = "lblAgrupacion"
        Me.lblAgrupacion.Size = New System.Drawing.Size(269, 16)
        Me.lblAgrupacion.TabIndex = 5
        Me.lblAgrupacion.Text = "Agrupacion"
        Me.lblAgrupacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResultado
        '
        Me.lblResultado.BackColor = System.Drawing.Color.SteelBlue
        Me.lblResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultado.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblResultado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblResultado.Location = New System.Drawing.Point(458, 62)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(126, 16)
        Me.lblResultado.TabIndex = 7
        Me.lblResultado.Text = "Resultado"
        Me.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteTotal
        '
        Me.lblImporteTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblImporteTotal.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotal.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblImporteTotal.Location = New System.Drawing.Point(5, 56)
        Me.lblImporteTotal.Name = "lblImporteTotal"
        Me.lblImporteTotal.Size = New System.Drawing.Size(178, 16)
        Me.lblImporteTotal.TabIndex = 8
        Me.lblImporteTotal.Text = "xxxx"
        Me.lblImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Importe Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.TrabajoFinal.My.Resources.Resources.pizarra_vacia
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblImporteTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(603, 328)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(188, 92)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TrabajoFinal.My.Resources.Resources.Fondo4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblResultado)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblAgrupacion)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lstBalance)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArticulosABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgrupacionABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TipoMovimientoABMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lstBalance As ListBox
    Friend WithEvents statusCon As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents statusBase As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblCantidad As Label
    Friend WithEvents lblAgrupacion As Label
    Friend WithEvents lblResultado As Label
    Friend WithEvents lblImporteTotal As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
