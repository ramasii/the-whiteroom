using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnswer : MonoBehaviour
{
    public GameManager gameManager;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource audioSource;
    public int idxJawab;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        }else{
            Touch();
        }
    }

    void Action()
    {
        Debug.Log("Sprite ditekan!");
        Question question = gameManager.GetQuestion();

        if (question.isYapping)
        {
            gameManager.NextDialog();
        }
        else
        {
            if (question.isAnwered)
            {
                //..
            }
            else
            {
                if(question.listJawaban[idxJawab].id != "tidakSiap"){
                    gameManager.Jawab(idxJawab);
                    gameManager.NextDialog();
                }
            }
        }

        if(animator){
            animator.SetTrigger("Click");
        }
        if(audioSource){
            audioSource.Play();
        }
    }

    void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    Action();
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (gameManager.alreadyEnd || gameManager.isEnding)
        {
            //..
        }else{
            Action();
        }
    }

    void GoInvisible()
    {
        Color warna = Color.white;
        warna.a = Mathf.Lerp(spriteRenderer.color.a, 0, Time.deltaTime);
        spriteRenderer.color = warna;
    }
}
