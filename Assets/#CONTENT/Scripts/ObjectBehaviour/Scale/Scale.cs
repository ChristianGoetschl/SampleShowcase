using UnityEngine;

public abstract class Scale : MonoBehaviour
{
    [SerializeField] protected AnimationCurve _xAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [SerializeField] protected AnimationCurve _yAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [SerializeField] protected AnimationCurve _zAxis = AnimationCurve.Constant(0f, 1f, 0f);

    protected Vector3 _originScale;
    protected float _xLength = 0f;
    protected float _yLength = 0f;
    protected float _zLength = 0f;

    protected virtual void Start()
    {
        _originScale = transform.localScale;

        _xLength = _xAxis.length == 0 ? 0f : _xAxis.keys[_xAxis.length - 1].time;
        _yLength = _yAxis.length == 0 ? 0f : _yAxis.keys[_yAxis.length - 1].time;
        _zLength = _zAxis.length == 0 ? 0f : _zAxis.keys[_zAxis.length - 1].time;
    }

    protected void SetScaleAt(float progress)
    {
        Vector3 localScaling = Vector3.zero;

        localScaling.x = EvaluateState(progress, ref _xAxis, _xLength);
        localScaling.y = EvaluateState(progress, ref _yAxis, _yLength);
        localScaling.z = EvaluateState(progress, ref _zAxis, _zLength);

        transform.localScale = _originScale + localScaling;
    }

    protected abstract float EvaluateState(float progress, ref AnimationCurve animCurve, float length);
}
