using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    private CharacterStats stats = null;
    private bool isPlayerInCollision = false;
    private float damageTimer = 0f;
    private float damageInterval = .2f;
    // Start is called before the first frame update
    private void Start()
    {
        GetReferences();
    }
    private void Update()
    {
        if (isPlayerInCollision)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                DealDamageToPlayer();
                damageTimer = 0f;
            }
        }
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
        stats = GetComponent<CharacterStats>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInCollision = false;
            damageTimer = 0f; // Reset the damage timer when the player exits collision
        }
    }

    private void DealDamageToPlayer()
    {
        CharacterStats playerStats = target.GetComponent<CharacterStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(10);
        }
    }
}
