using System.Data;

namespace LOPEZADRI_FILE_MANAGER_2.Models
{
    internal class FileHelper
    {
        //Atributos que contiene un archivo y sus propiedades
        public string? nameFile { get; set; }
        public DateTime lastModification { get; set; }
        public DateTime creationFile { get; set; }
        public string? filePath { get; set; }

        /*Metodo el cual carga los archivos de un directorio en especifico con base a una ruta 
        proporcionado en la clase de la forma*/
        public static List<FileHelper> LoadPath(string folderPath)
        {
            /* Lista para almacenar los archivos y carpetas y agregarlos a una lista la cual será retornada */
            List<FileHelper> fileList = new List<FileHelper>();

            // Obtiene la lista de rutas de archivos y carpetas en el directorio especificado
            string[] entries = Directory.GetFileSystemEntries(folderPath);

            // Itera sobre cada ruta de archivo o carpeta en el directorio
            foreach (string entryPath in entries)
            {
                // Crea un objeto FileSystemInfo para obtener información sobre el archivo o carpeta
                FileSystemInfo fileInfo = new FileInfo(entryPath);

                // Crea un nuevo objeto FileHelper y lo agrega a la lista
                fileList.Add(new FileHelper
                {
                    // Asigna el nombre del archivo o carpeta al campo 'nameFile'
                    nameFile = fileInfo.Name,

                    // Asigna la fecha de última modificación al campo 'lastModification'
                    lastModification = fileInfo.LastWriteTime.Date,

                    // Asigna la fecha de creación al campo 'creationFile'
                    creationFile = fileInfo.CreationTime.Date,

                    // Asigna la ruta completa del archivo o carpeta al campo 'filePath'
                    filePath = fileInfo.FullName
                });
            }

            // Retorna la lista de objetos FileHelper que representan los archivos y carpetas en el directorio
            return fileList;
        }


        /*Convierte la lista ya con contenido a una data table*/
        public static DataTable ConvertListToDataTable(List<FileHelper> fileList)
        {
            // Crea un nuevo objeto DataTable que se utilizará para almacenar los datos
            DataTable dataTable = new DataTable();

            // Agrega las columnas al DataTable con los nombres especificados
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Ultima Modificacion");
            dataTable.Columns.Add("Fecha de creacion");
            dataTable.Columns.Add("Ruta");

            // Itera sobre cada objeto FileHelper en la lista
            foreach (FileHelper fileInfoData in fileList)
            {
                // Agrega una nueva fila al DataTable con los datos del objeto FileHelper actual
                dataTable.Rows.Add(
                    fileInfoData.nameFile,                  // Nombre del archivo
                    fileInfoData.lastModification.Date,     // Fecha de última modificación
                    fileInfoData.creationFile.Date,         // Fecha de creación
                    fileInfoData.filePath                   // Ruta completa del archivo
                );
            }

            // Retorna el DataTable que contiene los datos convertidos de la lista
            return dataTable;
        }



    }
}
