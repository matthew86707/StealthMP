using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {
    public GameObject detectionText;
    public float seeDistance = 100f;
    public float detectionRate = 6f;
    public float fov = 90f;

    // Use this for initialization
    void Start() {
        //  detectionText.GetComponent<DetectionMang>().current += Time.deltaTime * detectionRate;
    }

    // Update is called once per frame
    void Update() {
        //Detection Stuff

        GameObject player = GameObject.FindGameObjectWithTag("localPlayer");
        if(player != null) { 
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);


        if (angle < fov * 0.5f) {
            RaycastHit hit;
                if (Physics.Raycast(transform.position, direction.normalized, out hit, seeDistance))
                {

                    if (hit.collider.gameObject.tag == "localPlayer" || hit.collider.gameObject.transform.parent.tag == "localPlayer")
                    {
                        detectionText.GetComponent<DetectionMang>().current += Time.deltaTime * detectionRate;
                    }
                }
        }
    }

}
}
