using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {

    public int currentPassed = 0;
    public float speed = 3f;
    public float seeDistance = 4f;
    public float detectionRate = 6f;

    public GameObject detectionText;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isServer)
        {
            if((currentPassed + 1) >= GetComponent<Waypoints>().waypoints.Length)
            {
                currentPassed = -1;
            }
            float step = speed * Time.deltaTime;
            this.transform.LookAt(GetComponent<Waypoints>().waypoints[currentPassed + 1]);
            transform.position = Vector3.MoveTowards(transform.position, GetComponent<Waypoints>().waypoints[currentPassed + 1].transform.position, step);
            if(Vector3.Distance(transform.position, GetComponent<Waypoints>().waypoints[currentPassed + 1].transform.position) < 0.01f)
            {
                currentPassed++;
            }
        }

     
	}
}
