using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField]
    Transform gameAreaTrans     = null;
    [SerializeField]
    Transform displayAreaTrans  = null;
	[SerializeField]
	float gameEndOffsetY        = 0.0f;
    [SerializeField]
    float moveSpeed             = 5.0f;

    [SerializeField]
    Transform roundsInfoTrans       = null;
	[SerializeField]
	GameObject roundInfoPrefab      = null;
    [SerializeField]
    float roundInfoObjectOffsetY    = 100.0f;
    [SerializeField]
    float spawnInterval             = 2.0f;
    float spawnCooldown             = 0.0f;

	[SerializeField] 
    TMP_Text instructionsText   = null;
	[SerializeField]
    string restartInstructions  = "Press Space to restart!";

	bool isDisplayingResults    = false;
    bool isDoneMovingUp         = false;
	bool isDoneAddingRoundInfo  = false;
    bool isMovingDown           = false;
    bool isDoneMovingDown       = false;
    bool isDoneResettingDisplay = false;


	int playerMoves = -1;
    int aiMoves     = -1;
    int results     = -1;
	int round       = 0;

    public bool IsDisplaying            { get { return isDisplayingResults; } }
    public bool IsDoneMovingUp            { get { return isDoneMovingUp; } }
    public bool IsDoneDisplayingRounds  { get { return isDoneAddingRoundInfo; } }
    public bool IsDoneMovingDown        { get { return isDoneMovingDown; } }
    public bool IsDoneResettingDisplay  { get { return isDoneResettingDisplay; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisplayingResults)
        {
            return;
        }

        if (!isDoneMovingUp)
        {
            MoveDisplayUp();
            return;
        }

		if (!isDoneAddingRoundInfo)
		{
			AddRoundInfo();
            return;
		}

        if (!isMovingDown)
        {
            return;
        }

        if (!isDoneMovingDown)
        {
			MoveDisplayDown();
            return;
		}
	}

    public void BeginDisplay(int playerMoves, int aiMoves, int results)
    {
        this.playerMoves        = playerMoves;
        this.aiMoves            = aiMoves;
        this.results            = results;
        round                   = 0;
		isDisplayingResults     = true;
		isDoneMovingUp          = false;
		isDoneAddingRoundInfo   = false;
		isMovingDown            = false;
		isDoneMovingDown        = false;
		isDoneResettingDisplay  = false;
	}

    void MoveDisplayUp()
    {
        if (gameAreaTrans.position.y >= gameEndOffsetY)
		{
			isDoneMovingUp    = true;
            return;
        }

        float newY  = gameAreaTrans.position.y + moveSpeed * Time.deltaTime;
        if (newY > gameEndOffsetY)
        {
            newY    = gameEndOffsetY;
        }
        // ensure amount to move does not overshoot
        gameAreaTrans.position      = new Vector3(0.0f, newY, 0.0f);
        displayAreaTrans.position   = new Vector3(0.0f, newY, 0.0f);
	}

    void AddRoundInfo()
    {
        if(playerMoves == 0)
        {
			isDoneAddingRoundInfo   = true;
            instructionsText.text   = restartInstructions;
            return;
		}

        if(spawnCooldown > 0.0f)
        {
            spawnCooldown -= Time.deltaTime;
            return;
        }

        spawnCooldown                               = spawnInterval;
        Vector3 spawnPos                            = new Vector3(0.0f, -roundInfoObjectOffsetY * round, 0.0f);
        GameObject roundInfoInstance                = Instantiate(roundInfoPrefab, roundsInfoTrans);
        // Unable to set spawnPos when instantiating as Unity will use
        // spawnPos to set position in world space instead of relative
        // to parent transform
        roundInfoInstance.transform.localPosition   = spawnPos;

        RoundInfoDisplay roundInfoDisplay           = roundInfoInstance.GetComponent<RoundInfoDisplay>();
        roundInfoDisplay.SetDisplay(round, playerMoves % 10, aiMoves % 10, results % 10);

        playerMoves /= 10;
		aiMoves     /= 10;
        results     /= 10;
		round++;
    }

    public void ResetDisplay()
    {
        isMovingDown        = true;
        isDoneMovingDown    = false;
	}

    void MoveDisplayDown()
    {
        if (gameAreaTrans.position.y <= 0.0f)
		{
			isDoneMovingDown    = true;
            return;
        }

        float newY  = gameAreaTrans.position.y - moveSpeed * Time.deltaTime;
        if (newY < 0.0f)
        {
            newY    = 0.0f;
        }
		// ensure amount to move does not overshoot
		gameAreaTrans.position      = new Vector3(0.0f, newY, 0.0f);
		displayAreaTrans.position   = new Vector3(0.0f, newY, 0.0f);
	}

    public void EndDisplay()
    {
        isDisplayingResults     = false;
		isDoneMovingDown        = false;
		roundsInfoTrans.DetachChildren();
	}
}
