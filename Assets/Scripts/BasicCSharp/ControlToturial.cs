using UnityEngine;

public class ControlToturial : MonoBehaviour
{
    int number = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            number++;
            if (number > 3)
            {
                Debug.Log("number > 3");
            }
            else if (number == 3)
            {
                Debug.Log("number == 3");
            }
            else
            {
                Debug.Log("number < 3");
            }
            Debug.Log("CurrentNumber = " + number);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            for (int i = 0; i < number; i++)
            {
                Debug.Log(i);
            }
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            WhileLoopFunction();
        }
    }

    void WhileLoopFunction()
    {
        /* 局部变量定义 */
        int a = 10;

        /* while 循环执行 */
        while (a < 20)
        {
            Debug.Log("a 的值 = " + a);
            a++;
        }
    }
}
