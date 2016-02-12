using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PokemonInfoPanel : MonoBehaviour
{
	private const string hpSliderName = "PlayerHPSlider";
	private const string hpCurrentName = "PlayerHPCurrentTxt";
	private const string hpTotalName = "PlayerHPTotalTxt";
	private const string xpTextName = "PlayerLvlText";
	private Slider hpSlider;
	private Health hpScript;
	private Text hpCurrentTxt;
	private Text hpTotalTxt;
	private Text xpText;
	private Experience xpScript;
	private int lastLvl = 0;


	void Awake()
	{
		Transform hpSliderTrans = transform.Find (hpSliderName);
		if (hpSliderTrans != null) {
			hpSlider = hpSliderTrans.GetComponent<Slider> ();
		}
		Transform hpCurTxtTrans = transform.Find (hpCurrentName);
		if (hpCurTxtTrans != null) {
			hpCurrentTxt = hpCurTxtTrans.GetComponent<Text> ();
		}
		Transform hpTotalTxtTrans = transform.Find (hpTotalName);
		if (hpTotalTxtTrans != null) {
			hpTotalTxt = hpTotalTxtTrans.GetComponent<Text> ();
		}
		Transform xpTextTrans = transform.Find (xpTextName);
		if (xpTextTrans != null) {
			xpText = xpTextTrans.GetComponent<Text> ();
		}
	}
	
	void LateUpdate() 
	{
		if (hpScript != null) {
			hpSlider.value = hpScript.currentHP / hpScript.totalHP;
			hpCurrentTxt.text = hpScript.currentHP.ToString("0");
			hpTotalTxt.text = hpScript.totalHP.ToString();
		}
		if (xpScript != null && xpScript.level != lastLvl) {
			xpText.text = xpScript.level.ToString ();
		}
	}

	public void linkPokemon(PlayerSprite player)
	{
		hpScript = player.hp;
		xpScript = player.xp;
	}

	public void unlinkPokemon()
	{
		// TODO: Zero out values here
		hpScript = null;
		xpScript = null;
	}




}
