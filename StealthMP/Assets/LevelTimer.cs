using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class LevelTimer : NetworkBehaviour {

    public GameObject timerText;

    public float realSeconds;

    [SyncVar]
    public int seconds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isServer)
        {
            realSeconds += Time.deltaTime;
            seconds = (int)(realSeconds);
        }

        timerText.GetComponent<Text>().text = seconds + "";
	}
}
