using UnityEngine;
using UnityEngine.AddressableAssets;

[RequireComponent(typeof(AddressableSpawner))]
public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private AssetReference _acAsset = null;
    [SerializeField] private AssetReference _legacyAnimAsset = null;
    [SerializeField] private AssetReference _scriptAsset = null;

    private AddressableSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<AddressableSpawner>();
    }

    private void Update()
    {
        // read hotkey input
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToACAsset();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToLegacyAsset();
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchToScriptAsset();

        if (Input.GetKeyDown(KeyCode.Space)) _spawner.SpawnObjects();
        if (Input.GetKeyDown(KeyCode.Backspace)) _spawner.DeSpawnObjects();
    }

    public void SwitchToACAsset() => _spawner.ObjectToSpawn = _acAsset;
    public void SwitchToLegacyAsset() => _spawner.ObjectToSpawn = _legacyAnimAsset;
    public void SwitchToScriptAsset() => _spawner.ObjectToSpawn = _scriptAsset;
}
