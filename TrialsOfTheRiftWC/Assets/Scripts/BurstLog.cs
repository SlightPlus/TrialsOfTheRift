using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BurstLog : MonoBehaviour {

    StreamWriter sw;

	// Use this for initialization
	void Awake () {
		Application.logMessageReceived += Application_logMessageReceived;
        Debug.Log("Boop?");
        string path = @"C:\Users\bombe\Desktop\doubledown.txt";
        if (!File.Exists(path)) {
            sw = File.CreateText(path);
        }
        
	}

    private void Application_logMessageReceived(string condition, string stackTrace, LogType type) {
        sw.Write("[dicks]: " + condition + "|\n");
        sw.Flush();
    }
}
