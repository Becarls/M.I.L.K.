using UnityEngine;
using System.Collections;

public class chooser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int i = 0;
        if (Input.GetKey(KeyCode.Q))
            i++;
        if (Input.GetKey(KeyCode.W))
            i++;
        if (Input.GetKey(KeyCode.E))
            i++;
        if (Input.GetKey(KeyCode.R))
            i++;
        if (Input.GetKey(KeyCode.T))
            i++;
        if (Input.GetKey(KeyCode.A))
            i++;
        if (Input.GetKey(KeyCode.S))
            i++;
        if (Input.GetKey(KeyCode.D))
            i++;
        if (Input.GetKey(KeyCode.F))
            i++;
        if (Input.GetKey(KeyCode.G))
            i++;
        if (Input.GetKey(KeyCode.Z))
            i++;
        if (Input.GetKey(KeyCode.X))
            i++;
        if (Input.GetKey(KeyCode.C))
            i++;
        if (Input.GetKey(KeyCode.V))
            i++;
        if (Input.GetKey(KeyCode.B))
            i++;
        if (Input.GetKey(KeyCode.Alpha1))
            i++;
        if (Input.GetKey(KeyCode.Alpha2))
            i++;
        if (Input.GetKey(KeyCode.Alpha3))
            i++;
        if (Input.GetKey(KeyCode.Alpha4))
            i++;
        if (Input.GetKey(KeyCode.Alpha5))
            i++;


        int j = i;
        i = 0;

        if (Input.GetKey(KeyCode.Y))
            i++;
        if (Input.GetKey(KeyCode.U))
            i++;
        if (Input.GetKey(KeyCode.I))
            i++;
        if (Input.GetKey(KeyCode.O))
            i++;
        if (Input.GetKey(KeyCode.P))
            i++;
        if (Input.GetKey(KeyCode.LeftBracket))
            i++;
        if (Input.GetKey(KeyCode.RightBracket))
            i++;
        if (Input.GetKey(KeyCode.H))
            i++;
        if (Input.GetKey(KeyCode.J))
            i++;
        if (Input.GetKey(KeyCode.K))
            i++;
        if (Input.GetKey(KeyCode.L))
            i++;
        if (Input.GetKey(KeyCode.Colon))
            i++;
        if (Input.GetKey(KeyCode.Quote))
            i++;
        if (Input.GetKey(KeyCode.N))
            i++;
        if (Input.GetKey(KeyCode.M))
            i++;
        if (Input.GetKey(KeyCode.Comma))
            i++;
        if (Input.GetKey(KeyCode.Period))
            i++;
        if (Input.GetKey(KeyCode.Question))
            i++;
        if (Input.GetKey(KeyCode.Alpha6))
            i++;
        if (Input.GetKey(KeyCode.Alpha7))
            i++;
        if (Input.GetKey(KeyCode.Alpha8))
            i++;
        if (Input.GetKey(KeyCode.Alpha9))
            i++;
        if (Input.GetKey(KeyCode.Alpha0))
            i++;

        if (i != j)
        {
            if ((j>4)&&(i > 4))
            {
                if(i> j)
                {
                    print("B");
                }
                else
                {
                    print("A");
                }
            }
            else if (i > 4)
            {
                print("B");
            } else if (j > 4)
            {
                print("A");
            }
        }

    }
    

}
