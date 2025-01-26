using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrPutih : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource BGM;
    private Animator animator;
    private AudioSource audioSource;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator){
            if((gameManager.isEnding || gameManager.alreadyEnd) && gameManager.secretEnding.title == ""){
                animator.SetBool("show", true);
                if(BGM.isPlaying == false){
                    BGM.Play();
                }

                if(Input.GetMouseButtonDown(0))
                {
                    Action();
                }
            }
            else if(gameManager.secretEnding.title != ""){
                animator.SetBool("show", false);

                if(Input.GetMouseButtonDown(0)){
                    Action();
                }
            }
        }
    }

    private void Action()
    {
        animator.SetTrigger("yapping");
        audioSource.Stop();
        audioSource.Play();
    }
}
