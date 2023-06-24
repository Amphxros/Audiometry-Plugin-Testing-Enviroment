using System;
using System.IO;
using Newtonsoft.Json;
using Telemetry.Events;

namespace TelemetryProcess
{
    class Program
    {
        static void processEvent(Event ev) { 
        //Aquí se hace la magia
        }
        static void deserializeFile(string archivo)
        {
            using (StreamReader sr = new StreamReader(archivo))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    try
                    {
                        Event ev = JsonConvert.DeserializeObject<Event>(linea);
                        processEvent(ev);
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Error al deserializar línea: {ex.Message}");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string directorio = "../../../../Telemetry"; // Reemplaza con la ruta del directorio que deseas procesar

            string[] archivosJson = Directory.GetFiles(directorio, "*.json");

            foreach (string archivo in archivosJson)
            {
                deserializeFile(archivo);
            }
        }

       
    }
}
