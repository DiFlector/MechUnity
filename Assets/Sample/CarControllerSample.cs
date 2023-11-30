#region

using System;
using System.Collections.Generic;
using LogitechG29.Core.Input;
using UnityEngine;

#endregion

namespace Sample
{
    public class CarControllerSample : MonoBehaviour
    {
        public List<AxleInfo> axleInfos; // информация о каждой отдельной оси
        public float maxMotorTorque; // максимальный крутящий момент, который двигатель может приложить к колесу
        public float maxSteeringAngle; // максимальный угол поворота, который может иметь колесо
        [SerializeField] private InputControllerReader _inputControllerReader;

        public void FixedUpdate()
        {
            var speed = 0f;
            if (_inputControllerReader.Throttle != 0)
            {
                speed = _inputControllerReader.Throttle;
            }
            else if (_inputControllerReader.Brake != 0)
            {
                speed = -_inputControllerReader.Brake;
            }

            var motor = maxMotorTorque * speed;
            var steering = maxSteeringAngle * _inputControllerReader.Steering;

            foreach (var axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
        }

        [Serializable]
        public class AxleInfo
        {
            public WheelCollider leftWheel;
            public WheelCollider rightWheel;
            public bool motor; // is this wheel attached to motor?
            public bool steering; // does this wheel apply steer angle?
        }
    }
}