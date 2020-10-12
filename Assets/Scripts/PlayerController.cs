using UnityEngine.AI;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    //float moveSpeed = 4f;
    //Vector3 forward, right;
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    private void Start()
    {
        //forward = Camera.main.transform.forward;
        //forward.y = 0;
        //forward = Vector3.Normalize(forward);
        //right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        References.thePlayer = gameObject;
        agent.updateRotation = false;
    }

    void Update()
    {
        //if (Input.anyKey)
        //    Move();
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
    //void Move()
    //{
    //    Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
    //    Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
    //    Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

    //    Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

    //    transform.forward = heading;
    //    transform.position += rightMovement;
    //    transform.position += upMovement;
    //}
}
