// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // For the Core build a FontResolver is needed.
            if (PdfSharp.Capabilities.Build.IsCoreBuild)
            {
#if true
                // The FailsafeFontResolver will substitute every font by a SegoeWP font.
                // This way you don't have to provide an own FontResolver for your issue.
                // If fonts are relevant for your issue, you have to assign an own FontResolver which supports the desired fonts instead.
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
#else
                // Use this code instead to use a small set of typical Windows fonts like Arial or Times New Roman without a FontResolver under Windows or WSL.
                GlobalFontSettings.UseWindowsFontsUnderWindows = true;
                GlobalFontSettings.UseWindowsFontsUnderWsl2 = true;
#endif
            }

            // Create a MigraDoc document.
            var document = CreateDocument();

            // Associate the MigraDoc document with a renderer.
            var pdfRenderer = new PdfDocumentRenderer
            {
                Document = document,
                PdfDocument = new PdfDocument
                {
                    PageLayout = PdfPageLayout.SinglePage
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFullFileName("IssueTemplate");
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }

        /// <summary>
        /// Creates minimalistic document.
        /// </summary>
        static Document CreateDocument()
        {
            // Create a new MigraDoc document.
            var document = new Document
            {
                Info =
                {
                    Title = "MigraDoc Issue Template",
                    Author = "Your Name",
                    Subject = "Demonstrate an issue of MigraDoc"
                }
            };

            // Add a section to the document.
            var section = document.AddSection();

            // Add a paragraph to the section.
            var paragraph = section.AddParagraph();

            // Set font color.
            paragraph.Format.Font.Color = Colors.DarkBlue;

            // Add some text to the paragraph.
            paragraph.AddFormattedText("Minimal, reproducible example", TextFormat.Bold);

            // Create the primary footer.
            var footer = section.Footers.Primary;

            // Add content to footer.
            paragraph = footer.AddParagraph();
            paragraph.Add(new DateField { Format = "yyyy/MM/dd HH:mm:ss" });
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            return document;
        }
    }
}
