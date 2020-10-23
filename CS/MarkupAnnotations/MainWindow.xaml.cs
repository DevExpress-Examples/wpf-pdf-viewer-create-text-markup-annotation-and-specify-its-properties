using DevExpress.Pdf;
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

            // Handle the TextMarkupAnnotationCreating event to specify the annotation properties.
            viewer.AnnotationCreating += Viewer_TextMarkupAnnotationCreating;

        }

        private void Viewer_TextMarkupAnnotationCreating(DependencyObject d, PdfAnnotationCreatingEventArgs e)
        {
            if (e.Builder.AnnotationType == PdfAnnotationType.Text || e.Builder.AnnotationType == PdfAnnotationType.TextMarkup)
            {
                IPdfViewerMarkupAnnotationBuilder annotationBuilder = e.Builder.AsMarkupAnnotationBuilder();

                annotationBuilder.Author = "John Smith";
                annotationBuilder.Contents = "Note.";
                annotationBuilder.Color = new PdfRGBColor(0.69, 0.75, 0.10);
            }
        }

        private void viewer_DocumentLoaded(object sender, RoutedEventArgs e)
        {

            // Select the document area where the markup annotation will be created.
            viewer.Select(new PdfDocumentArea(1, new PdfRectangle(90, 100, 240, 230)));

            // Highlight a selected text.
            viewer.HighlightSelectedText();
        }
    }
}
