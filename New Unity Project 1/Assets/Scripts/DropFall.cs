using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts
{
    public class DropFall : MonoBehaviour
    {
        private void Update()
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            transform.position = position;

            if (transform.position.y < -9.4)
            {
                Destroy(gameObject);
            }
        }
    }
}