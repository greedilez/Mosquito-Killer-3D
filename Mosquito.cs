using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mosquito : MonoBehaviour, IAnimatorTriggerable 
{
    private bool _isGameOver = false;

    public UnityEvent OnMosquitoKilled;

    private bool _isMovingToDestination = false;

    [SerializeField] private float _destinationChangeDelay = 3f;

    [SerializeField] private Animator _animator;

    private Vector3 _destinationPosition;
    
    [SerializeField] private float _speed = 0.1f;

    [SerializeField] private AudioSource _source;

    public void BeatMosquito(){
        if(!_isGameOver){
            Debug.Log($"{gameObject.name} has been killed!");
            if(OnMosquitoKilled != null) OnMosquitoKilled.Invoke();
            _isGameOver = true;
            _source.enabled = false;
            TriggerAnimation("Fall");
            Destroy(gameObject, 15f);
        }
    }

    private void FixedUpdate(){
        MoveToDestination();
    }

    public void SetDestination(Vector3 position){
        if(!_isMovingToDestination){
            _destinationPosition = position;
            Debug.Log($"Destination set: {position}");
            _isMovingToDestination = true;
            StartCoroutine(DestinationChangeDelay());
        }
    }

    private void MoveToDestination(){
        if(_isMovingToDestination && !_isGameOver){
            transform.position = Vector3.MoveTowards(transform.position, _destinationPosition, (_speed * Time.fixedDeltaTime));
            transform.LookAt(_destinationPosition);
        }
    }

    private IEnumerator DestinationChangeDelay(){
        yield return new WaitForSeconds(_destinationChangeDelay); if(_isMovingToDestination) _isMovingToDestination = false;
    }

    public void TriggerAnimation(string triggerName) => _animator.SetTrigger(triggerName);
}
