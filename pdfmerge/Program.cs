using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfmerge
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Select the PDF files to merge, (enter 'fin' to finish the selection):");

            List<string> files = new List<string>();

            string input;

            while((input = Console.ReadLine()) != "fin")
            {
                if(File.Exists(input))
                {
                    files.Add(input);
                    Console.WriteLine("File Added : " + input);
                }
                else
                {
                    Console.WriteLine("File not found : " + input);
                }
            }
            if(files.Count == 0)
            {
                Console.WriteLine("No files selected. The program will exit.");
                return;
            }

            Console.WriteLine("Merging files.");
            Mergepdf(files, "merged.pdf");
            Console.WriteLine("Merge completed, the file 'merged.pdf' has been created.");

        }

        static void Mergepdf(List<string> fileNames, string outputFileName)
        {
            using (var outputDocument = new PdfSharp.Pdf.PdfDocument())
            {
                try
                {
                    foreach (var fileName in fileNames)
                    {
                        using(var inputDocument = PdfSharp.Pdf.IO.PdfReader.Open(fileName, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                        {
                            int pageCount = inputDocument.PageCount;
                            for(int pageIndex = 0; pageIndex < pageCount; pageIndex++)
                            {
                                var page = inputDocument.Pages[pageIndex];
                                outputDocument.AddPage(page);
                            }
                        }
                        Console.WriteLine("File inserted: " + fileName);
                    }
                    outputDocument.Save(outputFileName);
                    Console.WriteLine("Merge completed. The file 'merge.pdf' have been created");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
