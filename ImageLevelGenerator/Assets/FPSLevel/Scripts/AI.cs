using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	
    [SerializeField]
    
    //variables 
	float Distance; 
	GameObject Target;

    public float lookAtDistance = 25.0f;
    public float moveSpeed = 5.0f;
    public float ContinueSpeed = 5;
	public float Damping = 6.0f;

	Vector3 rotation;

    public int Health = 3;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    //updates every tick 
    void Update ()
	{

        rotation = (Target.transform.position - transform.position);
        rotation.y = 0;

        // slows rotation based on variable Damping 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * Damping);

        // sets distance variable to the coordinates of what you set as the target (aka the player)
        Distance = Vector3.Distance(Target.transform.position, transform.position);

        //checks target distance with distance set for "lookAtDistance" (set by you in unity) 
        if (Distance > lookAtDistance)
        {
            moveSpeed = 0;
        }

        //checks target distance with distance set for "lookAtDistance" (set by you in unity) 
        if (Distance < lookAtDistance)
		{
            
			// tells code to do a custom function made called "lookAt"
			LookAt();
            moveSpeed = ContinueSpeed;
        }

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }


	//custom function 
	void LookAt ()
	{
		//sets "rotation" variable as the rotation to look at target  
		rotation = (Target.transform.position - transform.position);
        rotation.y = 0;

		//slows rotation based on variable Damping 
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * Damping);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    //When a bullet hits the AI, the AI will lose one health point
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Health -= 1;
        }
    }
}
