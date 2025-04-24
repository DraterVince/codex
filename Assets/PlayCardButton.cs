using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCardButton : MonoBehaviour
{
    ItemManager itemManager;

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject YouWinScreen;

    [SerializeField] TextMeshProUGUI playerHP;
    [SerializeField] TextMeshProUGUI enemyHP;

    public Item card;

    [SerializeField] GameObject Answer1;
    [SerializeField] GameObject Answer2;
    [SerializeField] GameObject Answer3;
    [SerializeField] GameObject Answer4;

    public Image playerHealthBar;
    public Image enemyHealthBar;
    public float playerHealthAmount = 4f;
    public float enemyHealthAmount = 4f;

    public Image cardDesign;

    Transform parent;
    [SerializeField] Transform playedCard;
    private void Update()
    {
        playerHP.text = playerHealthAmount.ToString() + " / 4";
        enemyHP.text = enemyHealthAmount.ToString() + " / 4";

        if (playerHealthAmount == 0f)
        {
            GameOverScreen.SetActive(true);
        }
        if (enemyHealthAmount == 0f)
        {
            YouWinScreen.SetActive(true);
        }
    }
    public void playButton()
    {
        int counter = 0;
        parent = transform.Find("PlayedCard");
        playedCard = parent.GetChild(0);

        if (counter == 0)
        {
            if (playedCard.name == "class")
            {
                EnemyTakeDamage(1);
                Answer1.SetActive(true);
                counter++;
            }
            else
            {
                PlayerTakeDamage(1);
            }
        }
        else if (counter == 1)
        {
            if (playedCard.name == "static")
            {
                EnemyTakeDamage(1);
                Answer2.SetActive(true);
                counter++;
            }
            else
            {
                PlayerTakeDamage(1);
            }
        }
        else if (counter == 2)
        {
            if (playedCard.name == "void")
            {
                EnemyTakeDamage(1);
                Answer3.SetActive(true);
                counter++;
            }
            else
            {
                PlayerTakeDamage(1);
            }
        }
        else if (counter == 3)
        {
            if (playedCard.name == "println")
            {
                EnemyTakeDamage(1);
                Answer4.SetActive(true);
                counter++;
            }
            else
            {
                PlayerTakeDamage(1);
            }
        }
    }
    public void PlayerTakeDamage(float damage)
    {
        playerHealthAmount -= damage;
        playerHealthBar.fillAmount = playerHealthAmount / 4f;
        
    }

    public void EnemyTakeDamage(float damage)
    {
        enemyHealthAmount -= damage;
        enemyHealthBar.fillAmount = enemyHealthAmount / 4f;
    }

    public void NextCards()
    {
        int randomIndex = Random.Range(0, 9);
        gameObject.name = itemManager.items[randomIndex].cardName;
        cardDesign.sprite = itemManager.items[randomIndex].artwork;
    }
}