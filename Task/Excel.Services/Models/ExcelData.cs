using System;
using System.ComponentModel;

namespace Excel.Services
{
    public class ExcelData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Squatting { get; set; }

        public int SteppingOverL { get; set; }

        public int SteppingOverPR { get; set; }

        public int LungeL { get; set; }

        public int LungePR { get; set; }

        public int ShoulderMobilityL { get; set; }

        public int ShoulderMobilityPR { get; set; }

        public int StraightLegRaiseL { get; set; }

        public int StraightLegRaisePR { get; set; }

        public int PushUps { get; set; }

        public int RotationalStabilityL { get; set; }

        public int RotationalStabilityPR { get; set; }

        public int Weight { get; set; }

        public int Growth { get; set; }

        public string Sex { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Date} {Squatting} {SteppingOverL} {SteppingOverPR} {LungeL} {LungePR} {ShoulderMobilityL} " +
                $"{ShoulderMobilityPR} {StraightLegRaiseL} {StraightLegRaisePR} {PushUps} {RotationalStabilityL} {RotationalStabilityPR} " +
                $"{Weight} {Growth} {Sex}";
        }
    }
}