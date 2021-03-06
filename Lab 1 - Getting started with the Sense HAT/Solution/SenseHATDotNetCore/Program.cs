﻿using System;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Sense.RTIMU;

namespace SenseHATDotNetCore
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.WriteLine("Welcome to the RaspberryPi SenseHAT - Ctrl-C to exit.");
            Console.WriteLine("=====================================================");
            Console.WriteLine();
            // Collect Simulated Sensor Data and send to IoT hub
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }

        private static DeviceClient s_deviceClient;

        // The device connection string to authenticate the device with your IoT hub.
        // This is found on the (Azure IoT Hub |  IoT Devices | <devicename> | Connection String primary)
        private const string s_connectionString = "<Your IoT Hub Connnection String with Device Id>";
         private static async void SendDeviceToCloudMessagesAsync()
        {
            Console.WriteLine("=== Serializing the Sensor Data to JSON format ===========");

            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);

            // Initial telemetry values
            double currentTemperature = 0;

            using (var settings = RTIMUSettings.CreateDefault())
            using (var imu = settings.CreateIMU())
            using (var pressure = settings.CreatePressure())
            using (var humidity = settings.CreateHumidity())

            while (true)
            {
                var imuData = imu.GetData();
                var humidityReadResult = humidity.Read();
                var pressureReadResult = pressure.Read();

                // Display RAW sensor data
                Console.WriteLine();
                Console.WriteLine($"Timestamp: {imuData.Timestamp:O}");
                Console.WriteLine($"FusionPose: {imuData.FusionPose}");
                Console.WriteLine($"FusionQPose: {imuData.FusionQPose}");
                Console.WriteLine($"Gyro: {imuData.Gyro}");
                Console.WriteLine($"Accel: {imuData.Accel}");
                Console.WriteLine($"Compass: {imuData.Compass}");
                Console.WriteLine();
                Console.WriteLine($"Pressure: {pressureReadResult.Pressure}");
                Console.WriteLine($"Humidity: {humidityReadResult.Humidity}");
                Console.WriteLine($"Temperature: {humidityReadResult.Temperatur}"); 

                // Convert Celsius to Fahrenheit 
                currentTemperature = humidityReadResult.Temperatur * 1.8 + 32;

                // Create JSON message
                Telemetry telemetryRow = new Telemetry();
                telemetryRow.DeviceId = "<Your Raspberry Pi Device Name>"; // i.e. raspberrypi-det-01
                telemetryRow.MessageId = 314;
                telemetryRow.CreatedDate = DateTime.UtcNow;
                telemetryRow.Temperature = Math.Round(Convert.ToDecimal(currentTemperature), 2);
                telemetryRow.Humidity = Math.Round(Convert.ToDecimal(humidityReadResult.Humidity), 2);
                telemetryRow.Pressure = Math.Round(Convert.ToDecimal(pressureReadResult.Pressure), 2);

                // Serialize sensor data to JSON format
                string messageString = JsonConvert.SerializeObject(telemetryRow);

                // Encode the characters into a sequence of bytes.
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                Console.WriteLine();
                Console.WriteLine("=== Sending data to IoT Hub ==============================");

                // Send the telemetry message
                await s_deviceClient.SendEventAsync(message).ConfigureAwait(false);

                Console.WriteLine($"=== {DateTime.Now}, {messageString}");
                Console.WriteLine();

                // Wait 5 secs
                await Task.Delay(5000).ConfigureAwait(false);
            }
        }

        public class Telemetry
        {
            public string DeviceId { get; set; }
            public int MessageId { get; set; }
            public DateTime CreatedDate { get; set; }
            public decimal Temperature { get; set; }
            public decimal Humidity { get; set; }
            public decimal Pressure { get; set; }
        }


    }
}
