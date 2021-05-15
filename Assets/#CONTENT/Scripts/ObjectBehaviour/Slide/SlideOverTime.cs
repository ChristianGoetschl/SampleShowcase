using UnityEngine;

public class SlideOverTime : Slide
{
    [SerializeField] private float _timeMultiplier = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _ratioOffset = 0f;

    protected virtual void Update()
    {
        SetSlideAt(Time.time * _timeMultiplier);
    }

    protected override float EvaluateState(float progress, ref AnimationCurve animCurve, float length)
    {
        if (length == 0f) return 0f;
        return animCurve.Evaluate((progress + (_ratioOffset * length)) % length);
    }
}
