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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArticulosABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgrupacionABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoMovimientoABMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstBalance = New System.Windows.Forms.ListBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArtículosToolStripMenuItem, Me.MovimientosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
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
        'MovimientosToolStripMenuItem
        '
        Me.MovimientosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovimientosABMToolStripMenuItem, Me.TipoMovimientoABMToolStripMenuItem})
        Me.MovimientosToolStripMenuItem.Name = "MovimientosToolStripMenuItem"
        Me.MovimientosToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.MovimientosToolStripMenuItem.Text = "&Movimientos"
        '
        'ArticulosABMToolStripMenuItem
        '
        Me.ArticulosABMToolStripMenuItem.Name = "ArticulosABMToolStripMenuItem"
        Me.ArticulosABMToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ArticulosABMToolStripMenuItem.Text = "&Articulos ABM"
        '
        'AgrupacionABMToolStripMenuItem
        '
        Me.AgrupacionABMToolStripMenuItem.Name = "AgrupacionABMToolStripMenuItem"
        Me.AgrupacionABMToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AgrupacionABMToolStripMenuItem.Text = "A&grupacion ABM"
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
        Me.lstBalance.Location = New System.Drawing.Point(87, 100)
        Me.lstBalance.Name = "lstBalance"
        Me.lstBalance.Size = New System.Drawing.Size(601, 242)
        Me.lstBalance.TabIndex = 1
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lstBalance)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMenuPrincipal"
        Me.Text = "Menú Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
End Class
