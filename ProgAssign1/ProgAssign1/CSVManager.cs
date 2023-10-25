using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace ProgAssign1
{
	public class CSVManager
	{
        

        public static void parse(String fileName)
        {
            Console.WriteLine("Parsing file for valid data . . .");
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    //Extracting Date
                    string regexPattern = @"\b(\d{4}/\d{1,2}/\d{1,2})\b";                  
                    Match match = Regex.Match(fileName, regexPattern);
                    string extractedDate = match.Groups[1].Value;


                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    //Console.WriteLine(string.Join(" ", parser.ReadFields()));
                    parser.ReadFields(); //skipping headers

                    int c = 0;

                    while (!parser.EndOfData)
                    {
                        
                        if (c == 0)
                        {
                            c = 1;
                            continue;
                        }

                      
                        //Process row
                        List < String > fields = new List<String>();
                        fields.Add(extractedDate);
                        fields.AddRange(parser.ReadFields());
                
                        if (fields.Contains(""))
                        {
                            Console.WriteLine("INCOMPLETE ROW---Skipped");
                            DirWalker.skippedRows = DirWalker.skippedRows + 1;
                        }
                        else
                        {
                            DirWalker.validRows = DirWalker.validRows + 1;
                            WriteToCsvFile(DirWalker.outputFile, fields);
                            
                        }


                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            return;

        }
        public static void WriteToCsvFile(string filePath, List<String> fields)
        {
            try
            {

                FileStream fs = new FileStream(filePath, FileMode.Append);
                using (var writer = new StreamWriter(fs))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    string row = "";
                    foreach (string field in fields)
                    {
                        row = row + field + ", ";
                        csv.WriteField(field);
                    }
                    Console.WriteLine(row);
                    csv.NextRecord();
                }

                fs.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }

        }
    }
}

