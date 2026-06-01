// using System.Diagnostics;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Makanan berhasil diambil!");

            GameManager.Instance.AddItem();

            Destroy(gameObject);
        }
    }
}
