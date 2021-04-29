using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Tooltip("Rotation speed in degress per second")]
    [SerializeField] private float _speed = 50f;

    [SerializeField] private bool _xAxis = false;
    [SerializeField] private bool _yAxis = true;
    [SerializeField] private bool _zAxis = false;

    [SerializeField] private Space _space = Space.World;

    private void Update()
    {
        float angle = _speed * Time.deltaTime;
        transform.Rotate(_xAxis ? angle : 0f, _yAxis ? angle : 0f, _zAxis ? angle : 0f, _space);
    }
}
