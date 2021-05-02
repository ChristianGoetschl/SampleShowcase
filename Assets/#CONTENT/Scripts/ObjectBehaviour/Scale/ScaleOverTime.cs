using UnityEngine;

public class ScaleOverTime : Scale
{
    [Range(0f, 1f)]
    [SerializeField] private float _ratioOffset = 0f;

    private void Update()
    {
        SetScaleAt(Time.time);
    }

    protected override float EvaluateState(float progress, ref AnimationCurve animCurve, float length)
    {
        if (length == 0f) return 0f;
        return animCurve.Evaluate((progress + (_ratioOffset * length)) % length);
    }
}
