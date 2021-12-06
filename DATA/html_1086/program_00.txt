using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int Score;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //DontDestroyOnLoadでシーン遷移後も保存出来る
        Score = 0;  //ゲームスタート時のスコア
    }

    public int GetScore()
    {
        return Score;  //スコア変数をResultスクリプトへ返す
    }
}

