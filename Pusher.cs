using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

    //Zの負方向にプッシャーが進む
    //プッシャーのコライダ―に反応してキャンディが押される
    //キャンディが落ちたら得点になる
    // Use this for initialization
    Vector3 startPosition;

    public float amplitude;//移動量パラメータ
    public float speed;//移動速度パラメータ

	void Start () {
        startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        //変位を計算
        float z = amplitude*Mathf.Sin(Time.time*speed);

        //zを変位させたポジションに再設定
        transform.localPosition = startPosition + new Vector3(0,0,z);
	}
}
