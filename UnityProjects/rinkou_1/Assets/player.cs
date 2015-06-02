using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public Vector3 pos;

    [RPC]
    void MoveLeft()
    {
        pos.x -= 0.2f;
        transform.position = pos;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        if (GetComponent<NetworkView>().isMine == true)
        {
            Debug.Log("true");
            if (Input.GetKey("right"))
            {
                pos.x += 0.2f;
                transform.position = pos;
            }
            else if (Input.GetKey("left"))
            {
                GetComponent<NetworkView>().RPC("MoveLeft", RPCMode.All);
            }
        }
	}
}
