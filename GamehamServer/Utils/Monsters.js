const { Rooms } = require("../Utils/Room");

// 몬스터
// 플레이어가 모여있는 룸에서 게임을 시작하면 몬스터 생성도 같이 시작한다
// 플레이어 수에 비례해서 몬스터의 수나 체력을 증가시킨다 -> 몬스터의 수를 늘리는 것보다 체력 늘리는 것이 좋아보임
// 그리고 시간에 따라서 보내주는 몬스터의 종류나 수가 달라져야 함

class MonsterSpanwer
{
    constructor(roomId)
    {
        this.roomId = roomId;
        
        this.timeCheckPoints = {
            "oneMin":0,
            "twoMin":1,
            "fourMin":2,
            "sixMin":3,
            "eightMin":4,
            "tenMin":5,
        };


    }
}

module.exports = {
    MonsterSpanwer: new MonsterSpanwer()
}