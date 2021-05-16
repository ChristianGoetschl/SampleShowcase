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

    public void SwitchToACAsset() => SwitchToAddressable(_acAsset);
    public void SwitchToLegacyAsset() => SwitchToAddressable(_legacyAnimAsset);
    public void SwitchToScriptAsset() => SwitchToAddressable(_scriptAsset);

    private void SwitchToAddressable(AssetReference newAssetRef)
    {
        _spawner.ObjectToSpawn = newAssetRef;
        _spawner.SpawnObjects();
    }
}
