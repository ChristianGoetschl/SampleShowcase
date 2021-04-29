using UnityEngine;

public class Slide : MonoBehaviour
{
    [SerializeField] private AnimationCurve _xAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [SerializeField] private AnimationCurve _yAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [SerializeField] private AnimationCurve _zAxis = AnimationCurve.Constant(0f, 1f, 0f);

    private Vector3 _originPos;
    private float _xLength = 0f;
    private float _yLength = 0f;
    private float _zLength = 0f;

    private void Start()
    {
        _originPos = transform.position;

        _xLength = _xAxis.length == 0 ? 0f : _xAxis.keys[_xAxis.length - 1].time;
        _yLength = _yAxis.length == 0 ? 0f : _yAxis.keys[_yAxis.length - 1].time;
        _zLength = _zAxis.length == 0 ? 0f : _zAxis.keys[_zAxis.length - 1].time;
    }

    private void Update()
    {
        float newX = _xLength == 0f ? 0f : _xAxis.Evaluate(Time.time % _xLength);
        float newY = _yLength == 0f ? 0f : _yAxis.Evaluate(Time.time % _yLength);
        float newZ = _zLength == 0f ? 0f : _zAxis.Evaluate(Time.time % _zLength);

        transform.position = _originPos + new Vector3(newX, newY, newZ);
    }
}
