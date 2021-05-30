using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private LookAtMode _mode = LookAtMode.YAxisOnly;

    private enum LookAtMode
    {
        AllAxis,
        YAxisOnly
    }

    private Transform _mainCamTransform;

    private void Awake()
    {
        _mainCamTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (_mode == LookAtMode.AllAxis)
            transform.LookAt(_mainCamTransform);
        else if (_mode == LookAtMode.YAxisOnly)
        {
            Vector3 lookDir = _mainCamTransform.position - transform.position;
            lookDir.y = 0f;
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
