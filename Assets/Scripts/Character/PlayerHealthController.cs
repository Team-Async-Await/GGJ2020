using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController Instance;

    public int CurrentHealth;
    public int MaxHealth;

    public float DamageInvincLength = 1f;
    private float InvincCount;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
        var renderer = PlayerController.Instance.GetComponent<SpriteRenderer>();

        if (InvincCount > 0)
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.5f);
            InvincCount -= Time.deltaTime;
        }
        else
        {
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
        }
    }


    private void UpdateUI()
    {
        UIController.Instance.HealthSlider.maxValue = MaxHealth;
        UIController.Instance.HealthSlider.value = CurrentHealth;

        UIController.Instance.HealthText.text = $"{CurrentHealth} / {MaxHealth}";
    }

    public void DamagePlayer()
    {
        
        if (InvincCount > 0)
        {
            return;
        }
          


        InvincCount = DamageInvincLength;
        CurrentHealth--;
        if (CurrentHealth <= 0)
        {
            PlayerController.Instance.gameObject.SetActive(false);
            UIController.Instance.DeathScreen.SetActive(true);
        }
    }
}
