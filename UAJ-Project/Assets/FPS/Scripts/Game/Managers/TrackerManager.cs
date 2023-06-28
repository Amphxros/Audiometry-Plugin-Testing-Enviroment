using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Telemetry;
using Telemetry.Events;

namespace Unity.FPS.Game
{
    public class TrackerManager : MonoBehaviour
    {
        
        private static Tracker tracker;

        private static void Awake()
        {

            string dataPath = Application.dataPath + "/" + "data/";
            tracker = Telemetry.Tracker.Instance("AudiometryTest", Telemetry.Persistance.PersistanceType.File, Telemetry.Serialization.SerializeType.JSON, dataPath + "AudiometryTest");
            tracker.init();
           
        }

         public static Telemetry.Tracker getTracker()
         {
             return tracker;
         }

    }       
}