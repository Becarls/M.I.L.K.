using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {


    public float speed = 10f;
	
	void Update () {
        Vector3 pos = this.transform.position;
        pos = pos + this.transform.up*Time.deltaTime*speed;
        this.transform.position = pos;
	}
}
