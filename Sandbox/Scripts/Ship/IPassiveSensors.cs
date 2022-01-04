using Godot;
using System;
using System.Collections.Generic;

public interface IPassiveSensors
{
    List<PassiveSensorReading> PassiveReadings {get;}
    float InterferenceScale {get;}
    float GConstant {get;}
}
