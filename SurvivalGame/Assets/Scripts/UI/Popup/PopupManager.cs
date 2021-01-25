using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    [SerializeField] private GameObject popupTextPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
    }

    public static PopupText CreatePopupText(Vector3 position, string text)
    {
        GameObject gameObject = Instantiate(Instance.popupTextPrefab, position, Quaternion.identity);
        PopupText popupText = gameObject.GetComponent<PopupText>();

        popupText.Text.text = text;
        popupText.Text.color = Color.white;

        popupText.SetAnimationProperties(new Vector3(0, 2, 0), 1.5f);

        return popupText;
    }

    public static PopupText CreatePopupText(Vector3 position, string text, Color color)
    {
        GameObject gameObject = Instantiate(Instance.popupTextPrefab, position, Quaternion.identity);
        PopupText popupText = gameObject.GetComponent<PopupText>();

        popupText.Text.text = text;
        popupText.Text.color = color;

        popupText.SetAnimationProperties(new Vector3(0, 2, 0), 1.5f);

        return popupText;
    }

    public static PopupText CreatePopupText(Vector3 position, string text, Color color, Vector3 offset, float lifeTime)
    {
        GameObject gameObject = Instantiate(Instance.popupTextPrefab, position, Quaternion.identity);
        PopupText popupText = gameObject.GetComponent<PopupText>();

        popupText.Text.text = text;
        popupText.Text.color = color;

        popupText.SetAnimationProperties(offset, lifeTime);

        return popupText;
    }
}
