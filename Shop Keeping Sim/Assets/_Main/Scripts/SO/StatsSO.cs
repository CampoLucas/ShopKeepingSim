using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// The common scriptable object that all entities share.
/// It doesn't have a class asset menu, because it shouldn't be assigned throw the inspector
/// It will be inherited by other scriptable objects
/// </summary>
public class StatsSO : ScriptableObject
{
    [SerializeField] private string id = "default";
    [SerializeField] private Texture defaultTexture;
    [SerializeField] private Color color = Color.white;

    public string ID => id;
    public Texture DefaultTexture => defaultTexture;
    public Color Color => color;
}

#if UNITY_EDITOR
/// <summary>
/// Even though StatsSO doesn't appear in the inspector, it still has a custom editor, because it will be inherit by other custom editor classes
/// </summary>
[CustomEditor(typeof(StatsSO))]
public class StatsSOEditor : Editor
{
    #region SerializedProperties
    
    private SerializedProperty _id;
    private SerializedProperty _defaultTexture;
    private SerializedProperty _color;
    
    #endregion

    private bool _identification = true;
    private bool _render = true;

    protected virtual void OnEnable()
    {
        _id = serializedObject.FindProperty("id");
        _defaultTexture = serializedObject.FindProperty("defaultTexture");
        _color = serializedObject.FindProperty("color");
    }

    public override void OnInspectorGUI()
    {
        _identification = EditorGUILayout.BeginFoldoutHeaderGroup(_identification, "Identification");
        if (_identification)
        {
            EditorGUILayout.PropertyField(_id);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.Space(10);
        
        _render = EditorGUILayout.BeginFoldoutHeaderGroup(_render, "Render");
        if (_render)
        {
            EditorGUILayout.PropertyField(_defaultTexture);
            EditorGUILayout.PropertyField(_color);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.Space(10);
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
