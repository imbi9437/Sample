using Script.Enemy;
using UnityEngine;

public interface IDungeonTraitEffect
{
    //todo : 각 함수의 매개변수에 시스템 혹은 객체에 접근해 기능을 구현할 보조 클래스 추가
    
    /// <summary>
    /// 던전 생성 시 적용되는 특성 EX)던전이 정예화된 채로 생성됨
    /// </summary>
    public void ApplyTo(Dungeon dungeon, TraitGrade grade);

    /// <summary>
    /// 던전 발견 시 적용되는 특성 EX)공개되는 던전 정보가 없도록 함
    /// </summary>
    public void OnDungeonDiscovered(TraitGrade grade);

    /// <summary>
    /// 던전 유지 시간 초과 시 적용되는 특성 EX)영지에 침공하는 몬스터 수 증가
    /// </summary>
    public void OnDungeonOverflowed(TraitGrade grade);

    /// <summary>
    /// 모험단 던전 공략 위해 배치 시 적용되는 특성 EX) 특정 직업의 모험가가 존재하지 않는경우 던전 공략 실패
    /// </summary>
    public void OnAdventureAssigned(TraitGrade grade);

    /// <summary>
    /// 던전 공략 판정 계산 시 적용되는 특성 EX) 공략 계산 시 던전 실패 확률 보정
    /// </summary>
    public void OnCombatCalculated(TraitGrade grade);

    /// <summary>
    /// 던전 공략 실패 시 적용되는 특성 EX) 던전 정예화 속도 가속
    /// </summary>
    public void OnCombatFailed(TraitGrade grade);

    /// <summary>
    /// 던전 공략 성공 시 적용되는 특성 EX) 하위던전 여러개 추가 발생
    /// </summary>
    public void OnCombatSucceeded(TraitGrade grade);

    /// <summary>
    /// 던전 클리어 보상 산정 시 적용되는 특성 EX) 던전 보상 감소
    /// </summary>
    public void OnRewardCalculated(TraitGrade grade);
}
