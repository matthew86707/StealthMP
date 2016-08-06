using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class AlarmTrigger : NetworkBehaviour {

    public GameObject AlarmText;
    public GameObject hands;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void triggerAlarm()
    {
            AlarmText.GetComponent<Text>().text = "ALARM";
        hands.GetComponent<Hands>().Aleart();
        RpctriggerAlarmClient();
            CmdtriggerAlarmServer();
        
    }
    [Command]
    void CmdtriggerAlarmServer()
    {
        Debug.Log("CMD TRIGGERREEDADSD");
        AlarmText.GetComponent<Text>().text = "ALARM";
      //  hands.GetComponent<Hands>().Aleart();
        RpctriggerAlarmClient();
    }
    [ClientRpc]
    void RpctriggerAlarmClient()
    {
      //  hands.GetComponent<Hands>().Aleart();
        AlarmText.GetComponent<Text>().text = "ALARM";
    }
}
