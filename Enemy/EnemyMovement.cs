
using UnityEngine;
using UnityEngine.AI;

    public class EnemyMovement : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _nav;
        private Rigidbody rigidbody;
        private Transform _player;
    //getComponents
        void Start()
        {
            _animator = GetComponent<Animator>();
            _nav = GetComponent<NavMeshAgent>();
            rigidbody = GetComponent<Rigidbody>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    //folowPlayer
        void FixedUpdate()
        {
            _nav.SetDestination(_player.position);

            bool run = _nav.velocity != Vector3.zero;

            
            run = run && !_animator.GetBool("attackRange");

            _animator.SetBool("run", run);  
        }
    }
