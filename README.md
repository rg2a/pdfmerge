# pdfmerge

Select PDF Files: When you run the program, it will prompt you to enter the names of the PDF files you want to merge. You should provide the file names one by one and press enter after each input. To finish the selection, enter 'fin' (without quotes).

File Validation: The program checks if each file exists in the provided path. If a file exists, it adds it to the list of files to be merged and displays a message confirming the file has been added. If a file is not found, it displays an error message indicating the file was not found.

No Files Selected: If you don't select any files (i.e., the files list is empty), the program will display a message saying "No files selected. The program will exit." The program will then terminate without performing the merge operation.

Merging Files: If one or more files are selected, the program proceeds to merge the selected PDF files. It displays a message indicating that the merging process has started.

Merge Operation: The method Mergepdf is responsible for merging the PDF files. It uses the PdfSharp library to create a new PDF document called outputDocument.

Iterating Over Files: The code iterates over each file in the fileNames list and opens it as an input document using PdfSharp.Pdf.IO.PdfReader.Open. It retrieves the number of pages in the input document and iterates over each page, adding it to the outputDocument using outputDocument.AddPage(page).

Saving the Merged File: Once all the pages from each input file are added to the outputDocument, it saves the merged document using outputDocument.Save(outputFileName). The merged PDF file will be named "merged.pdf".

Completion Message: After the merge operation is completed, the program displays a message saying "Merge completed. The file 'merged.pdf' has been created."
