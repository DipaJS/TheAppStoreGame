using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Textmesh Pro package

// Saves player inputs and manages tools for ease of entering the same inputs
// Attached to 'Input Fields' in PlayerDetails
public class InputManager : MonoBehaviour
{
    // Input fields, set in inspector
    public GameObject nickname;
    public GameObject gender;
    public GameObject age;
    public GameObject country;

    // Input field references to only need to find them once, as they'll be called often
    TMP_InputField nameField;
    TMP_InputField genderField;
    TMP_InputField ageField;
    TMP_InputField countryField;

    // Saved player data, might need better way to store
    public string savedName;
    public string savedGender;
    public int savedAge;
    public string savedCountry;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize input field variables
        nameField = nickname.GetComponent<TMP_InputField>();
        genderField = gender.GetComponent<TMP_InputField>();
        ageField = age.GetComponent<TMP_InputField>();
        countryField = country.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increments or decrements the age input (minimum of zero)
        // bool direction - true for incrementation, false for decrementation
    public void AgeStep(bool direction)
    {
        int years = 0;
        if (ageField.text != "") { 
            years = int.Parse(ageField.text); 
        }

        if (direction)
        {
            years++;
        }
        else
        {
            years--;
        }

        ageField.text = Mathf.Max(years, 0).ToString();
    }

    // Saves the input to the responding variable
        // string field - determines which variable to save to:
            // "nickname" for the name input
            // "gender" for the gender input
            // "age" for the age input
            // "country" for the country input
    // Called by the four InputFields
    public void OnInputChange(string field)
    {
        switch (field.ToLower())
        {
            case "nickname":
                savedName = nameField.text;
                break;
            case "gender": 
                savedGender = genderField.text;
                break;
            case "age":
                savedAge = int.Parse(ageField.text);
                break;
            case "country": 
                savedCountry = countryField.text;
                break;
            default:
                Debug.Log("Unknown argument for OnInputChange, data not saved!");
                break;
        }
    }
}
