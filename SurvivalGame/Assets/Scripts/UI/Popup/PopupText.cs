using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private Transform Transform;
    public float maxLifeTime;
    public float lifeTime;
    public Vector3 startPosition;
    public Vector3 offset;

    public TextMeshPro Text { get { return text; } }

    void Start()
    {
        if (text == null)
            text = GetComponent<TextMeshPro>();
        if (Transform == null)
            Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    public void SetAnimationProperties(Vector3 offset, float lifeTime)
    {
        startPosition = transform.position;
        this.offset = startPosition + offset;
        maxLifeTime = lifeTime;
        this.lifeTime = maxLifeTime;
    }

    private void Animation()
    {
        lifeTime -= Time.deltaTime;
        float progress = 1 - (lifeTime / maxLifeTime);
        if (progress <= 1)
        {
            Transform.localPosition = Vector3.Lerp(startPosition, offset, progress);
            text.alpha = Mathf.Lerp(1, 0, progress);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
