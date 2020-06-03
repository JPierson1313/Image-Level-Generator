using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5; //How fast the player can move
    public float jumpForce = 10; //How high the player can jump

    public bool canJump = true; //Check to see if we can jump or not
    public int jumpCount = 0; //How many jumps are done

    void FixedUpdate()
    {
        Vector3 desiredDirection = new Vector3();

        desiredDirection.x = Input.GetAxis("Horizontal");

        transform.position += desiredDirection * moveSpeed * Time.deltaTime;

        //When player press the SpaceBar while they can jump, the player will jump upwards with a certain amount of force and add to their jump count
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
            jumpCount++;
        }

        //If player does a double jump, then they can not jump anymore
        if(jumpCount == 2)
        {
            canJump = false;
        }

        //When player hits the R Key, it will reset the scene
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //When the player touches any object with the tag "Ground" their jumpCount will be reset to zero and can jump again
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
        }
    }
}
