using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LitJson;
using System.IO;

public partial class GameManager : MonoBehaviour{
	
	public TextAsset JsonFile;

	GameObject map;
	[SerializeField]
	Transform mapPos;
	[SerializeField]
	GameObject characterSpwaner;

	List<ButtonStatus> playerMotion;

	GameObject userChar;
	Charater userChatInfo;
	//TestMode
	[SerializeField]
	GameObject policeObject; //매니저에서 받아오기
	
	JsonData jsonData;
	JsonData mapData;

	public GameObject mapTile;

	int[][] mapArr;
	
	public string mapNumber;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		//JsonFile = Resources.Load("Jsonfile/StageInfo") as TextAsset;
		JsonReader jr = new JsonReader(JsonFile.text);
		Debug.Log(JsonFile.text);
		JsonData getData = JsonMapper.ToObject(JsonFile.text);
		jsonData = JsonMapper.ToObject(jr);
		jr.Close();

		mapData = jsonData["mapdata"][0]; //맵데이터 지정 나중에 해야함 
		ChangePalyButton(true);

		//LoadMap();
		LoadJsonData();
		CreatMap();
		playerMotion = new List<ButtonStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void LoadJsonData()
	{
		mapArr = new int[mapData["map_info"].Count][];
		for(int i = 0; i< mapArr.Length; ++i)
		{
			mapArr[i] = new int[mapData["map_info"][0].Count];
			
			
			for (int j = 0; j < mapArr[i].Length; ++j)
			{
				mapArr[i][j] = (int)mapData["map_info"][i][j];
			}
		}
	}
	void CreatMap()
	{
		for (int i = 0; i < mapArr.Length; ++i)
		{
			for (int j = 0; j < mapArr[i].Length; ++j)
			{
				if (mapArr[i][j] == 1)
				{
					GameObject tile = Instantiate(mapTile, new Vector3(i, 0, j), Quaternion.identity, mapPos.transform);
				}
			}
		}
		SetMapInfo();
	}
	//void LoadMap()
	//{

	//    //map = new GameObject();

	//    //test
		
	//    mapNumber = "1-1";
	//    map = Instantiate(Resources.Load("Prefab/Map/" + mapNumber) as GameObject);
	//    map.transform.SetParent(mapPos);
	//    map.transform.localPosition = Vector3.zero;
	//    map.transform.localScale = Vector3.one;

	//    Debug.Log("Prefab/Map/" + mapNumber);

	//    if (map == null)
	//        return;

	//    SetMapInfo();
	//}

	void SetMapInfo()
	{
		int tileValue = mapPos.transform.childCount;
		if (tileValue == 0)
			return;

		Vector3 boxPos = mapPos.transform.GetChild(0).transform.position;
		characterSpwaner.transform.position = new Vector3(boxPos.x , boxPos.y += 0.5f, boxPos.z);
		StartCoroutine(MapAnimation(tileValue));
		
		
	}
	//start animation
	IEnumerator MapAnimation(int tilevalue)
	{
		for (int tilenum = 0; tilenum < tilevalue; tilenum++)
		{
			GameObject tileBox = mapPos.transform.GetChild(tilenum).gameObject;

			LeanTween.moveLocalY(tileBox, 0.5f, 0.2f);
			yield return new WaitForSeconds(0.2f);
			LeanTween.moveLocalY(tileBox, 0, 0.2f);
		}
		userChar = Instantiate(Resources.Load("Prefab/Charater/" + "SimplePeople_Police_White") as GameObject);
		userChar.transform.position = characterSpwaner.transform.position;
		userChatInfo = userChar.GetComponent<Charater>();
		playerPos = new PlayerInfo(0, 0);
	}
	//motion add
	public void AddMotion(ButtonStatus motionname)
	{
		playerMotion.Add(motionname);
	}

	public struct PlayerInfo
	{
		public int playerX;
		public int playerY;
		

		public PlayerInfo(int _playerX, int _playerY)
		{
			playerX = _playerX;
			playerY = _playerY;
		}
		public Vector3 NowPlayerInfo()
		{
			return new Vector3(playerX, playerY);
		}
	}
}
