using UnityEngine;
using UnityEngine.AI;

public static class ExtenstionMethods
{
    public static bool GetPathTo(this NavMeshPath path, Vector3 fromPos, Vector3 toPos, int passableMask)
    {
        path.ClearCorners();
        return NavMesh.CalculatePath(fromPos, toPos, passableMask, path);
    }
    public static float GetPathLength(this NavMeshPath path)
    {
        if ((path.status == NavMeshPathStatus.PathInvalid) || (path.corners.Length <= 1))
        {
            return -1f;
        }
        
        float lng = 0f;
        for (int i = 1; i < path.corners.Length; ++i)
        {
            lng += Vector3.Distance(path.corners[i-1], path.corners[i]);
        }
        return lng;
    }
}
