using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PayMoneyAndChangeColor : MonoBehaviour
{
	Image spriteRenderer;

	public Sprite tile_building;
	public Sprite tile_empty;

	bool DoOnce = true;

    public List<GameObject> _buildings;

    private void Start()
	{
        spriteRenderer = GetComponent<Image>();
    }

	private void OnTriggerStay2D(Collider2D collider2D)
	{
		if (collider2D.CompareTag("Finish") && DoOnce && !PlayerPrefs.HasKey(gameObject.name))
		{
			DoOnce = false;
			PayMoneyChangeColorFonck(collider2D);
			SaveCubeDataFonck(collider2D);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Finish"))
		{
			spriteRenderer.sprite = tile_empty;
			DoOnce = true;
		}
	}

	void PayMoneyChangeColorFonck(Collider2D collider2D)
	{
		if (collider2D.name == "Building_A")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card1[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card1[1];
		}
		else if (collider2D.name == "Building_B")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card2[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card2[1];
		}
		else if (collider2D.name == "Building_C")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card3[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card3[1];
		}
		else if (collider2D.name == "Building_D")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card4[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card4[1];
		}
		else if (collider2D.name == "Building_E")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card5[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card5[1];
		}
		else if (collider2D.name == "Building_F")
		{
			GoldAndGem.GoldAndGemInt[0] = GoldAndGem.GoldAndGemInt[0] - GoldAndGem.Card6[0];
			GoldAndGem.GoldAndGemInt[1] = GoldAndGem.GoldAndGemInt[1] - GoldAndGem.Card6[1];
		}

		PlayerPrefs.SetInt("GoldInt", GoldAndGem.GoldAndGemInt[0]);
		PlayerPrefs.SetInt("GemInt", GoldAndGem.GoldAndGemInt[1]);

        spriteRenderer.sprite = tile_building;
    }

	void SaveCubeDataFonck(Collider2D collider2D)
	{
		PlayerPrefs.SetString(gameObject.name,collider2D.name);
	}
}
