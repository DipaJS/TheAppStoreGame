using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// This script will be called when a tab is interacted with 
// Attached to 'Main', 'Mail', and 'ACM' in 'GameView'

// Object that uses TabButton script is required to have an Image component
[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background; // Background color of tab changes depending of state. Is set in TabGroup. 
    


    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this); 
        
    }

   


    

    

    // Event methods for different states of a tab. Called from TabGroup. 

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
