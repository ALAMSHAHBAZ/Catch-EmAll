using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    // Start is called before the first frame update
  public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
        
    public void moveToInstruction(string scenename1)
    {
        Application.LoadLevel(scenename1);
    }

    public void quitApplication()
    {
        Application.Quit();
    }
}
