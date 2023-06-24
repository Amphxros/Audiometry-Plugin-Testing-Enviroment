using System;

namespace Telemetry.Events
{
    /// <summary>
    /// All the events are numbered here
    /// </summary>
    public enum EventType
    {
        //basic events
        StartTracking,  //
        StopTracking,   //
        SessionStart,   //
        SessionEnd,     //
        GameStart,      //
        GameEnd,        //
        LevelStart,     //
        LevelEnd,       //
        GamePaused,     //
        GameResumed,    //
       
        //Wizara Events
        StartPuzzle,    //
        EndPuzzle,      //
        PlayerDamaged,  //
        PlayerDead,     //
        ItemDropped,    //
        ItemPicked,     //
        AbilityCasted,  //
        AbilityHit,     //

        //More events here
        
        numOfEvents
    }
}
