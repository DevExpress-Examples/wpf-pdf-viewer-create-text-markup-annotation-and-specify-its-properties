using System.Windows;
using DevExpress.Pdf;
using DevExpress.Xpf.PdfViewer;

namespace MarkupAnnotations {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Load a document.
            viewer.OpenDocument("..\\..\\Demo.pdf");

            // Handle the TextMarkupAnnotationCreating event to specify the annotation properties.
            viewer.TextMarkupAnnotationCreating += Viewer_TextMarkupAnnotationCreating;

        }

        private void Viewer_TextMarkupAnnotationCreating(DependencyObject d, PdfTextMarkupAnnotationCreatingEventArgs e) {
            e.Author = "John Smith";
            e.Comment = "Note.";
            e.Color = System.Windows.Media.Color.FromRgb(229, 214, 0);
        }

        private void viewer_DocumentLoaded(object sender, RoutedEventArgs e) {

            // Select the document area where the markup annotation will be created.
            viewer.Select(new PdfDocumentArea(1, new PdfRectangle(90, 100, 240, 230)));

            // Highlight a selected text.
            viewer.HighlightSelectedText();
        }
    }
}
