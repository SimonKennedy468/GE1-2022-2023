using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CircleFormation : MonoBehaviour
{
   // Instantiates prefabs in a circle formation
   public GameObject prefab;
   public int numberOfObjects = 5;
   public float radius = 2f;
   public int RingsToGenerate =2;

   private float time = 0.0f;
   public float interpolationPeriod = 0.1f;

   int i = 0;

   public List<GameObject> allObjects = new List<GameObject>(); 
   

   public void GenerateRings()
   {
       for (int i = 0; i < numberOfObjects; i++)
       {
           float angle = i * Mathf.PI * 2 / numberOfObjects;
           float x = Mathf.Cos(angle) * radius;
           float z = Mathf.Sin(angle) * radius;
           Vector3 pos = transform.position + new Vector3(x, 0, z);
           float angleDegrees = -angle*Mathf.Rad2Deg;
           Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
           
           GameObject go = Instantiate(prefab, pos, rot);

           allObjects.Add(go); 
       }
    
       float NextObjNum = 1.75f;
       numberOfObjects = (int)(numberOfObjects * NextObjNum);
       //numberOfObjects = numberOfObjects * 2;
       
       radius = radius + 1;

       
        
   }

   public Color setColor(Color colorToSet)
   {
        Color color = new Color(Random.Range(0,3),Random.Range(0,3), Random.Range(0,3), Random.Range(0,3));
        return color;
   }

   void Start()
   {
        int i;
        for(i=0;i<RingsToGenerate;i++)
        {
            GenerateRings();
        }
        
   }

   void Update()
   {
        time += Time.deltaTime;

        if(time >= interpolationPeriod)
        {
            Renderer rend;
            GameObject objectToChange;
        
        
            for(i=0;i<allObjects.Count;i++)
            {
                Color color = new Color();
                color = setColor(color);
                objectToChange = allObjects[i];
                rend = objectToChange.GetComponent<Renderer>();
                rend.material.color = color;
            }
            time = 0.0f;
        }
        
        for(i=0;i<allObjects.Count;i++)
        {
            allObjects[i].transform.Rotate(1,1,1);
        }
        //Color color = new Color(r,g,b);
        
   }
}
