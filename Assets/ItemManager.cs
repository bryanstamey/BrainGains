﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using UnityEngine.UI;


public class ItemManager : MonoBehaviour {

	public static ItemManager instance;

	public GameObject panel;

	public Sprite brainPoster;
	public Sprite hangPoster;
	public Sprite bottles;
	public Sprite ovalRug;
	public Sprite starRug;
	public Sprite squareRug;
	public Sprite blinds;
	public Sprite curtains;
	public Sprite windows;
	public Sprite dumbell;
	public Sprite bag;
	public Sprite jumpRope;
	public Sprite bike;
	public Sprite mirror;
	public Sprite treadmill;

	//Game objects in scene that are the items in the Brain Cavity
	public GameObject brainPosterDecorate;
	public GameObject hangPosterDecorate;
	public GameObject bottlesDecorate;
	public GameObject ovalRugDecorate;
	public GameObject starRugDecorate;
	public GameObject squareRugDecorate;
	public GameObject blindsDecorate;
	public GameObject curtainsDecorate;
	public GameObject windowsDecorate;
	public GameObject dumbellDecorate;
	public GameObject bagDecorate;
	public GameObject jumpRopeDecorate;
	public GameObject bikeDecorate;
	public GameObject mirrorDecorate;
	public GameObject treadmillDecorate;

	public GameObject itemUIPrefab;
	private GameObject[] activeShopItems = new GameObject[3];
	private int numbOfItems = 0; //Number of items shown in the current shop/decorate UI

	private float xScale;
	private float yScale;
	private float incXVal;

	//Lay out all items available for each space
	[HideInInspector]
	public Item[] spaceA = new Item[3];
	public Item[] spaceB = new Item[3];
	public Item[] spaceC = new Item[3];
	public Item[] spaceD = new Item[3];
	public Item[] spaceE = new Item[3];
	public bool isDecorate = true;


