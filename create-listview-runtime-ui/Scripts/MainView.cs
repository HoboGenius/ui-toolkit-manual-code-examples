using UnityEngine;
using UnityEngine.UIElements;

public class MainView : MonoBehaviour
{
    [SerializeField]
    VisualTreeAsset m_ListEntryTemplate;

    void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>();

        // Initialize the character list controller
        var characterListController = new CharacterListController();
        // Pass the root element of the UI and the list template to the controller
        characterListController.InitializeCharacterList(uiDocument.rootVisualElement, m_ListEntryTemplate);
    }
}