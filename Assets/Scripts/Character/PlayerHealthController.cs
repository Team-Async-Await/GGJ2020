using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController Instance;

    public float DamageInvincLength = 1f;
    private float InvincCount;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (LevelController.Player1 != null)
        {
            UIController.Instance.HealthSliderP1.maxValue = LevelController.Player1.MaxHealth;
            UIController.Instance.HealthSliderP1.value = LevelController.Player1.CurrentHealth;
            UIController.Instance.HealthTextP1.text = $"{LevelController.Player1.CurrentHealth} / {LevelController.Player1.MaxHealth}";
        }
        if (LevelController.Player2 != null)
        {
            UIController.Instance.HealthSliderP2.maxValue = LevelController.Player2.MaxHealth;
            UIController.Instance.HealthSliderP2.value = LevelController.Player2.CurrentHealth;
            UIController.Instance.HealthTextP2.text = $"{LevelController.Player2.CurrentHealth} / {LevelController.Player2.MaxHealth}";
        }
    }

    public void DamagePlayer(GameObject player)
    {
        var renderer = player.GetComponent<SpriteRenderer>();
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.5f);
        if (InvincCount > 0)
        {
            return;
        }

        InvincCount = 1;
        StartCoroutine(Invicible(renderer, DamageInvincLength));
        var playerController = player.GetComponent<PlayerController>();
        playerController.CurrentHealth--;
        if (playerController.CurrentHealth <= 0)
        {
            player.SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator Invicible(SpriteRenderer renderer, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        InvincCount = 0;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
    }
}
