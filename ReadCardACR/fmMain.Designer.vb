<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btInit = New System.Windows.Forms.Button()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.btRead = New System.Windows.Forms.Button()
        Me.btReset = New System.Windows.Forms.Button()
        Me.btStatus = New System.Windows.Forms.Button()
        Me.btGo = New System.Windows.Forms.Button()
        Me.rtxtOut = New System.Windows.Forms.RichTextBox()
        Me.txtCardNo = New System.Windows.Forms.TextBox()
        Me.lblCardNo = New System.Windows.Forms.Label()
        Me.btEmpty = New System.Windows.Forms.Button()
        Me.cbTimer = New System.Windows.Forms.CheckBox()
        Me.tmAuto = New System.Windows.Forms.Timer(Me.components)
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.gbAuto = New System.Windows.Forms.GroupBox()
        Me.rbManual = New System.Windows.Forms.RadioButton()
        Me.rbAuto = New System.Windows.Forms.RadioButton()
        Me.btTest = New System.Windows.Forms.Button()
        Me.lblWithCard = New System.Windows.Forms.Label()
        Me.btNewStatus = New System.Windows.Forms.Button()
        Me.gbCommand = New System.Windows.Forms.GroupBox()
        Me.lblSample = New System.Windows.Forms.Label()
        Me.rbCommPassword = New System.Windows.Forms.RadioButton()
        Me.txtReadWrite = New System.Windows.Forms.TextBox()
        Me.rbCommSN = New System.Windows.Forms.RadioButton()
        Me.rbCommWrite = New System.Windows.Forms.RadioButton()
        Me.rbCommRead = New System.Windows.Forms.RadioButton()
        Me.rbCommCardNo = New System.Windows.Forms.RadioButton()
        Me.gbWrite = New System.Windows.Forms.GroupBox()
        Me.cbUL = New System.Windows.Forms.CheckBox()
        Me.gbAuto.SuspendLayout()
        Me.gbCommand.SuspendLayout()
        Me.gbWrite.SuspendLayout()
        Me.SuspendLayout()
        '
        'btInit
        '
        Me.btInit.Location = New System.Drawing.Point(25, 82)
        Me.btInit.Name = "btInit"
        Me.btInit.Size = New System.Drawing.Size(113, 33)
        Me.btInit.TabIndex = 0
        Me.btInit.Text = "● 啟始 ●"
        Me.btInit.UseVisualStyleBackColor = True
        '
        'btConnect
        '
        Me.btConnect.Location = New System.Drawing.Point(195, 82)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(113, 33)
        Me.btConnect.TabIndex = 1
        Me.btConnect.Text = "連接"
        Me.btConnect.UseVisualStyleBackColor = True
        '
        'btRead
        '
        Me.btRead.Location = New System.Drawing.Point(367, 82)
        Me.btRead.Name = "btRead"
        Me.btRead.Size = New System.Drawing.Size(113, 33)
        Me.btRead.TabIndex = 2
        Me.btRead.Text = "讀取 (指令)"
        Me.btRead.UseVisualStyleBackColor = True
        '
        'btReset
        '
        Me.btReset.Location = New System.Drawing.Point(25, 21)
        Me.btReset.Name = "btReset"
        Me.btReset.Size = New System.Drawing.Size(113, 33)
        Me.btReset.TabIndex = 3
        Me.btReset.Text = "重置"
        Me.btReset.UseVisualStyleBackColor = True
        '
        'btStatus
        '
        Me.btStatus.Location = New System.Drawing.Point(25, 143)
        Me.btStatus.Name = "btStatus"
        Me.btStatus.Size = New System.Drawing.Size(113, 32)
        Me.btStatus.TabIndex = 4
        Me.btStatus.Text = "詳細狀態"
        Me.btStatus.UseVisualStyleBackColor = True
        '
        'btGo
        '
        Me.btGo.Location = New System.Drawing.Point(367, 154)
        Me.btGo.Name = "btGo"
        Me.btGo.Size = New System.Drawing.Size(113, 47)
        Me.btGo.TabIndex = 5
        Me.btGo.Text = "一鍵  讀取 (指令)"
        Me.btGo.UseVisualStyleBackColor = True
        '
        'rtxtOut
        '
        Me.rtxtOut.Location = New System.Drawing.Point(508, 21)
        Me.rtxtOut.Name = "rtxtOut"
        Me.rtxtOut.ReadOnly = True
        Me.rtxtOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtxtOut.Size = New System.Drawing.Size(286, 301)
        Me.rtxtOut.TabIndex = 6
        Me.rtxtOut.Text = ""
        '
        'txtCardNo
        '
        Me.txtCardNo.Font = New System.Drawing.Font("新細明體", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtCardNo.Location = New System.Drawing.Point(84, 292)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.ReadOnly = True
        Me.txtCardNo.Size = New System.Drawing.Size(396, 28)
        Me.txtCardNo.TabIndex = 7
        '
        'lblCardNo
        '
        Me.lblCardNo.AutoSize = True
        Me.lblCardNo.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblCardNo.Location = New System.Drawing.Point(21, 297)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(57, 21)
        Me.lblCardNo.TabIndex = 8
        Me.lblCardNo.Text = "卡號:"
        Me.lblCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btEmpty
        '
        Me.btEmpty.Location = New System.Drawing.Point(367, 21)
        Me.btEmpty.Name = "btEmpty"
        Me.btEmpty.Size = New System.Drawing.Size(113, 33)
        Me.btEmpty.TabIndex = 9
        Me.btEmpty.Text = "清空 →"
        Me.btEmpty.UseVisualStyleBackColor = True
        '
        'cbTimer
        '
        Me.cbTimer.AutoSize = True
        Me.cbTimer.Location = New System.Drawing.Point(211, 30)
        Me.cbTimer.Name = "cbTimer"
        Me.cbTimer.Size = New System.Drawing.Size(84, 16)
        Me.cbTimer.TabIndex = 10
        Me.cbTimer.Text = "開啟時間器"
        Me.cbTimer.UseVisualStyleBackColor = True
        '
        'tmAuto
        '
        Me.tmAuto.Interval = 500
        '
        'txtMsg
        '
        Me.txtMsg.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMsg.Location = New System.Drawing.Point(84, 240)
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(396, 30)
        Me.txtMsg.TabIndex = 11
        '
        'gbAuto
        '
        Me.gbAuto.Controls.Add(Me.rbManual)
        Me.gbAuto.Controls.Add(Me.rbAuto)
        Me.gbAuto.Location = New System.Drawing.Point(197, 138)
        Me.gbAuto.Name = "gbAuto"
        Me.gbAuto.Size = New System.Drawing.Size(111, 78)
        Me.gbAuto.TabIndex = 12
        Me.gbAuto.TabStop = False
        '
        'rbManual
        '
        Me.rbManual.AutoSize = True
        Me.rbManual.Checked = True
        Me.rbManual.Location = New System.Drawing.Point(14, 47)
        Me.rbManual.Name = "rbManual"
        Me.rbManual.Size = New System.Drawing.Size(83, 16)
        Me.rbManual.TabIndex = 1
        Me.rbManual.TabStop = True
        Me.rbManual.Text = "手動取卡號"
        Me.rbManual.UseVisualStyleBackColor = True
        '
        'rbAuto
        '
        Me.rbAuto.AutoSize = True
        Me.rbAuto.Location = New System.Drawing.Point(14, 21)
        Me.rbAuto.Name = "rbAuto"
        Me.rbAuto.Size = New System.Drawing.Size(83, 16)
        Me.rbAuto.TabIndex = 0
        Me.rbAuto.Text = "自動取卡號"
        Me.rbAuto.UseVisualStyleBackColor = True
        '
        'btTest
        '
        Me.btTest.Location = New System.Drawing.Point(25, 238)
        Me.btTest.Name = "btTest"
        Me.btTest.Size = New System.Drawing.Size(50, 35)
        Me.btTest.TabIndex = 13
        Me.btTest.Text = "狀態→"
        Me.btTest.UseVisualStyleBackColor = True
        '
        'lblWithCard
        '
        Me.lblWithCard.AutoSize = True
        Me.lblWithCard.BackColor = System.Drawing.Color.Yellow
        Me.lblWithCard.Location = New System.Drawing.Point(256, 51)
        Me.lblWithCard.Name = "lblWithCard"
        Me.lblWithCard.Size = New System.Drawing.Size(29, 12)
        Me.lblWithCard.TabIndex = 14
        Me.lblWithCard.Text = "有卡"
        Me.lblWithCard.Visible = False
        '
        'btNewStatus
        '
        Me.btNewStatus.Location = New System.Drawing.Point(25, 183)
        Me.btNewStatus.Name = "btNewStatus"
        Me.btNewStatus.Size = New System.Drawing.Size(113, 33)
        Me.btNewStatus.TabIndex = 15
        Me.btNewStatus.Text = "新狀態"
        Me.btNewStatus.UseVisualStyleBackColor = True
        '
        'gbCommand
        '
        Me.gbCommand.Controls.Add(Me.lblSample)
        Me.gbCommand.Controls.Add(Me.rbCommPassword)
        Me.gbCommand.Controls.Add(Me.txtReadWrite)
        Me.gbCommand.Controls.Add(Me.rbCommSN)
        Me.gbCommand.Controls.Add(Me.rbCommWrite)
        Me.gbCommand.Controls.Add(Me.rbCommRead)
        Me.gbCommand.Controls.Add(Me.rbCommCardNo)
        Me.gbCommand.Location = New System.Drawing.Point(23, 340)
        Me.gbCommand.Name = "gbCommand"
        Me.gbCommand.Size = New System.Drawing.Size(770, 55)
        Me.gbCommand.TabIndex = 16
        Me.gbCommand.TabStop = False
        Me.gbCommand.Text = "指令"
        '
        'lblSample
        '
        Me.lblSample.AutoSize = True
        Me.lblSample.Location = New System.Drawing.Point(538, 13)
        Me.lblSample.Name = "lblSample"
        Me.lblSample.Size = New System.Drawing.Size(50, 36)
        Me.lblSample.TabIndex = 6
        Me.lblSample.Text = "0 1 2 3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4 5 6 7" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8 9 10 11"
        '
        'rbCommPassword
        '
        Me.rbCommPassword.AutoSize = True
        Me.rbCommPassword.Location = New System.Drawing.Point(161, 21)
        Me.rbCommPassword.Name = "rbCommPassword"
        Me.rbCommPassword.Size = New System.Drawing.Size(71, 16)
        Me.rbCommPassword.TabIndex = 5
        Me.rbCommPassword.Text = "核實密碼"
        Me.rbCommPassword.UseVisualStyleBackColor = True
        '
        'txtReadWrite
        '
        Me.txtReadWrite.Location = New System.Drawing.Point(485, 18)
        Me.txtReadWrite.MaxLength = 3
        Me.txtReadWrite.Name = "txtReadWrite"
        Me.txtReadWrite.Size = New System.Drawing.Size(40, 22)
        Me.txtReadWrite.TabIndex = 4
        Me.txtReadWrite.Text = "1"
        Me.txtReadWrite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbCommSN
        '
        Me.rbCommSN.AutoSize = True
        Me.rbCommSN.Location = New System.Drawing.Point(658, 21)
        Me.rbCommSN.Name = "rbCommSN"
        Me.rbCommSN.Size = New System.Drawing.Size(83, 16)
        Me.rbCommSN.TabIndex = 3
        Me.rbCommSN.Text = "讀卡機版本"
        Me.rbCommSN.UseVisualStyleBackColor = True
        '
        'rbCommWrite
        '
        Me.rbCommWrite.AutoSize = True
        Me.rbCommWrite.Location = New System.Drawing.Point(386, 21)
        Me.rbCommWrite.Name = "rbCommWrite"
        Me.rbCommWrite.Size = New System.Drawing.Size(71, 16)
        Me.rbCommWrite.TabIndex = 2
        Me.rbCommWrite.Text = "寫入區域"
        Me.rbCommWrite.UseVisualStyleBackColor = True
        '
        'rbCommRead
        '
        Me.rbCommRead.AutoSize = True
        Me.rbCommRead.Location = New System.Drawing.Point(293, 21)
        Me.rbCommRead.Name = "rbCommRead"
        Me.rbCommRead.Size = New System.Drawing.Size(71, 16)
        Me.rbCommRead.TabIndex = 1
        Me.rbCommRead.Text = "讀取區域"
        Me.rbCommRead.UseVisualStyleBackColor = True
        '
        'rbCommCardNo
        '
        Me.rbCommCardNo.AutoSize = True
        Me.rbCommCardNo.Checked = True
        Me.rbCommCardNo.Location = New System.Drawing.Point(61, 21)
        Me.rbCommCardNo.Name = "rbCommCardNo"
        Me.rbCommCardNo.Size = New System.Drawing.Size(47, 16)
        Me.rbCommCardNo.TabIndex = 0
        Me.rbCommCardNo.TabStop = True
        Me.rbCommCardNo.Text = "卡號"
        Me.rbCommCardNo.UseVisualStyleBackColor = True
        '
        'gbWrite
        '
        Me.gbWrite.Controls.Add(Me.cbUL)
        Me.gbWrite.Location = New System.Drawing.Point(25, 405)
        Me.gbWrite.Name = "gbWrite"
        Me.gbWrite.Size = New System.Drawing.Size(767, 62)
        Me.gbWrite.TabIndex = 17
        Me.gbWrite.TabStop = False
        Me.gbWrite.Text = "寫入區域內容"
        '
        'cbUL
        '
        Me.cbUL.AutoSize = True
        Me.cbUL.Location = New System.Drawing.Point(722, 25)
        Me.cbUL.Name = "cbUL"
        Me.cbUL.Size = New System.Drawing.Size(39, 16)
        Me.cbUL.TabIndex = 0
        Me.cbUL.Text = "UL"
        Me.cbUL.UseVisualStyleBackColor = True
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 484)
        Me.Controls.Add(Me.gbWrite)
        Me.Controls.Add(Me.gbCommand)
        Me.Controls.Add(Me.btNewStatus)
        Me.Controls.Add(Me.lblWithCard)
        Me.Controls.Add(Me.btTest)
        Me.Controls.Add(Me.gbAuto)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.cbTimer)
        Me.Controls.Add(Me.btEmpty)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.txtCardNo)
        Me.Controls.Add(Me.rtxtOut)
        Me.Controls.Add(Me.btGo)
        Me.Controls.Add(Me.btStatus)
        Me.Controls.Add(Me.btReset)
        Me.Controls.Add(Me.btRead)
        Me.Controls.Add(Me.btConnect)
        Me.Controls.Add(Me.btInit)
        Me.Name = "fmMain"
        Me.Text = "讀卡器"
        Me.gbAuto.ResumeLayout(False)
        Me.gbAuto.PerformLayout()
        Me.gbCommand.ResumeLayout(False)
        Me.gbCommand.PerformLayout()
        Me.gbWrite.ResumeLayout(False)
        Me.gbWrite.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btInit As Button
    Friend WithEvents btConnect As Button
    Friend WithEvents btRead As Button
    Friend WithEvents btReset As Button
    Friend WithEvents btStatus As Button
    Friend WithEvents btGo As Button
    Friend WithEvents rtxtOut As RichTextBox
    Friend WithEvents txtCardNo As TextBox
    Friend WithEvents lblCardNo As Label
    Friend WithEvents btEmpty As Button
    Friend WithEvents cbTimer As CheckBox
    Friend WithEvents tmAuto As Timer
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents gbAuto As GroupBox
    Friend WithEvents rbManual As RadioButton
    Friend WithEvents rbAuto As RadioButton
    Friend WithEvents btTest As Button
    Friend WithEvents lblWithCard As Label
    Friend WithEvents btNewStatus As Button
    Friend WithEvents gbCommand As GroupBox
    Friend WithEvents rbCommCardNo As RadioButton
    Friend WithEvents txtReadWrite As TextBox
    Friend WithEvents rbCommSN As RadioButton
    Friend WithEvents rbCommWrite As RadioButton
    Friend WithEvents rbCommRead As RadioButton
    Friend WithEvents rbCommPassword As RadioButton
    Friend WithEvents gbWrite As GroupBox
    Friend WithEvents cbUL As CheckBox
    Friend WithEvents lblSample As Label
End Class
