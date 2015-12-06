using UnityEngine;
using System.Collections;

public class Finder : MonoBehaviour {
    public Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    Vector3 destinationGoal;
    Vector3 destinationTresure;
    NavMeshAgent agent;
    int goal = 0;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destinationTresure = agent.destination;
    }

    void Update()
    {

        agent = GetComponent<NavMeshAgent>();
        destinationTresure = agent.destination;
        // Update destination if the target moves one unit
        if (goal == 0)
            if (Vector3.Distance(agent.transform.position, target.position) > 2.0f)
            {

                destinationTresure = target.position;

                agent.destination = destinationTresure;
            }
            else goal = 1;
        if (goal == 1)
        {
            if (Vector3.Distance(agent.transform.position, target1.position) > 2.0f)
            {

                destinationGoal = target1.position;

                agent.destination = destinationGoal;
            }
            else goal = 2;
        }
        if (goal == 2)
        {
            if (Vector3.Distance(agent.transform.position, target2.position) > 2.0f)
            {

                destinationGoal = target2.position;

                agent.destination = destinationGoal;
            }
            else goal = 3;
        }
        if (goal == 3)
        {
            if (Vector3.Distance(agent.transform.position, target3.position) > 2.0f)
            {

                destinationGoal = target3.position;

                agent.destination = destinationGoal;
            }
            else goal = 4;
        }
        if (goal == 4)
        {
            if (Vector3.Distance(agent.transform.position, target4.position) > 2.0f)
            {

                destinationGoal = target4.position;

                agent.destination = destinationGoal;
            }
            else goal = 5;
        }
    }
    /*
	public Transform destinationPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<NavMeshAgent> ().destination = destinationPoint.position;
	}*/
}
