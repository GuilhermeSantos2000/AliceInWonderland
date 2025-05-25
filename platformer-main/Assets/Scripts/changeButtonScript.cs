using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class changeButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private Sprite hoveredImage;
    [SerializeField] private Sprite defaultImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button startButton = GetComponent<Button>();

        Image startImage = startButton.GetComponent<Image>();

        startImage.sprite = hoveredImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button startButton = GetComponent<Button>();

        Image startImage = startButton.GetComponent<Image>();

        startImage.sprite = defaultImage;
    }

}
