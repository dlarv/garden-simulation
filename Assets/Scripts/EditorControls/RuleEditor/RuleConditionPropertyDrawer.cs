using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

//[CustomPropertyDrawer(typeof(RuleCondition))]
public class RuleConditionEditor : PropertyDrawer
{
    [SerializeField]
    bool[] targets = new bool[9];

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //position = new Rect(position.x, position.y, position.height * 4, position.width);
        EditorGUI.BeginProperty(position, label, property);

        // Calculate rects
        float width = position.width / 4;
        float height = position.height;
        var targetsRect = new Rect(position.x, position.y, width, height);
        var colorRect = new Rect(position.x + width, position.y, width, position.height);
        var opRect = new Rect(position.x + 2 * width, position.y, width, position.height);
        var quantityRect = new Rect(position.x + 3 * width, position.y, width, position.height);

        // Draw rule condition creation menu.
        // Pass in x position of button so popup opens nearby.
        //if (EditorGUI.DropdownButton(targetsRect, GUIContent.none, FocusType.Keyboard))
        // Init();
        //DrawToggleGrid(targetsRect);
        EditorGUI.PropertyField(targetsRect, property.FindPropertyRelative("targets"), GUIContent.none);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(colorRect, property.FindPropertyRelative("color"), GUIContent.none);
        EditorGUI.PropertyField(opRect, property.FindPropertyRelative("op"), GUIContent.none);
        EditorGUI.PropertyField(quantityRect, property.FindPropertyRelative("quantity"), GUIContent.none);

        EditorGUI.EndProperty();
    }

    void DrawToggleGrid(Rect rect)
    {
        float offset = 18;
        float width = rect.width / 3.5f;
        float height = rect.height / 3.5f;

        void DrawToggleRow(int startIndex, Rect rect)
        {
            targets[startIndex] = GUI.Toggle(
                rect, 
                targets[startIndex], 
                GUIContent.none);
            targets[startIndex + 1] = GUI.Toggle(
                new Rect(rect.x + offset, rect.y, rect.width, rect.height),
                targets[startIndex + 1],
                GUIContent.none);
            targets[startIndex + 2] = GUI.Toggle(
                new Rect(rect.x + 2*offset, rect.y, rect.width, rect.height),
                targets[startIndex + 2],
                GUIContent.none);
        }

        DrawToggleRow(0, new Rect(rect.x, rect.y, width, height));
        DrawToggleRow(3, new Rect(rect.x, rect.y + offset, width, height));
        DrawToggleRow(6, new Rect(rect.x, rect.y + 2* offset, width, height));
    }
}