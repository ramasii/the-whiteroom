using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string id;
    public string pertanyaan;
    public List<Answer> listJawaban;
    public bool isYapping;
    public bool isAnwered;
}
