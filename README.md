# A00477369_MCDA5510: Software Development

## About Me
Hi! My name is Neeyati. I am an inquisitive software developer with an immense interest in Big Data. I completed a Bachelor’s degree in Computer Applications with a strong foundation in Math and Programming Logic. After graduating, I also pursued and successfully completed a Post Graduate Diploma in Data Analysis. I believe Computer Science can pave the way for a more equitable world. I aspire to explore the unique and creative approaches toward technology which can help advance the world. I am dedicated and keen to work hard in this field to further my ambitions and become a professional Data Scientist.

## Assingment 1 : Directory Traversal and CSV Processing Program

### Location
- The Code is located under the ProgAssign1 Directory
- The Logs are stored in the ProgAssign1/ProgAssign1/logs/logs.txt file
- The Output Csv is stored in the ProgAssign1/ProgAssign1/Output/output.csv file

### Introduction
This C# program is designed to traverse a directory structure containing CSV files and store the data in a single CSV file. The CSV files are expected to contain customer information with specific data columns.

### Program Features

- **Directory Traversal**: The program recursively traverses the specified directory structure.
- **CSV Manager**: The program can read and write in the CSV files. *CSVHelper* Library is used to write the Data in the CSV file.
- **Logging**: The program utilizes logging to capture informational messages and all possible checked exceptions.
- **Data Validation**: It skips lines with incomplete records and logs them as skipped rows.
- **Logging Output**: The program logs the total execution time, the total number of valid rows, and the total number of skipped rows.
- **Data Columns**: The program expects CSV files with the following data columns:
  - First Name
  - Last Name
  - Street Number
  - Street
  - City
  - Province
  - Country
  - Postal Code
  - Phone Number
  - Email Address
  - Date (yyyy/mm/dd) extracted from the directory structure

### Notes
- Change the _rootDir_ variable in _DirWalker.cs_ to your local directory.
- This program was coded in a macbook. In order to ensure compatibility with Windows, if you intend to run this program on a Windows machine, please make the following modification:
- Replace the forward slashes '/' with backslashes '\\' in the _regexPattern_ variable located in the _CSVManager.cs_ file."

