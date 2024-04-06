using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnQueue : MonoBehaviour
{
    private Queue<string> queue = new Queue<string>();
    private bool full = false;
    private Coroutine processingCoroutine;
    private BattleSystem battleSystem;

    public List<Sprite> splashArts = new List<Sprite>(); // Lista splash artów
    public Sprite emptySprite;


    private void Start()
    {
        battleSystem = GameObject.FindAnyObjectByType<BattleSystem>();
    }

    public void AddUnit(string unitType, Sprite unitSplashArt)
    {
        if (!full)
        {
            queue.Enqueue(unitType);
            splashArts.Add(unitSplashArt);

            if (queue.Count == 5)
                full = true;

            if (processingCoroutine == null)
                processingCoroutine = StartCoroutine(ProcessQueueCoroutine());
        }
    }

    private IEnumerator ProcessQueueCoroutine()
    {
        while (queue.Count > 0)
        {
            string unitType = queue.Peek();
            Sprite unitSplashArt = splashArts[0];

            double cooldown = 0f;
            switch (unitType)
            {
                case "melee":
                    cooldown = battleSystem.playerMeleeCooldown;
                    break;
                case "range":
                    cooldown = battleSystem.playerRangeCooldown;
                    break;
                case "tank":
                    cooldown = battleSystem.playerTankCooldown;
                    break;
                case "healer":
                    cooldown = battleSystem.playerHealerCooldown;
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds((float)cooldown);

            Debug.Log("Tworzenie jednostki: " + unitType);
            battleSystem.spawnUnit(unitType);
            queue.Dequeue();
            splashArts.RemoveAt(0);

            // Aktualizuj splash arty, jeœli kolejka nie jest pusta
            if (queue.Count > 0)
            {
                int index = 0;
                while (index < queue.Count)
                {
                    if (index == queue.Count - 1)
                    {
                        /*splashArts[index] = emptySprite; // Ustaw pusty splash art na ostatniej pozycji w liœcie*/
                    }
                    else
                    {
                        splashArts[index] = splashArts[index + 1]; // Przesuñ splash arty w lewo, aby zaktualizowaæ ich pozycje w kolejce
                    }
                    index++;
                }
            }

            full = false;
        }

        processingCoroutine = null;
    }

}
