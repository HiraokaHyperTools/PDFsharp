using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using System.Windows.Controls.Primitives;

namespace DocumentViewer
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      // Create a new MigraDoc document
      Document document = SampleDocuments.CreateSample1();

      // HACK
      string ddl = DdlWriter.WriteToString(document);
      this.preview.Ddl = ddl;
    }

    private void Sample1_Click(object sender, RoutedEventArgs e)
    {
      Document document = SampleDocuments.CreateSample1();
      this.preview.Ddl = DdlWriter.WriteToString(document);
    }

    private void Sample2_Click(object sender, RoutedEventArgs e)
    {
      Document document = SampleDocuments.CreateSample2();
      this.preview.Ddl = DdlWriter.WriteToString(document);
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void CreatePdf_Click(object sender, RoutedEventArgs e)
    {
      PdfDocumentRenderer printer = new PdfDocumentRenderer();
      printer.DocumentRenderer = this.preview.Renderer;
      printer.Document = this.preview.Document;
      printer.RenderDocument();
      this.preview.Document.BindToRenderer(null);
      printer.Save("test.pdf");

      Process.Start("test.pdf");
    }
  }
}
