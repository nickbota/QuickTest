using UnityEngine;

public class Glow : MonoBehaviour, ISelectableObject
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    private Material defaultMaterial;

    private void Awake()
    {
        defaultMaterial = meshRenderer.material;
    }

    public void OnSelect()
    {
        meshRenderer.material = selectedMaterial;
    }
    public void OnDeselect()
    {
        meshRenderer.material = defaultMaterial;
    }
}