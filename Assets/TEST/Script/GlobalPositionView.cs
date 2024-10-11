using UnityEngine;
using UnityEditor;
using System.Collections;

public class GlobalPositionView : Editor
{
    [MenuItem("GameObject/Global Transform/Position", false, 10)]
    public static void ViewPosition()
    {
        var g = Selection.activeGameObject;

        if (g)
        {
            Debug.Log(g.transform.position);
        }
    }

    [MenuItem("GameObject/Global Transform/Rotation", false, 10)]
    public static void ViewRotation()
    {
        var g = Selection.activeGameObject;

        if (g)
        {
            Debug.Log(g.transform.rotation.eulerAngles);
        }
    }

    [MenuItem("GameObject/Global Transform/Scale", false, 10)]
    public static void ViewScale()
    {
        var g = Selection.activeGameObject;

        if (g)
        {
            Debug.Log(g.transform.lossyScale);
        }
    }

    [MenuItem("GameObject/Global Transform/Path", false, 10)]
    public static void ViewPath()
    {
        var g = Selection.activeGameObject;

        if (g)
        {
            string path = g.name;
            Transform t = g.transform;
            while (t.parent)
            {
                t = t.parent;
                path = t.name + "/" + path;
            }
            Debug.Log(path);
        }
    }
}