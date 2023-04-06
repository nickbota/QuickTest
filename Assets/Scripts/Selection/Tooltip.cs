using UnityEngine;

public class Tooltip : MonoBehaviour, ISelectableObject
{
    [SerializeField] private TooltipCounter tooltipCounter;
    [SerializeField] private string tipMessage;

    public void OnSelect()
    {
        tooltipCounter.ShowTip(tipMessage);
    }
    public void OnDeselect()
    {
        tooltipCounter.ClearCounter();
    }
}