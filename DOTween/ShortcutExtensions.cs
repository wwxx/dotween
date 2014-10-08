﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/28 10:40
//
// License Copyright (c) Daniele Giardini.
// This work is subject to the terms at http://dotween.demigiant.com/license.php

using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

#pragma warning disable 1573
namespace DG.Tweening
{
    /// <summary>
    /// Methods that extend known Unity objects and allow to directly create and control tweens from their instances
    /// </summary>
    public static class ShortcutExtensions
    {
        // ===================================================================================
        // CREATION SHORTCUTS ----------------------------------------------------------------

        #region Transform Shortcuts

        /// <summary>Tweens a Transform's position to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, x => target.position = x, endValue, duration)
                .SetOptions(snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's X position to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveX(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, x => target.position = x, new Vector3(endValue, 0, 0), duration)
                .SetOptions(AxisConstraint.X, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's Y position to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveY(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, x => target.position = x, new Vector3(0, endValue, 0), duration)
                .SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's Z position to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, x => target.position = x, new Vector3(0, 0, endValue), duration)
                .SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOLocalMove(this Transform target, Vector3 endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.localPosition, x => target.localPosition = x, endValue, duration)
                .SetOptions(snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's X localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOLocalMoveX(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.localPosition, x => target.localPosition = x, new Vector3(endValue, 0, 0), duration)
                .SetOptions(AxisConstraint.X, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's Y localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOLocalMoveY(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.localPosition, x => target.localPosition = x, new Vector3(0, endValue, 0), duration)
                .SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's Z localPosition to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOLocalMoveZ(this Transform target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.localPosition, x => target.localPosition = x, new Vector3(0, 0, endValue), duration)
                .SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Transform's rotation to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="useShortest360Route">If TRUE (default) the rotation will take the shortest route and will not rotate more than 360°.
        /// If FALSE the rotation will be fully accounted. Is always FALSE if the tween is set as relative</param>
        public static Tweener DORotate(this Transform target, Vector3 endValue, float duration, bool useShortest360Route = true)
        {
            return DOTween.To(() => target.rotation, x => target.rotation = x, endValue, duration)
                .SetOptions(useShortest360Route).SetTarget(target);
        }

        /// <summary>Tweens a Transform's localRotation to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="useShortest360Route">If TRUE (default) the rotation will take the shortest route and will not rotate more than 360°.
        /// If FALSE the rotation will be fully accounted. Is always FALSE if the tween is set as relative</param>
        public static Tweener DOLocalRotate(this Transform target, Vector3 endValue, float duration, bool useShortest360Route = true)
        {
            return DOTween.To(() => target.localRotation, x => target.localRotation = x, endValue, duration)
                .SetOptions(useShortest360Route).SetTarget(target);
        }

        /// <summary>Tweens a Transform's rotation to the given value, using its local axis system
        /// (like when rotating an object with the "local" switch enabled in Unity's editor).
        /// <para>The endValue passed is obviously considered relative to the transform's actual rotation.</para>
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOLocalAxisRotate(this Transform target, Vector3 endValue, float duration)
        {
            return DOTween.To(() => Quaternion.identity, x => target.localRotation = x, endValue, duration)
                .SetSpecialStartupMode(SpecialStartupMode.SetLocalAxisRotationSetter)
                .SetOptions(false).SetTarget(target);
        }

        /// <summary>Tweens a Transform's localScale to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOScale(this Transform target, Vector3 endValue, float duration)
        {
            return DOTween.To(() => target.localScale, x => target.localScale = x, endValue, duration).SetTarget(target);
        }

        /// <summary>Tweens a Transform's X localScale to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOScaleX(this Transform target, float endValue, float duration)
        {
            return DOTween.To(() => target.localScale, x => target.localScale = x, new Vector3(endValue, 0, 0), duration)
                .SetOptions(AxisConstraint.X)
                .SetTarget(target);
        }

        /// <summary>Tweens a Transform's Y localScale to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOScaleY(this Transform target, float endValue, float duration)
        {
            return DOTween.To(() => target.localScale, x => target.localScale = x, new Vector3(0, endValue, 0), duration)
                .SetOptions(AxisConstraint.Y)
                .SetTarget(target);
        }

        /// <summary>Tweens a Transform's Z localScale to the given value.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOScaleZ(this Transform target, float endValue, float duration)
        {
            return DOTween.To(() => target.localScale, x => target.localScale = x, new Vector3(0, 0, endValue), duration)
                .SetOptions(AxisConstraint.Z)
                .SetTarget(target);
        }

        /// <summary>Tweens a Transform's rotation so that it will look towards the given position.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="towards">The position to look at</param><param name="duration">The duration of the tween</param>
        /// <param name="axisConstraint">Eventual axis constraint for the rotation</param>
        /// <param name="up">The vector that defines in which direction up is (default: Vector3.up)</param>
        public static Tweener DOLookAt(this Transform target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
        {
            Vector3 vUp = (up == null) ? Vector3.up : (Vector3)up;
            towards -= target.position;
            switch (axisConstraint) {
            case AxisConstraint.X:
                towards.x = 0;
                break;
            case AxisConstraint.Y:
                towards.y = 0;
                break;
            case AxisConstraint.Z:
                towards.z = 0;
                break;
            }
            Vector3 lookAtRotation = Quaternion.LookRotation(towards, vUp).eulerAngles;
            return DOTween.To(() => target.rotation, x => target.rotation = x, lookAtRotation, duration)
                .SetTarget(target);
        }

        /// <summary>Punches a Transform's localPosition towards the given direction and then back to the starting one
        /// as if it was connected to the starting position via an elastic.</summary>
        /// <param name="punch">The direction and strength of the punch (added to the Transform's current position)</param>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting position when bouncing backwards.
        /// 1 creates a full oscillation between the punch direction and the opposite direction,
        /// while 0 oscillates only between the punch and the start position</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOPunchPosition(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1, bool snapping = false)
        {
            return DOTween.Punch(() => target.localPosition, x => target.localPosition = x, punch, duration, vibrato, elasticity)
                .SetTarget(target).SetOptions(snapping);
        }
        /// <summary>Punches a Transform's localScale towards the given size and then back to the starting one
        /// as if it was connected to the starting scale via an elastic.</summary>
        /// <param name="punch">The punch strength (added to the Transform's current scale)</param>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting size when bouncing backwards.
        /// 1 creates a full oscillation between the punch scale and the opposite scale,
        /// while 0 oscillates only between the punch scale and the start scale</param>
        public static Tweener DOPunchScale(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
        {
            return DOTween.Punch(() => target.localScale, x => target.localScale = x, punch, duration, vibrato, elasticity)
                .SetTarget(target);
        }
        /// <summary>Punches a Transform's localRotation towards the given size and then back to the starting one
        /// as if it was connected to the starting rotation via an elastic.</summary>
        /// <param name="punch">The punch strength (added to the Transform's current rotation)</param>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="vibrato">Indicates how much will the punch vibrate</param>
        /// <param name="elasticity">Represents how much (0 to 1) the vector will go beyond the starting rotation when bouncing backwards.
        /// 1 creates a full oscillation between the punch rotation and the opposite rotation,
        /// while 0 oscillates only between the punch and the start rotation</param>
        public static Tweener DOPunchRotation(this Transform target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
        {
            return DOTween.Punch(() => target.localEulerAngles, x => target.localRotation = Quaternion.Euler(x), punch, duration, vibrato, elasticity)
                .SetTarget(target);
        }

        /// <summary>Shakes a Transform's localPosition with the given values.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOShakePosition(this Transform target, float duration, float strength = 1, int vibrato = 10, float randomness = 90, bool snapping = false)
        {
            return DOTween.Shake(() => target.localPosition, x => target.localPosition = x, duration, strength, vibrato, randomness, false)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake).SetOptions(snapping);
        }
        /// <summary>Shakes a Transform's localPosition with the given values.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength on each axis</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOShakePosition(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90, bool snapping = false)
        {
            return DOTween.Shake(() => target.localPosition, x => target.localPosition = x, duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake).SetOptions(snapping);
        }
        /// <summary>Shakes a Transform's localRotation.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeRotation(this Transform target, float duration, float strength = 90, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.localEulerAngles, x => target.localRotation = Quaternion.Euler(x), duration, strength, vibrato, randomness, false)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }
        /// <summary>Shakes a Transform's localRotation.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength on each axis</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeRotation(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.localEulerAngles, x => target.localRotation = Quaternion.Euler(x), duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }
        /// <summary>Shakes a Transform's localScale.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeScale(this Transform target, float duration, float strength = 1, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.localScale, x => target.localScale = x, duration, strength, vibrato, randomness, false)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }
        /// <summary>Shakes a Transform's localScale.</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength on each axis</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeScale(this Transform target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.localScale, x => target.localScale = x, duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }

        /// <summary>Tweens a Transform's position through the given path waypoints, using the chosen path algorithm.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="path">The waypoints to go through</param>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="pathType">The type of path: Linear (straight path) or CatmullRom (curved CatmullRom path)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path (useless in case of Linear paths): higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOPath(
            this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null
        )
        {
            if (resolution < 1) resolution = 1;
            TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(PathPlugin.Get(), () => target.position, x => target.position = x, new Path(pathType, path, resolution, gizmoColor), duration)
                .SetTarget(target);

            t.plugOptions.mode = pathMode;
            return t;
        }
        /// <summary>Tweens a Transform's localPosition through the given path waypoints, using the chosen path algorithm.
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="path">The waypoint to go through</param>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="pathType">The type of path: Linear (straight path) or CatmullRom (curved CatmullRom path)</param>
        /// <param name="pathMode">The path mode: 3D, side-scroller 2D, top-down 2D</param>
        /// <param name="resolution">The resolution of the path: higher resolutions make for more detailed curved paths but are more expensive.
        /// Defaults to 10, but a value of 5 is usually enough if you don't have dramatic long curves between waypoints</param>
        /// <param name="gizmoColor">The color of the path (shown when gizmos are active in the Play panel and the tween is running)</param>
        public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(
            this Transform target, Vector3[] path, float duration, PathType pathType = PathType.Linear,
            PathMode pathMode = PathMode.Full3D, int resolution = 10, Color? gizmoColor = null
        )
        {
            if (resolution < 1) resolution = 1;
            TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(PathPlugin.Get(), () => target.localPosition, x => target.localPosition = x, new Path(pathType, path, resolution, gizmoColor), duration)
                .SetTarget(target);

            t.plugOptions.mode = pathMode;
            return t;
        }
        // TODO Used by path editor when creating the actual tween, but verify if it is truly needed when finished
        internal static TweenerCore<Vector3, Path, PathOptions> DOPath(
            this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D
        )
        {
            TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(PathPlugin.Get(), () => target.position, x => target.position = x, path, duration)
                .SetTarget(target);

            t.plugOptions.mode = pathMode;
            return t;
        }
        internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(
            this Transform target, Path path, float duration, PathMode pathMode = PathMode.Full3D
        )
        {
            TweenerCore<Vector3, Path, PathOptions> t = DOTween.To(PathPlugin.Get(), () => target.localPosition, x => target.localPosition = x, path, duration)
                .SetTarget(target);

            t.plugOptions.mode = pathMode;
            return t;
        }

        #endregion

        #region Rigidbody Shortcuts

        /// <summary>Tweens a Rigidbody's position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMove(this Rigidbody target, Vector3 endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, target.MovePosition, endValue, duration)
                .SetOptions(snapping).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's X position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveX(this Rigidbody target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, target.MovePosition, new Vector3(endValue, 0, 0), duration)
                .SetOptions(AxisConstraint.X, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's Y position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveY(this Rigidbody target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, target.MovePosition, new Vector3(0, endValue, 0), duration)
                .SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's Z position to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="snapping">If TRUE the tween will smoothly snap all values to integers</param>
        public static Tweener DOMoveZ(this Rigidbody target, float endValue, float duration, bool snapping = false)
        {
            return DOTween.To(() => target.position, target.MovePosition, new Vector3(0, 0, endValue), duration)
                .SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's rotation to the given value.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        /// <param name="useShortest360Route">If TRUE (default) the rotation will take the shortest route and will not rotate more than 360°.
        /// If FALSE the rotation will be fully accounted. Is always FALSE if the tween is set as relative</param>
        public static Tweener DORotate(this Rigidbody target, Vector3 endValue, float duration, bool useShortest360Route = true)
        {
            return DOTween.To(() => target.rotation, target.MoveRotation, endValue, duration)
                .SetOptions(useShortest360Route).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's rotation to the given value, using its local axis system
        /// (like when rotating an object with the "local" switch enabled in Unity's editor).
        /// <para>The endValue passed is obviously considered relative to the transform's actual rotation.</para>
        /// Also stores the transform as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOLocalAxisRotate(this Rigidbody target, Vector3 endValue, float duration)
        {
            return DOTween.To(() => Quaternion.identity, target.MoveRotation, endValue, duration)
                .SetSpecialStartupMode(SpecialStartupMode.SetLocalAxisRotationSetter)
                .SetOptions(false).SetTarget(target);
        }

        /// <summary>Tweens a Rigidbody's rotation so that it will look towards the given position.
        /// Also stores the rigidbody as the tween's target so it can be used for filtered operations</summary>
        /// <param name="towards">The position to look at</param><param name="duration">The duration of the tween</param>
        /// <param name="axisConstraint">Eventual axis constraint for the rotation</param>
        /// <param name="up">The vector that defines in which direction up is (default: Vector3.up)</param>
        public static Tweener DOLookAt(this Rigidbody target, Vector3 towards, float duration, AxisConstraint axisConstraint = AxisConstraint.None, Vector3? up = null)
        {
            Vector3 vUp = (up == null) ? Vector3.up : (Vector3)up;
            towards -= target.position;
            switch (axisConstraint) {
            case AxisConstraint.X:
                towards.x = 0;
                break;
            case AxisConstraint.Y:
                towards.y = 0;
                break;
            case AxisConstraint.Z:
                towards.z = 0;
                break;
            }
            Vector3 lookAtRotation = Quaternion.LookRotation(towards, vUp).eulerAngles;
            return DOTween.To(() => target.rotation, target.MoveRotation, lookAtRotation, duration)
                .SetTarget(target);
        }

        #endregion

        #region Camera Shortcuts

        /// <summary>Shakes a Camera's localPosition along its relative X Y axes with the given values.
        /// Also stores the camera as the tween's target so it can be used for filtered operations</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakePosition(this Camera target, float duration, float strength = 3, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.transform.localPosition, x => target.transform.localPosition = x, duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
        }
        /// <summary>Shakes a Camera's localPosition along its relative X Y axes with the given values.
        /// Also stores the camera as the tween's target so it can be used for filtered operations</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength on each axis</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakePosition(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.transform.localPosition, x => target.transform.localPosition = x, duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetCameraShakePosition);
        }

        /// <summary>Shakes a Camera's localRotation.
        /// Also stores the camera as the tween's target so it can be used for filtered operations</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeRotation(this Camera target, float duration, float strength = 90, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.transform.localEulerAngles, x => target.transform.localRotation = Quaternion.Euler(x), duration, strength, vibrato, randomness, false)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }
        /// <summary>Shakes a Camera's localRotation.
        /// Also stores the camera as the tween's target so it can be used for filtered operations</summary>
        /// <param name="duration">The duration of the tween</param>
        /// <param name="strength">The shake strength on each axis</param>
        /// <param name="vibrato">Indicates how much will the shake vibrate</param>
        /// <param name="randomness">Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). 
        /// Setting it to 0 will shake along a single direction.</param>
        public static Tweener DOShakeRotation(this Camera target, float duration, Vector3 strength, int vibrato = 10, float randomness = 90)
        {
            return DOTween.Shake(() => target.transform.localEulerAngles, x => target.transform.localRotation = Quaternion.Euler(x), duration, strength, vibrato, randomness)
                .SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake);
        }

        /// <summary>Tweens a Camera's backgroundColor to the given value.
        /// Also stores the camera as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOColor(this Camera target, Color endValue, float duration)
        {
            return DOTween.To(() => target.backgroundColor, x => target.backgroundColor = x, endValue, duration).SetTarget(target);
        }

        #endregion

        #region Material Shortcuts

        /// <summary>Tweens a Material's color to the given value.
        /// Also stores the material as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOColor(this Material target, Color endValue, float duration)
        {
            return DOTween.To(() => target.color, x => target.color = x, endValue, duration).SetTarget(target);
        }
        /// <summary>Tweens a Material's named color property to the given value.
        /// Also stores the material as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param>
        /// <param name="property">The name of the color property to tween (like _Tint or _SpecColor)</param>
        /// <param name="duration">The duration of the tween</param>
        public static Tweener DOColor(this Material target, Color endValue, string property, float duration)
        {
            return DOTween.To(() => target.GetColor(property), x => target.SetColor(property, x), endValue, duration).SetTarget(target);
        }

        /// <summary>Tweens a Material's alpha color to the given value
        /// (will have no effect unless your material supports transparency).
        /// Also stores the material as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOFade(this Material target, float endValue, float duration)
        {
            return DOTween.ToAlpha(() => target.color, x => target.color = x, endValue, duration)
                .SetTarget(target);
        }

        #endregion

        #region Light Shortcuts

        /// <summary>Tweens a Light's color to the given value.
        /// Also stores the light as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOColor(this Light target, Color endValue, float duration)
        {
            return DOTween.To(() => target.color, x => target.color = x, endValue, duration).SetTarget(target);
        }

        /// <summary>Tweens a Light's intensity to the given value.
        /// Also stores the light as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOIntensity(this Light target, float endValue, float duration)
        {
            return DOTween.To(() => target.intensity, x => target.intensity = x, endValue, duration).SetTarget(target);
        }

        /// <summary>Tweens a Light's shadowStrength to the given value.
        /// Also stores the light as the tween's target so it can be used for filtered operations</summary>
        /// <param name="endValue">The end value to reach</param><param name="duration">The duration of the tween</param>
        public static Tweener DOShadowStrength(this Light target, float endValue, float duration)
        {
            return DOTween.To(() => target.shadowStrength, x => target.shadowStrength = x, endValue, duration).SetTarget(target);
        }

        #endregion

        // ===================================================================================
        // OPERATION SHORTCUTS ---------------------------------------------------------------

        #region Operation Shortcuts

        /// <summary>
        /// Kills all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens killed.
        /// </summary>
        public static int DOKill(this Transform target)
        {
            return DOTween.Kill(target);
        }
        /// <summary>
        /// Kills all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens killed.
        /// </summary>
        public static int DOKill(this Rigidbody target)
        {
            return DOTween.Kill(target);
        }
        /// <summary>
        /// Kills all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens killed.
        /// </summary>
        public static int DOKill(this Material target)
        {
            return DOTween.Kill(target);
        }
        /// <summary>
        /// Kills all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens killed.
        /// </summary>
        public static int DOKill(this Camera target)
        {
            return DOTween.Kill(target);
        }

        /// <summary>
        /// Flips the direction (backwards if it was going forward or viceversa) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens flipped.
        /// </summary>
        public static int DOFlip(this Transform target)
        {
            return DOTween.Flip(target);
        }
        /// <summary>
        /// Flips the direction (backwards if it was going forward or viceversa) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens flipped.
        /// </summary>
        public static int DOFlip(this Rigidbody target)
        {
            return DOTween.Flip(target);
        }
        /// <summary>
        /// Flips the direction (backwards if it was going forward or viceversa) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOFlip(this Material target)
        {
            return DOTween.Flip(target);
        }
        /// <summary>
        /// Flips the direction (backwards if it was going forward or viceversa) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOFlip(this Camera target)
        {
            return DOTween.Flip(target);
        }

        /// <summary>
        /// Sends to the given position all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        /// <param name="to">Time position to reach
        /// (if higher than the whole tween duration the tween will simply reach its end)</param>
        /// <param name="andPlay">If TRUE will play the tween after reaching the given position, otherwise it will pause it</param>
        public static int DOGoto(this Transform target, float to, bool andPlay = false)
        {
            return DOTween.Goto(target, to, andPlay);
        }
        /// <summary>
        /// Sends to the given position all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        /// <param name="to">Time position to reach
        /// (if higher than the whole tween duration the tween will simply reach its end)</param>
        /// <param name="andPlay">If TRUE will play the tween after reaching the given position, otherwise it will pause it</param>
        public static int DOGoto(this Rigidbody target, float to, bool andPlay = false)
        {
            return DOTween.Goto(target, to, andPlay);
        }
        /// <summary>
        /// Sends to the given position all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        /// <param name="to">Time position to reach
        /// (if higher than the whole tween duration the tween will simply reach its end)</param>
        /// <param name="andPlay">If TRUE will play the tween after reaching the given position, otherwise it will pause it</param>
        public static int DOGoto(this Material target, float to, bool andPlay = false)
        {
            return DOTween.Goto(target, to, andPlay);
        }
        /// <summary>
        /// Sends to the given position all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        /// <param name="to">Time position to reach
        /// (if higher than the whole tween duration the tween will simply reach its end)</param>
        /// <param name="andPlay">If TRUE will play the tween after reaching the given position, otherwise it will pause it</param>
        public static int DOGoto(this Camera target, float to, bool andPlay = false)
        {
            return DOTween.Goto(target, to, andPlay);
        }

        /// <summary>
        /// Pauses all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens paused.
        /// </summary>
        public static int DOPause(this Transform target)
        {
            return DOTween.Pause(target);
        }
        /// <summary>
        /// Pauses all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens paused.
        /// </summary>
        public static int DOPause(this Rigidbody target)
        {
            return DOTween.Pause(target);
        }
        /// <summary>
        /// Pauses all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens paused.
        /// </summary>
        public static int DOPause(this Material target)
        {
            return DOTween.Pause(target);
        }
        /// <summary>
        /// Pauses all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens paused.
        /// </summary>
        public static int DOPause(this Camera target)
        {
            return DOTween.Pause(target);
        }

        /// <summary>
        /// Plays all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlay(this Transform target)
        {
            return DOTween.Play(target);
        }
        /// <summary>
        /// Plays all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlay(this Rigidbody target)
        {
            return DOTween.Play(target);
        }
        /// <summary>
        /// Plays all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlay(this Material target)
        {
            return DOTween.Play(target);
        }
        /// <summary>
        /// Plays all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlay(this Camera target)
        {
            return DOTween.Play(target);
        }

        /// <summary>
        /// Plays backwards all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayBackwards(this Transform target)
        {
            return DOTween.PlayBackwards(target);
        }
        /// <summary>
        /// Plays backwards all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayBackwards(this Rigidbody target)
        {
            return DOTween.PlayBackwards(target);
        }
        /// <summary>
        /// Plays backwards all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayBackwards(this Material target)
        {
            return DOTween.PlayBackwards(target);
        }
        /// <summary>
        /// Plays backwards all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayBackwards(this Camera target)
        {
            return DOTween.PlayBackwards(target);
        }

        /// <summary>
        /// Plays forward all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayForward(this Transform target)
        {
            return DOTween.PlayForward(target);
        }
        /// <summary>
        /// Plays forward all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayForward(this Rigidbody target)
        {
            return DOTween.PlayForward(target);
        }
        /// <summary>
        /// Plays forward all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayForward(this Material target)
        {
            return DOTween.PlayForward(target);
        }
        /// <summary>
        /// Plays forward all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens played.
        /// </summary>
        public static int DOPlayForward(this Camera target)
        {
            return DOTween.PlayForward(target);
        }

        /// <summary>
        /// Restarts all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens restarted.
        /// </summary>
        public static int DORestart(this Transform target)
        {
            return DOTween.Restart(target);
        }
        /// <summary>
        /// Restarts all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens restarted.
        /// </summary>
        public static int DORestart(this Rigidbody target)
        {
            return DOTween.Restart(target);
        }
        /// <summary>
        /// Restarts all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens restarted.
        /// </summary>
        public static int DORestart(this Material target)
        {
            return DOTween.Restart(target);
        }
        /// <summary>
        /// Restarts all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens restarted.
        /// </summary>
        public static int DORestart(this Camera target)
        {
            return DOTween.Restart(target);
        }

        /// <summary>
        /// Rewinds all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens rewinded.
        /// </summary>
        public static int DORewind(this Transform target)
        {
            return DOTween.Rewind(target);
        }
        /// <summary>
        /// Rewinds all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens rewinded.
        /// </summary>
        public static int DORewind(this Rigidbody target)
        {
            return DOTween.Rewind(target);
        }
        /// <summary>
        /// Rewinds all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens rewinded.
        /// </summary>
        public static int DORewind(this Material target)
        {
            return DOTween.Rewind(target);
        }
        /// <summary>
        /// Rewinds all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens rewinded.
        /// </summary>
        public static int DORewind(this Camera target)
        {
            return DOTween.Rewind(target);
        }

        /// <summary>
        /// Toggles the paused state (plays if it was paused, pauses if it was playing) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        public static int DOTogglePause(this Transform target)
        {
            return DOTween.TogglePause(target);
        }
        /// <summary>
        /// Toggles the paused state (plays if it was paused, pauses if it was playing) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        public static int DOTogglePause(this Rigidbody target)
        {
            return DOTween.TogglePause(target);
        }
        /// <summary>
        /// Toggles the paused state (plays if it was paused, pauses if it was playing) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        public static int DOTogglePause(this Material target)
        {
            return DOTween.TogglePause(target);
        }
        /// <summary>
        /// Toggles the paused state (plays if it was paused, pauses if it was playing) of all tweens that have this target as a reference
        /// (meaning tweens that were started from this target, or that had this target added as an Id)
        /// and returns the total number of tweens involved.
        /// </summary>
        public static int DOTogglePause(this Camera target)
        {
            return DOTween.TogglePause(target);
        }

        #endregion
    }
}