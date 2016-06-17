using UnityEngine;
using System.Collections;

public class GameHolder : MonoBehaviour {
    //オブジェクトの保有
    //オブジェクトをストックにためる
    //初期状態あり？
    //オブジェクトのストックに制限をもつ
    //オブジェクトを落としたら報酬として一つもつ
    // Use this for initialization

    //キャンディーホルダー
    //スタックにする？
    //デフォルトのキャンディ総量
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;
    
    //現在持っているキャンディの数
    int candy = DefaultCandyAmount;
    //ストック回復までの残り数秒
    int counter;

    //キャンディの消費
    public void ConsumeCandy()
    {
        if(candy>0)candy--;
    }

    //現在のキャンディの数を取得
    public int GetCandyAmount()
    {
        return candy;
    }

    //報酬を受け取る
    public void AddCandy(int amount)
    {
        candy += amount;
    }

    //Gui
    void OnGUI()
    {
        GUI.color = Color.black;
        //キャンディのストック数を表示
        string label = "Candy: "+candy;

        //回復カウントしているときだけ秒数を表示
        if (counter > 0) label = label + "(" + counter + ")";

        GUI.Label(new Rect(0,0,100,30),label);
         
    }

    void Update()
    {
        //キャンディのストックがデフォルトより少なく
        //回復カウントをしていないときにカウントをスタートさせる
        if (counter <= 0 && candy < DefaultCandyAmount)
        {
            StartCoroutine(RecoveryCandy());
        }

    }

    //回復コルーチン
    IEnumerator RecoveryCandy()
    {
        counter = RecoverySeconds;

        //1秒ずつカウントを進める
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}
