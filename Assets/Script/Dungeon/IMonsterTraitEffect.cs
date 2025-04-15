using UnityEngine;

namespace Script.Enemy
{
    public interface IMonsterTraitEffect
    {
        //todo : 각 함수의 매개변수에 시스템 혹은 객체에 접근해 기능을 구현할 보조 클래스 추가
        
        /// <summary>
        /// 몬스터 생성시 몬스터에 적용되는 특성 EX)해당 몬스터 생성 시 체력 증가
        /// </summary>
        public void ApplyTo(Monster monster, TraitGrade grade);

        /// <summary>
        /// 던전 생성 후 몬스터 던전 배치 시 EX)해당 몬스터 던전 배치 시 환경 오염 효과 부여
        /// </summary>
        public void OnPlacingDungeon(TraitGrade grade);
        
        /// <summary>
        /// 던전 클리어 될 경우 적용되는 특성 EX)해당 몬스터 배치 된 던전 클리어 시 특수 퀘스트 생성
        /// </summary>
        public void OnDungeonCleared(TraitGrade grade);

        /// <summary>
        /// 보상 산정 될 때 적용되는 특성 EX)해당 몬스터 배치 된 던전 보상 획득 시 골드량 증가
        /// </summary>
        public void OnRewardCalculated(TraitGrade grade);

        /// <summary>
        /// 던전 탐험 시작 된 후 결과 계산 시 적용되는 특성 EX)해당 몬스터 배치 된 던전 탐험 시 확정적 사망 이벤트 발생
        /// </summary>
        public void OnCombat(TraitGrade grade);
    }
}