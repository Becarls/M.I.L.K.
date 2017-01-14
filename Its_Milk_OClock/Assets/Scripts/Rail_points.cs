using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
public class Rail_points : MonoBehaviour {

    public float duration = 5f;
    public GameObject player;
    public GameObject points;
   // public GameObject point1;
   // public GameObject point2;
   // public GameObject point3;
    public GameObject desicion1a;
    public GameObject desicion1b;
    public GameObject desicion2a;
    public GameObject desicion2b;
    public GameObject chooser;

    private List<GameObject> desicion_array;
    private GameObject[] point_array;
    private chooser choose;
    
	// Use this for initialization
	void Start () {
        desicion_array = new List<GameObject>();
        desicion1a.SetActive(false);
        desicion1b.SetActive(false);
        choose = chooser.GetComponent<chooser>();
        desicion_array.Add(desicion1a);
        desicion_array.Add(desicion1b);
        desicion_array.Add(desicion2a);
        desicion_array.Add(desicion2b);
        //Initialize point array
        int num_points = GetChildren(ref point_array, points);
       // print(num_points);
        MoveLoop(num_points, point_array);
    }

    IEnumerator Move(GameObject p1) {
        Tween myLookTween1 = Look(p1.transform.position);
        yield return myLookTween1.WaitForCompletion();
        Tween myTween = player.transform.DOMove(p1.transform.position, duration, false);
        yield return myTween.WaitForCompletion();
        //This log will happen after the tween has completed
        //Tween myLookTween2 = Look(p2.transform.position);
        //yield return myLookTween2.WaitForCompletion();
        //yield return StartCoroutine(Move(p2, p2));

    }

    IEnumerator Move(GameObject p1, GameObject p2, GameObject p3, GameObject left, GameObject right) {
        yield return StartCoroutine(Move(p1));
        yield return Decide(p2, p3, left, right);
    }

    IEnumerator Decide(GameObject p1, GameObject p2, GameObject left, GameObject right) {
        left.SetActive(true);
        right.SetActive(true);
        while(!choose.left && !choose.right) {
            yield return new WaitForSeconds(.01f);
        }
        if (choose.left) {
            choose.left = false;
            choose.right = false;
            left.SetActive(false);
            right.SetActive(false);
            yield return StartCoroutine(Move(p1));
        }
        else if (choose.right) {
            choose.right = false;
            choose.left = false;
            left.SetActive(false);
            right.SetActive(false);
            yield return StartCoroutine(Move(p2));
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    Tween Look(Vector3 towards) {
        return player.transform.DOLookAt(towards, duration / 2f);
    }

    int GetChildren(ref GameObject[] points_array, GameObject parent) {
        int num_points = parent.transform.childCount;
        point_array = new GameObject[num_points];
        for (int i = 0; i < num_points; i++) {
            point_array[i] = parent.transform.GetChild(i).gameObject;
        }
        return num_points;
    }



    void MoveLoop(int num_points, GameObject[] pt_arr) {
        int decision_counter = 0;
        for (int i = 0; i < num_points; i++) {
           // print(pt_arr.Length);
            if (pt_arr[i].transform.childCount > 0) {
                GameObject[] new_pt_arr = new GameObject[pt_arr[i].transform.childCount];
                int new_num_points = GetChildren(ref new_pt_arr, pt_arr[i]);
                MoveLoop(new_num_points, new_pt_arr);
            }
            if (i == num_points - 3) {
                StartCoroutine(Move(point_array[i], pt_arr[i + 1], point_array[i + 2], desicion_array[decision_counter], desicion_array[decision_counter + 1]));
                decision_counter += 2;
            }

            StartCoroutine(Move(pt_arr[i]));
        }
    }
}
