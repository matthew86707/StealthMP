using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Interact : NetworkBehaviour {

    public GameObject CardCount;

    public GameObject InteractText;

	// Use this for initialization
	void Start () {
        InteractText = GameObject.Find("InteractText");
        CardCount = GameObject.Find("Cards");
	}

    void OnTriggerStay(Collider c)
    {
        InteractText.GetComponent<Text>().text = 
            c.gameObject.GetComponent<Interactable>().text;

        if (c.gameObject.tag == "card")
        {
           
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (isServer)
                {

                    if (c.gameObject.GetComponent<Interactable>().isCollected == false)
                    {
                        CardCount.GetComponent<CardCounter>().cards++;
                        NetworkServer.Destroy(c.gameObject);
                    }
                    c.gameObject.GetComponent<Interactable>().isCollected = true;
                }
                else
                {

                    if (c.gameObject.GetComponent<Interactable>().isCollected == false)
                    {
                        CmdDestroyThisCard(c.gameObject);
                    }
                    c.gameObject.GetComponent<Interactable>().isCollected = true;
                }
            }
        }

            if (c.gameObject.tag == "door")
            {
                if (Input.GetKeyUp(KeyCode.F))
                {
                    if (isServer)
                    {
                        RpcOpenDoor(c.gameObject);
                        GameObject.Find("Door").GetComponent<Animator>().SetTrigger("open");
                    }
                    else
                    {
                        CmdOpenDoor(c.gameObject);
                        GameObject.Find("Door").GetComponent<Animator>().SetTrigger("open");
                    }
                }
            }
        
    }
    void OnTriggerExit(Collider c)
    {
        InteractText.GetComponent<Text>().text = "";
    }


    [Command]
    void CmdDestroyThisCard(GameObject obj)
    {
        NetworkServer.Destroy(obj);
        CardCount.GetComponent<CardCounter>().cards++;
    }

    [Command]
    void CmdOpenDoor(GameObject door)
    {
        door.GetComponent<Animator>().SetTrigger("open");
        RpcOpenDoor(door);
    }
    [ClientRpc]
    void RpcOpenDoor(GameObject door)
    {

        door.GetComponent<Animator>().SetTrigger("open");
    }
    
}
