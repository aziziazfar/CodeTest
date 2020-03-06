using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CubeController : MonoBehaviour {

	public GameObject cube;
	public Transform intitialPosition; //Point A
	public Transform targetPosition; // Point B
	public float AnimationDelay;
    public float AnimationDuration;
    public float CubeLifetime;

	public int initialNumCubes = 0;
	public static int numCubes;

	public Text numUI;



	[System.Serializable]
	public class Item
    {
        public float AnimationDelay;
        public float AnimationDuration;
        public float CubeLifetime;

		
		public static Item CreateFromJSON(string jsonString)
		{
			return JsonUtility.FromJson<Item>(jsonString);
		}
	}
	private void Awake() 
    {
        numUI.text = initialNumCubes.ToString();
    }

	// Use this for initialization
	void Start () {
		// perform Load from data.json file
		using (StreamReader r = new StreamReader("./Assets/Data.json"))
        {
            string json = r.ReadToEnd();
			Item item = Item.CreateFromJSON (json);
			AnimationDelay = item.AnimationDelay;
			AnimationDuration = item.AnimationDuration;
			CubeLifetime = item.CubeLifetime;
		}
	}
	public static void UpdateScore(int newScore) 
    {
        Debug.Log("Score Updated: Added " + newScore + " points!");
        numCubes += newScore;
    }

    void LateUpdate()
    {
        numUI.text = initialNumCubes.ToString();

        initialNumCubes = numCubes;
    }
	
	// Update is called once per frame
	void Update () {
		 
		if(Input.GetKeyDown(KeyCode.Return))
         {
			UpdateScore(1);
            Debug.Log("Cube Appears");
			NewCube();
     	}
	}

	private void NewCube()
	{

			Debug.Log(CubeLifetime);

			Vector3 cubePos = new Vector3(-5, 0, 5);
			Quaternion cubeRot = new Quaternion(0,0,0,0);
			GameObject newCube = Instantiate(cube, cubePos, cubeRot);
			
			// buggy
			// need to move into Update()
			// newCube.transform.position = Vector3.MoveTowards(intitialPosition.position, targetPosition.position, AnimationDuration);

			Destroy(newCube, CubeLifetime);
	}
}
