using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public Pump pump1;
    public Pump pump2;
    public float MILK_FLOW_PER_PUMP;
    public float brokenPipeLeakAmount;

    private int numBurstedPipes = 0;
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
        numBurstedPipes++;
    }

    public void repairedPipe()
    {
        numBurstedPipes--;
    }

    private int selectPipe()
    {
        int pipeNum = Random.Range(0, pipes.Length);
        /*if (pipes[pipeNum].isBurst())
        {

        }*/ //maybe add this back if i don't want the same pipe to burst again

        return pipeNum;
    }

    public float getMilkFlow()
    {
        int numPumps = 0;
        numPumps += pump1.pumpStatus();
        //numPumps += pump2.pumpStatus();
        float milk = MILK_FLOW_PER_PUMP * numPumps;
        milk -= numBurstedPipes * brokenPipeLeakAmount;
        if (milk < 0) milk = 0;
        return milk;
    }
}
