using UnityEngine;
using TMPro;

interface ITextUpdatable{ public void UpdateText(TMP_Text text, object value); }

public class MosquitosDefeatCounter : MonoBehaviour, ITextUpdatable
{
    public int MosquitosDefeated{ get; private set; }

    [SerializeField] private TMP_Text _mosquitoesDefeatedText;

    public void AddDefeatedMosquitos(){
        MosquitosDefeated++;
        UpdateText(_mosquitoesDefeatedText, MosquitosDefeated);
        Debug.Log($"Mosquitos Defeated: {MosquitosDefeated}");
    }

    public void UpdateText(TMP_Text text, object value) => _mosquitoesDefeatedText.text = $"Mosquitoes Defeated: {value}";
}
