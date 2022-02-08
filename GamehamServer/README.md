# 페킷 정리

## 둘 다 주고받음

### joinroom
```cs
{
    (int)roomid: 참가하려는 방 ID
    (int)id: 요청 보낸 플레이어 ID
}
// 방 참가 요청
```

### leaveroom
```cs
{
    (int)roomid: 나가려는 방 ID
    (int)id: 요청 보낸 플레이어 ID
}
// 방 퇴장 요청
```

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


### roomquery
```js
{
    (List<RoomData>)roomData: {
        (List<int>)players: 접속한 플레이어들의 ID
        (bool)isPlaying: 게임 시작 여부
        (int)roomNumber: 방 ID
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