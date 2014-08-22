﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/05/07 12:56
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using UnityEngine;

#pragma warning disable 1591
namespace DG.Tweening.Core
{
    // Public so it can be used with SetOptions to show the correct overload
    // and also to allow custom plugins to change start/end/changeValue.
    // T1: type of value to tween
    // T2: format in which value is stored while tweening
    // TPlugOptions: options type
    public class TweenerCore<T1,T2,TPlugOptions> : Tweener where TPlugOptions : struct
    {
        // SETUP DATA ////////////////////////////////////////////////

        public T2 startValue, endValue, changeValue;
        internal DOGetter<T1> getter;
        internal DOSetter<T1> setter;
        internal ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin;
        internal TPlugOptions plugOptions;
        internal bool hasManuallySetStartValue; // TRUE when start value has been changed via ChangeStart/Values (allows DoStartup to take it into account)

        const string _TxtCantChangeSequencedValues = "You cannot change the values of a tween contained inside a Sequence";

        // ***********************************************************************************
        // CONSTRUCTOR
        // ***********************************************************************************

        internal TweenerCore()
        {
            typeofT1 = typeof(T1);
            typeofT2 = typeof(T2);
            typeofTPlugOptions = typeof(TPlugOptions);
            tweenType = TweenType.Tweener;
            Reset();
        }

        // ===================================================================================
        // PUBLIC METHODS --------------------------------------------------------------------

        public override Tweener ChangeStartValue<T>(T newStartValue, float newDuration = -1)
        {
            if (isSequenced) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning(_TxtCantChangeSequencedValues);
                return this;
            }
            if (typeof(T) != typeofT2) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning("ChangeEndValue: incorrect newStartValue type (is " + typeof(T) + ", should be " + typeofT2 + ")");
                return this;
            }
            return DoChangeStartValue(this, (T2)(object)newStartValue, newDuration);
        }

        public override Tweener ChangeEndValue<T>(T newEndValue, bool snapStartValue)
        { return ChangeEndValue(newEndValue, -1, snapStartValue); }

        public override Tweener ChangeEndValue<T>(T newEndValue, float newDuration = -1, bool snapStartValue = false)
        {
            if (isSequenced) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning(_TxtCantChangeSequencedValues);
                return this;
            }
            if (typeof(T) != typeofT2) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning("ChangeEndValue: incorrect newEndValue type (is " + typeof(T) + ", should be " + typeofT2 + ")");
                return this;
            }
            return DoChangeEndValue(this, (T2)(object)newEndValue, newDuration, snapStartValue);
        }

        public override Tweener ChangeValues<T>(T newStartValue, T newEndValue, float newDuration = -1)
        {
            if (isSequenced) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning(_TxtCantChangeSequencedValues);
                return this;
            }
            if (typeof(T) != typeofT2) {
                if (Debugger.logPriority >= 1) Debugger.LogWarning("ChangeValues: incorrect value type (is " + typeof(T) + ", should be " + typeofT2 + ")");
                return this;
            }
            return DoChangeValues(this, (T2)(object)newStartValue, (T2)(object)newEndValue, newDuration);
        }

        // ===================================================================================
        // INTERNAL METHODS ------------------------------------------------------------------

        // _tweenPlugin is not reset since it's useful to keep it as a reference
        internal override sealed void Reset()
        {
            base.Reset();

            getter = null;
            setter = null;
            plugOptions = new TPlugOptions();
            hasManuallySetStartValue = false;
        }

        // CALLED BY TweenManager at each update.
        // Returns TRUE if the tween needs to be killed
        internal override float UpdateDelay(float elapsed)
        {
            return DoUpdateDelay(this, elapsed);
        }

        // CALLED BY Tween the moment the tween starts, AFTER any delay has elapsed
        // (unless it's a FROM tween, in which case it will be called BEFORE any eventual delay).
        // Returns TRUE in case of success,
        // FALSE if there are missing references and the tween needs to be killed
        internal override bool Startup()
        {
            return DoStartup(this);
        }

        // Applies the tween set by DoGoto.
        // Returns TRUE if the tween needs to be killed
        internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode)
        {
            float updatePosition = useInversePosition ? duration - position : position;
            if (DOTween.useSafeMode) {
                try {
                    setter(tweenPlugin.Evaluate(plugOptions, this, isRelative, getter, updatePosition, startValue, changeValue, duration));
                } catch (MissingReferenceException) {
                    // Target/field doesn't exist anymore: kill tween
                    return true;
                }
            } else {
                setter(tweenPlugin.Evaluate(plugOptions, this, isRelative, getter, updatePosition, startValue, changeValue, duration));
            }
            return false;
        }
    }
}