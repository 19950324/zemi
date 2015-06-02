using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int test()
    {
        AndroidJavaObject plugin = new AndroidJavaObject("com.trident.rinkou.HelloWorld");
        int num1 = plugin.CallStatic<int>("test");
        return num1;
    }
}
