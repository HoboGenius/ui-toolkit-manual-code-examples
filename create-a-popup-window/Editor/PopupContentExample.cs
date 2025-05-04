using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupContentExample : PopupWindowContent
{
    //Set the window size
    public override Vector2 GetWindowSize()
    {
        return new Vector2(200, 100);
    }

    public override void OnGUI(Rect rect)
    {
        // Intentionally left empty
    }

    public override void OnOpen()
    {
        Debug.Log("Popup opened: " + this);

        var visualTreeAsset = Resources.Load<VisualTreeAsset>("PopupWindowContent");
        visualTreeAsset.CloneTree(editorWindow.rootVisualElement);
    }

    public override void OnClose()
    {
        Debug.Log("Popup closed: " + this);
    }
}