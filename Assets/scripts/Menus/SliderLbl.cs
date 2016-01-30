using UnityEngine;
using System.Collections;

public class SliderLbl : MonoBehaviour {
	public InstantGuiSlider belongsTo;
	public InstantGuiElement display;

	private float lastVal = 0;
	void LateUpdate()
	{
		if (belongsTo.value != lastVal) {
			lastVal = belongsTo.value;
			display.text = belongsTo.value.ToString ("0") + "%";
		}
	}
}
