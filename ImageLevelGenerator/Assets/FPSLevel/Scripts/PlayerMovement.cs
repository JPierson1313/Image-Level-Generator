using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int Speed = 16;
    public float BulletSpeed = 20;
    public int RotateSpeed = 100;

    public GameObject projectile;
    public Transform weapon;

	// Use this for initialization
	void Start () {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(projectile, weapon.position, weapon.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(weapon.transform.forward * BulletSpeed);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

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
	}
}
