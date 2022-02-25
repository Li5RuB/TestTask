using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Services.Mappers
{
    public static class Mapper
    {
        public static string Map(object prop)
        {
            if (prop == null)
                return "";
            switch (prop.ToString())
            {
                case "№": return "Id";
                case "Фио": return "Name";
                case "Дата обследования": return "Date";
                case "Приседание": return "Squatting";
                case "Перешагивание (л)": return "SteppingOverL";
                case "Перешагивание (пр)": return "SteppingOverPR";
                case "Выпад (л)": return "LungeL";
                case "Выпад(пр)": return "LungePR";
                case "Подвижность плечевого пояса (л)": return "ShoulderMobilityL";
                case "Подвижность плечевого пояса (пр)": return "ShoulderMobilityPR";
                case "Подъем прямой ноги (л)": return "StraightLegRaiseL";
                case "Подъем прямой ноги (пр)": return "StraightLegRaisePR";
                case "Отжимания": return "PushUps";
                case "Ротационная стабильность (л)": return "RotationalStabilityL";
                case "Ротационная стабильность (пр)": return "RotationalStabilityPR";
                case "вес": return "Weight";
                case "рост": return "Growth";
                case "пол": return "Sex";
            }
            return "";
        }
    }
    
}
