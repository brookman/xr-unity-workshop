using UnityEngine;

public class SbbClock : MonoBehaviour
{
    public Transform SecondHandFront;
    public Transform MinuteHandFront;
    public Transform HourHandFront;

    public Transform SecondHandBack;
    public Transform MinuteHandBack;
    public Transform HourHandBack;

    void Update()
    {
        float sekundenSprungDuration = 1.5f;
        float minuteHandTransitionDuration = 0.5f;

        var time = TimeProvider.GetTime();

        var minutesOfHourFloat = (float) (time.TotalMinutes % 60.0f);
        var minutesOfHour = (int) minutesOfHourFloat;

        var s = Mathf.Min((float) (time.TotalSeconds % 60.0f) / (60.0f - sekundenSprungDuration), 1.0f) * 360.0f;
        var m = LerpOutExpo(minutesOfHour - 1, minutesOfHour, minutesOfHourFloat - minutesOfHour, minuteHandTransitionDuration / 60f) / 60.0f * 360.0f;
        var h = (float) (time.TotalHours % 12.0f) / 12.0f * 360;

        SecondHandFront.localRotation = Quaternion.Euler(0, 0, s);
        MinuteHandFront.localRotation = Quaternion.Euler(0, 0, m);
        HourHandFront.localRotation = Quaternion.Euler(0, 0, h);

        SecondHandBack.localRotation = Quaternion.Euler(0, 0, s);
        MinuteHandBack.localRotation = Quaternion.Euler(0, 0, m);
        HourHandBack.localRotation = Quaternion.Euler(0, 0, h);
    }

    private static float LerpOutExpo(float from, float to, float t, float d)
    {
        if (t <= 0) return from;
        if (t >= d) return to;

        return (to - from) * (-Mathf.Pow(2, -10 * t / d) + 1) + from;
    }
}