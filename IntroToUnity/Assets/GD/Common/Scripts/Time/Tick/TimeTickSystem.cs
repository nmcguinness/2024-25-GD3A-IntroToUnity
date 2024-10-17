using System;
using UnityEngine;
using UnityEngine.Events;

namespace GD
{
    public class TimeTickSystem : Singleton<TimeTickSystem>
    {
        #region Fields

        private readonly float maxTickInterval = 0.1f;

        public enum TickRateMultiplierType : sbyte
        {
            RealTime = 1, HalfTime = 2, QuarterTime = 4, EighthTime = 8
        }

        public uint Tick
        {
            get
            {
                return tick;
            }
        }

        private uint tick = 0;
        private float tickTimer;

        private UnityEvent OnTick_Resolution_1 = new UnityEvent();

        private UnityEvent OnTick_Resolution_2 = new UnityEvent();

        private UnityEvent OnTick_Resolution_4 = new UnityEvent();

        private UnityEvent OnTick_Resolution_8 = new UnityEvent();

        #endregion Fields

        private void Awake()
        {
            if (maxTickInterval <= 0)
                throw new Exception("Tick System Max Tick Interval must be > 0!");
        }

        private void FixedUpdate()
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= maxTickInterval)
            {
                tickTimer -= maxTickInterval;

                tick++;

                OnTick_Resolution_1?.Invoke();

                if (tick % (int)TickRateMultiplierType.HalfTime == 0)
                {
                    OnTick_Resolution_2?.Invoke();

                    if (tick % (int)TickRateMultiplierType.QuarterTime == 0)
                    {
                        OnTick_Resolution_4?.Invoke();

                        if (tick % (int)TickRateMultiplierType.EighthTime == 0)
                        {
                            OnTick_Resolution_8?.Invoke();
                        }
                    }
                }
            }
        }

        public void RegisterListener(TickRateMultiplierType tickRateType, UnityAction listener)
        {
            switch (tickRateType)
            {
                case TickRateMultiplierType.RealTime:
                    OnTick_Resolution_1.AddListener(listener);
                    break;

                case TickRateMultiplierType.HalfTime:
                    OnTick_Resolution_2.AddListener(listener);
                    break;

                case TickRateMultiplierType.QuarterTime:
                    OnTick_Resolution_4.AddListener(listener);
                    break;

                case TickRateMultiplierType.EighthTime:
                    OnTick_Resolution_8.AddListener(listener);
                    break;
            }
        }

        public void UnregisterListener(TickRateMultiplierType tickRateType, UnityAction listener)
        {
            switch (tickRateType)
            {
                case TickRateMultiplierType.RealTime:
                    OnTick_Resolution_1.RemoveListener(listener);
                    break;

                case TickRateMultiplierType.HalfTime:
                    OnTick_Resolution_2.RemoveListener(listener);
                    break;

                case TickRateMultiplierType.QuarterTime:
                    OnTick_Resolution_4.RemoveListener(listener);
                    break;

                case TickRateMultiplierType.EighthTime:
                    OnTick_Resolution_8.RemoveListener(listener);
                    break;
            }
        }
    }
}