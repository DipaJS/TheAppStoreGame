using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

// Controller script for managing each tab
// Toggles new state when a new tab is interacted with 

public class TabGroup : MonoBehaviour
{

    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab; // Store current tab to avoid resetting the tab that is clicked 
    public List<GameObject> objectsToSwap; 
    
    public void Subscribe(TabButton button)
    {// Create a list after the first button subscribes to the group 
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        // Add the button to the list 
        tabButtons.Add(button);
    }

    // Methods for controlling the tabs
    // Each method changes the state of the button when one of the tabs is interacted with 

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
       
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex(); // index of tab object in hierarchy
        for(int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true); 
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    // Set all tabs to idle
    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab)
            {
                continue;
            }
            button.background.sprite = tabIdle; 
        }
    }



}
