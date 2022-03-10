using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DataNeededSelectorEditor : MonoBehaviour
{
    static List<CraftingDataNeeded> items;
#if UNITY_EDITOR
    // Start is called before the first frame update
    [MenuItem("Tacabur Yar/Crafting System/GetCraftingDataNeeded")]
    static void GetAllCraftingDataNeeded()
    {
        items = ScriptableObjectsFinder.GetAllInstancesInPath<CraftingDataNeeded>("Assets/CraftingSystem/ItemsNeeded");
        GameObject.Find("CraftingPanel").GetComponent<DataNeededSelector>().RecieveData(items);
    }
#endif
}
