
public class OutlineObject : Outline, ISelectableObject
{
    public void OnSelect()
    {
        OutlineMode = Mode.OutlineAll;
    }
    public void OnDeselect()
    {
        OutlineMode = Mode.OutlineHidden;
    }
}