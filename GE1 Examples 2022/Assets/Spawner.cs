using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy_tank;
    List<GameObject> tanks = new List<GameObject>();
    List<Vector3> spawn_points = new List<Vector3>();


    public void OnDrawGizmos()
    {
        int i = 0;
        if (!Application.isPlaying)
        {
            for (i = 0; i < 5; i++)
            {
                float angle = i * Mathf.PI * 2 / 5;
                float x = Mathf.Cos(angle) * 10;
                float z = Mathf.Sin(angle) * 10;

                Vector3 pos = transform.position + new Vector3(x, 0, z);

                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }




    System.Collections.IEnumerator Spawn()
    {;
        int i = 0;

        for (i = 0; i < 6; i++)
        {
            float angle = i * Mathf.PI * 2 / 5;
            float x = Mathf.Cos(angle) * 10;
            float z = Mathf.Sin(angle) * 10;

            Vector3 pos = transform.position + new Vector3(x, 0, z);
            spawn_points.Add(pos);
        }

        i = 0;
        while (tanks.Capacity < 5)
        {
            GameObject g = Instantiate(enemy_tank);
            g.AddComponent<Rigidbody>();
            g.transform.position = spawn_points[i];
            i++;
            if(i > 5)
            {
                i = 0;
            }
            yield return new WaitForSeconds(.2f);
            g.AddComponent<AITank>();
            tanks.Add(g);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
