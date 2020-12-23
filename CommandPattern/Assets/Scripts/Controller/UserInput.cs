using System;
using Commands;
using Interfaces;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller
{
    public class UserInput : MonoBehaviour
    {
        private void Update()
        {
            //leftClick
            //castRay
            //detect a cube
            //assign random color

            if (Input.GetMouseButtonDown(0))
            {
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    if (hitInfo.collider.CompareTag("Cube"))
                    {
                       
                        //EXECUTE CLICK COMMAND
                        ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color(
                            Random.value, Random.value, Random.value));
                        click.Execute();
                        CommandManager.Instance.AddCommand(click);
                    }
                }
                
            }
        }
    }
}