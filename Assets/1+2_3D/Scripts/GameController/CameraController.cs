using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._1_2_3D.Scripts.GameController
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private Vector3 offset;

        void Start()
        {
            offset = transform.position - player.position;
        }

        void FixedUpdate()
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
            transform.position = newPosition;
        }
    }
}
