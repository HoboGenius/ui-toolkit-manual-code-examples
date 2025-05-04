using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class DragAndDropWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit Examples/Drag And Drop")]
    public static void ShowExample()
    {
        DragAndDropWindow wnd = GetWindow<DragAndDropWindow>();
        wnd.titleContent = new GUIContent("Drag And Drop");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

          // Import UXML
        //var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/DragAndDropWindow.uxml");
        // load the visual tree from a resources folder
        var visualTree = Resources.Load<VisualTreeAsset>("DragAndDropWindow");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        //var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/DragAndDropWindow.uss");
        // Load a stylesheet from a resorces folder
        var styleSheet = Resources.Load<StyleSheet>("DragAndDropWindow");

        DragAndDropManipulator manipulator =
        new(rootVisualElement.Q<VisualElement>("object"));

    }
}