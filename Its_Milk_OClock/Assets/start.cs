using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	public string level;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel (level);
		}
	}
}
