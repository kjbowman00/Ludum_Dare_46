using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    private Pipe[] pipes;

    void Start()
    {
        pipes = GetComponentsInChildren<Pipe>();
    }

    void OnEnable()
    {
        EventManager.PipeBurst += burstAPipe;
    }

    private void OnDisable()
    {
        EventManager.PipeBurst -= burstAPipe;
    }

    void burstAPipe()
    {
        //Pick a pipe from our list
        int pipeNum = selectPipe();
        //Call its burst method
        pipes[pipeNum].burst();
    }

    private int selectPipe()
    {
        int pipeNum = Random.Range(0, pipes.Length);
        /*if (pipes[pipeNum].isBurst())
        {

        }*/ //maybe add this back if i don't want the same pipe to burst again

        return pipeNum;
    }
}
