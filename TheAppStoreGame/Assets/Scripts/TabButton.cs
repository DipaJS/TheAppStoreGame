using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

// Object that uses TabButton script is required to have an Image component
[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;

    // Image for the tab, changes depending on tab
    public Image background;

    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this); //  Subscribe tabbutton to tabgroup
    }

    // Tell the this tab to communicate with the tabgroup when it is interacted with 

    // This script will be called when any of the below events occur

    public void OnPointerEnter(PointerEventData eventData)
    { 

        tabGroup.OnTabEnter(this); 
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this); 
    }

   

   

}
