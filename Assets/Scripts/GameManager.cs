using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Question> listPertanyaan;
    public List<string> listEnding;
    public List<Answer> listChosenAnswer;
    public List<SecretEnding> secretEndings;
    public List<Sprite> listSecretSprite;
    public SecretEnding secretEnding;
    public Animator putihPutih;
    public AudioSource audioSource;
    public bool isEnding = false;
    public bool alreadyEnd = false;

    [SerializeField]
    private int idxQuestNow;
    private int idxEnding;
    private int idxSecretDial;

    void Awake()
    {
        DeclareSecretEndings();
    }
    public void NextDialog()
    {
        Debug.Log("next dialog");



        if (secretEnding.title != "") // jika secretending terisi
        {
            
            Debug.Log($"START secret ending {secretEnding.title}");

            if(idxSecretDial + 1 < secretEnding.GetDialogsCount()){
                idxSecretDial++;
            }else{
                Debug.Log($"SELESAI secret ending {secretEnding.title}");
                putihPutih.SetBool("Visible", true);
            }
        }
        else
        {
            if (isEnding == false)
            {
                Debug.Log($"next dialog : ending {isEnding}");
                if (listPertanyaan[idxQuestNow].id != "paham" && idxQuestNow + 1 < GetQuestCount())
                {
                    idxQuestNow++;
                    Debug.Log("next dialog : next pertanyaan");
                }
                else
                {
                    Debug.Log("sudah mencapai akhir quest");
                    if (alreadyEnd == false)
                    {
                        if (secretEnding.title != "") // ga ada secret ending
                        {
                            //...
                        }
                        else
                        {
                            isEnding = true;
                        }
                    }
                    else
                    {
                        Debug.Log("sudah ending dan ending");
                        secretEnding = TryCheckSecret();
                        if(secretEnding.title != ""){
                            //..
                            Debug.Log("auysdgaushdkjashdkas");
                        }else{
                            Debug.Log("-------------=================");
                            putihPutih.SetBool("Visible", true);
                        }
                    }
                }
            }
            else
            {
                Debug.Log($"next dialog : ending {isEnding}");
                if (idxEnding + 1 < GetEndCount()) // jika masih di dalam list ending
                {
                    idxEnding++;
                }
                else // ini jika list ending selesai ditampilkan
                {
                    idxQuestNow++;
                    isEnding = false;
                    alreadyEnd = true;
                    Debug.Log($"sudah mencapai akhir ending : isEnding diubah ke {isEnding} : alreadyEnd diubah ke {alreadyEnd}");
                }
            }
        }
    }

    public void Jawab(int idxJawab)
    {
        Question question = listPertanyaan[idxQuestNow];

        // not ending
        if (isEnding == false)
        {
            if (question.isYapping)
            {
                Debug.Log("ini cuma yapping, ngapain dijawab wak 😂");
            }
            else
            {
                if (question.id != "siap" && question.id != "lahir" && question.id != "aisdhaisd" && question.id != "menggali tanah")
                {
                    Answer jawaban = question.listJawaban[idxJawab];
                    listChosenAnswer.Add(jawaban);

                    foreach (string dial in jawaban.listEnding)
                    {
                        listEnding.Add(dial);
                    }

                    if (jawaban.audioClip)
                    {
                        audioSource.clip = jawaban.audioClip;
                        audioSource.Play();
                    }
                }
                question.isAnwered = true;
            }
        }
        // ending
        else
        {
            NextDialog();
        }
    }

    public Question GetQuestion()
    {
        return listPertanyaan[idxQuestNow];
    }

    public string GetDialEnding()
    {
        return listEnding[idxEnding];
    }

    public string GetDialSecret(){
        if(secretEnding.title != ""){
            return secretEnding.dialogs[idxSecretDial];
        }else{
            return "";
        }
    }

    public int GetQuestCount()
    {
        int i = 0;
        foreach (var item in listPertanyaan)
        {
            i++;
        }

        return i;
    }

    public int GetEndCount()
    {
        int i = 0;
        foreach (var item in listEnding)
        {
            i++;
        }

        return i;
    }

    SecretEnding TryCheckSecret()
    {
        foreach (SecretEnding secret in secretEndings)
        {
            for (int i = 0; i < 4; i++)
            {
                if (secret.idConditions[i] != listChosenAnswer[i].id)
                {
                    goto nextsecret;
                }

                if (i == 3 && secret.idConditions[i] == listChosenAnswer[i].id)
                {
                    Debug.Log($"SECRET ENDING {secret.title}");
                    return secret;
                }
            }

        nextsecret:;
        }

        Debug.Log("no secret");
        return secretEnding;
    }

    private void DeclareSecretEndings()
    {
        SecretEnding secretEnding1 = new SecretEnding(
            "Eternal Regret",
            new List<string> { "ambil", "setuju", "rem", "ambil pil" },
            new List<string> { "John, you ran from all your mistakes, but it only led you into a circle of regret.", "There is nowhere to hide.", "Here, in this white room, it's just you...", "and your sins." },
            listSecretSprite[0]
        );
        secretEndings.Add(secretEnding1);

        SecretEnding secretEnding2 = new SecretEnding(
            "Meaningless Sacrifice",
            new List<string> { "biarkan", "menolak", "melaju", "tolak pil" },
            new List<string> { "You gave everything, but this world never cared.", "You sacrificed, John, but it was never enough.", "Here, there's nothing left except you...", "and the emptiness you fought for." },
            listSecretSprite[1]
        );
        secretEndings.Add(secretEnding2);

        SecretEnding secretEnding3 = new SecretEnding(
            "Final Awareness",
            new List<string> { "ambil", "menolak", "melaju", "tolak pil" },
            new List<string> { "At last, John, you accepted it all.", "All your mistakes, all your sacrifices, all of yourself.", "No more burdens. No more pain. Only peace...", "one final time." },
            listSecretSprite[2]
        );
        secretEndings.Add(secretEnding3);
    }
}
