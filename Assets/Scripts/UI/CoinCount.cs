using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Unicorn.UI
{
	public class CoinCount : MonoBehaviour {

		private Text txt;

		void Start () {
			txt = GetComponent <Text> ();
			PlayerPrefs.SetInt("Coins", 0);
			txt.text = PlayerPrefs.GetInt("Coins").ToString() + "/" + 20;
		}
	}
}