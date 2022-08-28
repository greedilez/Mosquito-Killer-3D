using UnityEngine;

interface ISpawnable{ public void Spawn(GameObject objectToSpawn); }

public class MosquitosSpawnner : MonoBehaviour, ISpawnable
{
    [SerializeField] private RandomDestinationGenerator _randomDestinationGenerator;

    public void Spawn(GameObject objectToSpawn) => Instantiate(objectToSpawn, _randomDestinationGenerator.RandomDestinationPosition(), Quaternion.identity);
}
