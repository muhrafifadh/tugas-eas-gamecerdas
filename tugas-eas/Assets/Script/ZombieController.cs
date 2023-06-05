using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    private void Start()
    {
        GetReferences();
    }
    private void Update()
    {
        MoveToTarget();
    }

    // Update is called once per frame
    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        RotateToTarget();
    }
    private void RotateToTarget()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);
    }
    private void GetReferences()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}
