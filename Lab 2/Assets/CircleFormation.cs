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
   
   //function to generate the rings, no of rings can be manually set 
   public void GenerateRings()
   {    
        //runs for loop to generate each object in the ring
       for (int i = 0; i < numberOfObjects; i++)
       {
            //code sample from unity docs for prefab generation https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
           float angle = i * Mathf.PI * 2 / numberOfObjects;
           float x = Mathf.Cos(angle) * radius;
           float z = Mathf.Sin(angle) * radius;
           Vector3 pos = transform.position + new Vector3(x, 0, z);
           float angleDegrees = -angle*Mathf.Rad2Deg;
           Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
           
           GameObject go = Instantiate(prefab, pos, rot);

            //adds object to a list to store for later
           allObjects.Add(go); 
       }
       //increase radius of the ring by 1 and increase th enumber of objects by 1.75. there are more elegant solutions but this prevents them from clipping into one another
       float NextObjNum = 1.75f;
       numberOfObjects = (int)(numberOfObjects * NextObjNum);
       //numberOfObjects = numberOfObjects * 2;
       
       radius = radius + 1;

       
        
   }
    //generates a random color for the object then returns the colour value. generates rgb value between 1 and 3, testing showed higher than 3 almost always yeilded all white cubes
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
        //only recolours the objects each 10th of a second instead of every frame
        time += Time.deltaTime;

        if(time >= interpolationPeriod)
        {
            Renderer ren;
            GameObject objectToChange;
        
        
            for(i=0;i<allObjects.Count;i++)
            {
                Color color = new Color();
                color = setColor(color);
                objectToChange = allObjects[i];
                ren = objectToChange.GetComponent<Renderer>();
                ren.material.color = color;
            }
            time = 0.0f;
        }
        
        //loops through each object to spin
        for(i=0;i<allObjects.Count;i++)
        {
            allObjects[i].transform.Rotate(1,1,1);
        }
   }
}
