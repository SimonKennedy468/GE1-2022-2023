using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        System.Random spin = new System.Random();

        int x = spin.Next(1,2);
        int y = spin.Next(1,2);
        int z = spin.Next(1,2);
    
        transform.Rotate(x, y, z);
        //transform.Translate(0, 0.01f, 0);
    }
}
