using System;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Subjects;

namespace DesignPatternDemos.Observer.Observers
{
    /// <summary>
    /// Наблюдатель за показаниями различных датчиков
    /// Выводит показания на консоль
    /// </summary>
    public class ConsoleWriterObserver : ISensorObserver
    {
        public ConsoleWriterObserver(ISensorObservable sensorObservable)
        {
            sensorObservable.RegisterObserver(this);
        }
        
        /// <summary>
        /// Обновить информацию по показанию датчика и вывести ее на консоль
        /// </summary>
        /// <param name="sensorData"></param>
        public void UpdateInfo(object sensorData)
        {
            switch (sensorData)
            {
                case ClimateInfo climateInfo:
                    ShowClimateInfo(climateInfo);
                    break;
                case ActivityInfo activityInfo:
                    ShowLastActivityInfo(activityInfo);
                    break;
                default:
                    throw new Exception("Unresolved type of sensor data");
            }
        }

        private void ShowClimateInfo(ClimateInfo climateInfo)
        {
            Console.WriteLine($"Current temperature is: {climateInfo.Temperature}°C and humidity: {climateInfo.Humidity}%");
        }

        private void ShowLastActivityInfo(ActivityInfo activityInfo)
        {
            Console.WriteLine($"Last activity was at: {activityInfo.LastActivity}");
        }
    }
}