using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectionMang : MonoBehaviour {

    public GameObject alarmObj;

    public float current = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (current > 0f)
        {
            current -= Time.deltaTime * 5;
        }
        if(current >= 100)
        {
            GameObject.FindGameObjectWithTag("localPlayer").GetComponent<SendAlarmCmd>().triggerAlarm();
        }
        this.GetComponent<Text>().text = (int)(current) + "%";
	}
}
