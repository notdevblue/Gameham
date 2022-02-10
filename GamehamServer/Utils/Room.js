const { createWebSocketStream } = require("ws");
const { DataVO } = require("../VO/DataVO");
const { PrintException } = require("./PrintException");
const { sendResponse } = require("./Response");

class Rooms
{
    constructor() {
        this.rooms = [];
        this.roomID = 0;
    }

    createRoom(socket, name) {
        if (this.rooms.find(e => e.roomName == name) != undefined) { // 방 이름 중복
            sendResponse(socket, "이미 존재하는 방 이름입니다.");
        } else {
            this.rooms[this.roomID] = new Room(this.roomID, name);
            this.joinAt(socket, this.roomID);

            ++this.roomID;
        }
    }

    removeRoom(roomid) {
        if (!(roomid in this.rooms)) { // 삭제하려는 방 존재 X
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        } else {
            this.rooms.splice(roomid, 1);
        }
    }

    joinAt(socket, roomid) {
        if (!(roomid in this.rooms)) { // 해당 방 존재 X
            sendResponse(socket, "해당 방이 존재하지 않습니다.");
        } else {
            this.rooms[roomid].join(socket);
        }
    }

    leaveAt(socket, roomid) {
        if (!(roomid in this.rooms)) { // 해당 방 존재 X
            sendResponse(socket, 1);
        } else {
            
            if (socket.ready) { // 나기기 전 ready 는 false 로 처리해야 함
                this.ready(socket);
            }
            this.rooms[roomid].leave(socket);

            if (this.rooms[roomid].players.length == 0) { // 아무도 없는 방이면 삭제
                this.removeRoom(roomid);
            }
        }
    }

    startAt(roomid) {
        if (!(roomid in this.rooms)) { // 해당 방 존재 X
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        } else {
            this.rooms[roomid].start();
        }
    }

    ready(socket) {
        if (!(socket.room in this.rooms)) { // 해당 방 존재 X (서버 에러 가능성)
            sendResponse(socket, "해당 방을 찾을 수 없습니다.");
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        } else if (socket.room == -1) {
            sendResponse(socket, "방에 접속중이 아닙니다.");
        } else {
            socket.ready = !socket.ready;

            const payload = JSON.stringify({ id: socket.id, status: socket.ready });
            this.rooms[socket.room].broadcast(JSON.stringify(new DataVO("ready", payload)), socket.id);
            sendResponse(socket, 0);
        }
    }

    fetchDebugData() { // 모든 방 ID 와 이름
        let debugDataArray = [];
        let index = 0;

        this.players.forEach(e => {
            debugDataArray[index++] = `ROOM NAME:${e.roomName}`;
            debugDataArray[index++] = `ROOM ID:  ${e.roomNumber}`;
        });

        return debugDataArray;
    }
}

class Room
{
    constructor(id, name) {
        this.roomNumber = id;
        this.roomName = name;
        this.isPlaying = false;
        this.players = [];
    }

    join(socket) {

        if (socket.id in this.players) { // 소켓 중복 (서버 에러 가능성)
            sendResponse(socket, "이미 접속한 방입니다.");
            PrintException("DUPLICATE SOCKET", this.fetchDebugData(socket.id));
        } else {
            this.players[socket.id] = socket;
            socket.room = this.roomNumber;

            this.broadcast(JSON.stringify(new DataVO("joinroom", { id: socket.id })), socket.id);
            sendResponse(socket, 0);
        }
    }

    leave(socket) {
        if (!(socket.id in this.players)) { // 해당 방 접속 X (서버 에러 가능성)
            sendResponse(socket, "접속하지 않은 방에서의 퇴장 요청");
            PrintException("SOCKET NOT FOUND", this.fetchDebugData(socket.id));
        } else {
            this.players.splice(socket.id, 1);
            socket.room = -1;

            let payload = JSON.stringify({ id: socket.id });
            this.broadcast(JSON.stringify(new DataVO("leaveroom", payload)), socket.id);
            
            sendResponse(socket, 0);
        }
    }

    start() {
        if (this.isPlaying) { // 이미 게임 진행 중
            PrintException("ROOM ALREADY PLAYING", [this.isPlaying]);
        } else {
            this.players.forEach(e => { // 시작 브로드케스트 (onGame 변수 true 로 바꿔줘야 해서 이렇게 만듬)
                e.onGame = true;
                e.send(JSON.stringify(new DataVO("start", "")));
            });
        }
    }

    broadcast(data, excludeSocketid) {
        this.players.forEach(e => {
            if (e != excludeSocketid)
                e.send(data);
        });
    }


    fetchDebugData(socketid) { // 방에 접속된 소켓 ID
        let debugDataArray = [];
        let index = 3;

        debugDataArray[0] = `SOCKET ID: ${id}`;
        debugDataArray[1] = `SOCKET ID: ${id}\r\n`;
        debugDataArray[2] = "ROOM CONTAINS:";

        this.players.forEach(e => {
            debugDataArray[index++] = `\tSOCKET ID${e.id}`;
        });

        return debugDataArray;
    }
}

module.exports = {
    Rooms: new Rooms()
}