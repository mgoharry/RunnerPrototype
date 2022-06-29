using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    [SerializeField]
    float speed = 30f;

    private Vector3 startPos;

    private float widthRepeat;

    private PlayerController pcScript;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        widthRepeat = GetComponent<BoxCollider>().size.x / 2;

        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pcScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < startPos.x - widthRepeat)
        {
            transform.position = startPos;
        }
    }
}
