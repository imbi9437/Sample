using UnityEngine;

namespace Script.Enemy
{
    public interface IMonsterTraitEffect
    {
        /// <summary>
        /// 몬스터 생성시 적용되는 특성
        /// </summary>
        public void ApplyTo(Monster monster, TraitGrade grade);

        /// <summary>
        /// 던전 클리어 될 경우 적용되는 특성
        /// </summary>
        public void OnDungeonCleared(TraitGrade grade);

        /// <summary>
        /// 보상 산정 될 때 적용되는 특성
        /// </summary>
        public void OnRewardCalculated(TraitGrade grade);

        /// <summary>
        /// 던전 탐험 시작 된 후 결과 계산 시 적용되는 특성
        /// </summary>
        public void OnCombat(TraitGrade grade);
    }
}