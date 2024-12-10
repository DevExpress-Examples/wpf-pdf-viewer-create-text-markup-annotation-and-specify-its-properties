Imports DevExpress.Pdf
Imports DevExpress.Xpf.DocumentViewer
Imports DevExpress.Xpf.PdfViewer
Imports System.Windows

Namespace MarkupAnnotations

    Public Partial Class MainWindow
        Inherits DevExpress.Xpf.Core.ThemedWindow

        Public Sub New()
            Me.InitializeComponent()
            ' Load a document.
            Me.viewer.OpenDocument("..\..\Demo.pdf")
            ' Handle the AnnotationCreating event to specify the annotation properties.
            AddHandler Me.viewer.AnnotationCreating, AddressOf Me.Viewer_AnnotationCreating
        End Sub

        Private Sub Viewer_AnnotationCreating(ByVal d As DependencyObject, ByVal e As PdfAnnotationCreatingEventArgs)
            If e.Builder.AnnotationType = PdfAnnotationType.Text OrElse e.Builder.AnnotationType = PdfAnnotationType.TextMarkup Then
                Dim annotationBuilder As IPdfViewerMarkupAnnotationBuilder = e.Builder.AsMarkupAnnotationBuilder()
                annotationBuilder.Author = "John Smith"
                annotationBuilder.Contents = "Note"
                annotationBuilder.Color = New PdfRGBColor(0.23, 0.48, 0.34)
            End If
        End Sub

        Private Sub viewer_DocumentLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Select the text to highlight:
            Me.viewer.FindText(New TextSearchParameter With {.Text = "PDF Viewer"})
            ' Highlight selected text:
            Me.viewer.HighlightSelectedText()
            'Add a sticky note:
            Me.viewer.AddStickyNote(New PdfDocumentPosition(1, New PdfPoint(29, 568)), "Comment")
        End Sub
    End Class
End Namespace
