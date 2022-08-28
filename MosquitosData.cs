using UnityEngine;

public class MosquitosData : MonoBehaviour
{
    public Mosquito[] AllMosquitosOnScene() => FindObjectsOfType<Mosquito>();
}
