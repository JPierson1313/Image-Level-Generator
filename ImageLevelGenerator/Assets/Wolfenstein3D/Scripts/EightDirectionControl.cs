using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightDirectionControl : MonoBehaviour {

    public float speed = 8;

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);
    }
}
