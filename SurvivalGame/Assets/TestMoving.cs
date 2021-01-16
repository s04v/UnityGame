using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving : MonoBehaviour
{
    public float time = 0;
    public int segmentsCount = 20;
    public Transform tTransform;

    // Start is called before the first frame update
    void Start()
    {
        tTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        float num = (float)Mathf.PI * 10f * (1f - time * 1.5f) * (float)(-1) / (float)segmentsCount;

        tTransform.position = new Vector3(num, num, transform.position.z);

        if (time == 1)
        {
            time = 0;
        }
        else
        {
            time++;
        }

    }
}
