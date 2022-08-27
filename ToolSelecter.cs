using TMPro;
using UnityEngine;

public class ToolSelecter : MonoBehaviour
{
    [SerializeField] private TMP_Text _shootStateText;

    [SerializeField] private bool _defaultShootState = true;

    public bool Shoot{ get; private set; }

    private void Awake(){
        Shoot = _defaultShootState;
        UpdateShootStateText();
    }

    public void ChangeShootState(){
        Shoot = Shoot ? false : true;
        UpdateShootStateText();
    }

    private void UpdateShootStateText() => _shootStateText.text = Shoot ? "Shoot: ON" : "Shoot: OFF";
}
