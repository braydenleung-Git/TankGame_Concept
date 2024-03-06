using UnityEngine;
using System.Collections.Generic;

public class SceneButton : MonoBehaviour
{
    [Header("Objects pass through")]
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private GameObject maps;
    List<GameObject> avalible_Scenes = new List<GameObject>();
    private void Start()
    {
        // Find all components in the grid GameObject and its children
        GameObject[] Scenes = maps.GetComponentsInChildren<GameObject>();

        // Add references to the list
        avalible_Scenes.AddRange(Scenes);
        for (int i = 0; i < avalible_Scenes.Count; i++)
        {
            if (avalible_Scenes[i].activeSelf)
            {
                text.SetText(avalible_Scenes[i].name);
            }
        }
    }
    public void OnButtonPress()
    {
        //for each item in avalible_Scenes
        for(int i = 0; i<avalible_Scenes.Count; i++)
        {
            //if the current item is "active"
            if (avalible_Scenes[i].activeSelf)
            {
                /*
                 set the next scene as the active scene, to "toggle between scenes"
                 but if the i+1 is larger than the size of the list, then set the start as the active scene,
                 to prevent index out of bound.
                 */
                if(i+1 > avalible_Scenes.Count - 1)
                {
                    //setting the index 0 object/scene as "Active"
                    avalible_Scenes[0].SetActive(true);
                    avalible_Scenes[i].SetActive(false);
                    text.SetText(avalible_Scenes[0].name);
                    break;
                }
                else
                {
                    //setting the next object/scene as "Active"
                    avalible_Scenes[i + 1].SetActive(true);
                    avalible_Scenes[i].SetActive(false);
                    text.SetText(avalible_Scenes[i + 1].name);
                    break;
                }
            }
        }
    }
}
