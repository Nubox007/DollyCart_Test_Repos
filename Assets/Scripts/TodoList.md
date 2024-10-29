
### Todo List


1. 적 랜덤 공격 이펙트 구현 
2. 점수 스코어 UI 구현
3. 적 HP 개념 반영
4. 각 구간 별 속도 제어

### 기능 구현 구조


GameManager     
> PlayerManager        
        >  PlayerObject(GameObject)
> PathEventManager     
        >  EnemyEvent          
                > Enemy(CinemachineSmoothPath Object)