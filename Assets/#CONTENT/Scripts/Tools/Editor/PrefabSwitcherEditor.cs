using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabSwitcher))]
[CanEditMultipleObjects]
public class PrefabSwitcherEditor : Editor
{
    private PrefabSwitcher _target;

    private void OnEnable()
    {
        _target = target as PrefabSwitcher;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Swap"))
            ExchangePrefab();
    }

    [ContextMenu("Switch now")]
    public void ExchangePrefab()
    {
        if (_target == null) return;

        if (_target.NewPrefab == null)
        {
            Debug.LogWarning("No prefab set to switch out for");
            return;
        }

        // instantiate the new prefab
        GameObject newObj = PrefabUtility.InstantiatePrefab(_target.NewPrefab, _target.transform.parent) as GameObject;
        newObj.transform.position = _target.transform.position;
        newObj.transform.rotation = _target.transform.rotation;
        newObj.transform.localScale = _target.transform.localScale;
        newObj.transform.SetSiblingIndex(_target.transform.GetSiblingIndex());

        // set dirty so unity knows to save it even within another prefab
        EditorUtility.SetDirty(_target);

        // destroy the old one (breaks usage in prefabs -> delete manually for now)
        DestroyImmediate(_target.gameObject);
    }
}
