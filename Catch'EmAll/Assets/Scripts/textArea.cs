using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textArea : MonoBehaviour
{
    [TextArea]
    public string MyTextArea;
    public Text text;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        text.text = MyTextArea;
    }
    public void startGame(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
