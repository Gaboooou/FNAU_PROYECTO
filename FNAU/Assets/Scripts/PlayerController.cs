using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidad = 5f;
    public Animator animator;
    public FixedJoystick joystick;  // Drag & Drop desde el Inspector

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;

        Vector3 input = new Vector3(inputX, inputY, 0f).normalized;
        Vector3 movimiento = input * velocidad * Time.deltaTime;
        transform.position += movimiento;

        animator.SetFloat("movement", input.magnitude);

        if (inputX < -0.01f)
            transform.localScale = new Vector3(Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
        else if (inputX > 0.01f)
            transform.localScale = new Vector3(-Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
    }
}