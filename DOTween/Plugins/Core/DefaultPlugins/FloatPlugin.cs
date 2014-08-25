﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/05/06 16:33
// 
// License Copyright (c) Daniele Giardini.
// This work is subject to the terms at http://dotween.demigiant.com/license.php

using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Core.DefaultPlugins.Options;

#pragma warning disable 1591
namespace DG.Tweening.Plugins.Core.DefaultPlugins
{
    public class FloatPlugin : ABSTweenPlugin<float,float,FloatOptions>
    {
        public override float ConvertT1toT2(TweenerCore<float,float,FloatOptions> t, float value)
        {
            return value;
        }

        public override void SetRelativeEndValue(TweenerCore<float, float, FloatOptions> t)
        {
            t.endValue += t.startValue;
        }

        public override void SetChangeValue(TweenerCore<float, float, FloatOptions> t)
        {
            t.changeValue = t.endValue - t.startValue;
        }

        public override float GetSpeedBasedDuration(FloatOptions options, float unitsXSecond, float changeValue)
        {
            float res = changeValue / unitsXSecond;
            if (res < 0) res = -res;
            return res;
        }

        public override float Evaluate(FloatOptions options, Tween t, bool isRelative, DOGetter<float> getter, float elapsed, float startValue, float changeValue, float duration)
        {
            if (t.loopType == LoopType.Incremental) startValue += changeValue * (t.isComplete ? t.completedLoops - 1 : t.completedLoops);

            return !options.snapping
                ? EaseManager.Evaluate(t, elapsed, startValue, changeValue, duration, t.easeOvershootOrAmplitude, t.easePeriod)
                : (float)Math.Round(EaseManager.Evaluate(t, elapsed, startValue, changeValue, duration, t.easeOvershootOrAmplitude, t.easePeriod));
        }
    }
}