using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.alreadyEnd || gameManager.isEnding || gameManager.secretEnding.title != "")
        {
            GoInvisible();
        }
    }

    void GoInvisible()
    {
        Color warna = Color.white;
        warna.a = Mathf.Lerp(spriteRenderer.color.a, 0, Time.deltaTime);
        spriteRenderer.color = warna;
    }
}
