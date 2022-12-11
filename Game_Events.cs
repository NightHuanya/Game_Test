using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Events : MonoBehaviour
{
    public Cool_Down_List cool_Down_List;
    private void Start()
    {
        cool_Down_List = GameObject.FindWithTag("Game_Manager").GetComponent<Cool_Down_List>();
        player_Scrpit = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Call_Skill(string Method_Nmae,string Skill_ID)
    {
            StartCoroutine(Method_Nmae,Skill_ID);
    }
    public void Call_Potion(string Method_Nmae, Item Potion)
    {
        StartCoroutine(Method_Nmae,Potion);
    }
    public void Call_SystemKey(string Method_Nmae)
    {
        for (int i = 0; i < cool_Down_List.Cool_Downs.Count; i++)
        {
            if (cool_Down_List.Cool_Downs[i].Name == Method_Nmae)
            {
                return;
            }
        }
            StartCoroutine(Method_Nmae);
    }

    public GameObject KeyBoard_UI;
    IEnumerator Open_KeyBoard_Setting()
    {
        cool_Down_List.Add_Cool_Down_Event("Open_KeyBoard_Setting", 0.3f);
        KeyBoard_UI.SetActive(!KeyBoard_UI.activeSelf);
        yield return null;
    }

    public GameObject Backpack_UI;
    IEnumerator Open_Backpack()
    {
        cool_Down_List.Add_Cool_Down_Event("Open_Backpack", 0.3f);
        Backpack_UI.SetActive(!Backpack_UI.activeSelf);
        yield return null;
    }

    public GameObject Skill_UI;
    IEnumerator Open_Skill()
    {
        cool_Down_List.Add_Cool_Down_Event("Open_Skill", 0.3f);
        Skill_UI.SetActive(!Skill_UI.activeSelf);
        yield return null;
    }

    public GameObject EquipmentInventory_UI;
    IEnumerator Open_EquipmentInventory()
    {
        cool_Down_List.Add_Cool_Down_Event("Open_EquipmentInventory", 0.3f);
        EquipmentInventory_UI.SetActive(!EquipmentInventory_UI.activeSelf);
        yield return null;
    }
    
    public GameObject CharacterStat_UI;
    IEnumerator Open_CharacterStat()
    {
        cool_Down_List.Add_Cool_Down_Event("Open_CharacterStat", 0.3f);
        CharacterStat_UI.SetActive(!CharacterStat_UI.activeSelf);
        yield return null;
    }

    public Player player_Scrpit;
    IEnumerator Normal_Attack()
    {
        cool_Down_List.Add_Cool_Down_Event("Normal_Attack", 0.05f);
        player_Scrpit.Player_Attack();
        yield return null;
    }
    IEnumerator Jump()
    {
        cool_Down_List.Add_Cool_Down_Event("Jump", 0.05f);
        player_Scrpit.Player_Jump();
        yield return null;
    }
    IEnumerator Pick_Up_Item()
    {
        cool_Down_List.Add_Cool_Down_Event("Pick_Up_Item", 0.05f);
        player_Scrpit.Player_Pick_Up_Item();
        yield return null;
    }
}
