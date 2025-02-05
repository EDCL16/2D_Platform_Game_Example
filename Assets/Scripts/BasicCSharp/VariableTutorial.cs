using UnityEngine;

public class VariableTutorial : MonoBehaviour
{
    public int number;
    [SerializeField] float floatNumber;
    private string text = "hello world!!!";
    bool trueOrFalse = false;
    PlayerStatus playerStatus;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("number = " + number);
            Debug.Log("floatNumber = " + floatNumber);
            Debug.Log("text = " + text);
            Debug.Log("trueOrFalse = " + trueOrFalse);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            int localNumber = 10;
            Debug.Log("localNumber" + localNumber);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            playerStatus = new PlayerStatus();
            //playerStatus = new PlayerStatus("name",1);
        }
        //名稱 'localNumber' 不存在於目前的內容中CS0103
        //localNumber = 0;
    }
    void PrintNumber()
    {
        //名稱 'localNumber' 不存在於目前的內容中CS0103

        //Debug.Log("localNumber" + localNumber);         
    }

    void ErrorNaming()
    {
        // int 123a;
        // int a123;
        // int _;
        // int false;
    }
}
public class PlayerStatus
{
    public string name;
    public int health;
    // public PlayerStatus(string name, int health)
    // {
    //     this.name = name;
    //     this.health = health;
    // }
}