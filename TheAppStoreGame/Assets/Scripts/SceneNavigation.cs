using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    /*private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public Collider col;
    public Transform cameraPosition;*/
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        /*myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        col = GetComponent<Collider>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //Replace this with whatever logic you want to use to validate the objects you want to click on
                if (hit.collider.gameObject.tag == "Clickable")
                {
                    SceneManager.LoadScene(sceneName);
                    Debug.Log("Clicked!");
                }
            }
        }
    }

    /*void SceneShift()
    {
        Debug.Log("Scene2 loading: " + scenePaths[0]);
        Debug.Log("scenePaths: " + string.Join(",", scenePaths));
        //SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }*/
}

/*// Load an assetbundle which contains Scenes.
// When the user clicks a button the first Scene in the assetbundle is
// loaded and replaces the current Scene.

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Use this for initialization
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        {
            Debug.Log("Scene2 loading: " + scenePaths[0]);
            SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        }
    }
// Creates a Ray from the mouse position
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

Debug.DrawRay(Vector3 origin, Vector3 direction);
}*/