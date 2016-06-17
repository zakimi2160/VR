using UnityEngine;
using System.Collections;

public class CandyDestroyer : MonoBehaviour {
    public GameHolder candyHolder;
    public int reward;

    public GameObject effectPrefab;//エフェクトプリファブ
    public Vector3 effectRotation;//エフェクトの位置

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Candy")
        {
            candyHolder.AddCandy(reward);
            //オブジェクト削除
            Destroy(other.gameObject);

            if (effectPrefab != null)
            {
                //Candyのポジションにエフェクト発生
                Instantiate(effectPrefab, other.transform.position, Quaternion.Euler(effectRotation));
               
            }
        }

    }
}
