using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    public GameObject objectPrefab;
    public GameObject objectPrefab2;
    string ip = "127.0.0.1";
    string port = "8000";
    bool connected = false;

    private void CreatePlayer()
    {
         connected = true;
         Network.Instantiate(objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 1);
    }

    public void OnConnectedToServer()
    {
          connected = true;
          Network.Instantiate(objectPrefab2, objectPrefab2.transform.position, objectPrefab2.transform.rotation, 1);
    }
    public void OnServerInitialized()
    {
        CreatePlayer();
    }


    public void OnGUI()
    {
        if( !connected)
        {
            if( GUI.Button( new Rect( 10, 10, 90, 90), "Client"))
            {    
                Network.Connect(ip, int.Parse(port) ); 
            }
            if( GUI.Button( new Rect(10, 110, 90, 90), "Master"))
            {    
                Network.InitializeServer(10, int.Parse(port), false);    
               }
        }
    }

    void Start () {}
    void Update ()
    {
    }
}