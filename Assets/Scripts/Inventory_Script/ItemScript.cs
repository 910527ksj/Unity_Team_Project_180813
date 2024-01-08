using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ItemScript : MonoBehaviour
{
    static ItemScript _instance;
    public static ItemScript Instance()
    {
        return _instance;
    }

    public TextAsset jsonArmorData;
    public TextAsset jsonWeaponData;
    public TextAsset jsonOptionData;

    public GameObject ranManager;

    public string m_strName;

    private string m_strSpriteName;

    public UISprite m_sprIcon;

    public UISprite m_sprFrame;

    public GameObject m_selectFrame;

    public UILabel m_equipLabel;

    public InventoryManagerScript m_cParent;

    public GameObject normalF;
    public GameObject magicF;
    public GameObject rareF;    
    public GameObject legendF;

    //랜덤 스크립트에서 불러올 것
    public string ItemName; //아이템 이름
    public string GradeName; //아이템 등급명
    public int ItemRequestLevel; //아이템 착용 요구레벨
    public int ItemBuffCreateMin; //아이템의 최소공격력(방어구일 경우엔 이게 방어력)
    public int ItemBuffCreateMax; //아이템의 최대공격력
    public string ItemPre; //아이템의 접두사
    public string ItemSuf; //아이템의 접미사
    public List<string> OptionName; //옵션 이름
    public List<int> OptionBuffMin; //옵션의 최소수치
    public List<int> OptionBuffMax; //옵션의 최대수치
    public string ItemCategory;
    public int ItemLevel; //아이템 레벨

    public string ItemName_KR;
    public string ItemPre_KR;
    public string ItemSuf_KR;
    public List<string> OptionName_KR;

    public List<string> m_ItemNameList;
    public List<string> m_ItemNameList_KR;
    public List<string> m_ItemAffixName;
    public List<string> m_ItemAffixName_KR;
    public List<string> m_OptionName;
    public List<string> m_OptionName_KR;

    //아이템 고유정보
    public string itemDataJson;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        m_selectFrame.gameObject.SetActive(false);
        GradeFrame();
        InitItem();        
    }

    void Update()
    {
        
    }

    
    private void InitItem()
    {
        var ItemNameWeaponData = JSON.Parse(jsonWeaponData.text);

        for (int i = 0; i < 194; i++)
        {
            m_ItemNameList.Add(ItemNameWeaponData[i]["ItemName"]);
            m_ItemNameList_KR.Add(ItemNameWeaponData[i]["ItemName_kr"]);
        }

        var ItemNameArmorData = JSON.Parse(jsonArmorData.text);

        for (int i = 0; i < 151; i++)
        {
            m_ItemNameList.Add(ItemNameArmorData[i]["ItemName"]);
            m_ItemNameList_KR.Add(ItemNameArmorData[i]["ItemName_kr"]);
        }

        var ItemNameAffixNameData = JSON.Parse(jsonOptionData.text);

        for (int i = 0; i < 1243; i++)
        {
            m_ItemAffixName.Add(ItemNameAffixNameData[i]["ItemAffixeName"]);
            m_ItemAffixName_KR.Add(ItemNameAffixNameData[i]["ItemAffixeName_Kr"]);
        }

        var ItemBuffDataData = JSON.Parse(jsonOptionData.text);

        for (int i = 0; i < 1243; i++)
        {
            m_OptionName.Add(ItemNameAffixNameData[i]["BuffData[0]"]);
            m_OptionName_KR.Add(ItemNameAffixNameData[i]["BuffDataName_Kr"]);
        }
    }

    public void ItemOption()
    {
        ranManager.GetComponent<ItemRandom>().ItemGrade();
        ranManager.GetComponent<ItemRandom>().LoadItemTable();

        KRPatch();

        ItemName = ranManager.GetComponent<ItemRandom>().ItemName;
        ItemCategory = ranManager.GetComponent<ItemRandom>().ItemCategory;
        GradeName = ranManager.GetComponent<ItemRandom>().GradeName;
        ItemRequestLevel = ranManager.GetComponent<ItemRandom>().ItemRequestLevel;
        ItemBuffCreateMin = ranManager.GetComponent<ItemRandom>().ItemBuffCreateMin;
        ItemBuffCreateMax = ranManager.GetComponent<ItemRandom>().ItemBuffCreateMax;
        ItemPre = ranManager.GetComponent<ItemRandom>().ItemPre;
        ItemSuf = ranManager.GetComponent<ItemRandom>().ItemSuf;
        ItemLevel = ranManager.GetComponent<ItemRandom>().ItemLevel;

        //깊은 복사 해줘야므로
        OptionName = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
        OptionBuffMin = new List<int>(ranManager.GetComponent<ItemRandom>().OptionBuffMin);
        OptionBuffMax = new List<int>(ranManager.GetComponent<ItemRandom>().OptionBuffMax);
        
    }

    public void KRPatch()
    {
        for (int i = 0; i < m_ItemNameList.Count; i++)
        {
            if (ranManager.GetComponent<ItemRandom>().ItemName == m_ItemNameList[i])
            {
                for (int j = 0; j < m_ItemNameList_KR.Count; j++)
                {
                    if (i == j)
                    {
                        ItemName_KR = m_ItemNameList_KR[j];
                    }
                }
            }
        }

        for (int i = 0; i < m_ItemAffixName.Count; i++)
        {
            if (ranManager.GetComponent<ItemRandom>().ItemPre == m_ItemAffixName[i])
            {
                for (int j = 0; j < m_ItemAffixName_KR.Count; j++)
                {
                    if (i == j)
                    {
                        ItemPre_KR = m_ItemAffixName_KR[j];
                    }
                }
            }
        }

        for (int i = 0; i < m_ItemAffixName.Count; i++)
        {
            if (ranManager.GetComponent<ItemRandom>().ItemSuf == m_ItemAffixName[i])
            {
                for (int j = 0; j < m_ItemAffixName_KR.Count; j++)
                {
                    if (i == j)
                    {
                        ItemSuf_KR = m_ItemAffixName_KR[j];
                    }
                }
            }
        }

        for (int i = 0; i < m_OptionName.Count; i++)
        {
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 1)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                           
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 2)
            {                
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                            
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 3)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 4)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[3] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[3] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 5)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[3] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[3] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[4] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[4] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 6)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[3] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                  
                            OptionName_KR[3] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[4] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                   
                            OptionName_KR[4] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[5] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {              
                            OptionName_KR[5] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 7)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                         
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                      
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {             
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[3] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                 
                            OptionName_KR[3] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[4] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {          
                            OptionName_KR[4] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[5] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {             
                            OptionName_KR[5] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[6] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {           
                            OptionName_KR[6] = m_OptionName_KR[j];
                        }
                    }
                }
            }
            if (ranManager.GetComponent<ItemRandom>().OptionName.Count == 8)
            {
                if (ranManager.GetComponent<ItemRandom>().OptionName[0] == m_OptionName[i])
                {
                    OptionName_KR = new List<string>(ranManager.GetComponent<ItemRandom>().OptionName);
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                    
                            OptionName_KR[0] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[1] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {                 
                            OptionName_KR[1] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[2] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {               
                            OptionName_KR[2] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[3] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {               
                            OptionName_KR[3] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[4] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {     
                            OptionName_KR[4] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[5] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {           
                            OptionName_KR[5] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[6] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {            
                            OptionName_KR[6] = m_OptionName_KR[j];
                        }
                    }
                }
                if (ranManager.GetComponent<ItemRandom>().OptionName[7] == m_OptionName[i])
                {
                    for (int j = 0; j < m_OptionName_KR.Count; j++)
                    {
                        if (i == j)
                        {          
                            OptionName_KR[7] = m_OptionName_KR[j];
                        }
                    }
                }
            }
        }
    }
    void GradeFrame()
    {
        if(GradeName == "Normal")
        {
            normalF.SetActive(true);
            magicF.SetActive(false);
            rareF.SetActive(false);
            legendF.SetActive(false);
        }
        if (GradeName == "Magic")
        {
            normalF.SetActive(false);
            magicF.SetActive(true);
            rareF.SetActive(false);
            legendF.SetActive(false);
        }
        if (GradeName == "Rare")
        {
            normalF.SetActive(false);
            magicF.SetActive(false);
            rareF.SetActive(true);
            legendF.SetActive(false);
        }
        if (GradeName == "Legendary")
        {
            normalF.SetActive(false);
            magicF.SetActive(false);
            rareF.SetActive(false);
            legendF.SetActive(true);
        }
    }

    //터치 시 테두리 프레임 활성화
    public void SetSelected(bool bSelected)
    {
        m_selectFrame.gameObject.SetActive(bSelected);
    }


    // 정보를 설정하는 함수
    public void SettingInfo(string spriteName)
    {        
        // 같은 아틀라스에 있으니 스프라이트 이름 찾아 넣어주면 이미지가 바뀜
        m_sprIcon.spriteName = spriteName;
        gameObject.name = ItemPre_KR + " " + ItemSuf_KR + " " + ItemName_KR;
        //이름 설정
        m_strName = ItemPre_KR + " " + ItemSuf_KR + " " + ItemName_KR;
    }

    // 터치 하면 발생하는 이벤트
    // 전에 Button을 썼지만 OnClick으로 사용
    // OnClick은 NGUI에서 제공하는 함수로 터치하면 발생
    void OnClick()
    {
        Debug.Log(m_strName + " 이 클릭되었습니다.");

        // 부모에게 내가 선택 되었다고 알림
        //InventoryManagerScript 함수
        m_cParent.SelectItem(this);     // 이 함수는 조금 후에 만듬.우선 이렇게 작성.
    }

    
}
