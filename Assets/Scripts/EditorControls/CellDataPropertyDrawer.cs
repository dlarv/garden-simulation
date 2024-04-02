using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(CellData))]
public class CellDataPropertyDrawer : PropertyDrawer
{
    CellData data;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        CellDataPopup popup = new(property.FindPropertyRelative("color").colorValue);
        if (EditorGUI.DropdownButton(position, GUIContent.none, FocusType.Passive))
        {
            UnityEditor.PopupWindow.Show(position, popup);
            //popup.ed
            //popup.ShowAsDropDown(position, new Vector2(100f, 100f));
            

        }
        property.FindPropertyRelative("color").colorValue = popup.color;
            Debug.Log(popup.color);
        EditorGUI.EndProperty();
    }


}
