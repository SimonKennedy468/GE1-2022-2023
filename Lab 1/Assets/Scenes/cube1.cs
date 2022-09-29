using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float waitTime = 1.0f;
    float updateTime = 0.1f;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time > waitTime)
        {
            waitTime += updateTime;

            System.Random spin = new System.Random();

            int x = spin.Next(-1,1);
            int y = spin.Next(-1,1);
            int z = spin.Next(-1,1);

        
            transform.Rotate(x, y, z);
            //transform.Translate(0, 0.01f, 0);
            waitTime = 0;
        }
    }
}

//comment for 2nd commit
