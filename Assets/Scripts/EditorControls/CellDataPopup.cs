using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CellDataPopup : PopupWindowContent
{
    public CellDataPopup(Color color)
    {
        this.color = color;
    }
    private readonly float HEIGHT = 30f;
    public Color color;

    public override void OnGUI(Rect rect)
    {
        GUILayout.Label("CellData");
        Rect colorRect = new(rect.x, rect.y + HEIGHT, rect.width, rect.height / 10f);
        color = EditorGUILayout.ColorField("", color, GUILayout.Width(50));
        //EditorGUI.PropertyField(colorRect, property.FindPropertyRelative("color"));
    }
}

