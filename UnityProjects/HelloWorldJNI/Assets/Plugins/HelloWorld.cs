﻿using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_ANDROID
        //呼び出すJARのパッケージ名を指定
        AndroidJavaObject plugin = new AndroidJavaObject("com.example.java.helloworld.HelloWorldJava");
        //AndroidJavaClass plugin = new AndroidJavaClass("test.HelloWorldJNI");
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        //JARのメソッドを指定する
        int num1 = plugin.CallStatic<int>("getInt1");
        int num2 = plugin.CallStatic<int>("getInt2");

        Debug.Log(num1);
        Debug.Log(num2);
        Debug.Log("aaaa");
#endif        
	}
	// Update is called once per frame
	void Update () {
	
	}
}
