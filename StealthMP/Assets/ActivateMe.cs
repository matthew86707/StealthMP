using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class ActivateMe : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            this.GetComponent<CharacterController>().enabled = true;
            this.GetComponent<FirstPersonController>().enabled = true;
            this.GetComponentInChildren<Camera>().enabled = true;
            this.gameObject.tag = "localPlayer";
            Cursor.visible = false;

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
