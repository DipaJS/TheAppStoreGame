using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Textmesh Pro package

// Fills and filters a custom searchable dropdown menu
// Attached to 'Country' in PlayerDetails
public class DropdownFilter : MonoBehaviour
{
    // List of strings to put as options in the dropdown
    private List<string> optionsList;

    // Variables to check when the dropdown should be closed
    private bool close;
    private int closeCounter;

    // Variables set in the inspector
    public TMP_InputField inputField;
    public GameObject dropdown;
    public GameObject dropdownContent;
    public Button optionPrefab;
    public bool exhaustive; // Determines if the input must be from the optionsList or if free input is allowed
    public string optionFile; // The name of the file containing the dropdown options

    // Start is called before the first frame update
    private void Start()
    {
        /*TextAsset txt = (TextAsset)Resources.Load("position", typeof(TextAsset));  
            and then split the text into lines

        List<string> lines = new List<string>(txt.text.Split('System.Environment.NewLine'));*/
        //optionsList = new List<string> { "Option A", "Option B", "Option C", "Option D" };

        TextAsset optionsTxt = Resources.Load<TextAsset>(System.IO.Path.Combine("Text Files", optionFile));
        optionsList = new List<string>(optionsTxt.text.Split('\n'));
        optionsList.Sort();

        foreach (string option in optionsList)
        {
            CreateButton(option);
        }

        dropdown.SetActive(false);
        
        closeCounter = 0;
    }

    // Primes the dropdown for closing
    // Called on OnEndEdit for the inputField
    public void closeSearch()
    {
        close = true;
    }

    // Creates a short delay to let the onClick event register before the buttons are removed
    private void FixedUpdate()
    {
        if (close)
        {
            closeCounter++;
            if(closeCounter >= 10)
            {
                dropdown.SetActive(false);
                close = false;
                closeCounter = 0;
                if(exhaustive)
                {
                    if (!optionsList.Contains(inputField.text))
                    {
                        inputField.text = "";
                    }
                }
            }
        }
    }

    // Creates a button in the dropdown
        // string option - The text displayed on the button, as well as what it will use as parameter for its clickOption
    private Button CreateButton(string option)
    {
        Button button = Object.Instantiate(optionPrefab, dropdownContent.transform);
        button.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = option;
        button.onClick.AddListener(delegate { clickOption(option); });
        return button;
    }

    // onClick for the dropdown options to select that option
        // string option - The string that will be put into the inputField
    public void clickOption(string option)
    {
        inputField.text = option;
    }

    // Filters which options are displayed in the dropdown
        // string input - A string that is searched for, if the options has it as a substring they will be set as active, otherwise they will be set as deactive
    public void FilterDropdown(string input)
    {
        bool anyActive = false;
        foreach(Transform button in dropdownContent.transform)
        {
            string buttonText = button.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;

            if(buttonText.IndexOf("No results found") >= 0)
            {
                Destroy(button.gameObject);
            }

            if(buttonText.IndexOf(input, System.StringComparison.OrdinalIgnoreCase) >= 0)
            {
                button.gameObject.SetActive(true);
                anyActive = true;
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }

        if(!anyActive && exhaustive)
        {
            CreateButton("No results found");
        }
    }
}
