using UnityEngine;

public abstract class Rotate : MonoBehaviour
{
    [Tooltip("Rotation speed on the x-axis in degress per second")]
    [SerializeField] protected AnimationCurve _xAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [Tooltip("Rotation speed on the y-axis in degress per second")]
    [SerializeField] protected AnimationCurve _yAxis = AnimationCurve.Constant(0f, 1f, 60f);
    [Tooltip("Rotation speed on the z-axis in degress per second")]
    [SerializeField] protected AnimationCurve _zAxis = AnimationCurve.Constant(0f, 1f, 0f);

    [SerializeField] private Space _space = Space.World;

    protected float _xLength = 0f;
    protected float _yLength = 0f;
    protected float _zLength = 0f;

    protected virtual void Start()
    {
        _xLength = _xAxis.length == 0 ? 0f : _xAxis.keys[_xAxis.length - 1].time;
        _yLength = _yAxis.length == 0 ? 0f : _yAxis.keys[_yAxis.length - 1].time;
        _zLength = _zAxis.length == 0 ? 0f : _zAxis.keys[_zAxis.length - 1].time;
    }

    protected void SetRotationAt(float progress)
    {
        float newXSpeed = EvaluateState(progress, ref _xAxis, _xLength);
        float newYSpeed = EvaluateState(progress, ref _yAxis, _yLength);
        float newZSpeed = EvaluateState(progress, ref _zAxis, _zLength);

        transform.Rotate(newXSpeed, newYSpeed, newZSpeed, _space);
    }

    protected abstract float EvaluateState(float progress, ref AnimationCurve animCurve, float length);
}
