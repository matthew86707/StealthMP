using UnityEngine;
using System.Collections;

public class Hands : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)){
            this.GetComponent<Animator>().SetBool("running", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("running", false);
        }
	}

    public void Aleart()
    {
        this.GetComponent<Animator>().SetTrigger("aleart");
        Debug.Log("TRIGGERR SET");
    }
}
