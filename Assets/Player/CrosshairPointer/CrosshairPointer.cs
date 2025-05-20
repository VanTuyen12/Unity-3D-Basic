
using UnityEngine;

public class CrosshairPointer : SaiMonoBehaviour
{
    //Code Hong Tam
    protected float maxDistance = 100f;
    protected Collider hitObj;
    [SerializeField] LayerMask layerMask= -1;

    protected virtual void Update()
    {
        this.Pointing();
    }

    protected virtual void Pointing()
    {
        #region Giai Thich
        //Screen.width: Lấy chiều rộng của màn hình
        //Screen.height: Lấy chiều cao của màn hình
        //Chia cho 2 để tìm ra điểm chính giữa.
        //Tọa độ Z là 0, vì tọa độ trên màn hình thường chỉ có X và Y thôi.
        #endregion
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        #region Giai Thich
        //Camera.main: Lấy cái camera chính trong scene của bạn (cái camera được tag là "MainCamera").
        //ScreenPointToRay: Nó lấy một điểm trên màn hình 2D chuyển nó thành một "tia sáng"
        //ray : chứa thông tin về điểm bắt đầu và hướng đi của tia sáng.
        #endregion
        
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);//tia sáng này bắt đầu từ vị trí của camera và đi xuyên qua cái điểm giữa màn hình đó, hướng vào thế giới 3D.

        #region Giai Thich
        //out RaycastHit hit: Nếu tia sáng đâm vào vật gì đó, thông tin về điểm va chạm sẽ được lưu vào biến hit.
        //maxDistance: giới hạn khoảng cách tối đa mà tia sáng này được đi.
        //chỉ định những "lớp" (layer) nào mà tia sáng này được phép đâm vào
        #endregion
        
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask)) //return True or False
        {
            //hit.point: vị trí nơi tia sáng đâm vào bề mặt của vật thể đầu tiên nó gặp.
            transform.position = hit.point;//di chuyen den vi tri va cham do
            
            this.hitObj = hit.collider;
        }
    }
}
