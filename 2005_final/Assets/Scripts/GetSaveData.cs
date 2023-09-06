using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GetSaveData : MonoBehaviour
{
    GameObject dataaObject;
    GameObject parentObject;
    GameObject prefab_A, prefab_B, prefab_C, prefab_D, prefab_E, prefab_F;
    Sprite tile_building;

    Image spriteRenderer;

    void Start()
    {
        parentObject = GameObject.Find("Grid");
        prefab_A = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_A.prefab");
        prefab_B = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_B.prefab");
        prefab_C = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_C.prefab");
        prefab_D = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_D.prefab");
        prefab_E = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_E.prefab");
        prefab_F = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Building_F.prefab");
        tile_building = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Images/tile-empty.png");
        spriteRenderer = GetComponent<Image>();
        GetSaveDataFonck();
    }

    void GetSaveDataFonck()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            ClonePref();
            spriteRenderer.sprite = tile_building;
        }
    }

    void ClonePref()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "Building_A")
        {
            dataaObject = Instantiate(prefab_A, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_A";
            dataaObject.tag = "Finish";
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Building_B")
        {
            dataaObject = Instantiate(prefab_B, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_B";
            dataaObject.tag = "Finish";
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Building_C")
        {
            dataaObject = Instantiate(prefab_C, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_C";
            dataaObject.tag = "Finish";
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Building_D")
        {
            dataaObject = Instantiate(prefab_D, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_D";
            dataaObject.tag = "Finish";
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Building_E")
        {
            dataaObject = Instantiate(prefab_E, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_E";
            dataaObject.tag = "Finish";
        }
        else if (PlayerPrefs.GetString(gameObject.name) == "Building_F")
        {
            dataaObject = Instantiate(prefab_F, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            dataaObject.transform.SetParent(parentObject.transform);
            dataaObject.transform.localScale = new Vector3(1f, 1f, 1f);
            dataaObject.name = "Building_F";
            dataaObject.tag = "Finish";
        }
    }
}
