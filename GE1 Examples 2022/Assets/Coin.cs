using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 gravity = new Vector3(0, -9.8f, 0);
    public float speed;
    public float timeAcc;
    public Vector3 velocity = new Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        timeAcc = 0;
        float dist = 381.0f;
        float time = Mathf.Sqrt(dist / (0.5f * gravity.y));
        Debug.log("Expected: " + time);
        float finalSpeed = time * gravity.y;
        Debug.log("Finalspeed = " + finalSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0)
        {
            velocity += gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            timeAcc += Time.deltaTime
            speed = velocity.magnitude;
        }


    }
}