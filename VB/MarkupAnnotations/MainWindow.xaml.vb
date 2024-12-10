Imports System.Windows
Imports DevExpress.Pdf
Imports DevExpress.Xpf.PdfViewer

Namespace MarkupAnnotations

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            ' Load a document.
            Me.viewer.OpenDocument("..\..\Demo.pdf")
            ' Handle the TextMarkupAnnotationCreating event to specify the annotation properties.
            AddHandler Me.viewer.TextMarkupAnnotationCreating, AddressOf Me.Viewer_TextMarkupAnnotationCreating
        End Sub

        Private Sub Viewer_TextMarkupAnnotationCreating(ByVal d As DependencyObject, ByVal e As PdfTextMarkupAnnotationCreatingEventArgs)
            e.Author = "John Smith"
            e.Comment = "Note."
            e.Color = Media.Color.FromRgb(229, 214, 0)
        End Sub

        Private Sub viewer_DocumentLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Select the document area where the markup annotation will be created.
            Me.viewer.Select(New PdfDocumentArea(1, New PdfRectangle(90, 100, 240, 230)))
            ' Highlight a selected text.
            Me.viewer.HighlightSelectedText()
        End Sub
    End Class
End Namespace
