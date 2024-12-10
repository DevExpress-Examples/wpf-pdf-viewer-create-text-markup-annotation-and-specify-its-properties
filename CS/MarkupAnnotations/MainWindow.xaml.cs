using DevExpress.Pdf;
using DevExpress.Xpf.DocumentViewer;
using DevExpress.Xpf.PdfViewer;
using System.Windows;

namespace MarkupAnnotations
{

    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load a document.
            viewer.OpenDocument("..\\..\\Demo.pdf");

            // Handle the AnnotationCreating event to specify the annotation properties.
            viewer.AnnotationCreating += Viewer_AnnotationCreating;

        }

        private void Viewer_AnnotationCreating(DependencyObject d, PdfAnnotationCreatingEventArgs e)
        {
            if (e.Builder.AnnotationType == PdfAnnotationType.Text || e.Builder.AnnotationType == PdfAnnotationType.TextMarkup)
            {
                IPdfViewerMarkupAnnotationBuilder annotationBuilder = e.Builder.AsMarkupAnnotationBuilder();

                annotationBuilder.Author = "John Smith";
                annotationBuilder.Contents = "Note";
                annotationBuilder.Color = new PdfRGBColor(0.23, 0.48, 0.34);
            }
        }

        private void viewer_DocumentLoaded(object sender, RoutedEventArgs e)
        {
            // Select the text to highlight:
            viewer.FindText(new TextSearchParameter { Text = "PDF Viewer" });

            // Highlight selected text:
            viewer.HighlightSelectedText();

            //Add a sticky note:
            viewer.AddStickyNote(new PdfDocumentPosition(1, new PdfPoint(29, 568)), "Comment");
        }
    }
}
