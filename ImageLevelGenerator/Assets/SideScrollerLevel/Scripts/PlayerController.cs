using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 10;

    public bool canJump = true;
    public int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredDirection = new Vector3();

        desiredDirection.x = Input.GetAxis("Horizontal");

        transform.position += desiredDirection * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
            jumpCount++;
        }

        if(jumpCount == 2)
        {
            canJump = false;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            canJump = true;
        }
    }
}
