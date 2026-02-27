using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    float bgWidth = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        BoxCollider b = GetComponent<BoxCollider>();
        bgWidth = b.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float d = startPos.x - transform.position.x;
        if (d > bgWidth / 2)
        {
            transform.position = startPos;
        }
    }
}
