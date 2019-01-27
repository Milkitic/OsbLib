﻿using System;
using System.Globalization;
using System.Linq;
using OSharp.Storyboard.Enums;

namespace OSharp.Storyboard.Models.EventType
{
    public class Rotate : IEvent
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
        public float R1 => Start[0];
        public float R2 => End[0];

        public Rotate(EasingType easing, float startTime, float endTime, float r1, float r2)
        {
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            Start = new[] { r1 };
            End = new[] { r2 };
            EventType = EventEnum.Rotate;
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