using System;

/// <summary>
/// Enemy 객체 공격용 인터페이스
/// 겹칠 시 삭제하거나 이름 변경
/// </summary>
public interface IAttack
{
    public void AttacktoPlayer();
}