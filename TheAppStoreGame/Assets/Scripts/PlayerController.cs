using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController //: MonoBehaviour
{
   /* private static PlayerController _instance;
    public static PlayerController instance{get{
        if (_instance == null){
            GameObject go = new GameObject("PlayerController");
            go.AddComponent<PlayerController>();
            }
            return _instance;
        }
    }*/

    // Start is called before the first frame update
   /* void Start()
    {
        
   }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public bool ifClicked(GameObject o){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            return hit.collider.gameObject == o;
        }
        else return false;
    }
}
