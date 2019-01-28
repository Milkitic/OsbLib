﻿using System;

namespace OSharp.Storyboard.Common
{
    public struct RangeValue<T> where T : IComparable
    {
        public T StartTime { get; }
        public T EndTime { get; }

        public RangeValue(T startTime, T endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    public class RangeValueObject<T> where T : IComparable
    {
        public T StartTime { get; set; }
        public T EndTime { get; set; }

        public RangeValueObject(T startTime, T endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}