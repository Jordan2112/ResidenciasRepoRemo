using System.Data;
using System.IO.Compression;

namespace LOPEZADRI_FILE_MANAGER_2.Models
{
    internal class FileHelper
    {
        //Atributos que contiene un archivo y sus propiedades
        public string nameFile { get; set; }
       
        public string? filePath { get; set; }

        /*Metodo el cual carga los archivos de un directorio en especifico con base a una ruta 
        proporcionado en la clase de la forma*/
        public static List<FileHelper>? LoadDirectory(string folderpath)
        {
            List<FileHelper> fileList = new List<FileHelper>();

            string[] entries = Directory.GetFileSystemEntries(folderpath);

            // Iterar sobre cada ruta de archivo o carpeta en el directorio
            foreach (string entryPath in entries)
            {
                // Crear un objeto FileSystemInfo para obtener información sobre el archivo o carpeta
                FileSystemInfo fileInfo = new FileInfo(entryPath);

                // Crear un nuevo objeto FileHelper y agregarlo a la lista
                fileList.Add(new FileHelper
                {
                    // Asignar el nombre del archivo o carpeta al campo 'nameFile'
                    nameFile = fileInfo.Name,

                    filePath = fileInfo.FullName
                });



            }
            return fileList;

        }
        public static List<FileHelper>? LoadPath(string folderPath)
        {
            List<FileHelper> fileList = new List<FileHelper>();

            // Verificar si la ruta es un archivo ZIP
            if (Path.GetExtension(folderPath).Equals(".zip", StringComparison.OrdinalIgnoreCase))
            {
                // Lógica para cargar el contenido de un archivo ZIP
                using (ZipArchive archive = ZipFile.OpenRead(folderPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        // Crear un nuevo objeto FileHelper y agregarlo a la lista
                        fileList.Add(new FileHelper
                        {
                            nameFile = entry.Name,
                          
                            filePath = entry.FullName
                        });
                    }
                }
            }
            else if (Directory.Exists(folderPath)) // Verificar si la ruta es un directorio existente
            {
                // Obtener la lista de archivos en el directorio
                string[] files = Directory.GetFiles(folderPath);

                // Iterar sobre cada archivo en el directorio
                foreach (string filePath in files)
                {
                    if (Path.GetExtension(filePath).Equals(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        // Si es un archivo ZIP, llamar recursivamente a LoadPath para obtener los archivos dentro del ZIP
                        fileList.AddRange(LoadPath(filePath));
                    }
                   
                }
            }
            else
            {
                throw new ArgumentException("La ruta especificada no es un archivo ZIP ni un directorio existente.");
            }

            // Retornar la lista de objetos FileHelper
            return fileList;
        }


        /*Convierte la lista ya con contenido a una data table*/
        public static DataTable ConvertListToDataTable(List<FileHelper> fileList)
        {
            // Crea un nuevo objeto DataTable que se utilizará para almacenar los datos
            DataTable dataTable = new DataTable();

            // Agrega las columnas al DataTable con los nombres especificados
            dataTable.Columns.Add("Nombre");
           
            dataTable.Columns.Add("Ruta");

            // Itera sobre cada objeto FileHelper en la lista
            foreach (FileHelper fileInfoData in fileList)
            {
                // Agrega una nueva fila al DataTable con los datos del objeto FileHelper actual
                dataTable.Rows.Add(
                    fileInfoData.nameFile,                  // Nombre del archivo
                  
                    fileInfoData.filePath                   // Ruta completa del archivo
                );
            }

            // Retorna el DataTable que contiene los datos convertidos de la lista
            return dataTable;
        }

    }
}
