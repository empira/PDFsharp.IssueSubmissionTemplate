// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using System.Reflection;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // For the Core build a FontResolver is needed.
            if (Capabilities.Build.IsCoreBuild)
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

            // Create a new PDF document.
            var document = new PdfDocument();
            document.Info.Title = "PDFsharp Issue Template";
            document.Info.Author = "Your Name";
            document.Info.Subject = "Demonstrate an issue of PDFsharp";
            document.PageLayout = PdfPageLayout.SinglePage;

#if DEBUG
            // Create PDF files that are somewhat human-readable.
            document.Options.Layout = PdfWriterLayout.Verbose;
#endif

            // Create an empty page in this document.
            var page = document.AddPage();

            // Get an XGraphics object for drawing on this page.
            var gfx = XGraphics.FromPdfPage(page);

            // Create a font.
            var font = new XFont("Verdana", 20, XFontStyleEx.BoldItalic);

            // Draw the text.
            gfx.DrawString("Minimal, reproducible example", font, XBrushes.Black,
                new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFullFileName("IssueTemplate");
            Console.WriteLine($"Filename='{filename}'");
            document.Save(filename);
            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }
    }
}
