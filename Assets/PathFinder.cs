using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PathFinder : MonoBehaviour {
//    public GameObject listHolder;
    public WallManager listHolder;
    GameObject[,] test;
    private bool[,] isDescovored =new bool[10,10];
    private Stack<GameObject> gridStack = new Stack<GameObject>();
    public int positionX;
    public int positionY;
    private Stack S = new Stack();
    GameObject currentGrid;
    GameObject targetGrid;
    public Text tester;
    int firstTime = 1;
    Transform target;
    Vector3 destinationGoal;
    Vector3 destinationTresure;
    NavMeshAgent agent;
    int goal = 1;

    // Use this for initialization
    void Start() {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destinationTresure = agent.destination;
        GameObject[,] Array = listHolder.getList();
        //sets targetGrid to current position.
        targetGrid = Array[0, 0] ;

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                isDescovored[i, j] = false;
                    

    }


    void DFS(GameObject v)
    {
        gridStack.Push(v);        //while (gridStack.Count > 0)

            //cycle through until node with no trap and is unExplored is found. If no such node exists cycle until unexplored node found. 
           // while (gridStack.Peek().name.Contains("Trap"))
                v = (GameObject)gridStack.Pop();
        //tester.text = v.name;
        if (v != null &&!isDescovored[(int)v.transform.position.x, (int)v.transform.position.z])
        {
            firstTime = 0;
            tester.text = "inside";
            //      Navigate to V
            target = v.transform;
            isDescovored[(int)v.transform.position.x, (int)v.transform.position.z] = true;
           
            GameObject[] List = getAjacent(v);
            for (int i = 0; i < List.Length; i++)
            {
                //could randomize order of w push to make the path unpredictable by    player 
                //rather then cycling pops, make sure to push nodes with traps first to make adventures avoid them

                if (List[i] != null) { gridStack.Push(List[i]);
                    targetGrid = List[i];
                }
                    
            }
        }
        Debug.Log("stack: " + gridStack.Count);

    }
    
    GameObject[] getAjacent(GameObject v) {
        int x = (int)v.transform.position.x;
        int y = (int)v.transform.position.z;
        int next = 0;
        GameObject tmp;
        GameObject[] List=new GameObject[9];
        GameObject[,] Array = listHolder.getList();
        //new GameObject[10][10];
        for(int i = -1; i < 2; i++){
            for (int j = -1; j < 2; j++)
            {
                if (//!Array[x + i, y + j].name.Contains("Wall") &&
                    (i != 0 && j != 0) && ((x+i > 0 && y+j > 0) && (x+i < 10 && y+j <10) ) )
                {
                    List[next] = Array[x + i, y + j];
                    next += 1;
                }
          }
        }
        for (int i = 1; i < List.Length; i++)
            if (Random.value >= .5) {
                tmp = List[i];
                List[i] = List[i - 1];
                List[i - 1]=tmp;
            }
        for (int i = 0; i < List.Length; i++)
            if (List[i].name.Contains("Trap")) {
                //Move trap to first,
                //Push all other nodes forward by 1
                tmp = List[i];
            for (int j = i; j > 0; j--) {
                    List[i] = List[i - 1];
                }
            List[0] = tmp;
            }


        return List;
    }
    
    
	// Update is called once per frame
	void Update () {
            
            if (target != null && Vector3.Distance(agent.transform.position, target.position) > 1.0f)
            {

                destinationTresure = target.position;

                agent.destination = destinationTresure;
                tester.text = "in if";
            Debug.Log("target pos: " + target.position + "agent pos " + agent.transform.position);
            Debug.Log("in if: " + gridStack.Count);
        }
            else
        {
            tester.text = "else";
            if (firstTime == 1)
                targetGrid = listHolder.getList()[0, 0];
            DFS(targetGrid);
            }

        test = listHolder.getList();
        if (test[3, 3] == null)
            tester.text = "not Wall";
        //else if (test[3, 3].name.Contains("Wall"))
            //tester.text = "is Wall";
        else if (test[3, 3].name.Contains("Trap"))
        tester.text = "is Trap";

        //if current grid is same as old grid do nothing


        //if current grid is different then do depth first search to find next grid to move to

    }
}
