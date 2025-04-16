using Script.Order;
using UnityEngine;

public static class AdventureFactory
{
    public static Adventure Create()
    {
        Adventure adventure = new Adventure();

        //todo : 모험가 내부 정보 결정 함수 추가
        
        return adventure;
    }
}
