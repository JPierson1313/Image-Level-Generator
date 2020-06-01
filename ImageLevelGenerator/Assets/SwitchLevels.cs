using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevels : MonoBehaviour
{
    public string nextScene; //Use a string for the name of the scene the script will take the player to

    // Update is called once per frame
    void Update()
    {
        //When the player presses the Enter/Return Button, it will load the next scene that is given for the string field
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
