using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public ItemManager itemManager;

    public Image cardDesign;

    [SerializeField] GameObject Card;
    public void Start()
    {
        int randomIndex = Random.Range(0, 9);
        gameObject.name = itemManager.items[randomIndex].cardName;
        cardDesign.sprite = itemManager.items[randomIndex].artwork;
    }
}