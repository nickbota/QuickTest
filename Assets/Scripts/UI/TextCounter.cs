using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;

    protected void UpdateCounter(string newText, Color textColor)
    {
        textComponent.text = newText;
        textComponent.color = textColor;
    }
}