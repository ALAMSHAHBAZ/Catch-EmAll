
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GameSceneController : MonoBehaviour
{

    public Text scoreText;
    public Text coinText;
    public GameObject[] randomObjectArray = new GameObject[7];
    //public GameObject ball;
    GameObject targetObject;
    private int tag;

    private void Start()
    {
        //Scenes scenes1 = new Scenes();
        GameObject selectedGameObject;
        tag = Int32.Parse(Scenes.getParam("Tag"));
        Debug.Log("Tag is " + tag);
        
        targetObject = Instantiate(randomObjectArray[tag], new Vector3(0, 0, 20), Quaternion.identity) as GameObject;

        int prevVal = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "Balls Collected: " + prevVal.ToString()+" / 7";
        coinText.text = "Coins:" + (prevVal * 10).ToString();
    
    }
    void rotateGO(GameObject instantiatedObject)
    {
     
            instantiatedObject.transform.Rotate(new Vector3(30f, 100f, 0f) * Time.deltaTime);
       
    }
    public void updateScore()
    {

        int newScore = PlayerPrefs.GetInt("HighScore") + 1;
        if (newScore == 7)
        {
            PlayerPrefs.DeleteAll();
        }
        PlayerPrefs.SetInt("HighScore", newScore);
        scoreText.text = "Balls Collected: " + newScore.ToString() + " / 7";
        coinText.text = "Coins:" + (newScore * 10).ToString();

        //targetObject.SetActive(false);
        Destroy(targetObject);
        SceneManager.LoadScene("LocationbasedGame");
    }

    void Update()
    {
        Debug.Log("update");
        rotateGO(targetObject);
        //findDifference(instantiatedObjectArray);

    }

}
