using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ColorfulAttribute : PropertyAttribute {
    public ColorfulAttribute () {

    }
}

[CustomPropertyDrawer (typeof (ColorfulAttribute))]
public class ColorfulDrawer : PropertyDrawer {
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
        var color = GUI.backgroundColor;
        GUI.backgroundColor = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
        EditorGUI.PropertyField (position, property, label);
        GUI.backgroundColor = color;
    }
}
