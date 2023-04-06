using UnityEngine;

public class TooltipCounter : TextCounter
{
    private void Awake()
    {
        ClearCounter();
    }

    public void ShowTip(string tip)
    {
        UpdateCounter(tip, Color.white);
    }
    public void ClearCounter()
    {
        UpdateCounter("", Color.white);
    }
}