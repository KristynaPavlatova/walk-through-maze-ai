using System.Collections.Generic;
using UnityEngine;

public class AgentAI : MonoBehaviour
{
    public bool _rayDebug = false;
    public bool _availableDirCount = true;
    [HideInInspector]
    public Vector3 lastCrossroad;
    public int lastCrossroadDirectionTaken;
    public int lastDirectionTaken;
    [HideInInspector]
    public List<int> pathTaken;
    [HideInInspector]
    public bool isInDeadEnd = false;

    private RaySidesAndDown _raycast;
    private AgentManager _agentManager;
    private bool[] _goDirections = new bool[4];//left, right, front, back
    private int _StepsTaken;//keep track of how many steps agent made to check for a direction in the generationPath and then chose this step from gnerationPath or random with percentage probability

    //TO DO: before making a move, when you decided a direction to go, store the lastDirectionTaken by taking the opposite of the dir you are going to move to
    private void OnValidate()
    {
        _raycast = this.GetComponent<RaySidesAndDown>();
        Debug.Assert(_raycast, "Agent does not have a RaysToSides script component!");
        _agentManager = GameObject.FindGameObjectWithTag("agentManager").GetComponent<AgentManager>();
        Debug.Assert(_agentManager, "AgentManager script not found!");
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateAvailableDirections();
        getNumberOfAvailableDirections();

    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //check where you are standing
        //  -> goalFound
        //check available directions
        //decide direction (random)
        //  -> note crossroad
        //move to direction
        //store lastDirectionTaken = GetOppositeOfDirection()

        if (!_raycast.StandingOnGoal())
        {
            if (!isInDeadEnd)
            {
                UpdateAvailableDirections();
                if (getNumberOfAvailableDirections() > 1)
                {
                    //random decide the direction
                    //  -> random(0,4)
                    //     -> while goDirections[this random direction] == false >>> this is invalid direction -> keep choosing
                    //     -> while this random direction == _agentManager.GetStepInGenerationPath(current step) -> keep choosing
                    //
                    // A random direction was chosen. Now the probability:
                    //   Chose between the random direction and given step from the generationPath based on probability
                    //
                    //move(to the chosen available direction)
                }
                else if (getNumberOfAvailableDirections() == 1)
                {
                    //go through available directions and find the one that is true
                    //without looking in to the generationPath -> checking only in crossroads
                    //move(the to the available direction)
                }
                else
                {
                    //there is no available direction for this agen. Mark as in deadEnd.
                    isInDeadEnd = true;
                    _agentManager.AgentAtDeadEnd();
                }
                //store lastDirTaken
            }
            else
            {

            }
        }
        else
        {
            _agentManager.GoalFound(pathTaken);
        }
    }
    private void UpdateAvailableDirections()
    {
        if (_raycast.CanGoLeft())
        {
            if (GetOppositeOfDirection(lastDirectionTaken) != 0)
            {
                _goDirections[0] = _raycast.CanGoLeft();
            }
        }
        if (_raycast.CanGoRight())
        {
            if (GetOppositeOfDirection(lastDirectionTaken) != 0)
            {
                _goDirections[1] = _raycast.CanGoRight();
            }
        }
        if (_raycast.CanGoForward())
        {
            if (GetOppositeOfDirection(lastDirectionTaken) != 0)
            {
                _goDirections[2] = _raycast.CanGoForward();
            }
        }
        if (_raycast.CanGoBack())
        {
            if (GetOppositeOfDirection(lastDirectionTaken) != 0)
            {
                _goDirections[3] = _raycast.CanGoBack();
            }
        }

        if(_rayDebug) Debug.Log($"Agent can go to left {_goDirections[0]}, right {_goDirections[1]}, forward {_goDirections[2]}, back {_goDirections[3]}");
    }
    private int getNumberOfAvailableDirections()
    {
        int count = 0;
        foreach (bool dir in _goDirections)
        {
            if (dir) count++;
        }
        if (_availableDirCount) Debug.Log("Directions available: " +count);
        return count;
    }
    private void noteLastCrossroad(int pAvailableDir)
    {
        if (pAvailableDir > 1)
        {
            lastCrossroad = this.transform.position;
        }
    }
    private void noteLastCrossroadDirectionTaken(int pDir)
    {
        lastCrossroadDirectionTaken = pDir;
    }
    private int GetOppositeOfDirection(int pDir)
    {
        //Left & Right
        if (pDir == 0)
        {
            return 1;
        }else
        if (pDir == 1)
        {
            return 0;
        }else
        //Forward & Back
        if (pDir == 2)
        {
            return 3;
        }else
        if (pDir == 3)
        {
            return 2;
        }
        else
        {
            return -1;
        }
    }
}
