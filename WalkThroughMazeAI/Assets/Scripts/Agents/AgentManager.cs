using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public int agentsInGeneration = 2;

    private List<GameObject> agents;
    private int agentsAtDeadEnd;
    private List<int> generationPath = null;

    public int GetStepInGenerationPath(int pStepNumber)
    {
        //for the agent to chose a random number for direction
        return generationPath[pStepNumber];
    }
    public void GoalFound(List<int> pPath)
    {
        Debug.Log("GOAL FOUND!");
    }
    public void AgentAtDeadEnd()
    {
        agentsAtDeadEnd++;
    }

    private void Update()
    {
        if(agentsAtDeadEnd == agentsInGeneration)
        {
            //go through all the agents
            //get their last crossroad
            //calculate a distance from this to the goal
            //find the closest one
            //get the agent's path
            //make this path the generation path
            //
            //foreach ()
            //{
            //
            //}
        }
    }
}
