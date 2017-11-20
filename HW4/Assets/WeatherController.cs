using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

//using SimpleJSON;
//using JSONObject;
using System.Collections.Generic;
public class WeatherController : MonoBehaviour
{
	public String countryLocation;
 	public JSONObject returnvalue;
	public static WeatherController instance;

	public EffectInstantiate effect;

	void Start()
	{
		effect = FindObjectOfType (typeof(EffectInstantiate)) as EffectInstantiate;
		countryLocation = "UKXX0085";
		StartCoroutine(GetText (countryLocation));

	}

	public void setCountry(String country){
		StartCoroutine(GetText (country));

		//GetComponent()
		//EffectInstantiate xx = new EffectInstantiate();
		//xx.bobby (returnvalue.ToString ());
	}

	IEnumerator GetText (String countryLocation)
	{
		string encodedString = "{\"field1\": 0.5,\"field2\": \"sampletext\",\"field3\": [1,2,3]}";
		JSONObject weathericon = new JSONObject(encodedString);
		string encodedString2 = "{\"field1\": 0.5,\"field2\": \"sampletext\",\"field3\": [1,2,3]}";
		returnvalue = new JSONObject(encodedString2);
		String countrycode = String.Concat("https://hackathon.pic.pelmorex.com/api/data/observation?locationcode=",countryLocation);
		using (UnityWebRequest www = UnityWebRequest.Get(countrycode))
			//www.SetRequestHeader("Content-Type", "application/json");
		{
			yield return www.Send();
			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else //success
			{
				JSONObject weatherobs = new JSONObject(www.downloadHandler.text);
				weathericon = weatherobs.GetField("data").GetField("icon");

				String result = String.Concat ("https://hackathon.pic.pelmorex.com/api/icon?obs=", weathericon.str ,"&locale=en-CA");
				using (UnityWebRequest wwe = UnityWebRequest.Get(result))
					//www.SetRequestHeader("Content-Type", "application/json");
				{
					yield return wwe.Send();
					if (wwe.isNetworkError || wwe.isHttpError)
					{
						Debug.Log(wwe.error);
					}
					else //success
					{
						JSONObject weathericoninfo = new JSONObject(wwe.downloadHandler.text);
						returnvalue = weathericoninfo.GetField("image");

						Debug.Log(weathericon + " . " + returnvalue);

						effect.changeScene (returnvalue.ToString());
					}
				}



			}
		}

		Debug.Log (returnvalue);
	}




	void accessData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				Debug.Log(key);
				accessData(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			foreach(JSONObject j in obj.list){
				accessData(j);
			}
			break;
		case JSONObject.Type.STRING:
			Debug.Log(obj.str);
			break;
		case JSONObject.Type.NUMBER:
			Debug.Log(obj.n);
			break;
		case JSONObject.Type.BOOL:
			Debug.Log(obj.b);
			break;
		case JSONObject.Type.NULL:
			Debug.Log("NULL");
			break;
		}
	}
}
[System.Serializable]
public class Weather2
{
	public string meta;
	public string type;
}



