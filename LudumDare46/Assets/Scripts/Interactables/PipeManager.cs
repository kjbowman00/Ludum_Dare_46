using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public Pump pump1;
    public Pump pump2;
    public float MILK_FLOW_PER_PUMP;
    public float brokenPipeLeakAmount;

    private List<Pipe> nonBurstedPipes;
    private Pipe[] pipes;

    void Start()
    {
        nonBurstedPipes = new List<Pipe>();
        pipes = GetComponentsInChildren<Pipe>();
        for (int i = 0; i < pipes.Length; i++)
        {
            nonBurstedPipes.Add(pipes[i]);
        }
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

    public float getMilkFlow()
    {
        int numPumps = 0;
        numPumps += pump1.pumpStatus();
        //numPumps += pump2.pumpStatus();
        float milk = MILK_FLOW_PER_PUMP * numPumps;
        int numBurstPipes = pipes.Length - nonBurstedPipes.Count;
        milk -= numBurstPipes * brokenPipeLeakAmount;
        if (milk < 0) milk = 0;
        Debug.Log("milk" + milk);
        return milk;
    }
}
