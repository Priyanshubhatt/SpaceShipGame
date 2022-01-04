using Godot;
using System;
using System.Collections.Generic;

public interface IActiveSensors
{
    List<EMSReading> PerformScan (float globalAngle, float arcRadians, float range);
    //float EMSInterferenceScale {get;}
    float GConstant {get;}
}
