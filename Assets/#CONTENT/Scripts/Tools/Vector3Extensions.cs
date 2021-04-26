using UnityEngine;

// extends Vector3 
public static class Vector3Extensions 
{
    // takes optional params, accessible with x: 
    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        // if x = null, take original.x
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }
    public static Vector3 DirectionTo(this Vector3 source, Vector3 destination)
    {
        return Vector3.Normalize(destination - source);
    }
}
