using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files

public class DataController : MonoBehaviour 
{
	private Data[] allData;

	private string gameDataFileName = "data.json";

	void Start()
	{
		DontDestroyOnLoad(gameObject);

		LoadGameData();

		//Cargar la escena del juego
	}

	public Data GetCurrentData()
	{
		// If we wanted to return different s, we could do that here
		// We could store an int representing the current  index in PlayerProgress

		return allData[0];
	}

	private void LoadGameData()
	{
		// Path.Combine combines strings into a file path
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

		if(File.Exists(filePath))
		{
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText(filePath); 
			// Pass the json to JsonUtility, and tell it to create a GameData object from it
			GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

			// Retrieve the allData property of loadedData
			allData = loadedData.allData;
		}
		else
		{
			Debug.LogError("Cannot load game data!");
		}
	}
}