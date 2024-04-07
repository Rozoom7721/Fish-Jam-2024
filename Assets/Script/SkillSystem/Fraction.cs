using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fraction : MonoBehaviour
{


    public string fractionName;

    public FractionPassives fractionPassives;
    public FractionSkills fractionSkills;
    public FractionStatistics fractionStatistics;
    public int skillTier;
    public int bigPoints;
    public int smallPoints;


    public List<UnitStats> availbleUnits;

    public UnitStats meleeUnit;
    public UnitStats rangeUnit;
    public UnitStats tankUnit;
    public UnitStats healerUnit;

    public GameObject meleePrefab;
    public GameObject rangePrefab;
    public GameObject tankPrefab;
    public GameObject healerPrefab;

    public List<UnitStats> all_unit_types;


    public List<int> levelsDone;
    public int lastLevelId;

    private bool shouldNotify;
    private List<ISkillOnClickListener> skillOnClickListeners;
    public void addSkillOnClickListener(ISkillOnClickListener listener)
    {
        skillOnClickListeners.Add(listener);
    }
    private void notifySkillOnClickListeners()
    {
        if (shouldNotify == false) return;

        foreach(ISkillOnClickListener listener in skillOnClickListeners)
        {
            if(listener != null)
            {
                listener.onSkillOnClick();

            }
        }
    }

    private void Awake()
    {

        if(GameObject.FindGameObjectWithTag("Player") != gameObject && gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (GameObject.FindGameObjectWithTag("Enemy") != gameObject && gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        /*        skillOnClickListeners = new List<ISkillOnClickListener>();*/
        if (gameObject.tag == "Player")
        {
            DontDestroyOnLoad(gameObject);
            loadData();
        }
    }

    void Start()
    {
        RecalculateStatistits();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(fractionStatistics == null) fractionStatistics = gameObject.AddComponent<FractionStatistics>();

        if (scene.name == "SampleScene")
        {
            if (skillOnClickListeners != null)
            {
                skillOnClickListeners = null;
                shouldNotify = false;
            }

        }
        else
        {
            skillOnClickListeners = new List<ISkillOnClickListener>();
            shouldNotify = true;
        }


        RecalculateStatistits();
    }


    public void RecalculateStatistits()
    {
        updateSkillTier();
        CalculateGoldIncome();
        CalculateHealthPoints();
        CalculateCooldown();
        CalculateDamage();
        
        
        notifySkillOnClickListeners();
    }

    private void CalculateGoldIncome()
    {
        fractionStatistics.passiveGoldIncome = fractionPassives.basePassiveGoldIncome + fractionSkills.passiveGoldIncome;
        fractionStatistics.goldIncomeForUnit = fractionPassives.baseGoldIncomeForUnit + fractionSkills.goldIncomeForUnit;
    }

    private void CalculateHealthPoints()
    {
        fractionStatistics.unitHealthPoints = fractionPassives.baseUnitHealthPoints * Mathf.Pow(10, skillTier * 3);
        fractionStatistics.leaderHealthPoints = fractionPassives.baseLeaderHealthPoints *  Mathf.Pow(10, skillTier * 3);
    }

    private void CalculateCooldown()
    {
        fractionStatistics.cooldownOfSkills = fractionPassives.baseCooldownOfSkills - (fractionPassives.baseCooldownOfSkills * ((double)fractionSkills.cooldownOfSkills / 10));
        fractionStatistics.unitAttackSpeed = fractionPassives.baseUnitAttackSpeed + (fractionPassives.baseCooldownOfSkills * ((double)fractionSkills.cooldownOfSkills * 2 / 10));
    }

    private void CalculateDamage()
    {
        fractionStatistics.unitDamage = fractionPassives.baseUnitDamage * Mathf.Pow(10, skillTier * 3);
        fractionStatistics.unitCriticalHitChance = fractionPassives.baseUnitCriticalHitChance * fractionSkills.unitCriticalHitChance;
    }

    private void updateSkillTier()
    {
        if (fractionSkills.passiveGoldIncome >= 3
            && fractionSkills.unitHealthPoints >= 3
            && fractionSkills.cooldownOfSkills >= 3
            && fractionSkills.unitDamage >= 3)
        {
            skillTier = 4;
        }
        else if (fractionSkills.passiveGoldIncome >= 2
            && fractionSkills.unitHealthPoints >= 2
            && fractionSkills.cooldownOfSkills >= 2
            && fractionSkills.unitDamage >= 2)
        {
            skillTier = 3;
        }
        else if (fractionSkills.passiveGoldIncome >= 1
            && fractionSkills.unitHealthPoints >= 1
            && fractionSkills.cooldownOfSkills >= 1
            && fractionSkills.unitDamage >= 1)
        {
            skillTier = 2;
        }
        else
        {
            skillTier = 1;
        }

    }


    public void UpgradeSkill(string skillID, int tier)
    {

        if (tier > skillTier) return;

        switch(skillID)
        {
            case "passiveGoldIncome":
                if(bigPoints > 0 && fractionSkills.passiveGoldIncome < tier)
                {
                    fractionSkills.passiveGoldIncome += 1;
                    bigPoints -= 1;
                }
                break;

            case "goldIncomeForUnit":
                if (smallPoints > 0 && fractionSkills.goldIncomeForUnit < tier)
                {
                    fractionSkills.goldIncomeForUnit += 1;
                    smallPoints -= 1;
                }
                break;

            case "unitHealthPoints":
                if(bigPoints > 0 && fractionSkills.unitHealthPoints < tier)
                {
                    fractionSkills.unitHealthPoints += 1;
                    bigPoints -= 1;
                }
                break;

            case "leaderHealthPoints":
                if(smallPoints > 0 && fractionSkills.leaderHealthPoints < tier)
                { 
                    fractionSkills.leaderHealthPoints += 1;
                    smallPoints -= 1;
                }
                break;

            case "cooldownOfSkills":
                if(bigPoints > 0 && fractionSkills.cooldownOfSkills < tier)
                {
                    fractionSkills.cooldownOfSkills += 1;
                    bigPoints -= 1;
                }
                break;

            case "unitAttackSpeed":
                if(smallPoints > 0 && fractionSkills.unitAttackSpeed < tier)
                {
                    fractionSkills.unitAttackSpeed += 1;
                    smallPoints -= 1;
                }
                break;

            case "unitDamage":
                if(bigPoints > 0 && fractionSkills.unitDamage < tier)
                {
                    fractionSkills.unitDamage += 1;
                    bigPoints -= 1;
                }
                break;

            case "unitCriticalHitChance":
                if(smallPoints > 0 && fractionSkills.unitCriticalHitChance < tier)
                {
                    fractionSkills.unitCriticalHitChance += 1;
                    smallPoints -= 1;
                }
                break;

            default: break;

        }

        RecalculateStatistits();

    }

    public void AddUnit(string unitID)
    {
        foreach(UnitStats unit in all_unit_types)
        {
            if(unit.unitId == unitID)
            {
                if(!availbleUnits.Contains(unit))
                {
                    availbleUnits.Add(unit);
                    break;
                }
            }
        }
    }

    public void SelectUnit(string unitID)
    {

        foreach (UnitStats unit in all_unit_types)
        {
            if (unit.unitId == unitID)
            {

                if(availbleUnits.Contains(unit))
                {
                    if(unitID.Contains("melee"))
                    {
                        meleeUnit = unit;
                    }

                    if(unitID.Contains("range"))
                    {
                        rangeUnit = unit;
                    }

                    if(unitID.Contains("tank"))
                    {
                        tankUnit = unit;
                    }

                    if(unitID.Contains("healer"))
                    {
                        healerUnit = unit;
                    }

                }
                else
                {
                    Debug.Log("Unit is not avaible (not bought)");
                }

            }
        }
    }


    public void unselectUnit(string unitId)
    {
        Debug.Log(unitId);
        if(meleeUnit  !=null && meleeUnit.unitId == unitId)
        {
            meleeUnit = null;
            return;
        }

        if (rangeUnit != null &&  rangeUnit.unitId == unitId)
        {
            rangeUnit = null;
            return;
        }

        if  (tankUnit != null && tankUnit.unitId == unitId)
        {
            tankUnit = null;
            return;
        }

        if (healerUnit != null && healerUnit.unitId == unitId)
        {
            healerUnit = null;
            return;
        }

    }

    public void CopyFrom(Fraction other)
    {
        fractionName = other.fractionName;
        fractionPassives = other.fractionPassives;
        fractionSkills = other.fractionSkills;
        fractionStatistics = other.fractionStatistics;
        skillTier = other.skillTier;
        bigPoints = other.bigPoints;
        smallPoints = other.smallPoints;

        availbleUnits = new List<UnitStats>(other.availbleUnits);

        meleeUnit = other.meleeUnit;
        rangeUnit = other.rangeUnit;
        tankUnit = other.tankUnit;
        healerUnit = other.healerUnit;

        meleePrefab = other.meleePrefab;
        rangePrefab = other.rangePrefab;
        tankPrefab = other.tankPrefab;
        healerPrefab = other.healerPrefab;

        all_unit_types = new List<UnitStats>(other.all_unit_types);
    }

    public void saveData()
    {
        Debug.Log("Saving data");
        string levelsString = string.Join(",", levelsDone.ConvertAll(x => x.ToString()).ToArray());
        PlayerPrefs.SetString("levelsDone", levelsString);

        PlayerPrefs.SetInt("bigPoints", bigPoints);
        PlayerPrefs.SetInt("smallPoints", smallPoints);

        string availbleUnitsString = "";
        foreach(UnitStats unit in availbleUnits)
        {
            availbleUnitsString = availbleUnitsString + "," + unit.unitId;
        }
        PlayerPrefs.SetString("availbleUnits", availbleUnitsString);

        if(meleeUnit != null)
        {
            PlayerPrefs.SetString("meleeUnit", meleeUnit.unitId);
        }
        else
        {
            PlayerPrefs.SetString("meleeUnit", "");

        }

        if (rangeUnit != null)
        {
            PlayerPrefs.SetString("rangeUnit", rangeUnit.unitId);
        }
        else
        {
            PlayerPrefs.SetString("rangeUnit", "");

        }

        if (tankUnit != null)
        {
            PlayerPrefs.SetString("tankUnit", tankUnit.unitId);
        }
        else
        {
            PlayerPrefs.SetString("tankUnit", "");

        }

        if (healerUnit != null)
        {
            PlayerPrefs.SetString("healerUnit", healerUnit.unitId);
        }
        else
        {
            PlayerPrefs.SetString("healerUnit", "");

        }

    }

    private void loadData()
    {
        string levelsDoneString = PlayerPrefs.GetString("levelsDone", "");
        string[] levelsDoneArray = levelsDoneString.Split(',');

        foreach (string levelString in levelsDoneArray)
        {
            int level;
            if (int.TryParse(levelString, out level))
            {
                levelsDone.Add(level);
            }
            else
            {
                Debug.LogWarning("Failed to parse level: " + levelString);
            }
        }


        string availbleUnitsString = PlayerPrefs.GetString("availbleUnits", "");
        string[] availbleUnitsArray = availbleUnitsString.Split(',');

        foreach (string unitId in availbleUnitsArray)
        {
            foreach (UnitStats unit in all_unit_types)
            {
                if(unit.unitId == unitId)
                {
                    availbleUnits.Add(unit);
                    break;
                }
            }
        }

        bigPoints = PlayerPrefs.GetInt("bigPoints", 0);
        smallPoints = PlayerPrefs.GetInt("smallPoints", 0);

        string meleeString = PlayerPrefs.GetString("meleeUnit", "");
        if(meleeString != "")
        {
            foreach(UnitStats unit in all_unit_types)
            {
                if (unit.unitId == meleeString)
                { 
                    meleeUnit = unit;
                }
            }
        }

        string rangeString = PlayerPrefs.GetString("rangeUnit", "");
        if (rangeString != "")
        {
            foreach (UnitStats unit in all_unit_types)
            {
                if (unit.unitId == rangeString)
                {
                    rangeUnit = unit;
                }
            }
        }

        string tankString = PlayerPrefs.GetString("tankUnit", "");
        if (tankString != "")
        {
            foreach (UnitStats unit in all_unit_types)
            {
                if (unit.unitId == tankString)
                {
                    tankUnit = unit;
                }
            }
        }

        string healerString = PlayerPrefs.GetString("healerUnit", "");
        if (healerString != "")
        {
            foreach (UnitStats unit in all_unit_types)
            {
                if (unit.unitId == healerString)
                {
                    healerUnit = unit;
                }
            }
        }

    }


}
