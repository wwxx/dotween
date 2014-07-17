﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/15 17:50

using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening
{
    public sealed class Sequence : Tween
    {
        // SETUP DATA ////////////////////////////////////////////////

        internal readonly List<Tween> sequencedTweens = new List<Tween>(); // Only Tweens (used for despawning)
        readonly List<ABSSequentiable> _sequencedObjs = new List<ABSSequentiable>(); // Tweens plus SequenceCallbacks

        internal Sequence()
        {
            tweenType = TweenType.Sequence;
            Reset();
        }

        // ===================================================================================
        // PUBLIC METHODS --------------------------------------------------------------------

        public override void Reset()
        {
            base.Reset();

            sequencedTweens.Clear();
            _sequencedObjs.Clear();
        }

        // ===================================================================================
        // CREATION METHODS ------------------------------------------------------------------

        internal static Sequence DoInsert(Sequence inSequence, Tween t, float atPosition)
        {
            TweenManager.AddActiveTweenToSequence(t);

            t.isSequenced = t.creationLocked = true;
            if (t.loops == -1) t.loops = 1;
            t.autoKill = false;
            t.delay = t.elapsedDelay = 0;
            t.delayComplete = true;
            t.sequencedPosition = atPosition;
            t.sequencedEndPosition = t.sequencedPosition + (t.duration * t.loops);

            if (t.sequencedEndPosition > inSequence.duration) inSequence.duration = t.sequencedEndPosition;
            inSequence._sequencedObjs.Add(t);
            inSequence.sequencedTweens.Add(t);

            return inSequence;
        }

        internal static Sequence DoAppendInterval(Sequence inSequence, float interval)
        {
            inSequence.duration += interval;
            return inSequence;
        }

        internal static Sequence DoInsertCallback(Sequence inSequence, TweenCallback callback, float atPosition)
        {
            SequenceCallback c = new SequenceCallback(atPosition, callback);
            c.sequencedPosition = c.sequencedEndPosition = atPosition;
            inSequence._sequencedObjs.Add(c);
            if (inSequence.duration < atPosition) inSequence.duration = atPosition;
            return inSequence;
        }

        // ===================================================================================
        // INTERNAL METHODS ------------------------------------------------------------------

        // CALLED BY Tween the moment the tween starts.
        // Returns TRUE in case of success (always TRUE for Sequences)
        internal override bool Startup()
        {
            return DoStartup(this);
        }

        internal override bool ApplyTween(ApplyTweenData data)
        {
            return DoApplyTween(this, data);
        }

        // Called by DOTween when spawning/creating a new Sequence.
        internal static void Setup(Sequence s)
        {
            s.isPlaying = DOTween.defaultAutoPlayBehaviour == AutoPlay.All || DOTween.defaultAutoPlayBehaviour == AutoPlay.AutoPlaySequences;
            s.loopType = DOTween.defaultLoopType;
        }

        internal static bool DoStartup(Sequence s)
        {
            s.startupDone = true;
            s.fullDuration = s.loops > -1 ? s.duration * s.loops : Mathf.Infinity;
            // Order sequencedObjs by start position
            s._sequencedObjs.Sort(SortSequencedObjs);
            return true;
        }

        // Applies the tween set by DoGoto.
        // Returns TRUE if the tween needs to be killed
        internal static bool DoApplyTween(Sequence s, ApplyTweenData data)
        {
            float from, to = 0;
            if (data.updateMode == UpdateMode.Update && data.newCompletedSteps > 0) {
                // Run all cycles elapsed since last update
                int cycles = data.newCompletedSteps;
                int cyclesDone = 0;
                from = data.prevPosition;
                bool isInverse = s.loopType == LoopType.Yoyo
                    && (data.prevPosition < s.duration ? data.prevCompletedLoops % 2 != 0 : data.prevCompletedLoops % 2 == 0);
                while (cyclesDone < cycles) {
                    if (cyclesDone > 0) from = to;
                    to = isInverse ? 0 : s.duration;
                    Debug.Log("CYCLE inverse: " + isInverse);
                    if (ApplyInternalCycle(s, from, to, data.updateMode)) return true;
                    cyclesDone++;
                    if (s.loopType == LoopType.Yoyo) isInverse = !isInverse;
                }
            }
            // Run current cycle
            if (data.newCompletedSteps > 0) from = data.useInversePosition ? s.duration : 0;
            else from = data.useInversePosition ? s.duration - data.prevPosition : data.prevPosition;
            return ApplyInternalCycle(s, from, data.useInversePosition ? s.duration - s.position : s.position, data.updateMode);
        }

        // ===================================================================================
        // METHODS ---------------------------------------------------------------------------

        static bool ApplyInternalCycle(Sequence s, float fromPos, float toPos, UpdateMode updateMode)
        {
            bool isGoingBackwards = toPos < fromPos;
            Debug.Log("     goingBackwards: " + isGoingBackwards + " from/to: " + fromPos + "," + toPos);
            if (isGoingBackwards) {
                int len = s._sequencedObjs.Count - 1;
                for (int i = len; i > -1; --i) {
                    ABSSequentiable sequentiable = s._sequencedObjs[i];
                    if (updateMode == UpdateMode.Update && (sequentiable.sequencedEndPosition < toPos || sequentiable.sequencedPosition > fromPos)) continue;
                    if (sequentiable.tweenType == TweenType.Callback) sequentiable.onStart();
                    else {
                        // Nested Tweener/Sequence
                        float gotoPos = toPos - sequentiable.sequencedPosition;
                        Tween t = (Tween)sequentiable;
                        t.isBackwards = isGoingBackwards;
                        Debug.Log("             < " + t.stringId);
                        if (TweenManager.Goto(t, gotoPos, false, updateMode)) return true;
                    }
                }
            } else {
                int len = s._sequencedObjs.Count;
                for (int i = 0; i < len; ++i) {
                    ABSSequentiable sequentiable = s._sequencedObjs[i];
                    if (updateMode == UpdateMode.Update && (sequentiable.sequencedPosition > toPos || sequentiable.sequencedEndPosition < fromPos)) continue;
                    if (sequentiable.tweenType == TweenType.Callback) sequentiable.onStart();
                    else {
                        // Nested Tweener/Sequence
                        float gotoPos = toPos - sequentiable.sequencedPosition;
                        Tween t = (Tween)sequentiable;
                        t.isBackwards = isGoingBackwards;
                        Debug.Log("             > " + t.stringId);
                        if (TweenManager.Goto(t, gotoPos, false, updateMode)) return true;
                    }
                }
            }
            return false;
        }

        static int SortSequencedObjs(ABSSequentiable a, ABSSequentiable b)
        {
            if (a.sequencedPosition > b.sequencedPosition) return 1;
            if (a.sequencedPosition < b.sequencedPosition) return -1;
            return 0;
        }
    }
}