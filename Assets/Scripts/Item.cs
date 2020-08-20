using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public int stretchScale = 3;
    public int stretchDuration = 4;
    public static bool canSpawnItem = true;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallControl ball = collision.gameObject.GetComponent<BallControl>();
        if (ball)
        {
            Sequence seq = DOTween.Sequence();
            seq
                .Append(player1.transform.DOScaleY(stretchScale, 0.6f))
                .Join(player2.transform.DOScaleY(stretchScale, 0.6f))
                .AppendInterval(stretchDuration)
                .Append(player1.transform.DOScaleY(1f, 0.6f))
                .Join(player2.transform.DOScaleY(1f, 0.6f));
            seq.Play();
            canSpawnItem = true;
            Destroy(gameObject);

        }
    }
}
