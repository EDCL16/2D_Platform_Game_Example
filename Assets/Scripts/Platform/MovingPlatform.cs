using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MovingPlatform : MonoBehaviour
{
    // 定義平台移動的模式
    public enum MovementType { Loop, PingPong }

    [Header("平台移動路徑")]
    // 指定平台會經過的各個路徑點 (請直接拖入場景中的 Transform，注意其位置會以世界座標運算)
    public Transform[] waypoints;

    [Header("移動參數")]
    public float speed = 2f;
    // 在 Inspector 中選擇移動模式：循環或往返
    public MovementType movementType = MovementType.Loop;

    // 當前目標點索引
    private int currentWaypointIndex = 0;
    // 往返模式下記錄前進或反向 (1：向前、-1：向後)
    private int direction = 1;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        // 使用世界座標進行移動
        Transform targetPoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // 當平台接近目標點時 (<0.1f 可視為到達)，更新下一個目標點的索引
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (movementType == MovementType.Loop)
            {
                // 循環模式：移動到下一個點，最後一點後回到第一點
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else if (movementType == MovementType.PingPong)
            {
                // 往返模式：到達首尾時反轉方向
                if (currentWaypointIndex == waypoints.Length - 1)
                {
                    direction = -1;
                }
                else if (currentWaypointIndex == 0)
                {
                    direction = 1;
                }
                currentWaypointIndex += direction;
            }
        }
    }

    // 在 Scene 視圖中繪製 Gizmos 預覽路徑與當前目標點
    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        // 先繪製各路徑點間的連線
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
        // 如果是循環模式，最後一點連到第一點
        if (movementType == MovementType.Loop && waypoints.Length > 1)
        {
            if (waypoints[0] != null && waypoints[waypoints.Length - 1] != null)
            {
                Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);
            }
        }

        // 繪製每個路徑點的小球，並在上方標示索引
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null)
                continue;

            // 若遊戲正在執行，則將目前目標點用紅色標示
            if (Application.isPlaying && i == currentWaypointIndex)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.cyan;

            Gizmos.DrawSphere(waypoints[i].position, 0.2f);

#if UNITY_EDITOR
            // 在路徑點上方偏上方0.3單位處顯示索引數字，若是目前點則標示「Current: n」
            string label = (Application.isPlaying && i == currentWaypointIndex) ? ("Current: " + i) : i.ToString();
            Handles.Label(waypoints[i].position + Vector3.up * 0.3f, label);
#endif
        }
    }
}
