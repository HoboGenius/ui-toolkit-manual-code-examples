using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterListController
{
    // UXML template for list entries
    VisualTreeAsset m_ListEntryTemplate;

    // UI element references
    ListView m_CharacterList;
    Label m_CharClassLabel;
    Label m_CharNameLabel;
    VisualElement m_CharPortrait;

    List<CharacterData> m_AllCharacters;

    public void InitializeCharacterList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        // Build the list of character data objects
        EnumerateAllCharacters();

        // Store a reference to the template for the list entries
        m_ListEntryTemplate = listElementTemplate;

        // Store a reference to the character list element
        m_CharacterList = root.Q<ListView>("character-list");

        // Store references to the selected character info elements
        m_CharClassLabel = root.Q<Label>("character-class");
        m_CharNameLabel = root.Q<Label>("character-name");
        m_CharPortrait = root.Q<VisualElement>("character-portrait");

        // Populate the UI list with the data from the characters list
        FillCharacterList();

        // Register to get a callback when an item is selected
        m_CharacterList.selectionChanged += OnCharacterSelected;
    }

    void EnumerateAllCharacters()
    {
        // Build the list
        m_AllCharacters = new List<CharacterData>();
        // Add the data objects to the list
        m_AllCharacters.AddRange(Resources.LoadAll<CharacterData>("Characters"));

        Debug.Log($"Loaded {m_AllCharacters.Count} characters");
    }

    void FillCharacterList()
    {
        // Set up a make item function for a list entry
        // This is the reused mapping for each of the line items in the list
        m_CharacterList.makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = m_ListEntryTemplate.Instantiate();

            // Instantiate a controller for the data
            var newListEntryLogic = new CharacterListEntryController();

            // Assign the controller script to the visual element
            // this is stored in a special container called userData
            // https://docs.unity3d.com/ScriptReference/UIElements.VisualElement.html
            newListEntry.userData = newListEntryLogic;

            // Initialize the controller script
            newListEntryLogic.SetVisualElement(newListEntry);

            // Return the root of the instantiated visual tree
            return newListEntry;
        };
        Debug.Log($"Created make item template");


        // Set up bind function for a specific list entry
        m_CharacterList.bindItem = (item, index) =>
        {
            Debug.Log($"Binding item {index} - {m_AllCharacters[index].CharacterName}");
            (item.userData as CharacterListEntryController)?.SetCharacterData(m_AllCharacters[index]);
        };

        // Set a fixed item height matching the height of the item provided in makeItem.
        // For dynamic height, see the virtualizationMethod property.
        m_CharacterList.fixedItemHeight = 45;

        // Set the actual item's source list/array
        m_CharacterList.itemsSource = m_AllCharacters;
        Debug.Log($"Set items source to {m_CharacterList.itemsSource}");
    }

    void OnCharacterSelected(IEnumerable<object> selectedItems)
    {
        // Get the currently selected item directly from the ListView
        var selectedCharacter = m_CharacterList.selectedItem as CharacterData;

        // Handle none-selection (Escape to deselect everything)
        if (selectedCharacter == null)
        {
            // Clear
            m_CharClassLabel.text = "";
            m_CharNameLabel.text = "";
            m_CharPortrait.style.backgroundImage = null;

            return;
        }

        // Fill in character details
        m_CharClassLabel.text = selectedCharacter.Class.ToString();
        m_CharNameLabel.text = selectedCharacter.CharacterName;
        m_CharPortrait.style.backgroundImage = new StyleBackground(selectedCharacter.PortraitImage);
    }
}