using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_ANDROID 
        Debug.Log(HelloWorld.test());
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
