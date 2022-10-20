using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;    

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using

            for(int i = 0; i < numWaypoints; i++)
            {
                float angle = i * Mathf.PI * 2 / numWaypoints;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;

                Vector3 pos = transform.position + new Vector3(x,0,z);
                //waypoint.Add(pos);
                
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
        for(int i = 0; i < 6; i++)
            {
                float angle = i * Mathf.PI * 2 / numWaypoints;
                float x = Mathf.Cos(angle) * radius	;
                float z = Mathf.Sin(angle) * radius;

                Vector3 pos = transform.position + new Vector3(x,0,z);
                waypoints.Add(pos);
            }

    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        if(Vector3.Distance(this.transform.position, waypoints[current]) < 3)
        {
            current++;
            if(current >= waypoints.Count)
            {
                current = 0;
            }
        }


        //this.transform.LookAt(waypoints[current]);

        Quaternion next_wp = Quaternion.LookRotation(waypoints[current] - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, next_wp, speed * Time.deltaTime);
        this.transform.Translate(0,0, speed * Time.deltaTime);



        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        var tank_direction = this.transform.position - player.transform.position;
        var front_or_befind = Vector3.Dot(tank_direction, player.transform.forward);

        if(front_or_befind > 0)
        {
            GameManager.Log("In front of tank");
            //GUI.Label(Rect(0,0,100,100), "In front of tank");
        }

        
        else if(front_or_befind < 0)
        {
            GameManager.Log("behind of tank");
        }

        
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        var ang_check = player.transform.position - this.transform.position;
        float curr_angle = Vector3.Angle(ang_check, transform.forward);
        if((Vector3.Distance(player.transform.position, this.transform.position) < 10) && curr_angle < 45)
        {
            GameManager.Log("In range");
        }
        GameManager.Log("Current Angle = " + curr_angle);
        

    }
}
