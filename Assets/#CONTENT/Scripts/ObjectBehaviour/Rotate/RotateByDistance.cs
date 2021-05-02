using UnityEngine;

public class RotateByDistance : Rotate
{
    [SerializeField] private Transform _originTarget = null;
    [SerializeField] private Transform _distanceTarget = null;

    [SerializeField] private float _innerRadius = 2f;
    [SerializeField] private float _outerRadius = 10f;

    protected override void Start()
    {
        if (_originTarget == null || _distanceTarget == null) { enabled = false; return; }
        base.Start();
    }

    protected void Update()
    {
        // remap distance to progress ratio
        float progressRatio = (Vector3.Distance(transform.position, _distanceTarget.position) - _innerRadius) / _outerRadius;
        SetRotationAt(1f - progressRatio);
    }

    protected override float EvaluateState(float progress, ref AnimationCurve animCurve, float length)
    {
        if (length == 0f) return 0f;
        progress = Mathf.Clamp01(progress);
        return animCurve.Evaluate(progress * length) * Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        if (_originTarget == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_originTarget.position, _innerRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_originTarget.position, _outerRadius);
    }
}
