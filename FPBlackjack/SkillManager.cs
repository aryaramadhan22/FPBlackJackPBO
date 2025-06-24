using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPBlackjack
{
    public class SkillManager
    {
        public int SkillGauge { get; private set; } = 0;
        public int MaxGauge { get; private set; } = 50;
        public bool PreventBustActive { get; private set; } = false;
        public bool DoubleDamageActive { get; private set; } = false;

        public void AddGauge(int amount)
        {
            SkillGauge += amount;
            if (SkillGauge > MaxGauge) SkillGauge = MaxGauge;
        }

        public void ResetGauge()
        {
            SkillGauge = 0;
        }

        public bool CanActivateSkill()
        {
            return SkillGauge >= MaxGauge && !PreventBustActive && !DoubleDamageActive;
        }

        public void ActivatePreventBust()
        {
            if (CanActivateSkill())
            {
                PreventBustActive = true;
                ResetGauge();
            }
        }

        public void ActivateDoubleDamage()
        {
            if (CanActivateSkill())
            {
                DoubleDamageActive = true;
                ResetGauge();
            }
        }

        public void ResetSkills()
        {
            PreventBustActive = false;
            DoubleDamageActive = false;
        }
    }
}
