using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    private float _coins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            _coinsText.text = _coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}
