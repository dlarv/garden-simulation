using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//[CustomPropertyDrawer(typeof(Rule))]
public class RulePropertyDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property.FindPropertyRelative("conditions"), GUIContent.none);
        EditorGUI.LabelField(new Rect(position.x, position.y * 4, position.width, position.height),"");
    }
}
