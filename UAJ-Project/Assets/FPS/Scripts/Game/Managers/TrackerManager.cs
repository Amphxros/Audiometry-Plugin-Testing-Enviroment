using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Telemetry;
using Telemetry.Events;
using System;

namespace Unity.FPS.Game
{
    public class TrackerManager : MonoBehaviour
    {
        
        private static Tracker tracker;

        private static void Awake()
        {

            string dataPath = Application.dataPath + "/" + "data/";

            //Creamos un "id" unico por prueba para generar un archivo distinto por sesion
            DateTime dtfoo = new DateTime(2010, 10, 20);
            DateTimeOffset dtfoo2 = new DateTimeOffset(dtfoo).ToUniversalTime();
            long afoo = dtfoo2.ToUnixTimeMilliseconds();

            tracker = Telemetry.Tracker.Instance("AudiometryTest", Telemetry.Persistance.PersistanceType.File, Telemetry.Serialization.SerializeType.JSON, dataPath + "AudiometryTest" + afoo);
            tracker.init();
           
        }

         public static Telemetry.Tracker getTracker()
         {
             return tracker;
         }

    }       
}