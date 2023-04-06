using UnityEngine;

public class Pulsate : MonoBehaviour, ISelectableObject
{
    [SerializeField] private Animator anim;
    private const string PULSATEANIMATION_NAME = "Pulsate";
    private const string IDLEANIMATION_NAME = "Idle";

    public void OnSelect()
    {
        anim.Play(PULSATEANIMATION_NAME);
    }
    public void OnDeselect()
    {
        anim.Play(IDLEANIMATION_NAME);
    }
}