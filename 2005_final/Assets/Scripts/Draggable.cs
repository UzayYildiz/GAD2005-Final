using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool IsDrag = false;
    private Vector3 mouseStartPost;
    private Vector3 SpriteStartPost;
    private Vector3 startPos;

    Image stainColor;

    bool DoOnce = true, IsMenuTrigger = true;

    GameObject prefab_A, prefab_B, prefab_C, prefab_D, prefab_E, prefab_F;
    GameObject parentObject;
    GameObject newObject;
    int column_1 = 130, column_2 = 355, row_1 = 815, row_2 = 615, row_3 = 420;

    private void Start()
    {
        stainColor = GetComponent<Image>();
        startPos = transform.position;

        parentObject = GameObject.Find("Grid");
        prefab_A = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_A.prefab");
        prefab_B = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_B.prefab");
        prefab_C = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_C.prefab");
        prefab_D = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_D.prefab");
        prefab_E = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_E.prefab");
        prefab_F = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_F.prefab");
    }

    private void Update()
    {
        if (gameObject.tag == "Finish" && stainColor.color == Color.black && DoOnce && IsMenuTrigger == false)
        {
            DoOnce = false;
            ClonePref();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObject.tag != "Finish")
        {
            if (stainColor.color == Color.green)
            {
                IsDrag = true;
                mouseStartPost = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                SpriteStartPost = transform.localPosition;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.tag != "Finish")
        {
            if (IsDrag)
            {
                transform.localPosition = SpriteStartPost + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseStartPost);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.tag = "Finish";
        IsDrag = false;
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Menu") && IsDrag == false)
        {
            gameObject.tag = "Building";
            transform.position = startPos;
            IsMenuTrigger = true;
        }
        else if (collider2D.CompareTag("Menu") == false)
        {
            IsMenuTrigger = false;
        }
    }

    void ClonePref()
    {
        if (gameObject.name == "Building_A")
        {
            newObject = Instantiate(prefab_A, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_1, row_1, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_A";
            GoldAndGem.CardBackgrounds[0] = newObject;
        }
        else if (gameObject.name == "Building_B")
        {
            newObject = Instantiate(prefab_B, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_2, row_1, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_B";
            GoldAndGem.CardBackgrounds[1] = newObject;
        }
        else if (gameObject.name == "Building_C")
        {
            newObject = Instantiate(prefab_C, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_1, row_2, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_C";
            GoldAndGem.CardBackgrounds[2] = newObject;
        }
        else if (gameObject.name == "Building_D")
        {
            newObject = Instantiate(prefab_D, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_2, row_2, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_D";
            GoldAndGem.CardBackgrounds[3] = newObject;
        }
        else if (gameObject.name == "Building_E")
        {
            newObject = Instantiate(prefab_E, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_1, row_3, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_E";
            GoldAndGem.CardBackgrounds[4] = newObject;
        }
        else if (gameObject.name == "Building_F")
        {
            newObject = Instantiate(prefab_F, new Vector3(0, 0, 0), Quaternion.identity);
            newObject.transform.SetParent(parentObject.transform);
            newObject.transform.position = new Vector3(column_2, row_3, 0);
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.name = "Building_F";
            GoldAndGem.CardBackgrounds[5] = newObject;
        }
    }
}