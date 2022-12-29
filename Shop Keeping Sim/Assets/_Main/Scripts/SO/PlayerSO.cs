using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Player", order = 1)]
public class PlayerSO : StatsSO
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float interactionRadius = 1;
    [SerializeField] private LayerMask interactionMask;

    public float Speed => speed;
    public float InteractionRadius => interactionRadius;
    public LayerMask InteractionMask => interactionMask;
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerSO))]
public class PlayerSOEditor : StatsSOEditor
{
    #region SerializedProperties

    private SerializedProperty _speed;
    private SerializedProperty _interactionRadius;
    private SerializedProperty _interactionMask;

    #endregion

    private bool _stats = true;

    protected override void OnEnable()
    {
        base.OnEnable();
        _speed = serializedObject.FindProperty("speed");
        _interactionRadius = serializedObject.FindProperty("interactionRadius");
        _interactionMask = serializedObject.FindProperty("interactionMask");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _stats = EditorGUILayout.BeginFoldoutHeaderGroup(_stats, "Stats");
        if (_stats)
        {
            EditorGUILayout.PropertyField(_speed);
            EditorGUILayout.PropertyField(_interactionMask);
            EditorGUILayout.PropertyField(_interactionRadius);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.Space(10);
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
