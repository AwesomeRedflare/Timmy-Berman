using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isRightSide = false;

    public float maxBar = 5f;
    public float barLevel = 5f;

    public Image powerBar;

    public GameObject gameOverPanel;

    public GameObject tree;

    private void Update()
    {
        barLevel -= Time.deltaTime;
        powerBar.fillAmount = barLevel / maxBar;

        if(barLevel > maxBar)
        {
            barLevel = maxBar;
        }

        if (barLevel <= 0)
        {
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        if (gameOverPanel.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (tree.transform.GetChild(0).gameObject.CompareTag("Left Branch") && isRightSide == false)
        {
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        if (tree.transform.GetChild(0).gameObject.CompareTag("Right Branch") && isRightSide == true)
        {
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && isRightSide == false)
        {
            transform.position = new Vector2(transform.position.x + 2, transform.position.y);
            isRightSide = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isRightSide == true)
        {
            isRightSide = false;
            transform.position = new Vector2(transform.position.x - 2, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            barLevel += 0.2f;
            Vector2 treeFall = new Vector2(tree.transform.position.x, tree.transform.position.y - 1);
            tree.transform.position = treeFall;
            Destroy(tree.transform.GetChild(0).gameObject);
            Score.scoreAmount++;
        }
    }
}
