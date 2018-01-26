using Aspose.Pdf;
using Aspose.Pdf.Facades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAsposePdfMerg
{
    class Program
    {
        private static string dataDir;
        static void Main(string[] args)
        {
            // For complete examples and data files, please go to https://github.com/aspose-pdf/Aspose.Pdf-for-.NET
            // The path to the documents directory.
            Console.WriteLine("Please provide the directory path to merge PDF files.");

            dataDir  = Console.ReadLine();
            //string[] files = Directory.GetFiles(dataDir, "*.pdf");


            //Console.WriteLine("Mergerd the pdf file : {0}", files.Length);

            //var timeSpanPDFFacade = PDFConcatenateUsingPDFFacades(files);
            //Console.Write(String.Format("Using PDF Facades = {0:00}.{1:00}s\t", timeSpanPDFFacade.Seconds, timeSpanPDFFacade.Milliseconds / 10));

            //Getting Exception in evalution mode
            //var timeSpanPDF = PDFConcatenateUsingPDF(files);
            //Console.Write(String.Format("Using PDF Facades = {0:00}.{1:00}s\t", timeSpanPDF.Seconds, timeSpanPDF.Milliseconds / 10));

            Console.WriteLine("Converting doc/word file to PDF");


            string[] docFiles = Directory.GetFiles(dataDir, "*.docx");
            var timeSpanDocToPDF = ConverDocToPDF(docFiles[0]);
            Console.Write(String.Format("Using PDF Facades = {0:00}.{1:00}s\t", timeSpanDocToPDF.Seconds, timeSpanDocToPDF.Milliseconds / 10));

            Console.ReadLine();
        }

        private static TimeSpan PDFConcatenateUsingPDFFacades(string[] files)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            PdfFileEditor pfe = new PdfFileEditor();
            pfe.CopyOutlines = false;
            pfe.Concatenate(files, dataDir + "\\Facades\\CopyOutline_out.pdf");
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private static TimeSpan PDFConcatenateUsingPDF(string[] files)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Open first document
            Document pdfDocument1 = new Document(files[0]);
            // Open other documents
            for (int i = 1; i < files.Length; i++)
            {
                Document pdfDocument2 = new Document(files[i]);
                
                // Add pages of second document to the first
                pdfDocument1.Pages.Add(pdfDocument2.Pages);
            }

            // Save concatenated output file
            pdfDocument1.Save(dataDir + "\\PDF\\ConcatenatePdfFiles_out.pdf");
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private static TimeSpan ConverDocToPDF(string docFile)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // load the file to be converted
            var doc = new Aspose.Words.Document(docFile);
            // save in different formats
            doc.Save(dataDir + "\\Document\\output.pdf", Aspose.Words.SaveFormat.Pdf);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
