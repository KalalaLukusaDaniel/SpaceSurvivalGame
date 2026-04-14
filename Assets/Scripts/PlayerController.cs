using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Label levelText;
    private Label scoreText;
    private Label bonusText;
    private Button restartButton;

    private float levelScore = 0f;
    private int currentLevel = 1;
    private float levelMaxScore = 100f;

    private int lives = 0;

    private bool isTransitioning = false;

    private Vector2 startPosition;
    private float startRotation;

    public float scoreMultiplier = 10f;
    public float thrustForce = 1f;
    public float maxSpeed = 5f;

    public GameObject boosterFlame;
    public GameObject explosionEffect;

    private Rigidbody2D rb;

    public UIDocument uiDocument;

    public InputAction moveForward;
    public InputAction lookPosition;

    public static float obstacleSpeedMultiplier = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startPosition = rb.position;
        startRotation = rb.rotation;

        var root = uiDocument.rootVisualElement;

        scoreText = root.Q<Label>("ScoreLabel");
        levelText = root.Q<Label>("LevelLabel");
        bonusText = root.Q<Label>("BonusLabel");
        restartButton = root.Q<Button>("RestartButton");

        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;

        moveForward.Enable();
        lookPosition.Enable();

        scoreText.style.position = Position.Absolute;
        scoreText.style.top = 25;
        scoreText.style.right = 25;
        scoreText.style.fontSize = 20;

        levelText.style.position = Position.Absolute;
        levelText.style.top = 25;
        levelText.style.left = 25;
        levelText.style.fontSize = 16;
        levelText.style.color = Color.yellow;

        bonusText.style.position = Position.Absolute;
        bonusText.style.top = 55;
        bonusText.style.left = 25;
        bonusText.style.fontSize = 14;
        bonusText.style.color = Color.cyan;
    }

    void Update()
    {
        if (isTransitioning) return;

        levelScore += Time.deltaTime * scoreMultiplier;

        scoreText.text = "Score: " + Mathf.FloorToInt(levelScore) + " / " + levelMaxScore;
        bonusText.text = "Lives: " + lives;
        levelText.text = "LEVEL " + currentLevel;

        if (levelScore >= levelMaxScore)
        {
            NextLevel();
        }

        if (moveForward.IsPressed())
        {
            Vector3 screenPos = lookPosition.ReadValue<Vector2>();
            screenPos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            Vector2 direction = ((Vector2)worldPos - rb.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            rb.AddForce(direction * thrustForce);

            if (rb.linearVelocity.magnitude > maxSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        boosterFlame.SetActive(moveForward.IsPressed());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (lives > 0)
        {
            lives--;

            var sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = Color.white;
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            restartButton.style.display = DisplayStyle.Flex;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            lives++;
            levelScore += 10f;

            var sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = Color.cyan;

            RepositionBonus(other.gameObject);
        }
    }

    void RepositionBonus(GameObject bonus)
    {
        float x = Random.Range(-4f, 4f);
        float y = Random.Range(-3f, 3f);

        bonus.transform.position = new Vector2(x, y);
    }

    void NextLevel()
    {
        currentLevel++;

        if (currentLevel > 3)
        {
            scoreText.text = "VICTOIRE 🎉";
            Time.timeScale = 0f;
            return;
        }

        StartCoroutine(LevelTransition());
    }

    System.Collections.IEnumerator LevelTransition()
    {
        isTransitioning = true;

        Time.timeScale = 0f;

        levelText.text = "LEVEL " + currentLevel;
        scoreText.text = "LEVEL UP!";

        yield return new WaitForSecondsRealtime(2f);

        levelScore = 0f;
        levelMaxScore = currentLevel * 100f;
        lives = 0;

        rb.position = startPosition;
        rb.rotation = startRotation;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // 🔥 SEULE MODIF FAITE ICI
        obstacleSpeedMultiplier = Mathf.Pow(6f, currentLevel - 1);

        Time.timeScale = 1f;
        isTransitioning = false;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}