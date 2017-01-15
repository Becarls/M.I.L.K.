using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {

	private float awake = 0;

	// Use this for initialization
	void Start () {
		awake = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > (awake + 5f)) {
			Application.LoadLevel ("start");
		}
	}
}
