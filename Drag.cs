using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    float ZPosition;
    Vector3 Offset;
    public Camera MainCamera;
    bool Dragging;
    public UnityEvent OnBeginDrag;
    public UnityEvent OnEndDrag;
    public GameObject CollisionObject;
    public static Drag instance;
    public bool IsDone = false;
    public Vector3 firstpos;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        MainCamera = Camera.main;
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

   void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));
        }

    }
    private void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
    }

    private void OnMouseUp()
    {
        EndDrag();
    }
    public void BeginDrag()
    {
        OnBeginDrag.Invoke();
        Dragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }
    public void EndDrag()
    {
        OnEndDrag.Invoke();
        Dragging = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == CollisionObject)
        {
            collision.gameObject.GetComponent<Renderer>().material.color= Color.white;
            //CollisionObject.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }

}
