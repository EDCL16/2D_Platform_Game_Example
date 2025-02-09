using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint; // 槍口位置
    [SerializeField] float playerPickupDistance = 0.7f;
    private bool isPicked = false;
    private Transform playerTransform;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        playerTransform = FindFirstObjectByType<PlayerController>().transform;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isPicked)
        {
            RotateGunToMouse(); // 槍跟隨滑鼠旋轉
            FollowPlayer();
            if (Input.GetMouseButtonDown(0)) // 左鍵開火
            {
                ShootBullet();
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) // 按 E 撿起或放下
        {
            bool isPlayerCloseEnough = Vector3.Distance(playerTransform.position, transform.position) < playerPickupDistance;
            if (!isPlayerCloseEnough) return;

            if (isPicked) DropGun();
            else PickUpGun();
        }
    }

    void PickUpGun()
    {
        isPicked = true;
        transform.SetParent(playerTransform);
        transform.localPosition = new Vector3(0.5f, -0.3f, 0f); // 槍在玩家手上
        transform.localRotation = Quaternion.identity;
    }

    void DropGun()
    {
        isPicked = false;
        transform.SetParent(null);
        transform.position = playerTransform.position + playerTransform.forward * 1f;
        transform.rotation = originalRotation;
    }

    void RotateGunToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // 設定深度，確保 `ScreenToWorldPoint` 能正確運算
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = worldMousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = transform.right * 10f; // 2D 子彈發射
    }

    void FollowPlayer()
    {
        transform.position = playerTransform.position;
    }
}
