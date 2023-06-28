using System;
using System.IO;
using Newtonsoft.Json;
using Telemetry.Events;

namespace TelemetryProcess
{
    class Program
    {
        //Variables para estadisticas totales
        static int partidas = 0;

        //Grupo A
        static int partidasA = 0;
        static long tiempoPartidasA = 0;
        static int disparosA = 0;
        static int danoRecibidoA = 0;
        static int danoRealizadoA = 0;
        static int killsA = 0;
        static int alertasA = 0;

        //Grupo B
        static int partidasB = 0;
        static long tiempoPartidasB = 0;
        static int disparosB = 0;
        static int danoRecibidoB = 0;
        static int danoRealizadoB = 0;
        static int killsB= 0;
        static int alertasB = 0;

        //Variables partida actual
        static bool audiometria = false;
        static long initTime = 0;
        static long endTime = 0;

        static void generateStats() {

            using (StreamWriter archivo = new StreamWriter("data.txt"))
            {
                archivo.WriteLine("DATOS");
                archivo.WriteLine("Partidas: " + partidas);
                archivo.WriteLine("Partidas grupo A: " + partidasA);
                archivo.WriteLine("Partidas grupo B: " + partidasB);
                archivo.WriteLine("ESTADISTICAS GRUPO A:");
                archivo.WriteLine("Tiempo promedio: " + (tiempoPartidasA / partidasA) + "s");
                archivo.WriteLine("Daño recibido promedio: " + (danoRecibidoA / partidasA));
                archivo.WriteLine("Daño realizado promedio: " + (danoRealizadoA / partidasA));
                archivo.WriteLine("Disparos realizados promedio: " + (disparosA / partidasA));
                archivo.WriteLine("Asesinatos promedio: " + (killsA / partidasA));
                archivo.WriteLine("Alertas promedio: " + (alertasA / partidasA));
                archivo.WriteLine("ESTADISTICAS GRUPO B:");
                archivo.WriteLine("Tiempo promedio: " + (tiempoPartidasB / partidasB) + "s");
                archivo.WriteLine("Daño recibido promedio: " + (danoRecibidoB / partidasB));
                archivo.WriteLine("Daño realizado promedio: " + (danoRealizadoB / partidasB));
                archivo.WriteLine("Disparos realizados promedio: " + (disparosB / partidasB));
                archivo.WriteLine("Asesinatos promedio: " + (killsB / partidasB));
                archivo.WriteLine("Alertas promedio: " + (alertasB / partidasB));


                archivo.Close();
            }

        }
        static void processEvent(Event ev) {
            switch (ev._data["Event"]) {
                case "GameStart":
                    initTime = ev._timeStamp;
                    break;
                case "GameEnd":
                    endTime = ev._timeStamp;
                    break;
                case "PluginConfig":
                    audiometria = true;
                    break;
                case "GunShot":
                    if (!audiometria) disparosB++;
                    else disparosA++;
                    break;
                case "PlayerHurt":
                    if (!audiometria) danoRecibidoB++;
                    else danoRecibidoA++;
                    break;
                case "EnemyHurt":
                    if (!audiometria) danoRealizadoB++;
                    else danoRealizadoA++;
                    break;
                case "EnemyDead":
                    if (!audiometria) killsB++;
                    else killsA++;
                    break;
                case "EnemyAlert":
                    if (!audiometria) alertasB++;
                    else alertasA++;
                    break;
                default:
                    break;

            }
        }
        static void deserializeFile(string archivo)
        {
            partidas++;
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

            if (!audiometria)
            {
                partidasB++;
                tiempoPartidasB += (endTime - initTime)/1000;
            }
            else {
                partidasA++;
                tiempoPartidasA += (endTime - initTime)/1000;
            }

            audiometria = false;
        }

        static void Main(string[] args)
        {
            string directorio = "../../../../Telemetry"; // Reemplaza con la ruta del directorio que deseas procesar

            string[] archivosJson = Directory.GetFiles(directorio, "*.json");

            foreach (string archivo in archivosJson)
            {
                deserializeFile(archivo);
            }

            generateStats();
        }

       
    }
}
