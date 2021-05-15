using UnityEngine;
using UnityEngine.UI;

public class PerformanceDisplay : MonoBehaviour
{
    [SerializeField] private AddressableSpawner _spawner = null;
    [SerializeField] private Image _loadProgressbar_img = null;
    [SerializeField] private Image _instProgressbar_img = null;
    [SerializeField] private TMPro.TextMeshProUGUI _titleTxt = null;
    [SerializeField] private TMPro.TextMeshProUGUI _loadTxt = null;
    [SerializeField] private TMPro.TextMeshProUGUI _instTxt = null;

    private void Update()
    {
        float loadProgress = _spawner.GetLoadingProgress();
        float instantiateProgress = _spawner.GetInstantiateProgress();

        _loadProgressbar_img.fillAmount = loadProgress;
        _instProgressbar_img.fillAmount = instantiateProgress;

        if (loadProgress == 0f)
            _loadTxt.text = "Not loaded";
        else if (loadProgress < 1f)
            _loadTxt.text = "Loading...";
        else
            _loadTxt.text = "Finished loading";

        if (instantiateProgress == 0f)
            _instTxt.text = "Nothing instantiated";
        else
            _instTxt.text = "Objects instantiated: " + _spawner.ObjectCount();
    }

    public void SetTitle(string newTitle)
    {
        _titleTxt.text = newTitle;
    }
}
