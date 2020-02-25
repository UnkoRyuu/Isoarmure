using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (fieldOfview))]
public class fielOfviewEditor : Editor
{
    private void OnSceneGUI()
    {
        fieldOfview fow = (fieldOfview)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
    }
}
