using UnityEngine;

public class DrawTargetGizmo : MonoBehaviour
{
    [SerializeField] private Color _gizmoColor = Color.white;
    [SerializeField] private Shape _shape = Shape.Cube;
    [SerializeField] private bool _destroyOnStart = true;

    private enum Shape
    {
        Cube,
        Sphere,
        Mesh
    }

    private void Start()
    {
        if (_destroyOnStart) Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _gizmoColor;

        if (_shape == Shape.Cube)
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        else if (_shape == Shape.Sphere)
            Gizmos.DrawWireSphere(transform.position, transform.lossyScale.magnitude);
        else if (_shape == Shape.Mesh)
        {
            MeshFilter meshFilter = GetComponentInParent<MeshFilter>();
            if (meshFilter != null)
                Gizmos.DrawWireMesh(meshFilter.sharedMesh, transform.position);
        }
    }
}
