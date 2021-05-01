using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _ratioOffset = 0f;

    [Tooltip("Rotation speed on the x-axis in degress per second")]
    [SerializeField] private AnimationCurve _xAxis = AnimationCurve.Constant(0f, 1f, 0f);
    [Tooltip("Rotation speed on the y-axis in degress per second")]
    [SerializeField] private AnimationCurve _yAxis = AnimationCurve.Constant(0f, 1f, 60f);
    [Tooltip("Rotation speed on the z-axis in degress per second")]
    [SerializeField] private AnimationCurve _zAxis = AnimationCurve.Constant(0f, 1f, 0f);

    [SerializeField] private Space _space = Space.World;

    private float _xLength = 0f;
    private float _yLength = 0f;
    private float _zLength = 0f;

    private void Start()
    {
        _xLength = _xAxis.length == 0 ? 0f : _xAxis.keys[_xAxis.length - 1].time;
        _yLength = _yAxis.length == 0 ? 0f : _yAxis.keys[_yAxis.length - 1].time;
        _zLength = _zAxis.length == 0 ? 0f : _zAxis.keys[_zAxis.length - 1].time;
    }

    private void Update()
    {
        float newXSpeed = _xLength == 0f ? 0f : _xAxis.Evaluate((Time.time + (_ratioOffset * _xLength)) % _xLength) * Time.deltaTime;
        float newYSpeed = _yLength == 0f ? 0f : _yAxis.Evaluate((Time.time + (_ratioOffset * _yLength)) % _yLength) * Time.deltaTime;
        float newZSpeed = _zLength == 0f ? 0f : _zAxis.Evaluate((Time.time + (_ratioOffset * _zLength)) % _zLength) * Time.deltaTime;

        transform.Rotate(newXSpeed, newYSpeed, newZSpeed, _space);
    }
}
