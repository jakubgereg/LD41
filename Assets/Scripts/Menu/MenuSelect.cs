using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private TMP_Text _text;

    private FontStyles d_fontStyle;
    private Color d_color;
    private Material d_FA;

    public Color HighlightColor = Color.white;

    public Material FA;

    public void Awake()
    {
        _text = GetComponent<TMP_Text>();

        d_fontStyle = _text.fontStyle;
        d_color = _text.color;
        d_FA = _text.fontMaterial;

        SetDefaultStyle(_text);
    }

    public void OnSelect(BaseEventData eventData)
    {
        HighlightSelected(_text);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetDefaultStyle(_text);
    }

    private void HighlightSelected(TMP_Text text)
    {
        text.fontMaterial = FA;
        text.fontStyle = (FontStyles)20;
        text.color = HighlightColor;
    }

    private void SetDefaultStyle(TMP_Text text)
    {
        text.fontMaterial = d_FA;
        text.fontStyle = d_fontStyle;
        text.color = d_color;
    }
}
