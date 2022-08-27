using UnityEngine;

public class TouchData : MonoBehaviour
{
    public Touch CurrentTouch{ get; private set; }

    public TouchPhase CurrentTouchPhase{ get; private set; }

    public bool TouchExists{ get; private set; }

    private void Update() => UpdateCurrentTouchState();

    private void UpdateCurrentTouchState(){
        if(Input.touchCount > 0){
            TouchExists = true;
            Touch touch = Input.GetTouch(0);
            CurrentTouch = touch;
            CurrentTouchPhase = touch.phase;
        }
        else TouchExists = false;
    }

    public Vector2 TouchPosition(Touch touch, float xAdjust, float yAdjust) => new Vector2(touch.position.x + xAdjust, touch.position.y + yAdjust);
}
