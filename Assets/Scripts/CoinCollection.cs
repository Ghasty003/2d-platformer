using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] private Text score;
    private int scoreCount = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Coin")
        {
            scoreCount++;
            Destroy(collider.gameObject);
            score.text = "Score: " + scoreCount;
        }
    }
}
