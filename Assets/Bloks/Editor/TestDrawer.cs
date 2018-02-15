using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(TestAttribute))]
public class TestDrawer : PropertyDrawer
{
    TestAttribute TestAttribute { get { return (TestAttribute)attribute; } }

    const int TextHeight = 20;

    public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) {
        return TextHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
//        if (prop.propertyType != SerializedPropertyType.String)
//            return;
        //EditorGUI.LabelField(position, label.text, "Use it with a string");
        prop.boolValue = EditorGUI.Toggle(position, label.text, prop.boolValue);
    }
}
