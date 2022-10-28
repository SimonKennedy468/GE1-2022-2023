using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, 5);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "brick")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            Debug.Log("Explosion");

        }
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
