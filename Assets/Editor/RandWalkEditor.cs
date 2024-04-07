using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(AbstractDungeon), true)]
public class RandWalkEditor : Editor
{
    AbstractDungeon generator;

    private void Awake()
    {
        generator = (AbstractDungeon)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create"))
        {
            generator.createDungeon();
        }
    }

}
