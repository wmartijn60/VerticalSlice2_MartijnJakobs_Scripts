using UnityEngine;
using System.Collections;

//Old script is verdandert door peter.
public class EnemyAttack : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;
    private bool _collidedWithPlayer;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }
    //trigger enter
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("attackRange", true);
        }
        
    }
    //collision enter
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = true;
            
        }
      
    }
    //colision exit
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = false;
        }
    
    }
    //trigger exit
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("attackRange", false);
        }
      
    }
  
    }
}