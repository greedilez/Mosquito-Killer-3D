using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestinationGenerator : MonoBehaviour
{
    [SerializeField] private Transform _basePoint;

    [SerializeField] private MosquitosData _mosquitosData;

    [SerializeField] private float _minimalOffset, _maximalOffset, _xMultiplier;

    [SerializeField] private float _destinationChangeDelay = 3f;

    private void Start(){
        SetRandomDestinationToMosquitos();
        StartCoroutine(DestinationChange());
    }

    private IEnumerator DestinationChange(){
        yield return new WaitForSeconds(_destinationChangeDelay);{
            SetRandomDestinationToMosquitos();
            StartCoroutine(DestinationChange());
        }
    }

    public Vector3 RandomDestinationPosition() => new Vector3(_basePoint.position.x + (Random.Range(_minimalOffset, _maximalOffset) * _xMultiplier), _basePoint.position.y + Random.Range(_minimalOffset, _maximalOffset), _basePoint.position.z + Random.Range(_minimalOffset, _maximalOffset));

    public void SetRandomDestinationToMosquitos(){
        Mosquito[] mosquitoes = _mosquitosData.AllMosquitosOnScene();
        if(mosquitoes.Length <= 0){
            Debug.Log("No mosquitoes at scene!");
            return;
        }
        for (int i = 0; i < mosquitoes.Length; i++){ mosquitoes[i].SetDestination(RandomDestinationPosition()); }
    }
}
