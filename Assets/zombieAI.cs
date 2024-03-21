using UnityEngine;
using UnityEngine.AI;

public class zombieAI : MonoBehaviour
{
    public bool walk;
    public NavMeshAgent _agent;
    public Animator _animator;
    public GameObject _Target;

    public float damageAmount = 10f;
    public float attackRange = 2f; // Range within which the zombie attacks the player

    private bool isAttacking = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_agent.enabled)
        {
            _agent.SetDestination(_Target.transform.position);
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _animator.SetBool("walk", false);
                if (!isAttacking)
                {
                    isAttacking = true;
                    _animator.SetBool("attack", true);
                }
            }
            else
            {
                _animator.SetBool("walk", true);
                isAttacking = false;
                _animator.SetBool("attack", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected in trigger zone");
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        PlayerHealthBar playerHealth = _Target.GetComponent<PlayerHealthBar>();
        if (playerHealth != null)
        {
            Debug.Log("Dealing damage to player");
            playerHealth.Damage(damageAmount * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("PlayerHealthBar component not found on player GameObject");
        }
    }
}
