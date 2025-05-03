using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace MyUILibraryAlternative
{
    [CustomEditor(typeof(DestructibleTankScript))]
    public class DestructibleTankEditor : Editor
    {
        [SerializeField]
        VisualTreeAsset visualTreeAsset;

        public override VisualElement CreateInspectorGUI()
        {
            return visualTreeAsset.CloneTree();
        }
    }
}