using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SecretEnding
{
    public string title;
    public List<string> idConditions;
    public List<string> dialogs;
    public Sprite sprite;

    public SecretEnding(string title, List<string> idConditions, List<string> dialogs, Sprite sprite){
        this.title = title;
        this.idConditions = idConditions;
        this.dialogs = dialogs;
        this.sprite = sprite;
    }

    public int GetDialogsCount(){
        int a = 0;
        foreach(var i in dialogs){
            a++;
        }

        return a;
    }
}
