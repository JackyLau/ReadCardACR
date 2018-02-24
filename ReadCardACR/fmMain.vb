Public Class fmMain

    Dim nRetCode, nProtocol, hContext, hCard, nReaderCount As Integer  ' 常備參數
    Dim cReaderList As String  ' 有多少部讀卡機
    Dim cReaderGroup As String  ' 有多少部讀卡機
    Dim cCardReaderName As String  ' 使用中之讀卡機名字
    Dim lConnected As Boolean  ' 是否已連接了一張卡

    ' 以下都是讀取一張卡號時, 要使用的參數 (btRead 及 SCardTransmit)
    Dim bSendBuff(262), bRecvBuff(262) As Byte
    Dim nSendLen, nRecvLen As Integer
    Dim pioSendRequest As SCARD_IO_REQUEST

    Dim nLastState As Integer  ' 上一次讀取狀態 (SCardGetStatusChange) 時的識別號 (RdrEventState)
    Dim l_WithCard As Boolean  ' 已有卡在讀卡器上
    Dim txtWrite(16) As TextBox


    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call p_MakeTextBox()
    End Sub


    '   啟始讀卡機 (選取一部)
    Private Sub btInit_Click(sender As Object, e As EventArgs) Handles btInit.Click

        ' 已安裝在系統上的所有讀卡機之字串名字
        cReaderList = StrDup(255, vbNullChar)
        nReaderCount = 255

        nRetCode = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, hContext)

        If nRetCode = SCARD_S_SUCCESS Then
            nRetCode = SCardListReaders(hContext, cReaderGroup, cReaderList, nReaderCount)

            If nRetCode = SCARD_S_SUCCESS Then
                ' 只取第一部找到的讀卡機名字, 作為內定便用之讀卡機
                cCardReaderName = Split(cReaderList, vbNullChar)(0)
                rtxtOut.SelectedText = "已取得了讀卡器名稱 " & cCardReaderName & vbCrLf
                rtxtOut.SelectionStart = Len(rtxtOut.Text)
            Else
                rtxtOut.SelectedText = GetScardErrMsg(nRetCode) & vbCrLf
                rtxtOut.SelectionStart = Len(rtxtOut.Text)
            End If
        Else
            rtxtOut.SelectedText = GetScardErrMsg(nRetCode) & vbCrLf
            rtxtOut.SelectionStart = Len(rtxtOut.Text)
        End If
    End Sub


    ' 連接讀卡機, 只要是有卡在讀卡機上才會成功連接
    Private Sub btConnect_Click(sender As Object, e As EventArgs) Handles btConnect.Click
        If lConnected Then nRetCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD)

        nRetCode = SCardConnect(hContext, cCardReaderName, SCARD_SHARE_SHARED, (SCARD_PROTOCOL_T0 Or SCARD_PROTOCOL_T1), hCard, nProtocol)

        If nRetCode = SCARD_S_SUCCESS Then
            rtxtOut.SelectedText = "已連接了 " & cCardReaderName & vbCrLf
            rtxtOut.SelectionStart = Len(rtxtOut.Text)
            lConnected = True
        End If
    End Sub


    ' 讀取一張已連接的卡的資料 (卡號)
    Private Sub btRead_Click_1(sender As Object, e As EventArgs) Handles btRead.Click

        Dim tmpStr As String
        Dim i As Integer

        txtCardNo.Text = "XXX"

        ' ClearBuffers (清理)
        For i = 0 To 262
            bSendBuff(i) = &H0
            bRecvBuff(i) = &H0
        Next i

        If rbCommCardNo.Checked Then
            ' 發給讀卡器的指令, 讀取卡號
            bSendBuff(0) = &HFF ' CLA
            bSendBuff(1) = &HCA ' INS
            'bSendBuff(2) = &H1 ' P1: ISO 14443 A Card
            bSendBuff(2) = &H0 ' P1: Other cards
            bSendBuff(3) = &H0 ' P2
            bSendBuff(4) = &H0 ' Le: Full Length
            nSendLen = 5
        ElseIf rbCommPassword.Checked Then
            ' 發給讀卡器的指令, 核實密碼
            bSendBuff(0) = &HFF ' CLA
            bSendBuff(1) = &H86 ' INS
            bSendBuff(2) = &H0 ' P1: Other cards
            bSendBuff(3) = &H0 ' P2
            bSendBuff(4) = &H5 ' Le
            bSendBuff(5) = &H1
            bSendBuff(6) = &H0
            bSendBuff(7) = CByte(txtReadWrite.Text)
            bSendBuff(8) = &H60
            bSendBuff(9) = &H1
            nSendLen = 10
        ElseIf rbCommRead.Checked Then
            ' 發給讀卡器的指令, 讀取區域
            bSendBuff(0) = &HFF ' CLA
            bSendBuff(1) = &HB0 ' INS
            bSendBuff(2) = &H0 ' P1: Other cards
            'bSendBuff(3) = &H1 ' P2
            bSendBuff(3) = CByte(txtReadWrite.Text) ' P2
            bSendBuff(4) = &H10 ' Le: Full Length
            For i = 0 To 15
                txtWrite(i).Text = "00"
            Next
            nSendLen = 5
        ElseIf rbCommWrite.Checked Then
            ' 發給讀卡器的指令, 寫入區域
            If (Val(txtReadWrite.Text) + 1) Mod 4 = 0 Then
                MsgBox("不能寫入密碼區")
                Exit Sub
            End If
            bSendBuff(0) = &HFF ' CLA
            bSendBuff(1) = &HD6 ' INS
            bSendBuff(2) = &H0 ' P1: Other cards
            bSendBuff(3) = CByte(txtReadWrite.Text) ' P2
            bSendBuff(4) = CByte(IIf(cbUL.Checked, &H4, &H10)) ' Le: Full Length
            For i = 0 To 15
                bSendBuff(i + 5) = CByte("&H" & txtWrite(i).Text)
            Next
            'nSendLen = 9
            nSendLen = 21
        ElseIf rbCommSN.Checked Then
            ' 讀取讀卡機之固件版本用
            bSendBuff(0) = &HFF ' CLA
            bSendBuff(1) = &H0 ' INS
            bSendBuff(2) = &H48
            bSendBuff(3) = &H0
            bSendBuff(4) = &H0
            nSendLen = 5
        End If

        'nSendLen = bSendBuff(4) + 5
        nRecvLen = &HFF

        tmpStr = ""
        For i = 0 To (nSendLen - 1)
            tmpStr = tmpStr + Strings.Right("00" & Hex(bSendBuff(i)), 2) + " "
        Next

        rtxtOut.SelectedText = "發出查詢指令: " & tmpStr & vbCrLf
        rtxtOut.SelectionStart = Len(rtxtOut.Text)

        pioSendRequest.dwProtocol = 2
        pioSendRequest.cbPciLength = Len(pioSendRequest)

        ' 發出指令到讀卡器, 及提取讀回的資料
        nRetCode = SCardTransmit(hCard, pioSendRequest, bSendBuff(0), nSendLen, pioSendRequest, bRecvBuff(0), nRecvLen)

        If nRetCode = SCARD_S_SUCCESS Then
            ' 已讀取到卡號, 顯示卡號
            tmpStr = ""
            For i = 0 To (nRecvLen - 1)
                If rbCommSN.Checked Then
                    tmpStr = tmpStr + Chr(bRecvBuff(i))  ' 讀取讀卡機之固件版本用
                Else
                    tmpStr = tmpStr + Strings.Right("00" & Hex(bRecvBuff(i)), 2) + " "
                    If (rbCommRead.Checked) And (i < 16) Then txtWrite(i).Text = Strings.Right("00" & Hex(bRecvBuff(i)), 2)
                End If
            Next i
            If rbCommSN.Checked Then
                txtCardNo.Text = tmpStr.Trim
            ElseIf Len(tmpStr.Trim) > 6 Then
                txtCardNo.Text = Strings.Left(tmpStr.Trim, (Len(tmpStr.Trim) - 6))
            End If

            If (Len(tmpStr.Trim) > 6) And (rbCommSN.Checked = False) Then txtCardNo.Text = Strings.Left(tmpStr.Trim, (Len(tmpStr.Trim) - 6))

            rtxtOut.SelectedText = "接收回傳訊息: " & tmpStr.Trim & vbCrLf
        Else
            rtxtOut.SelectedText = "無卡錯誤: " & CStr(nRetCode) & vbCrLf
        End If
        rtxtOut.SelectionStart = Len(rtxtOut.Text)
    End Sub


    ' 顯示讀卡器現時狀態內容
    Private Sub btStatus_Click(sender As Object, e As EventArgs) Handles btStatus.Click
        Dim myCard As SCARD_READERSTATE  ' 傳回之參數
        Dim cATRvalue As String  ' 用作顯示的十六進字串
        Dim i As Integer

        ' 先啟始內容, 及設定讀卡器名字
        With myCard
            '.RdrName = "ACS ACR122 0"
            .RdrName = cCardReaderName
            .UserData = 0
            .RdrCurrState = 0
            .RdrEventState = 0
            .ATRLength = 0
            Erase .ATRValue
        End With

        ' 副程式取得內容
        nRetCode = SCardGetStatusChange(hContext, 1, myCard, 1)

        If nRetCode = SCARD_S_SUCCESS Then
            Debug.Print(hContext & " -RdrName- '" & CStr(myCard.RdrName) & "' -UserData- '" & CStr(myCard.UserData) & "' -CurrState- '" & CStr(myCard.RdrCurrState) & "' -EventState- '" & CStr(myCard.RdrEventState) & "' -Length- '" & myCard.ATRLength)

            cATRvalue = ""
            For i = 0 To (myCard.ATRLength - 1)
                cATRvalue = cATRvalue & Hex(myCard.ATRValue(i)) & "-"
            Next

            Debug.Print(cATRvalue & vbCrLf)
        End If
    End Sub


    ' 測試讀卡器狀態是否有改變
    Private Function f_ChangeCard() As Boolean
        Dim myCard As SCARD_READERSTATE  ' 傳回之參數

        ' 先啟始內容, 及設定讀卡器名字
        With myCard
            .RdrName = cCardReaderName
            .UserData = 0
            .RdrCurrState = 0
            .RdrEventState = 0
            .ATRLength = 0
            Erase .ATRValue
        End With

        ' 副程式取得內容
        nRetCode = SCardGetStatusChange(hContext, 1, myCard, 1)

        If nRetCode = SCARD_S_SUCCESS Then
            ' 若上一次讀取狀態時的識別號, 不同於本次讀取狀態時的識別號 (RdrEventState), 返回 "已更改" (True)
            If nLastState <> myCard.RdrEventState Then
                nLastState = myCard.RdrEventState
                l_WithCard = (myCard.ATRLength > 0)  ' 若 ATRLength 大於 0, 即表示有卡在讀卡器上
                Return True
            Else
                Return False
            End If
        Else
            l_WithCard = False
            Return False
        End If
    End Function


    ' 簡單的單次顯示, 讀卡器是否有變更過狀態
    Private Sub btTest_Click(sender As Object, e As EventArgs) Handles btTest.Click
        If f_ChangeCard() Then
            txtMsg.Text = "已更改狀態"
            If l_WithCard Then
                txtMsg.Text = txtMsg.Text & " - 有卡"
            Else
                txtMsg.Text = txtMsg.Text & " - 無卡"
            End If
        Else
            txtMsg.Text = "沒有改變"
        End If
    End Sub


    ' 時間器 (Timer), 每隔一段時間 (i.e. 500mS), 讀取一次讀卡器是否已更改了狀態
    Private Sub tmAuto_Tick(sender As Object, e As EventArgs) Handles tmAuto.Tick
        If f_ChangeCard() Then
            '若已更改, 再次連接讀卡器 (因為每次更改了另一張卡, 都要重新連接讀卡器)
            Call btConnect_Click(sender, e)
            Call f_ChangeCard()  ' 要再執行一次測試程序, 以更新原本之 "讀取狀態識別號" (RdrEventState)
            If (l_WithCard) And (rbAuto.Checked) Then Call btRead_Click_1(sender, e)  ' 若返回的狀態是有卡, 而且已選取了自動讀取, 便讀取最新卡號
        End If
        lblWithCard.Visible = l_WithCard
    End Sub


    ' 清理顯示文字
    Private Sub btEmpty_Click(sender As Object, e As EventArgs) Handles btEmpty.Click, btReset.Click
        rtxtOut.Clear()
        txtCardNo.Clear()
    End Sub

    ' 是否執行定時更新時間器
    Private Sub cbTimer_CheckedChanged(sender As Object, e As EventArgs) Handles cbTimer.CheckedChanged
        tmAuto.Enabled = cbTimer.Checked
        btTest.Enabled = (Not cbTimer.Checked)
        If cbTimer.Checked = False Then lblWithCard.Visible = False
    End Sub


    ' 自動讀取最新卡號
    Private Sub rbAuto_CheckedChanged(sender As Object, e As EventArgs) Handles rbAuto.CheckedChanged
        If rbAuto.Checked Then
            cbTimer.Checked = True
            rbCommCardNo.Checked = True
        End If
    End Sub

    ' 一鍵手動讀取卡號
    Private Sub btGo_Click(sender As Object, e As EventArgs) Handles btGo.Click
        If (hContext = 0) Or (cCardReaderName = "") Then Call btInit_Click(sender, e)  ' 若未取得所有讀卡器名字
        If (lConnected = False) Then
            ' 未曾連接讀卡器
            Call btConnect_Click(sender, e)
        Else
            ' 已連接讀卡器, 測試是否之前有更改過卡片
            If f_ChangeCard() Then
                ' 有更改過卡片, 再次重新連接讀卡器上之新卡片
                Call btConnect_Click(sender, e)
                Call f_ChangeCard()  ' 要再執行一次測試程序, 以更新原本之 "讀取狀態識別號" (RdrEventState)
            End If
        End If
        Call btRead_Click_1(sender, e)  ' 讀取最新之卡片號碼
    End Sub

    ' 重置所有輸出, 及常備參數
    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        cbTimer.Checked = False
        rbManual.Checked = True
        txtMsg.Clear()

        hContext = 0
        cCardReaderName = ""
        lConnected = False
        hCard = 0
    End Sub

    ' 輸入了讀寫區域區號, 整理為合理值
    Private Sub txtReadWrite_TextChanged(sender As Object, e As EventArgs) Handles txtReadWrite.TextChanged
        txtReadWrite.Text = CStr(Val(txtReadWrite.Text))
        If Val(txtReadWrite.Text) > 255 Then txtReadWrite.Text = "255"
    End Sub


    ' 新的 顯示讀卡器現時狀態內容
    Private Sub btNewStatus_Click(sender As Object, e As EventArgs) Handles btNewStatus.Click
        Dim nReaderLen As Integer
        Dim nState As Integer
        Dim nATRLen As Integer
        Dim nATRVal(32) As Byte
        Dim x As String


        nReaderLen = 0
        nState = 0
        nATRLen = 32

        nRetCode = SCardStatus(hCard, cCardReaderName, nReaderLen, nState, nProtocol, nATRVal(0), nATRLen)

        If nRetCode = SCARD_S_SUCCESS Then

            Debug.Print(hCard & "' -ReaderLen- '" & CStr(nReaderLen) & "' -State- '" & CStr(nState) & "' -Protocol- '" & CStr(nProtocol) & "' -Length- '" & CStr(nATRLen))

            x = ""
            For i = 0 To (nATRLen - 1)
                x = x & Hex(nATRVal(i)) & "-"
            Next

            Debug.Print(x & vbCrLf)
        Else
            Debug.Print(hCard & "' -ReaderLen- '" & CStr(nReaderLen) & "' -State- '" & CStr(nState) & "' -Protocol- '" & CStr(nProtocol) & "' -Length- '" & CStr(nATRLen) & " -X- " & nRetCode)
        End If
    End Sub


    ' 製作 16 個輸入 "區域內容" 的 TextBox
    Private Sub p_MakeTextBox()
        Dim i As Integer

        For i = 0 To 15
            txtWrite(i) = New TextBox
            gbWrite.Controls.Add(txtWrite(i))
            txtWrite(i).Name = "txtWrite" & CStr(i)
            txtWrite(i).MaxLength = 2
            txtWrite(i).TextAlign = HorizontalAlignment.Center
            txtWrite(i).Width = 26
            txtWrite(i).Top = 24
            txtWrite(i).Left = (i * 42) + 50
            txtWrite(i).Text = "00"
        Next

    End Sub



End Class
