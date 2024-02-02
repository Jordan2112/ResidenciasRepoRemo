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

           
                // Crear un directorio de extracción en el directorio de trabajo actual
                string extractionDirectory = Path.Combine(Environment.CurrentDirectory, "Extraccion");
                Directory.CreateDirectory(extractionDirectory);

                // Extraer el contenido del archivo ZIP
                ZipFile.ExtractToDirectory(zipFilePath, extractionDirectory);

                // Obtener la lista de archivos extraídos
                string[] extractedFilePaths = Directory.GetFiles(extractionDirectory);
                foreach (string filePath in extractedFilePaths)
                {
                    fileInfo fileInfo = new fileInfo
                    {
                        nameFile = Path.GetFileName(filePath),
                        lastModification = File.GetLastWriteTime(filePath),
                        filePath = filePath

                    };
                    fileContentZip.Add(fileInfo);
                }

               return fileContentZip;
           

        }

        public static DataTable ConvertListToDataTableZip2(List<fileInfo> fileList)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre");
           \
            dataTable.Columns.Add("Ruta");

            foreach (fileInfo fileInfo in fileList)
            {

                dataTable.Rows.Add(fileInfo.nameFile, fileInfo.filePath);
            }

            return dataTable;
        }



    }

}
