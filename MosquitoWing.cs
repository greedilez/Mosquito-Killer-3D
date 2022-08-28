using UnityEngine;

interface IObjectEnableStateChangable{ public void ChangeObjectEnableState(bool state); }

public class MosquitoWing : MonoBehaviour, IObjectEnableStateChangable
{
    public void ChangeObjectEnableState(bool state) => gameObject.SetActive(state);
}
