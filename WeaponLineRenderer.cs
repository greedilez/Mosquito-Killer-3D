using UnityEngine;

interface IAnimatorTriggerable{ public void TriggerAnimation(string triggerName); }

public class WeaponLineRenderer : MonoBehaviour, IAnimatorTriggerable
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private Weapon _weapon;

    [SerializeField] private Animator _animator;

    public void TriggerAnimation(string triggerName) => _animator.SetTrigger(triggerName);

    public void DrawLineByRay(){
        _lineRenderer.SetPosition(0, _weapon.transform.position);
        _lineRenderer.SetPosition(1, _weapon.CurrentHit.point);
    }
}
