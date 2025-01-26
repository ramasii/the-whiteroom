using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GambarEnding : MonoBehaviour
{
    public GameManager gameManager;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.secretEnding.title != ""){
            spriteRenderer.sprite = gameManager.secretEnding.sprite;
            animator.SetBool("Show", true);
        }
    }
}
