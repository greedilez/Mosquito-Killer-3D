using UnityEngine;
using UnityEngine.SceneManagement;

interface ISceneLoader{ public void LoadScene(int sceneIndex); }

public class GameSceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] private int _gameSceneIndex = 1;

    private void Update() => LoadGameSceneOnFingerTap();

    private void LoadGameSceneOnFingerTap(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began) LoadScene(_gameSceneIndex);
        }
    }

    public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
