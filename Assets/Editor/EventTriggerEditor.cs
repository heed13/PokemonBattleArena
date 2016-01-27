using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Events;



[CustomEditor(typeof(EventTrigger))] 
public class EventTriggerEditor : Editor {

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();

		serializedObject.Update();
		EventTrigger myTarget = (EventTrigger) target;
		EditorGUIUtility.LookLikeInspector();
		EditorGUIUtility.LookLikeControls();

		if (myTarget.triggerPropertiesFold) {
			EditorGUILayout.BeginVertical ("textField");
			EditorGUILayout.Separator ();

			SerializedProperty onTrigger = serializedObject.FindProperty ("onTrigger"); // <-- UnityEvent
			EditorGUI.BeginChangeCheck ();

			EditorGUILayout.PropertyField (onTrigger, true);

			if (EditorGUI.EndChangeCheck ()) {
				serializedObject.ApplyModifiedProperties ();
			}
			EditorGUILayout.EndVertical();
			EditorGUILayout.Separator ();
		}
	}
}
