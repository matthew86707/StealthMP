using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CardCounter : NetworkBehaviour {

    [SyncVar]
    public int cards;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = cards + "/6";
	}
}
