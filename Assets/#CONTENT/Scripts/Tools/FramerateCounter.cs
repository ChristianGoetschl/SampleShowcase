using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class FramerateCounter : MonoBehaviour
{
    [SerializeField] private float _hudRefreshRate = 1f;

    private TMPro.TextMeshProUGUI _label;
    private float _timer;
    private int _fps = 0;
    private bool _display = true;

    private void Awake()
    {
        _label = GetComponent<TMPro.TextMeshProUGUI>();
        _label.enabled = enabled;
    }

    private void Start()
    {
        _display = _label.enabled;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F))
        {
            _display = !_display;
            _label.enabled = _display;
        }
#endif

        if (_display)
            ShowFPS();
    }

    private void ShowFPS()
    {
        if (Time.unscaledTime > _timer)
        {
            _fps = (int)(1f / Time.unscaledDeltaTime);

            _label.text = _fps + " FPS";
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
