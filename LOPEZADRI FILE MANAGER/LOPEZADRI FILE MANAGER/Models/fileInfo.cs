using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER.Models
{
    internal class fileInfo
    {
        public string nameFile { get; set; }
        public DateTime lastModification { get; set; }
        public DateTime creationFile { get; set; }
        public string filePath { get; set; }

        public fileInfo()
        {
            nameFile = string.Empty;
            filePath = string.Empty;
        }

        public static List<fileInfo> LoadFiles(string folderPath)
        {
            List<fileInfo> fileList = new List<fileInfo>();

            string[] files = Directory.GetFiles(folderPath);

            foreach (string filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                fileList.Add(new fileInfo
                {
                    nameFile = fileInfo.Name,
                    lastModification = fileInfo.LastWriteTime,
                    filePath = fileInfo.FullName
                });
            }

            return fileList;
        }

        public static DataTable ConvertListToDataTable(List<fileInfo> fileList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Ultima Modificacion");
            dataTable.Columns.Add("Ruta");

            foreach (fileInfo fileInfoData in fileList)
            {
                dataTable.Rows.Add(fileInfoData.nameFile, fileInfoData.lastModification, fileInfoData.filePath);
            }

            return dataTable;
        }

        public static List<fileInfo> LoadFilesZip(string folderPath)
        {
            List<fileInfo> fileContentZip = new List<fileInfo>();
            if (File.Exists(folderPath) && folderPath.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            {
                using (ZipArchive archive = ZipFile.OpenRead(folderPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        fileContentZip.Add(new fileInfo
                        {
                            nameFile = entry.Name,
                            lastModification = entry.LastWriteTime.Date,
                            filePath = entry.FullName

                        }) ;
                    }
                }
            }
           
            return fileContentZip;
        }

        public static DataTable ConvertListToDataTableZip(List<fileInfo> fileList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Ultima Modificacion");
            dataTable.Columns.Add("Ruta");

            foreach (fileInfo fileInfo in fileList)
            {

                dataTable.Rows.Add(fileInfo.nameFile, fileInfo.lastModification,fileInfo.filePath);
            }

            return dataTable;
        }

        public static List<fileInfo> ExtractZipContents(string zipFilePath)
        {
            List<fileInfo> fileContentZip = new List<fileInfo>();

            try
            {
                // Crear un directorio de extracción en el directorio de trabajo actual
                string extractionDirectory = Path.Combine(Environment.CurrentDirectory, "ZIPS");
                Directory.CreateDirectory(extractionDirectory);

                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryPath = Path.Combine(extractionDirectory, entry.FullName);

                        // Si la entrada es un directorio, asegurarse de que exista
                        if (entry.FullName.EndsWith("/"))
                        {
                            Directory.CreateDirectory(entryPath);
                        }
                        else
                        {
                            // Extraer la entrada del archivo ZIP
                            entry.ExtractToFile(entryPath, true);

                            fileInfo fileInfo = new fileInfo
                            {
                                nameFile = entry.Name,
                                lastModification = File.GetLastWriteTime(entryPath),
                                filePath = entryPath
                            };
                            fileContentZip.Add(fileInfo);
                        }
                    }
                }

                return fileContentZip;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al extraer archivos ZIP: " + ex.Message);
                return fileContentZip; // Devuelve la lista vacía en caso de error
            }
        }



        public static DataTable ConvertListToDataTableZip2(List<fileInfo> fileList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre");
           
            dataTable.Columns.Add("Ruta");

            foreach (fileInfo fileInfo in fileList)
            {

                dataTable.Rows.Add(fileInfo.nameFile, fileInfo.filePath);
            }

            return dataTable;
        }



    }

}
