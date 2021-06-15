using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Vector2 position;
    private Wall[] walls;
    private float wallWidth = 8f;
    private float wallHight = 4f;

    // These numbers will later be based on difficulty
    private int potionsQuantity = 4;
    private int moneyQuantity = 2;
    /* ---------- Necessary prefabs ---------- */
    public GameObject redPotionPrefab;
    public GameObject bluePotionPrefab;
    public GameObject greenPotionPrefab;
    public GameObject coinPrefab;
    public GameObject boxPrefab;
    /* ---------- Other necessary info ---------- */
    private float xPosMin, xPosMax, zPosMin, zPosMax;
    private enum potionTypes { BLUE = 1, GREEN = 2, RED = 3 };
    private int potionTypesQuantity = 3;
    private enum moneyTypes { COIN = 1, BOX = 2 };
    private int moneyTypesQuantity = 2;

    void Start()
    {
        xPosMin = position.x - wallWidth / 2 + 1;
        zPosMin = position.y - wallWidth / 2 + 1;
        xPosMax = position.x + wallWidth / 2 - 1;
        zPosMax = position.y + wallWidth / 2 - 1; 
        StartCoroutine(GeneratePotions());
        StartCoroutine(GenerateMoney());
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public Wall[] GetWalls()
    {
        return walls;
    }

    public void SetWalls(Wall[] walls)
    {
        this.walls = walls;
    }

    public float GetWallWidth()
    {
        return wallWidth;
    }

    public float GetWallHight()
    {
        return wallHight;
    }

    IEnumerator GeneratePotions()
    {
        int currentPotionsQuantity = 0;
        while (currentPotionsQuantity < potionsQuantity)
        {
            float xRandomPos = Random.Range(xPosMin, xPosMax);
            float zRandomPos = Random.Range(zPosMin, zPosMax);
            potionTypes potionType = (potionTypes)Random.Range(1, potionTypesQuantity + 1);
            switch (potionType)
            {
                case potionTypes.BLUE:
                    {
                        GameObject generatedPotion = Instantiate(bluePotionPrefab, new Vector3(xRandomPos, 0, zRandomPos), Quaternion.identity);
                        generatedPotion.transform.parent = transform;
                        break;
                    }
                case potionTypes.RED:
                    {
                        GameObject generatedPotion = Instantiate(redPotionPrefab, new Vector3(xRandomPos, 0, zRandomPos), Quaternion.identity);
                        generatedPotion.transform.parent = transform;
                        break;
                    }
                case potionTypes.GREEN:
                    {
                        GameObject generatedPotion = Instantiate(greenPotionPrefab, new Vector3(xRandomPos, 0, zRandomPos), Quaternion.identity);
                        generatedPotion.transform.parent = transform;
                        break;
                    }
            }

            yield return new WaitForSeconds(5f);
            currentPotionsQuantity++;
        }
    }

    IEnumerator GenerateMoney()
    {
        int currentMoneyQuantity = 0;
        while (currentMoneyQuantity < moneyQuantity)
        {
            float xRandomPos = Random.Range(xPosMin, xPosMax); 
            float zRandomPos = Random.Range(zPosMin, zPosMax); 
            moneyTypes potionType = (moneyTypes)Random.Range(1, moneyTypesQuantity + 1);
            switch (potionType)
            {
                case moneyTypes.COIN:
                    {
                        GameObject generatedMoney = Instantiate(coinPrefab, new Vector3(xRandomPos, 0, zRandomPos), Quaternion.identity);
                        generatedMoney.transform.parent = transform;
                        break;
                    }
                case moneyTypes.BOX:
                    {
                        GameObject generatedMoney = Instantiate(boxPrefab, new Vector3(xRandomPos, 0, zRandomPos), Quaternion.identity);
                        generatedMoney.transform.parent = transform;
                        break;
                    }
            }
            yield return new WaitForSeconds(10f);
            currentMoneyQuantity++;
        }
    }
}
