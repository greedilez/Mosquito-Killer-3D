using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ToolSelecter _toolSelecter;

    [SerializeField] private TouchData _touchData;

    [SerializeField] private float _rayLength = 100f;

    [SerializeField] private float _fireDelay = 0.5f;

    [SerializeField] private Vector2 _fireAdjust = Vector2.zero;

    public UnityEvent OnShoot;

    public Ray CurrentRay{ get; private set; }

    public RaycastHit CurrentHit{ get; private set; }

    private RaycastHit hit;

    private bool _isFired = false;

    private void Update(){
        if(_toolSelecter.Shoot && _touchData.TouchExists) Shoot();
    }

    private void Shoot(){
        if(!_isFired){
            Ray ray = Camera.main.ScreenPointToRay(_touchData.TouchPosition(_touchData.CurrentTouch, _fireAdjust.x, _fireAdjust.y));
            CurrentRay = ray;
            Debug.DrawRay(transform.position, ray.direction * _rayLength, Color.green, _rayLength);
            if(Physics.Raycast(transform.position, ray.direction, out hit, _rayLength)){
                if(hit.collider.tag == "Mosquito") BeatMosquito(hit);
            }
            CurrentHit = hit;
            OnShoot.Invoke();
            _isFired = true;
            StartCoroutine(FireDelay());
        }
    }

    private IEnumerator FireDelay(){
        yield return new WaitForSeconds(_fireDelay); if(_isFired) _isFired = false;
    }

    public void BeatMosquito(RaycastHit hit){
        Mosquito mosquito = hit.collider.GetComponent<Mosquito>();
        mosquito.BeatMosquito();
    }
}
