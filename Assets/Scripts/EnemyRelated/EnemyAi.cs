using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask Ground, Player;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float AIMoveSpeed;
    public Transform[] navPoint;
    public int desPoint = 0;
    public float visionRange;
    public float visionConeAngle;
    public float attackRange1 = 4f;
    public Light myLight;

    private void Awake()
    {
        player.gameObject.SetActive(true);
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (References.thePlayer != null)
        {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);
            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;

            Patroling();

            //Check for sight and attack range
            if (Vector3.Distance(transform.position, playerPosition) <= visionRange && playerInAttackRange)
            {
                if(Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle && Vector3.Distance(transform.position, playerPosition) > attackRange1)
                {
                    ChasePlayer();
                }
                if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle && Vector3.Distance(transform.position, playerPosition) < attackRange1)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private void Patroling()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
            myLight.color = Color.white;
        }
    }

    void GoToNextPoint()
    {
        if (navPoint.Length > 0)
        {
            agent.destination = navPoint[desPoint].position;
            desPoint++;
            desPoint %= navPoint.Length;
            agent.speed = 2;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        myLight.color = Color.red;
        agent.speed = 3;
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 18f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            //End of Attack

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
