using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{

    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotaton;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

        PossibleRots = correctRotaton.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotaton[0] || transform.eulerAngles.z == correctRotaton[1])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotaton[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotaton[0] || transform.eulerAngles.z == correctRotaton[1] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotaton[0] && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
    }
}
