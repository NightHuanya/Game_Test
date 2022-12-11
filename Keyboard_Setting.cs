using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Key
{
    public string[] Event_Name = new string[0];
    public string Key_Name;
    public Image KeyImage;
    public Item[] Item_content = new Item[0];
    public string[] Skill_ID = new string[0];
}
public class Keyboard_Setting : MonoBehaviour
{
    public GameObject[] Standby_Keys;
    public Game_Key[] Keys = new Game_Key[54];
    public float[] Game_Keys_Cool_Down = new float[54];
    public GameObject Keys_Parent;
    public Game_Events game_Events;

    void Start()
    {
        GameObject[] All_KeysImage = GameObject.FindGameObjectsWithTag("ItemBox_KeyBoard");
        for (int i = 0; i < All_KeysImage.Length; i++)
        {
            Keys[i] = new Game_Key();
            Keys[i].KeyImage = All_KeysImage[i].GetComponent<Image>();
            Keys[i].Key_Name = All_KeysImage[i].name.Substring(4);
            Keys[i].Event_Name = All_KeysImage[i].GetComponent<UI_Drag_Base>().Method_Name;
        }
        Standby_Keys = GameObject.FindGameObjectsWithTag("ItemBox_Standby_Keys");
        game_Events = gameObject.GetComponent<Game_Events>();
    }

    // Update is called once per frame
    void Update()
    {
        int Index = 0;
        foreach ( Game_Key Key in Keys)
        {
            if (Input.GetKey(Key.Key_Name.ToLower()))
            {
                if(Game_Keys_Cool_Down[Index] >= 0.01f)
                {
                    for (int i = 0; i < Key.Event_Name.Length; i++)
                    {
                        switch (Key.KeyImage.gameObject.GetComponent<UI_Drag_Base>().Type.ToString())
                        {
                            case "Potion":
                                game_Events.Call_Potion((Key.Event_Name[i]), Key.Item_content[i]);
                                break;
                            case "Skill":
                                game_Events.Call_Skill((Key.Event_Name[i]), Key.Skill_ID[i]);
                                break;
                            case "SystemKey":
                                game_Events.Call_SystemKey((Key.Event_Name[i]));
                                break;
                            default:
                                break;
                        }
                    }
                    Game_Keys_Cool_Down[Index] = 0;
                }
                Game_Keys_Cool_Down[Index] += Time.deltaTime;
                Index++;
            }
        }
    }
}
