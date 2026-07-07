using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] private string nextScene = "Level2";

    [Header("Portal Appearance")]
    [SerializeField] private float appearTime = 105f; // 01:45

    private Collider2D portalCollider;
    private SpriteRenderer spriteRenderer;

    private bool isActive = false;
    private float timer;

    private void Start()
    {
        portalCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // اول مخفی باشد
        portalCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (isActive)
            return;

        timer += Time.deltaTime;

        if (timer >= appearTime)
        {
            ShowPortal();
        }
    }

    private void ShowPortal()
    {
        isActive = true;

        portalCollider.enabled = true;
        spriteRenderer.enabled = true;

        Debug.Log("Portal Appeared!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        SceneManager.LoadScene(nextScene);
    }
}