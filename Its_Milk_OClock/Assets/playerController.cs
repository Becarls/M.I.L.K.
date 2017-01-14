using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    //Karl's Basic StateMachine
    //To add a state:
    //1. Add a value to the State enum
    //2. Add an IEnum with the same name from Step 1, followed by "State" (No spaces).
    //When calling GoToState, pass the enum name, not the IEnum name.

    public float startDelay = 0f;
    private float wakeTime;
    private bool gameStarted = false;

    public enum State { Intro, Start };

    public State state;

    public Transform[] travelPoints;

    IEnumerator IntroState()
    {
        Debug.Log("Intro");
        yield return new WaitForSeconds(0f);

        while (state == State.Intro)
        {
            if (Input.GetKey(KeyCode.A))
            {
                GoToState("Start");
            }
            yield return 0;
        }
    }

    IEnumerator StartState()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(0f);

        while (state == State.Start)
        {
            //GoToState("Intro");
            yield return 0;
        }
    }


        //-----------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------

        void Start()
    {
        wakeTime = Time.time;
        //state = State.Intro;
        GoToState("Intro");

    }

    //void Update()
    //{
    //    if ((!gameStarted) && (Time.time > wakeTime + startDelay))
    //    {
    //        gameStarted = true;
    //        GoToState("Start");
    //    }

    //}

    void GoToState(string stateName)
    {
        state = (State)System.Enum.Parse(typeof(State), stateName);
        string coroutineName = stateName + "State";
        StartCoroutine(coroutineName);
    }
}
