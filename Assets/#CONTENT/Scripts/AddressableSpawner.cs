using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableSpawner : MonoBehaviour
{
    public AssetReference ObjectToSpawn;

    [SerializeField] private int _spawnRows = 5;
    [SerializeField] private int _spawnColumns = 5;
    [SerializeField] private float _rowOffset = 1f;
    [SerializeField] private float _columnOffset = 1f;

    private AsyncOperationHandle _loadOperationHandle;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    public float GetLoadingProgress() {
        if (!_loadOperationHandle.IsValid()) return 0f;
        return _loadOperationHandle.PercentComplete;
    }

    public float GetInstantiateProgress()
    {
        if (!_loadOperationHandle.IsValid() || _spawnedObjects.Count < 1) return 0f;
        return _spawnedObjects.Count / (_spawnRows * _spawnColumns);
    }

    public int ObjectCount() => _spawnedObjects.Count;

    [ContextMenu("Spawn objects")]
    public void SpawnObjects()
    {
        if (_spawnedObjects.Count > 0) DeSpawnObjects();
        if (!ObjectToSpawn.RuntimeKeyIsValid()) return;

        // load object
        _loadOperationHandle = Addressables.LoadAssetAsync<GameObject>(ObjectToSpawn);
        _loadOperationHandle.Completed += (operation) =>
        {
            Vector3 spawnPos;
            // then instantiate
            for (int i = 0; i < _spawnColumns * _spawnRows; i++)
            {
                spawnPos = transform.position + i % _spawnColumns * transform.right * _columnOffset + i / _spawnColumns * transform.forward * _rowOffset;
                ObjectToSpawn.InstantiateAsync(spawnPos, Quaternion.identity, transform).Completed += (asyncOpHandle) =>
                {
                    _spawnedObjects.Add(asyncOpHandle.Result);
                };
            }
        };
    }

    [ContextMenu("Despawn opbjects")]
    public void DeSpawnObjects()
    {
        foreach (GameObject go in _spawnedObjects)
        {
            Addressables.ReleaseInstance(go);
            Destroy(go);
        }
        _spawnedObjects.Clear();

        Addressables.Release(_loadOperationHandle);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 spawnPos;
        for (int i = 0; i < _spawnColumns * _spawnRows; i++)
        {
            spawnPos = transform.position + i % _spawnColumns * transform.right * _columnOffset + i / _spawnColumns * transform.forward * _rowOffset;
            Gizmos.DrawWireCube(spawnPos, transform.lossyScale);
        }
    }
}
