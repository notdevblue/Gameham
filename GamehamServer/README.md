# 페킷 정리

## 둘 다 주고받음

### move
```cs
{
    (Vector2)pos: 위치
    (Quaternion)rot: 회전
    (int)id: 이동한 플레이어 ID
}
// 이동 동기화 용
```

* * *

## 서버가 클라이언트로

### joinroom
```cs
{
    (int)id: 요청 보낸 플레이어 ID
}
// 방 참가 요청
```

### leaveroom
```cs
{
    (int)id: 요청 보낸 플레이어 ID
}
// 방 퇴장 요청
```

### roomquery
```js
{
    (List<RoomData>)roomData: {
        (int)players: 접속한 플레이어들의 ID
        (bool)isPlaying: 게임 시작 여부
        (int)roomNumber: 방 ID
        (string)roomName: 방 이름
    }
}
// 방 리스트
```

### error
```js
{
    (string)msg: 에러 메세지
}
// 에러 발생 시
```

### ready
```js
{
    (int)id: 레디한 플레이어 id
    (bool)status: 레디 상태
}
```
### start
```js
{
}
// 게임 시작 시
```

### response
```js
{
}
// 오류가 발생하지 않았고, 아무런 패킷이 필요하지 않은 답변일 시
```

* * *

## 클라이언트가 서버로

### joinroom
```cs
{
    (int)roomid: 참가하려는 방 ID
}
// 방 참가 요청
```

### leaveroom
```cs
{
    (int)roomid: 나가려는 방 ID
}
// 방 퇴장 요청
```

### roomquery
```cs
{
}
// 방 정보 불러오기 용도
```

### createroom
```cs
{
    (string)msg: 방 이름
}
// 방 생성 용
// 알아서 접속됨
```

### ready
```cs
{
}
// 레디 상태 변경 용
```

* * *

## Socket 변수들
```js
socket.room: 접속 중인 방 ID, 없다면 -1
socket.onGame: 게임 중인지
socket.ready: 레디 상태
socket.id: 고유 ID

# deprecated
socket.server: wsServer
```