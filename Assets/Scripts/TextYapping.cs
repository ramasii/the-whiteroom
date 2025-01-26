using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextYapping : MonoBehaviour
{
    public GameManager gameManager;
    public Transform endPivot;
    private RectTransform rectTransform;


    void Awake()
    {
        rectTransform = GetComponentInParent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator TypeText(string line)
    {
        string textBuffer = null;
        TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();

        foreach (char c in line)
        {
            textBuffer += c;
            textMesh.text = textBuffer;
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Question question = gameManager.GetQuestion();
        TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();

        if (textMesh)
        {
            // Debug.Log($"gameManager.secretEnding.title = {gameManager.secretEnding.title}");
            if (gameManager.secretEnding.title != "")
            {
                textMesh.text = gameManager.GetDialSecret();

                PindahPos();

                if (Input.GetMouseButtonDown(0) && rectTransform.position.y - endPivot.position.y < 0.2)
                {
                    gameManager.NextDialog();
                }
            }
            else
            {
                if (gameManager.isEnding == false)
                {
                    textMesh.text = question.pertanyaan;

                    if (gameManager.alreadyEnd)
                    {
                        if (Input.GetMouseButtonDown(0) && rectTransform.position.y - endPivot.position.y < 0.2)
                        {
                            gameManager.NextDialog();
                        }
                    }

                }
                else
                {
                    textMesh.text = gameManager.GetDialEnding();

                    PindahPos();

                    if (Input.GetMouseButtonDown(0) && rectTransform.position.y - endPivot.position.y < 0.2)
                    {
                        gameManager.Jawab(0);
                    }
                }
            }
        }
    }

    void PindahPos()
    {
        Vector3 newPos = Vector3.Lerp(rectTransform.position, endPivot.position, Time.deltaTime);

        rectTransform.position = newPos;
    }

}
