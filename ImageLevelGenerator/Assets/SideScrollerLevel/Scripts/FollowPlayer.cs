using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] Transform player; //Player object the camera will follow

    //Checks to see if there is an instantiated object with the tag "Player" to make the camera follow the player
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Debug.Log("No player found");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Updates the position of the camera to only follow the player in the x axis
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
