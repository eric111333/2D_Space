using UnityEngine.UI;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public static int gold;
    private int HpPuls;
    private float UFOhpMax;
    private float UFOattackDamage;
    private int AttPuls;
    public Text goldtext;
    public Text Hptext;
    public Text expHptext;
    public Text expAtttext;
    public Text Atttext;
    void Start()
    {
        //gold = 5000;
        gold = PlayerPrefs.GetInt("gold");
        HpPuls = PlayerPrefs.GetInt("HpPuls");
        UFOhpMax = PlayerPrefs.GetFloat("UFOhpMax");
        AttPuls = PlayerPrefs.GetInt("AttPuls");
        UFOattackDamage = PlayerPrefs.GetFloat("UFOattackDamage");
        goldtext.text = "" + gold;
        Hptext.text = "" + UFOhpMax;
        Atttext.text = "" + UFOattackDamage;
        expHptext.text = "UFO血量提升" + "\n" + "$" + (300 + HpPuls * 100);
        expAtttext.text = "UFO攻擊提升" + "\n" + "$" + (300 + AttPuls * 100);
    }

    public void pulsHP()
    {
        if (gold >= 300 + HpPuls * 100)
        {
            gold -= 300 + HpPuls * 100;
            HpPuls++;
            UFOhpMax += 50;
            goldtext.text = "" + gold;
            Hptext.text = "" + UFOhpMax;
            expHptext.text = "UFO血量提升" + "\n" + "$" + (300 + HpPuls * 100);
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.SetFloat("HpPuls", HpPuls);
            PlayerPrefs.SetFloat("UFOhpMax", UFOhpMax);
        }
        if (gold < 300 + HpPuls * 100)
        {
            expHptext.text = "UFO血量提升" + "\n" + "金錢不足";
        }
    }
    public void pulsAttack()
    {
        if(gold>=300+AttPuls*100)
        {
            gold -= 300 + AttPuls * 100;
            AttPuls++;
            UFOattackDamage += 10;
            goldtext.text = "" + gold;
            Atttext.text = "" + UFOattackDamage;
            expAtttext.text = "UFO攻擊提升" + "\n" + "$" + (300 + AttPuls * 100);
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.SetInt("AttPuls", AttPuls);
            PlayerPrefs.SetFloat("UFOattackDamage", UFOattackDamage);
        }
        if(gold<300 +AttPuls*100)
        {
            expAtttext.text = "UFO攻擊提升"+ "\n"+"金錢不足";
        }    
    }
    void Update()
    {

    }


}
