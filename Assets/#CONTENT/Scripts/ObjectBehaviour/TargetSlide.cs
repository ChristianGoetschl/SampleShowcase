using UnityEngine;

public class TargetSlide : MonoBehaviour
{
    [Tooltip("Target gameObject which will be destroyed on Start")]
    [SerializeField] private Transform _target = null;
    [SerializeField] private AnimationCurve _speedCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    private Vector3 _originPos;
    private Vector3 _targetPos;

    private float _currentState = 0f;
    private float _targetState = 0f;
    private float _animDuration = 1f;

    private void Awake()
    {
        _originPos = transform.position;
        _targetPos = _target.position;
        _animDuration = _speedCurve.keys[_speedCurve.length - 1].time;
    }

    private void Update()
    {
        if (Mathf.Abs(_targetState - _currentState) < Time.deltaTime) _currentState = _targetState;
        else
        {
            if (_targetState > _currentState)
                _currentState += Time.deltaTime;
            else if (_targetState < _currentState)
                _currentState -= Time.deltaTime;
        }

        transform.position = Vector3.Lerp(_originPos, _targetPos, _speedCurve.Evaluate(_currentState));
    }

    [ContextMenu("Move to target")]
    public void MoveToTarget() => _targetState = _animDuration;

    [ContextMenu("Reset movement")]
    public void ResetMovement() => _targetState = 0f;
}
