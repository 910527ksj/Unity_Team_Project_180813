using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class testItemRandomBackUp : MonoBehaviour
{
    static testItemRandomBackUp _instance = null;
    public static testItemRandomBackUp Instance()
    {
        return _instance;
    }

    public bool RandomStart; //최적화를 위한 랜덤 중복 방지
    public int playerLV; //플레이어 레벨

    //**
    public List<TextAsset> ItemTable; //무기, 방어구 같은 대분류 테이블 파일 리스트
    public TextAsset OptionTable; //옵션 테이블 파일
    //**

    public int SelectTableNum; //랜덤으로 선택된 대분류 테이블 번호
    public int ItemLevelRange = 5; //랜덤으로 등장할 아이템 레벨의 범위

    //**
    public bool InvenMargin; //인벤토리에 여유공간이 있으면 true, 없으면 false
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
    //**

    public int OptionCount; //아이템에 붙일 옵션의 갯수
    public string ItemCategory; //아이템 카테고리명
    public int ItemLevel; //아이템 레벨
    public List<string> RandomItemName;
    public List<int> OptionNum;
    public List<int> FinalOpt;
    public List<int> FinalOptGroup;
    public List<int> PreFinalOpt; //옵션의 접두사
    public List<int> SufFinalOpt; //옵션의 접미사

    void Start()
    {
        if (_instance == null)
            _instance = this;

        playerLV = PlayerPrefs.GetInt("playerLV", 1); //가져올 플레이어 레벨이 없으면 기본값은 1
        RandomStart = true; //상자 사용하기 버튼을 눌렀음
        InvenMargin = true;
        IventoryMargin();
    }

    void IventoryMargin() //인벤토리에 여유 공간이 있는지 체크
    {
        if (InvenMargin == true)
        {
            ItemGrade(); // 아이템의 등급과 붙일 옵션 갯수 결정하기
            LoadItemTable(); // 아이템 대분류 테이블 랜덤으로 가져오기
        }
        else
        {
            //인벤토리에 여유공간이 없습니다. 인벤토리를 비워주세요. 라는 메시지창 출력
        }
    }

    public void ItemGrade() //아이템의 등급과 붙일 옵션 갯수 결정
    {
        int GradeProba = Random.Range(0, 1000);

        if (0 <= GradeProba && GradeProba < 800)
        {
            GradeName = "Normal";
            OptionCount = 1;
        }
        if (800 <= GradeProba && GradeProba < 950)
        {
            GradeName = "Magic";
            OptionCount = Random.Range(2, 5);
        }
        if (950 <= GradeProba && GradeProba < 999)
        {
            GradeName = "Rare";
            OptionCount = Random.Range(5, 8);
        }
        if (999 <= GradeProba && GradeProba < 1000)
        {
            GradeName = "Legendary";
            OptionCount = 8;
        }
    }

    public void LoadItemTable() //아이템 대분류 테이블 가져오기
    {
        int ItemTableMax = ItemTable.Count;
        SelectTableNum = Random.Range(0, ItemTableMax);

        HighLVItemSearch();
    }

    void HighLVItemSearch() //테이블 안에서 플레이어 레벨과 같거나 레벨이 높은 아이템 전부 검색
    {
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);

        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i]["ItemLevel"] >= playerLV && ItemData[i]["ItemLevel"] <= playerLV + ItemLevelRange)
            {
                int j = 1;
                do
                {
                    if (ItemData[i]["ItemLevel"] == playerLV)
                    {
                        RandomItemName.Add(ItemData[i]["ItemName"]);
                        break;
                    }
                    else
                    {
                        if (ItemData[i]["ItemLevel"] == playerLV + j)
                        {
                            RandomItemName.Add(ItemData[i]["ItemName"]);
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                } while (ItemData[i]["ItemLevel"] > playerLV + ItemLevelRange);
            }
        }

        if (RandomItemName.Count == 0)
            LowLVItemSearch();
        if (RandomItemName.Count > 0)
            SelectItem();
    }
    void LowLVItemSearch() //플레이어 레벨과 같거나 높은 아이템이 테이블에 없다면 낮은거 전부 검색
    {
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);

        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i]["ItemLevel"] >= playerLV - ItemLevelRange && ItemData[i]["ItemLevel"] < playerLV)
            {
                int j = 1;
                do
                {
                    if (ItemData[i]["ItemLevel"] == playerLV - j)
                    {
                        RandomItemName.Add(ItemData[i]["ItemName"]);
                        break;
                    }
                    else
                    {
                        j++;
                    }
                } while (ItemData[i]["ItemLevel"] > playerLV - ItemLevelRange);
            }
        }

        SelectItem();
    }

    void SelectItem() //아이템 1개 골라내서 요구레벨, 최소공격력, 최대공격력 랜덤 돌리기
    {
        //위에서 검색한 아이템들 랜덤 돌려서 1개만 골라내기
        int RandomItemNum = Random.Range(0, RandomItemName.Count);
        ItemName = RandomItemName[RandomItemNum];
        RandomItemName.Clear();

        //골라낸 아이템에 수치들 랜덤 돌려서 붙이기
        var ItemData = JSON.Parse(ItemTable[SelectTableNum].text);
        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i]["ItemName"] == ItemName)
            {
                ItemLevel = ItemData[i]["ItemLevel"];
                ItemCategory = ItemData[i]["ItemCategory"]; // 카테고리명을 기준으로 옵션 돌릴 것
                ItemRequestLevel = Random.Range(ItemData[i]["ItemRequestLevelMin"], ItemData[i]["ItemRequestLevelMax"] + 1);
                ItemBuffCreateMin = Random.Range(ItemData[i]["ItemBuffCreateMinMin[0]"], ItemData[i]["ItemBuffCreateMinMax[0]"] + 1);
                ItemBuffCreateMax = Random.Range(ItemData[i]["ItemBuffCreateMaxMin[0]"], ItemData[i]["ItemBuffCreateMaxMax[0]"] + 1);
            }
        }

        OptionSearch();
    }

    void OptionSearch() //아이템 카테고리와 착용레벨 기준으로 옵션 검색
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                string ItemCategoryStr = "ItemCategoryDatas[" + j + "]";

                if (ItemCategory == OptionData[i][ItemCategoryStr])
                {
                    if (OptionData[i]["ItemLevelRestrictSt"] <= ItemLevel && ItemLevel <= OptionData[i]["ItemLevelRestrictEd"])
                    {
                        OptionNum.Add(OptionData[i]["ItemAffixeDataKey"]);
                    }
                }
            }
        }

        OptionSelect();
    }
    void OptionSelect() //최종 선택된 옵션 랜덤 돌리고 마무리
    {
        var OptionData = JSON.Parse(OptionTable.text);

        //등급마다 정해진 수 만큼 옵션 랜덤 돌리기
        do
        {
            int FinalOption = Random.Range(0, OptionNum.Count);

            for (int i = 0; i < OptionData.Count; i++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == OptionNum[FinalOption])
                {
                    int optGroupNum = OptionData[i]["ItemAffixGroup"];
                    bool optGroup = FinalOptGroup.Contains(optGroupNum);
                    if (optGroup == false)
                    {
                        FinalOpt.Add(OptionNum[FinalOption]);
                        FinalOptGroup.Add(optGroupNum);
                    }
                }
            }
        } while (FinalOpt.Count < OptionCount);

        OptionNum.Clear();

        FinalOption();
        PreOrSuf();

        FinalOpt.Clear();
        FinalOptGroup.Clear();

        ItemOutput();
        RandomStart = false;
    }

    void FinalOption() //최종 옵션에서 능력치 뽑아오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < FinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == FinalOpt[j])
                {
                    OptionName.Add(OptionData[i]["BuffData[0]"]);

                    int BuffMin = Random.Range(OptionData[i]["BuffCreateMinMin[0]"], OptionData[i]["BuffCreateMinMax[0]"]);
                    int BuffMax = Random.Range(OptionData[i]["BuffCreateMaxMin[0]"], OptionData[i]["BuffCreateMaxMax[0]"]);

                    OptionBuffMin.Add(BuffMin);
                    OptionBuffMax.Add(BuffMax);
                }
            }
        }
    }
    void PreOrSuf() //최종 옵션에서 접두사와 접미사로 각각 분류
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < FinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == FinalOpt[j])
                {
                    string Pref = "ITEM_AFFIX_PREFIX";
                    string Suff = "ITEM_AFFIX_SUFFIX";
                    if (OptionData[i]["AffixType"] == Pref)
                    {
                        PreFinalOpt.Add(FinalOpt[j]);
                    }
                    if (OptionData[i]["AffixType"] == Suff)
                    {
                        SufFinalOpt.Add(FinalOpt[j]);
                    }
                }
            }
        }

        if (PreFinalOpt.Count > 0)
        {
            PreSelect();
            PreFinalOpt.Clear();
        }

        if (SufFinalOpt.Count > 0)
        {
            SufSelect();
            SufFinalOpt.Clear();
        }
    }
    void PreSelect() //옵션 최대레벨이 가장 높은 접두사를 가져오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < PreFinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == PreFinalOpt[j])
                {
                    int optionLevel = OptionData[i]["ItemLevelRestrictEd"];
                    int optionLevelMax = 0;

                    if (optionLevel > optionLevelMax)
                    {
                        optionLevelMax = optionLevel;
                        ItemPre = OptionData[i]["ItemAffixeName"];
                    }
                }
            }
        }
    }
    void SufSelect() //옵션 최대레벨이 가장 높은 접미사를 가져오기
    {
        var OptionData = JSON.Parse(OptionTable.text);

        for (int i = 0; i < OptionData.Count; i++)
        {
            for (int j = 0; j < SufFinalOpt.Count; j++)
            {
                if (OptionData[i]["ItemAffixeDataKey"] == SufFinalOpt[j])
                {
                    int optionLevel = OptionData[i]["ItemLevelRestrictEd"];
                    int optionLevelMax = 0;

                    if (optionLevel > optionLevelMax)
                    {
                        optionLevelMax = optionLevel;
                        ItemSuf = OptionData[i]["ItemAffixeName"];
                    }
                }
            }
        }
    }

    void ItemOutput() //랜덤함수의 결과값을 전부 더해서 최종 출력한 아이템 정보를 텍스트 파일에 저장
    {
        ItemData itemdatas = new ItemData();
        var FinalItemJson = JsonUtility.ToJson(itemdatas);
        //
        StreamWriter sw = new StreamWriter("Assets/Resources/playerItem.txt", true); //파일생성
        sw.WriteLineAsync(FinalItemJson);
        sw.Close();

        OptionName.Clear();
        OptionBuffMin.Clear();
        OptionBuffMax.Clear();
    }
}

public class ItemData
{
    public string ItemName = ItemRandom.Instance().ItemName; //아이템 이름
    public string GradeName = ItemRandom.Instance().GradeName; //아이템 등급명
    public int ItemRequestLevel = ItemRandom.Instance().ItemRequestLevel; //아이템 착용 요구레벨
    public int ItemBuffCreateMin = ItemRandom.Instance().ItemBuffCreateMin; //아이템의 최소공격력(방어구일 경우엔 이게 방어력)
    public int ItemBuffCreateMax = ItemRandom.Instance().ItemBuffCreateMax; //아이템의 최대공격력
    public string ItemPre = ItemRandom.Instance().ItemPre; //아이템의 접두사
    public string ItemSuf = ItemRandom.Instance().ItemSuf; //아이템의 접미사
    public List<string> OptionName = ItemRandom.Instance().OptionName; //옵션 이름
    public List<int> OptionBuffMin = ItemRandom.Instance().OptionBuffMin; //옵션의 최소수치
    public List<int> OptionBuffMax = ItemRandom.Instance().OptionBuffMax; //옵션의 최대수치
}


