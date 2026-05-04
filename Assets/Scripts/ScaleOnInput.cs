using UnityEngine;

public class ScaleOnInput : MonoBehaviour
{
    public float deltaScale = 1.0f;
    public KeyCode inputKey = KeyCode.None;
	public Vector3 maxScale = Vector3.one;
	Vector3 initialScale    = Vector3.one;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		initialScale = transform.localScale;
	}

    // Update is called once per frame
    void Update()
    {
        if(inputKey == KeyCode.None)
        {
            return;
        }

        if(Input.GetKey(inputKey))
        {
            Vector3 newScale    = transform.localScale;
            // x value of localScale has reached max, stop scaling
			if (newScale.x >= maxScale.x)
            {
                return;
            }
			// y value of localScale has reached max, stop scaling
			if (newScale.y >= maxScale.y)
			{
				return;
			}
			// z value of localScale has reached max, stop scaling
			if (newScale.z >= maxScale.z)
			{
				return;
			}

			newScale                += Vector3.one * deltaScale * Time.deltaTime;
            transform.localScale    = newScale;
		}
        else 
        {
			transform.localScale = initialScale;
		}
    }
}
