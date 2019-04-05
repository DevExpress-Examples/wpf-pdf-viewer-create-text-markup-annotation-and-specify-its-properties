<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MarkupAnnotations/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MarkupAnnotations/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MarkupAnnotations/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MarkupAnnotations/MainWindow.xaml.vb))
<!-- default file list end -->
#  How to create a text markup annotation and specify its properties 


This example shows how to create a markup annotation that highlights a selected text on a page. To create this annotation for a selected text, call one of the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.PdfViewer.PdfViewerControl.HighlightSelectedText.overloads">PdfViewerControl.HighlightSelectedText</a> overload methods. <br><br>To specify the annotation properties when the markup annotation is being created, handle the <a href="https://documentation.devexpress.com/WPF/DevExpress.Xpf.PdfViewer.PdfViewerControl.TextMarkupAnnotationCreating.event">PdfViewerControl.TextMarkupAnnotationCreating </a>event.

<br/>


