Sub InsertImage()
    With Application.FileDialog(msoFileDialogFilePicker)
        .AllowMultiSelect = False
        .ButtonName = "Submit"
        .Title = "Select an image file"
        .Filters.Clear
        .Filters.Add "JPG", "*.JPG"
        .Filters.Add "JPEG File Interchange Format", "*.JPEG"
        .Filters.Add "Graphics Interchange Format", "*.GIF"
        .Filters.Add "Portable Network Graphics", "*.PNG"
        .Filters.Add "Tag Image File Format", "*.TIFF"
        .Filters.Add "All Pictures", "*.*"

        If .Show = -1 Then
            Dim img As Object
            Set img = ActiveSheet.Pictures.Insert(.SelectedItems(1))

            'Position Image
            img.Left = ActiveCell.Left
            img.Top = ActiveCell.Top

            'Set image sizes in points (72 point per inch)
            img.Width = 150
            img.Height = 150
        Else
            MsgBox ("Cancelled.")
        End If
    End With
End Sub

Private Sub Worksheet_SelectionChange(ByVal Target As Range)
    If Target.Address = "$A$1" Or Target.Address = "$A$10" Or Target.Address = "$A$20" Then
        Cancel = True
        Call InsertImage
    End If
End Sub