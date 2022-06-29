using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 25f;

    private PlayerController pcScript;
    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pcScript.gameOver) {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        

        if (transform.position.x < -4)
        {
            Destroy(gameObject);
        }
    }
}
