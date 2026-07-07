using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] private GameObject coinPrefab;

    [Header("Spawn Area")]
    [SerializeField] private Vector2 areaSize = new Vector2(10, 5);

    [Header("Time")]
    [SerializeField] private float spawnTime = 3f;

    private GameObject currentCoin;

    private void Start()
    {
        InvokeRepeating(nameof(CheckAndSpawnCoin), 0f, spawnTime);
    }

    private void CheckAndSpawnCoin()
    {
        // اگر هنوز سکه قبلی وجود دارد، چیزی نساز
        if (currentCoin != null)
            return;

        SpawnCoin();
    }

    private void SpawnCoin()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(
                transform.position.x - areaSize.x / 2,
                transform.position.x + areaSize.x / 2
            ),
            Random.Range(
                transform.position.y - areaSize.y / 2,
                transform.position.y + areaSize.y / 2
            )
        );

        currentCoin = Instantiate(
            coinPrefab,
            randomPosition,
            Quaternion.identity
        );

        // وقتی سکه حذف شد، اجازه ساخت سکه جدید بده
        Coin coin = currentCoin.GetComponent<Coin>();

        if (coin != null)
        {
            coin.SetSpawner(this);
        }
    }

    public void CoinCollected()
    {
        currentCoin = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(
            transform.position,
            areaSize
        );
    }
}