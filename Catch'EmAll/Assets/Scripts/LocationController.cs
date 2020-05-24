using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocationController : MonoBehaviour
{
    
    public Transform Map;
    public Transform Trainer;
    public static LocationService deviceLocation;
    public GameObject[] randomObjectArray = new GameObject[7];
    GameObject[] instantiatedObjectArray = new GameObject[7];
    private string s=" ";
    private int randomX, randomZ;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        Debug.Log("awake");
        MyRandomObject();

    }
    // 26.855125, 80.922678
    // Start is called before the first frame update
    void Start()
    {   
        
        Debug.Log("Start");
        //DestroyMethod();
        findDifference(instantiatedObjectArray);
       
        // deviceLocation.Start();
    }
    void MyRandomObject()
    {
        Debug.Log("Random Object is called");
        
        for(int i = 0; i < 7; i++)
        {
                 randomX = Random.Range(-75, 75);
                 randomZ = Random.Range(-75, 75);
           
            
            if (PlayerPrefs.GetInt("selectedObject" + i.ToString(), 999) != 999)
            {
                Debug.Log("previous selectedObjects deleted : "+i);
                continue;
            }
            instantiatedObjectArray[i] = Instantiate(randomObjectArray[i], new Vector3(randomX, Map.position.y, randomZ), Quaternion.identity) as GameObject;
            Vector3 newPosition = instantiatedObjectArray[i].transform.position; // We store the current position
            newPosition.y = 5; // We set a axis, in this case the y axis
            instantiatedObjectArray[i].transform.position = newPosition;
        }
            
    }

    void rotateGO(GameObject[]  instantiatedObjectArray)
    {
       

        for( int i=0; i<7;i++)
        {
            if (PlayerPrefs.GetInt("selectedObject" + i.ToString(), 999) != 999)
            {
                Debug.Log("previous selectedObjects deleted : " + i);
                continue;
            }
            instantiatedObjectArray[i].transform.Rotate(new Vector3(30f, 100f, 0f) * Time.deltaTime);
        }
    }

    void findDifference(GameObject[] instantiatedObject)
    {
        
        for(int i = 0; i <7; i++)
        {
            if (instantiatedObject[i] !=null)
            {
                float diff = Vector3.Distance(instantiatedObject[i].transform.position, Trainer.position);
                if (diff <= 10f)
                {
                    print("Close to object....Distance= " + diff);
                    Debug.Log("Instantiated object successfully");
                    string parameters = instantiatedObject[i].tag;
           
                    Debug.Log("Tag: "+parameters);
                    s = "selectedObject" + i.ToString();
                   
                    PlayerPrefs.SetInt(s, i);
                  
                    Destroy(instantiatedObject[PlayerPrefs.GetInt(s)]);
                    Debug.Log("Object deleted with tag: " + parameters + " ......" + s);
                    //randomObjectArray[i] = null;
                    Scenes.Load("GameScene" , "Tag",i.ToString());
                    
                }
            }
          
        }

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        rotateGO(instantiatedObjectArray);
        findDifference(instantiatedObjectArray);
        
    }

}

