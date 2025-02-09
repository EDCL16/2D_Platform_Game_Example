using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("移動參數")]
    public float speed = 2f;          // 移動速度
    private int direction = 1;        // 移動方向：1 向右，-1 向左

    [Header("懸崖檢測")]
    [Tooltip("用來檢測前下方是否有地板（用於檢查懸崖）")]
    public Transform groundDetection;
    [Tooltip("檢測懸崖的 raycast 距離")]
    public float groundDetectionDistance = 2f;

    [Header("前方障礙檢測")]
    [Tooltip("用來檢測前方是否有障礙物（例如牆壁）")]
    public Transform frontDetection;
    [Tooltip("檢測前方障礙物的 raycast 距離")]
    public float frontDetectionDistance = 0.5f;

    void Update()
    {
        // 按目前方向移動
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // 檢測懸崖：從 groundDetection 位置往下發射一條 raycast
        RaycastHit2D groundHit = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDetectionDistance);
        // 當下方沒有檢測到物件，或檢測到的物件 tag 不是 "ground" 時，代表遇到懸崖
        if (groundHit.collider == null || !groundHit.collider.CompareTag("Ground"))
        {
            Flip();
        }

        // 檢測前方障礙：從 frontDetection 位置往前發射 raycast（方向依據目前移動方向）
        RaycastHit2D frontHit = Physics2D.Raycast(frontDetection.position, Vector2.right * direction, frontDetectionDistance);
        // 當前方有碰到物件，且該物件 tag 為 "ground" 時，代表前方有障礙物

        if (frontHit.collider == null)
        {
            return;
        }
        bool hasObstacle = frontHit.collider.CompareTag("Ground") || frontHit.collider.CompareTag("Enemy");
        if (hasObstacle)
        {
            Flip();
        }
    }

    // 翻轉敵人（改變移動方向及 Sprite 的朝向）
    void Flip()
    {
        // 反轉移動方向
        direction *= -1;
        // 反轉 Sprite：通過改變 x 軸縮放值
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    // 在 Scene 視窗中繪製 raycast 的檢測線，方便除錯
    void OnDrawGizmos()
    {
        if (groundDetection != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundDetection.position, groundDetection.position + Vector3.down * groundDetectionDistance);
        }

        if (frontDetection != null)
        {
            Gizmos.color = Color.blue;
            // 注意：此處使用 direction，遊戲執行時 direction 可能變動，但在編輯模式下方向可能無法正確顯示
            Gizmos.DrawLine(frontDetection.position, frontDetection.position + Vector3.right * direction * frontDetectionDistance);
        }
    }
}
