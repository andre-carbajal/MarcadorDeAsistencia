using MarcadorDeAsistencia.DTO;
using MarcadorDeAsistencia.Response;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarcadorDeAsistencia.Clases
{
    internal class FaceDetectionService
    {
        private const string url = "http://localhost:5000";

        private static readonly HttpClient client = new HttpClient();
        private Bitmap lastFrame;
        private string idEmpleado;

        public void SetFrame(Bitmap frame)
        {
            lastFrame = frame;
        }

        public void SetIdEmpleado(string id)
        {
            idEmpleado = id;
        }

        public async Task<RecognizeResponse> DetectPerson()
        {
            try
            {
                await Task.Delay(1000);

                string base64Image = ConvertImageToBase64(lastFrame);
                Console.WriteLine($"{base64Image}");

                var dto = new RecognizeDto
                {
                    image = base64Image,
                    id_empleado = idEmpleado
                };

                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url + "/recognize", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var detectionResult = JsonConvert.DeserializeObject<RecognizeResponse>(responseContent);

                    return detectionResult;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        private string ConvertImageToBase64(Bitmap image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

    }
}
