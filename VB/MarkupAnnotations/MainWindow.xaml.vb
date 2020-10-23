Imports System.Windows
Imports DevExpress.Pdf
Imports DevExpress.Xpf.PdfViewer

Namespace MarkupAnnotations

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Load a document.
            viewer.OpenDocument("..\..\Demo.pdf")

            ' Handle the TextMarkupAnnotationCreating event to specify the annotation properties.
            AddHandler viewer.AnnotationCreating, AddressOf Viewer_TextMarkupAnnotationCreating

        End Sub

        Private Sub Viewer_TextMarkupAnnotationCreating(ByVal d As DependencyObject, ByVal e As PdfAnnotationCreatingEventArgs)
            If e.Builder.AnnotationType = PdfAnnotationType.Text OrElse e.Builder.AnnotationType = PdfAnnotationType.TextMarkup Then
                Dim annotationBuilder As IPdfViewerMarkupAnnotationBuilder = e.Builder.AsMarkupAnnotationBuilder()
                annotationBuilder.Author = "John Smith"
                annotationBuilder.Contents = "Note."
                annotationBuilder.Color = New PdfRGBColor(0.69, 0.75, 0.1)
            End If
        End Sub

        Private Sub viewer_DocumentLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Select the document area where the markup annotation will be created.
            viewer.Select(New PdfDocumentArea(1, New PdfRectangle(90, 100, 240, 230)))

            ' Highlight a selected text.
            viewer.HighlightSelectedText()
        End Sub
    End Class
End Namespace
