using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int Speed = 16; //Movement Speed for the Player
    public float BulletSpeed = 20; //Speed of the bullet
    public int RotateSpeed = 100; //Rotational speed for Player turning left or right

    public GameObject projectile;
    public Transform weapon;

    void FixedUpdate ()
    {
        //When the player clicks the Left Mouse Button, they will launch a bullet prefab in front of them
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(projectile, weapon.position, weapon.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(weapon.transform.forward * BulletSpeed);
        }

        //Moving and Rotating player
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * RotateSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }

        //Pressing the R Key will allow the player to reset the level
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
