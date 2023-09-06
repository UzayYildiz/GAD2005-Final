using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldAndGem : MonoBehaviour
{
    public static int[] GoldAndGemInt = new int[2];

    public static int[] Card1 = { 1, 3 };
    public static int[] Card2 = { 3, 5 };
    public static int[] Card3 = { 2, 7 };
    public static int[] Card4 = { 4, 8 };
    public static int[] Card5 = { 5, 9 };   
    public static int[] Card6 = { 6, 10 };

    public Text GoldText, GemText;
    public Text Card1_GoldText, Card1_GemText;
    public Text Card2_GoldText, Card2_GemText;
    public Text Card3_GoldText, Card3_GemText;
    public Text Card4_GoldText, Card4_GemText;
    public Text Card5_GoldText, Card5_GemText;
    public Text Card6_GoldText, Card6_GemText;

    public static List<GameObject> CardBackgrounds = new();
    Image[] cardImages;
 
    void Start()
    {
        if (!PlayerPrefs.HasKey("GoldInt") && !PlayerPrefs.HasKey("GemInt"))
        {
            PlayerPrefs.SetInt("GoldInt", 5);
            PlayerPrefs.SetInt("GemInt", 8);
        }

        GoldAndGemInt[0] = PlayerPrefs.GetInt("GoldInt");
        GoldAndGemInt[1] = PlayerPrefs.GetInt("GemInt");

        CardBackgrounds.Add(GameObject.Find("Building_A"));
        CardBackgrounds.Add(GameObject.Find("Building_B"));
        CardBackgrounds.Add(GameObject.Find("Building_C"));
        CardBackgrounds.Add(GameObject.Find("Building_D"));
        CardBackgrounds.Add(GameObject.Find("Building_E"));
        CardBackgrounds.Add(GameObject.Find("Building_F"));
    }

    void Update()
    {
         ChangeColor();
        ChangeTextFonck();
    }

    void ChangeColor()
    {
        cardImages = new Image[CardBackgrounds.Count];

        for (int i = 0; i < cardImages.Length; i++)
        {
            cardImages[i] = CardBackgrounds[i].GetComponent<Image>();
        }

        int[] cardArrayGold = new int[] { Card1[0], Card2[0], Card3[0], Card4[0], Card5[0], Card6[0] };
        int[] cardArrayGem = new int[] { Card1[1], Card2[1], Card3[1], Card4[1], Card5[1], Card6[1] };

        for (int r = 0; r < cardImages.Length; r++)
        {
            if (cardImages[r].gameObject.tag == "Finish")
            {
                cardImages[r].color = Color.black;
            }
            else if (GoldAndGemInt[0] < cardArrayGold[r] || GoldAndGemInt[1] < cardArrayGem[r])
            {
                cardImages[r].color = Color.red;
            }
            else if (GoldAndGemInt[1] < cardArrayGem[r])
            {
                cardImages[r].color = Color.red;
            }
            else
            {
                cardImages[r].color = Color.green;
            }
        }   
    }

    void ChangeTextFonck()
    {
        GoldText.text = GoldAndGemInt[0].ToString();
        GemText.text = GoldAndGemInt[1].ToString();

        Card1_GoldText.text = Card1[0].ToString();
        Card1_GemText.text = Card1[1].ToString();

        Card2_GoldText.text = Card2[0].ToString();
        Card2_GemText.text = Card2[1].ToString();

        Card3_GoldText.text = Card3[0].ToString();
        Card3_GemText.text = Card3[1].ToString();

        Card4_GoldText.text = Card4[0].ToString();
        Card4_GemText.text = Card4[1].ToString();

        Card5_GoldText.text = Card5[0].ToString();
        Card5_GemText.text = Card5[1].ToString();

        Card6_GoldText.text = Card6[0].ToString();
        Card6_GemText.text = Card6[1].ToString();
    }
}
