using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private CoinSpawner spawner;

    public void SetSpawner(CoinSpawner coinSpawner)
    {
        spawner = coinSpawner;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        GameManager.Instance.AddCoin(value);

        if (spawner != null)
        {
            spawner.CoinCollected();
        }

        Destroy(gameObject);
    }
}