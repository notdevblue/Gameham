const { DataVO } = require("../VO/DataVO");
const { broadcast } = require("./Broadcast");
const { Vector2 } = require("./Vector2");

// 몬스터
// 플레이어가 모여있는 룸에서 게임을 시작하면 몬스터 생성도 같이 시작한다
// 플레이어 수에 비례해서 몬스터의 수나 체력을 증가시킨다 -> 몬스터의 수를 늘리는 것보다 체력 늘리는 것이 좋아보임
// 그리고 시간에 따라서 보내주는 몬스터의 종류나 수가 달라져야 함

const timer = ms => new Promise(res => setTimeout(res, ms));

class MonsterSpanwer
{
    //constructor(socket, room)
    constructor(socket)
    {
        //this.room = room;
        this.spawnLength = 30;
        this.socket = socket;

        this.monsterSpawnTimes = {};

        this.addMonsterSpawnTime(2, [1]);
        this.addMonsterSpawnTime(4, [1, 1]);
        this.addMonsterSpawnTime(6, [2]);
        this.addMonsterSpawnTime(8, [2, 2]);
        this.addMonsterSpawnTime(10, [1, 1, 1, 2, 3]);
        this.addMonsterSpawnTime(12, [3, 1]);
        this.addMonsterSpawnTime(14, [3, 1]);
        this.addMonsterSpawnTime(16, [3, 1]);
        this.addMonsterSpawnTime(18, [3, 1]);
        this.addMonsterSpawnTime(20, [3, 1]);
        this.addMonsterSpawnTime(22, [3, 1]);
        this.addMonsterSpawnTime(24, [3, 1]);
        this.addMonsterSpawnTime(26, [3, 1]);
        this.addMonsterSpawnTime(28, [3, 1]);
        this.addMonsterSpawnTime(30, [3, 1]);
    }

    addMonsterSpawnTime(minute, monsters)
    {
        this.monsterSpawnTimes[minute * 60] = monsters;
    }

    randomPos()
    {
        let rand = Math.random() * 360;

        return new Vector2(Math.cos(rand) * this.spawnLength, Math.sin(rand) * this.spawnLength);
    }

    spawnStart()
    {
        // 30분 동안 반복하면서 소환하는 코드 작성
        this.start(60 * 30);
    }

    spawnMonster(curTime)
    {
        let monsterSpawnTimeKeys = Object.keys(this.monsterSpawnTimes);

        for(let i = 0; i < monsterSpawnTimeKeys.length; i++)
        {
            if(monsterSpawnTimeKeys[i] > curTime)
            {
                this.sendMonsterValue(curTime, monsterSpawnTimeKeys[i]);
                return;
            }
        }
    }

    start(endSecond)
    {
        let i = 0;

        setInterval(() =>{
            this.spawnMonster(i);
            i++;

            console.log(i);

            if(endSecond < i)
            {
                clearInterval(this);
            }
        }, 1000);
    }

    sendMonsterValue(curTime, key)
    {
        //let randomPlayerId = room.players[Math.random() * room.players.length].id;

        broadcast(
            this.socket, 
            JSON.stringify(
                new DataVO("Monster", 
                    JSON.stringify(
                        {
                            "randomPlayerId":1, 
                            "curTime":curTime, 
                            "spawnMonsterIds":this.monsterSpawnTimes[key], 
                            "randomPos":this.randomPos()
                        }
                    )
                )
            )
        )
    }
}
exports.MonsterSpanwer = MonsterSpanwer;