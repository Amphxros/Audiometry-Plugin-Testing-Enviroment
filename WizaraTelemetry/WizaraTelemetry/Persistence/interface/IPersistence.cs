
namespace WizaraTelemetry
{
    public interface IPersistance
    {
        /// <summary>
        /// Sets the format of the data that it's gonna be persisted
        /// </summary>
        /// <param name="serializer"></param>
        void setSerializer(ISerializer serializer);
        /// <summary>
        /// Persists an event in their media(file, server...)
        /// </summary>
        void PersistEvent(/*TrackingEvent ev*/);
    }
}