	public int neurobucks = 100;
	public Text neuroBucks_Text;
	// Use this for initialization

	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else if (instance != this) {
			//Destroy (gameObject);
		}
	}
	void Start () {
		xScale = 11.476f;
		yScale = 12.911f;
		incXVal = 80;

		Item blindsItem = new Item (50, blinds, 'a', 1, blindsDecorate);
		Item curtainsItem = new Item (50, curtains, 'a',2, curtainsDecorate);
		Item windowsItem = new Item (100, windows, 'a',3, windowsDecorate);
		spaceA = new Item[] { blindsItem, curtainsItem, windowsItem }; 

		Item dumbellItem = new Item (50, dumbell, 'b',4, dumbellDecorate);
		Item bagItem = new Item (50, bag, 'b',5, bagDecorate);
		Item jumpRopeItem = new Item (100, jumpRope, 'b',6, jumpRopeDecorate);
		spaceB = new Item[] { dumbellItem, bagItem, jumpRopeItem }; 

		Item bikeItem = new Item (50, bike, 'c',7, bikeDecorate);
		Item mirrorItem = new Item (50, mirror, 'c',8, mirrorDecorate);
		Item treadmillItem = new Item (100, treadmill, 'c',9, treadmillDecorate);
		spaceC = new Item[] { bikeItem, mirrorItem, treadmillItem }; 

		Item ovalRugItem = new Item (50, ovalRug, 'd',10, ovalRugDecorate);
		Item squareRugItem = new Item (50, squareRug, 'd',11, squareRugDecorate);
		Item starRugItem = new Item (100, starRug, 'd',12, starRugDecorate);
		spaceD = new Item[] { ovalRugItem, squareRugItem, starRugItem }; 

		Item brainPItem = new Item (50, brainPoster, 'e',13, brainPosterDecorate);
		Item hangPItem = new Item (50, hangPoster, 'e',14, hangPosterDecorate);
		Item bottleShelfItem = new Item (100, bottles, 'e',15, bottlesDecorate);
		spaceE = new Item[] { brainPItem, hangPItem, bottleShelfItem }; 
	}
	
	// Update is called once per frame
	void Update () {
		neuroBucks_Text.text = neurobucks.ToString ();
	}

	public void displayShopItems(char space)
	{
		refreshShopItems ();
		if (space == 'a') {
			for(int i = 0; i < spaceA.Length; i++)
			{
				//This should work to where, if the shop should be in decorate mode, it will show stuff sold, and vice versa
				if(spaceA[i].getSold() == isDecorate){
					//Instatiate Item based on Prefab
					activeShopItems [numbOfItems] = Instantiate (itemUIPrefab, panel.transform.position,panel.transform.rotation);
					//Set it to be a parent of the space game object
					activeShopItems [numbOfItems].transform.SetParent (panel.transform,false);
					//Depending on how many items are in the list for that space, space them out
					activeShopItems [numbOfItems].transform.Translate (incXVal * numbOfItems,0,0);
					activeShopItems [numbOfItems].GetComponent<RectTransform> ().anchoredPosition.Set (incXVal * numbOfItems, 40);
					//Depending on what item it is, get the sprite and make it the new image 
					activeShopItems [numbOfItems].GetComponent<Image> ().sprite = spaceA [i].getSprite ();
					//Depending on what item it is, get the cost and make it the new text
					if(isDecorate == false)
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = spaceA [i].getCost();
					else
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = null;
					//Attach item to itemButton script in Prefab
					activeShopItems [numbOfItems].GetComponent<ItemButton>().holder = spaceA[i];
					//Number of items displayed increases
					numbOfItems++;
				}
			}

		} else if (space == 'b') {
			for(int i = 0; i < spaceB.Length; i++)
			{
				if(spaceB[i].getSold() == isDecorate){
					//Instatiate Item based on Prefab
					activeShopItems [numbOfItems] = Instantiate (itemUIPrefab, panel.transform.position,panel.transform.rotation);
					//Set it to be a parent of the space game object
					activeShopItems [numbOfItems].transform.SetParent (panel.transform,false);
					//Depending on how many items are in the list for that space, space them out
					activeShopItems [numbOfItems].transform.Translate (incXVal * numbOfItems,0,0);
					activeShopItems [numbOfItems].GetComponent<RectTransform> ().anchoredPosition.Set (incXVal * numbOfItems, 40);
					//Depending on what item it is, get the sprite and make it the new image 
					activeShopItems [numbOfItems].GetComponent<Image> ().sprite = spaceB [i].getSprite ();
					//Depending on what item it is, get the cost and make it the new text
					if(isDecorate == false)
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = spaceB [i].getCost();
					else
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = null;
					//Attach item to itemButton script in Prefab
					activeShopItems [numbOfItems].GetComponent<ItemButton>().holder = spaceB[i];
					//Number of items displayed increases
					numbOfItems++;
				}
			}

		} else if (space == 'c') {
			for(int i = 0; i < spaceC.Length; i++)
			{
				if(spaceC[i].getSold() == isDecorate){
					//Instatiate Item based on Prefab
					activeShopItems [numbOfItems] = Instantiate (itemUIPrefab, panel.transform.position,panel.transform.rotation);
					//Set it to be a parent of the space game object
					activeShopItems [numbOfItems].transform.SetParent (panel.transform,false);
					//Depending on how many items are in the list for that space, space them out
					activeShopItems [numbOfItems].transform.Translate (incXVal * numbOfItems,0,0);
					activeShopItems [numbOfItems].GetComponent<RectTransform> ().anchoredPosition.Set (incXVal * numbOfItems, 40);
					//Depending on what item it is, get the sprite and make it the new image 
					activeShopItems [numbOfItems].GetComponent<Image> ().sprite = spaceC [i].getSprite ();
					//Depending on what item it is, get the cost and make it the new text
					if(isDecorate == false)
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = spaceC [i].getCost();
					else
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = null;
					//Attach item to itemButton script in Prefab
					activeShopItems [numbOfItems].GetComponent<ItemButton>().holder = spaceC[i];
					//Number of items displayed increases
					numbOfItems++;
				}
			}


		} else if (space == 'd') {
			for(int i = 0; i < spaceD.Length; i++)
			{
				if(spaceD[i].getSold() == isDecorate){
					//Instatiate Item based on Prefab
					activeShopItems [numbOfItems] = Instantiate (itemUIPrefab, panel.transform.position,panel.transform.rotation);
					//Set it to be a parent of the space game object
					activeShopItems [numbOfItems].transform.SetParent (panel.transform,false);
					//Depending on how many items are in the list for that space, space them out
					activeShopItems [numbOfItems].transform.Translate (incXVal * numbOfItems,0,0);
					activeShopItems [numbOfItems].GetComponent<RectTransform> ().anchoredPosition.Set (incXVal * numbOfItems, 40);
					//Depending on what item it is, get the sprite and make it the new image 
					activeShopItems [numbOfItems].GetComponent<Image> ().sprite = spaceD [i].getSprite ();
					//Depending on what item it is, get the cost and make it the new text
					if(isDecorate == false)
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = spaceD [i].getCost();
					else
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = null;
					//Attach item to itemButton script in Prefab
					activeShopItems [numbOfItems].GetComponent<ItemButton>().holder = spaceD[i];
					//Number of items displayed increases
					numbOfItems++;
				}
			}

		} else if (space == 'e') {
			for(int i = 0; i < spaceE.Length; i++)
			{
				if(spaceE[i].getSold() == isDecorate){
					//Instatiate Item based on Prefab
					activeShopItems [numbOfItems] = Instantiate (itemUIPrefab, panel.transform.position,panel.transform.rotation);
					//Set it to be a parent of the space game object
					activeShopItems [numbOfItems].transform.SetParent (panel.transform,false);
					//Depending on how many items are in the list for that space, space them out
					activeShopItems [numbOfItems].transform.Translate (incXVal * numbOfItems,0,0);
					activeShopItems [numbOfItems].GetComponent<RectTransform> ().anchoredPosition.Set (incXVal * numbOfItems, 40);
					//Depending on what item it is, get the sprite and make it the new image 
					activeShopItems [numbOfItems].GetComponent<Image> ().sprite = spaceE [i].getSprite ();
					//Depending on what item it is, get the cost and make it the new text
					if (isDecorate == false)
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = spaceE [i].getCost ();
					else
						activeShopItems [numbOfItems].GetComponentInChildren<Text> ().text = null;
					//Attach item to itemButton script in Prefab
					activeShopItems [numbOfItems].GetComponent<ItemButton>().holder = spaceE[i];
					//Number of items displayed increases
					numbOfItems++;
				}
			}

		} else {
			Debug.Log ("Uhh.....well this shouldn't happen");
		}
	}



	public void refreshShopItems()
	{
		if (numbOfItems != 0) {
			for (int i = 0; i < numbOfItems; i++) {
				GameObject.Destroy (activeShopItems [i].gameObject);
				Debug.Log ("WOOT DESTROY " + i);
			}
			//xVal = startXVal;
			activeShopItems = new GameObject[3];
			numbOfItems = 0;
		}
	}
}

public class Item {
	private int cost;
	private bool sold;
	private Sprite sprite;
	public char space;
	private int id;
	public GameObject DecorateDisplay;

	public Item(int c, Sprite s, char sp, int i, GameObject d){
		cost = c;
		sold = false;
		sprite = s;
		space = sp;
		id = i;
		DecorateDisplay = d;
	}

	public void sellItem(){
		sold = true;
	}

	public bool getSold(){
		return sold;
	}
		

	public Sprite getSprite(){
		return sprite;
	}

	public int getId(){
		return id;
	}

	public string getCost(){
		return cost.ToString();
	}

		public int getCostNumb(){
			return cost;
		}

}

