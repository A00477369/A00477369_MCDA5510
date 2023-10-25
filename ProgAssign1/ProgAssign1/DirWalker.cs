using System.Diagnostics;

namespace ProgAssign1
{


    public class DirWalker
    {
        //Setting up initial variables
        public static string rootDir = "/Users/mehta/Desktop/smu/Sem1/Software Development/Repos/A00477369_MCDA5510/ProgAssign1/ProgAssign1/";
        public static string logFile = rootDir + "logs/logs.txt";
        public static string inputDir = rootDir + "Sample Data";
        public static string outputFile = rootDir + "Output/output.csv";
        public static long validRows = 0;
        public static long skippedRows = 0;

        public void walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {

                Console.WriteLine("File:" + filepath);
                CSVManager.parse(filepath);
            }

            return;
        }

        public static void Main(String[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //Start the stopwatch
            stopwatch.Start();
        
            //Setting up logs
            FileStream fs = new FileStream(logFile, FileMode.Append);
            var log = new StreamWriter(fs);
            Console.SetOut(log);

            Console.WriteLine("-----------Program Started----------");

            //Generating headers
            Console.WriteLine("Generating Headers. . . ");
            List<String> headers = new List<string>();
            headers.Add("Date");
            headers.Add("First Name");
            headers.Add("Last Name");
            headers.Add("Street Number");
            headers.Add("Street");
            headers.Add("City");
            headers.Add("Province");
            headers.Add("Country");
            headers.Add("Postal Code");
            headers.Add("Phone Number");
            headers.Add("Email Address");
            CSVManager.WriteToCsvFile(outputFile, headers);
            DirWalker fw = new DirWalker();
            fw.walk(inputDir);

            //Stop the stopwatch
            stopwatch.Stop();

            Console.WriteLine("-----------Program Stopped----------");

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = (double)elapsedMilliseconds / 10000;
            Console.WriteLine($"Execution time: {elapsedSeconds} seconds");
            Console.WriteLine($"Total valid rows: {validRows}");
            Console.WriteLine($"Total skipped rows: {skippedRows}");
            log.Flush();
        }

    }
}
