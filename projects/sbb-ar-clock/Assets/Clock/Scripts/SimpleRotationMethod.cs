using System;
using UnityEngine;

public class SimpleRotationMethod : MonoBehaviour, Clock.RotationMethod
{
    public Clock.HandRotation GetHandRotationForTime(TimeSpan timeSinceMidnight)
    {
        double minutesSinceMidnight = timeSinceMidnight.TotalMinutes; // decimal: e.g. 823.384
        double hoursSinceMidnight = timeSinceMidnight.TotalHours; // decimal: e.g. 19.290

        // Exercise:
        var rotationSeconds = minutesSinceMidnight % 60;
        var rotationMinutes = hoursSinceMidnight % 60;
        var rotationHours = hoursSinceMidnight / 12;

        return new Clock.HandRotation
        {
            s = (float) rotationSeconds,
            m = (float) rotationMinutes,
            h = (float) rotationHours
        };
    }
}