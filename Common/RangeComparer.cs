﻿using System;
using System.Collections.Generic;

namespace OSharp.Storyboard.Common
{
    public class RangeComparer<T> : IComparer<RangeValue<T>> where T : IComparable
    {
        public int Compare(RangeValue<T> x, RangeValue<T> y)
        {
            var value = x.StartTime.CompareTo(y.StartTime);
            return value == 0
                ? x.EndTime.CompareTo(y.EndTime)
                : value;
        }
    }
    public class RangeObjectComparer<T> : IComparer<RangeValueObject<T>> where T : IComparable
    {
        public int Compare(RangeValueObject<T> x, RangeValueObject<T> y)
        {
            var value = x.StartTime.CompareTo(y.StartTime);
            return value == 0
                ? x.EndTime.CompareTo(y.EndTime)
                : value;
        }
    }
}