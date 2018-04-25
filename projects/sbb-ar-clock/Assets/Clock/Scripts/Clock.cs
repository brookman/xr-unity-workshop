using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public struct HandRotation
    {
        public float s;
        public float m;
        public float h;
    }

    public interface RotationMethod
    {
        HandRotation GetHandRotationForTime(TimeSpan timeSinceMidnight);
    }

    public Transform SecondHandFront;
    public Transform MinuteHandFront;
    public Transform HourHandFront;
    public Transform SecondHandBack;
    public Transform MinuteHandBack;
    public Transform HourHandBack;

    private RotationMethod HandRotationMethod;

    void Start()
    {
        HandRotationMethod = GetComponent<RotationMethod>();
    }

    void Update()
    {
        var time = TimeProvider.GetTime();

        if (HandRotationMethod != null)
        {
            var handRotation = HandRotationMethod.GetHandRotationForTime(time);

            SecondHandFront.localRotation = Quaternion.Euler(0, 0, handRotation.s * 360);
            MinuteHandFront.localRotation = Quaternion.Euler(0, 0, handRotation.m * 360);
            HourHandFront.localRotation = Quaternion.Euler(0, 0, handRotation.h * 360);

            SecondHandBack.localRotation = Quaternion.Euler(0, 0, handRotation.s * 360);
            MinuteHandBack.localRotation = Quaternion.Euler(0, 0, handRotation.m * 360);
            HourHandBack.localRotation = Quaternion.Euler(0, 0, handRotation.h * 360);
        }
    }
}