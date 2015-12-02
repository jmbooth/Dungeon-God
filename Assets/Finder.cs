using UnityEngine;
using System.Collections;

public class Finder : MonoBehaviour {
    public Transform target;
    public Transform target1;
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
            if (Vector3.Distance(agent.transform.position, target.position) > 1.0f)
            {

                destinationTresure = target.position;

                agent.destination = destinationTresure;
            }
            else goal = 1;
        if (goal ==1)
            if (Vector3.Distance(destinationGoal, target1.position) > 1.0f)
            {

                destinationGoal = target1.position;

                agent.destination = destinationGoal;
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
