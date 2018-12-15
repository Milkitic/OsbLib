﻿using System;
using System.Globalization;
using System.Linq;
using Milkitic.OsbLib.Enums;

namespace Milkitic.OsbLib.Models.EventType
{
    public class Vector : IEvent
    {
        public EventEnum EventType { get; set; }
        public EasingType Easing { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public float[] Start { get; set; }
        public float[] End { get; set; }
        public string Script => Start.SequenceEqual(End) ? string.Join(",", Start) : $"{string.Join(",", Start)},{string.Join(",", End)}";
        public int ParamLength => Start.Length;
        public bool IsStatic => Start.Equals(End);

        public float Vx1 => Start[0];
        public float Vy1 => Start[1];
        public float Vx2 => End[0];
        public float Vy2 => End[1];

        public Vector(EasingType easing, float startTime, float endTime, float vx1, float vy1, float vx2, float vy2)
        {
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            Start = new[] { vx1, vy1 };
            End = new[] { vx2, vy2 };
            EventType = EventEnum.Vector;
        }

        public void AdjustTime(float time)
        {
            StartTime += time;
            EndTime += time;
        }

        public override string ToString()
        {
            return string.Join(",",
                EventType.ToShortString(),
                (int)Easing,
                Math.Round(StartTime).ToString(CultureInfo.InvariantCulture),
                StartTime.Equals(EndTime) ? "" : Math.Round(EndTime).ToString(CultureInfo.InvariantCulture),
                Script);
        }
    }
}
