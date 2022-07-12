using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    private CoinViewer _coinViewer;
    private float _coins = 0;

    private void Start()
    {
        _coinViewer = GetComponent<CoinViewer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            _coinViewer._coinsText.text = _coins.ToString();
            Destroy(collision.gameObject);
        }
    }
}
