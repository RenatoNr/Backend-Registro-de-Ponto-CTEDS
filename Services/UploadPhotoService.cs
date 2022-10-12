
namespace Registro_de_Ponto_CTEDS.Services
{
    //Classe provisória para gravar imagem do funcionário localmente
    public class UploadPhotoService
    {
 string strFileName;

        string fileFolder = "Uploads/Photos";



        public static string SaveFile(IFormFile file)
        {
            string strFilePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = System.IO.File.Create(strFilePath))
                {
                    file.CopyToAsync(stream);
                }

                
            }
            return strFilePath;
        }

    }
}
