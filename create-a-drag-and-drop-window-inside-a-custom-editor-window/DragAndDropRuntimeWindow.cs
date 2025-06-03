using GWG.WindowFramework;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDropRuntimeWindow : MonoBehaviour
{
    public VisualTreeAsset visualTreeAsset;
    public StyleSheet styleSheet;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        WindowFrame testWindow = new WindowFrame();

        testWindow.Title = "Drag and Drop Window";
        testWindow.DefaultWidth = 300;
        testWindow.DefaultHeight = 300;


        // Instantiate UXML
        VisualElement ui = visualTreeAsset.Instantiate();
        testWindow.Content.Add(ui);

        // Add USS
        if (styleSheet != null)
            testWindow.Content.styleSheets.Add(styleSheet);

        // Attach manipulator if needed
        var draggable = testWindow.Content.Q<VisualElement>("object");
        if (draggable != null)
            draggable.AddManipulator(new DragAndDropManipulator(draggable));


        // Add the window to the root
        root.Add(testWindow);
    }
}