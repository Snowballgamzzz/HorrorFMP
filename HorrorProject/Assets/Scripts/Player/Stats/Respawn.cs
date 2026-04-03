using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 lastStandingPoint;
    private Vector3 respawnVelocity;

    public bool isTriggered;
    public bool isGrounded;

    public LayerMask groundLayerMask;

    public GameObject player;
    PlayerHealth health;

    private void Start()
    {
        isTriggered = false;
        isGrounded = true;
        health = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (!isTriggered)
        {
            isGrounded = IsGrounded();

            if (isGrounded)
            {
                lastStandingPoint = player.transform.position;
                respawnVelocity = player.GetComponent<Rigidbody>().linearVelocity;
            }
        }

        if (health.health <= 0)
        {
            //health.health = health.maxHealth;
            //RespawnAtLastStandingPoint();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float distance = player.GetComponent<Collider>().bounds.extents.y + 0.1f;
        return Physics.Raycast(player.transform.position, Vector3.down, out hit, distance, groundLayerMask);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.respawnPoint = this.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            isGrounded = false;
        }
    }

    public void RespawnAtLastStandingPoint()
    {
        player.transform.position = lastStandingPoint;
        player.GetComponent<Rigidbody>().linearVelocity = respawnVelocity;
    }
}
