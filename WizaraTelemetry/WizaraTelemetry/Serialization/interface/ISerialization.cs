using System;


namespace WizaraTelemetry
{
    public interface ISerializer
    {
        /// <summary>
        /// Serializes a tracking event
        /// </summary>
        /// <returns> the data of the event formatted</returns>
        object Serialize(/*TrackingEvent ev*/);
        
        /// <returns>the format of the data (.json, .csv, .xml...)</returns>
        string GetExtension();
    }
}