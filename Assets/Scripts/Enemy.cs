using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float waypointDistance = 5f;
    public float Speed = 5f;
    public NavMeshAgent agent;

    private Transform[] points;
    private int currentWaypoint = 1;
    private float onMeshThreshold = 3;

    // Start is called before the first frame update
    void Start()
    {
        points = waypointParent.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        points = waypointParent.GetComponentsInChildren<Transform>();
        if (points != null)
        {
            // Draw a red line at the transform position point.
            Gizmos.color = Color.red;
            for (int i = 1; i < points.Length - 1; i++)
            {
                Transform pointA = points[i];
                Transform pointB = points[i + 1];
                Gizmos.DrawLine(pointA.position, pointB.position);
            }

            // Draw a Sphere of the current object around it.
            for (int i = 1; i < points.Length; i++)
            {
                Gizmos.DrawSphere(points[i].position, waypointDistance);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Do not continue on if there are no more waypoints.
        if (points.Length == 0)
        {
            return;
        }
        if(currentWaypoint >= points.Length)
        {
            // Return back to the first way point if enemy is at the end of the waypoint
            currentWaypoint = 1;
        }
        print("Current Waypoint: " + currentWaypoint);
        // Get the current waypoint
        Transform currentPoint = points[currentWaypoint];
        // Move towards current waypoint
        
        agent.SetDestination(currentPoint.position);
        // Check if distance between waypoint is close
        float distance = Vector3.Distance(transform.position, currentPoint.position);
        if (distance < waypointDistance)
        {
            // If the distance between the waypoint is close, go to the next waypoint
            currentWaypoint++;
        }
    }

    public bool IsAgentOnNavMesh(GameObject agentObject)
    {
        Vector3 agentPosition = agentObject.transform.position;
        NavMeshHit hit;

        // Check for nearest point on navmesh to agent, within onMeshThreshold
        if (NavMesh.SamplePosition(agentPosition, out hit, onMeshThreshold, NavMesh.AllAreas))
        {
            // Check if the positions are vertically aligned
            if (Mathf.Approximately(agentPosition.x, hit.position.x)
                && Mathf.Approximately(agentPosition.z, hit.position.z))
            {
                // Lastly, check if object is below navmesh
                return agentPosition.y >= hit.position.y;
            }
        }

        return false;
    }
}