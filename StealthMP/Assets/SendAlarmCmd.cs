using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class SendAlarmCmd : NetworkBehaviour {

    public GameObject AlarmText;
    public GameObject hands;
    public bool hasTrigger;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        AlarmText = GameObject.Find("AlarmText");
	}

    public void triggerAlarm()
    {
        if (!hasTrigger)
        {
          //  hands.GetComponent<Hands>().Aleart();
         //   AlarmText.GetComponent<Text>().text = "ALARM";
            if (isServer)
            {
                hasTrigger = true;
                RpctriggerAlarmClient();
            }
            else
            {
                CmdtriggerAlarmServer();
                hasTrigger = true;
            }
        }
    }
    [Command]
    void CmdtriggerAlarmServer()
    { 
        hands.GetComponent<Hands>().Aleart();
        AlarmText.GetComponent<Text>().text = "ALARM";
        RpctriggerAlarmClient();
    }
    [ClientRpc]
    void RpctriggerAlarmClient()
    {
        hands.GetComponent<Hands>().Aleart();
        AlarmText.GetComponent<Text>().text = "ALARM";
    }
}

