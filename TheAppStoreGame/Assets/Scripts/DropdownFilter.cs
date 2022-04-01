using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Textmesh Pro package

public class DropdownFilter : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private TMP_Dropdown dropdown;

    private List<TMP_Dropdown.OptionData> dropdownOptions;

    // Start is called before the first frame update
    private void Start()
    {
        dropdownOptions = dropdown.options;
    }

    public void FilterDropdown(string input)
    {
        List<TMP_Dropdown.OptionData> tmp = dropdownOptions.FindAll(option => option.text.IndexOf(input, System.StringComparison.OrdinalIgnoreCase) >= 0);
        if (tmp.Count != 0)
        {
            dropdown.options = tmp;
        }
        else
        {
            dropdown.options = new List<TMP_Dropdown.OptionData> { new TMP_Dropdown.OptionData("No results found") };
        }
    }
}
