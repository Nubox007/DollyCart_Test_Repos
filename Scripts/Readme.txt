## 스크립트 설명


IAttack, IEventCall = 인터페이스 스크립트

TestInput           = 테스트용 입력 스크립트 (추후 제거), 시작 시 1회 한정 Space바 입력으로 player객체 이동개시


DollyPaths 적 객체 트랙관리 스크립트
->  하위 객체로 Cinemachine Smooth Path 스크립트를 포함한 객체를 배열로 저장
    상위 PathManager가 해당 객체를 페이즈 별로 구분하여 사용하기 위한 배열 저장용 스크립트

PathEventManager 트랙 이벤트 관리 매니저 스크립트
->  페이즈 시작시 적 객체들에게 트랙 초기화 및 이동 실행
    적 객체들이 Enemy 클래스에서 CallEvent를 호출하면 점수 및 객체 카운트하고 모든 객체가 죽으면 
    다음 페이즈로 넘어감

Enemy 적 객체 스크립트
->  IEventCall,IAttack 인터페이스 상속 받아서 공격 및 파괴 시 이벤트 호출 메서드 호출
    (공격은 미구현 ), 페이즈 시작 시 속도 조절로 트랙을 타고 이동

PlayerManager 플레이어 트랙 관리 스크립트
->  플레이어 객체가 트랙을 따라 움직이면서 출발 혹은 도착 시, 코루틴으로 속도 보간 처리
    정지 시 완전히 속도 0이 되는게 아닌 0.01로 움직여서 조금씩 움직임

    인스펙터 창의 blendspeed로 보간 비율 조정
    car_Speed로 카트 최대 스피드 지정(구간 테스트 후 최대 속도 지정, 기본 속도 1)
    phaseUnit 정지를 원하는 구간 지정

GameManaer 최상위 관리 객체
->  현재 PathEventManager와 PlayerManager 관리
    두 객체 간에 콜백 메서드 전달
    추후 점수 및 공격 이펙트 객체 연결 필요


