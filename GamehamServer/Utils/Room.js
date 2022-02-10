const { createWebSocketStream } = require("ws");
const { PrintException } = require("./PrintException");

class Rooms
{
    constructor() {
        this.rooms = [];
        this.roomID = 0;
    }

    createRoom(name) {
        if (this.rooms.find(e => e.roomName == name) != undefined) {
            console.log("중복 방 이름");
        } else {
            this.rooms[this.roomID] = new Room(this.roomID, name);
            return this.roomID++;
        }
    }

    removeRoom(roomid) {
        if (!(roomid in this.rooms)) {
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        } else {
            this.rooms.splice(roomid, 1);
        }
    }

    joinAt(socket, roomid) {
        if (!(roomid in this.rooms)) {
            console.log("해당 방 없음");
        } else {
            return this.rooms[roomid].join(socket);
        }
    }

    leaveAt(socket) {
        leave(socket);
    }

    startAt(roomid) {
        if (!(roomid in this.rooms)) {
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        }
    }

    ready(socket) {
        if (!(socket.room in this.rooms)) {
            PrintException("ROOM NOT FOUND", this.fetchDebugData());
        } else if (socket.room == -1) {
            console.log("방에 접속중이 아님");
        } else {
            socket.ready = !socket.ready;
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

        if (socket.id in this.players) { // 소켓 중복
            PrintException("DUPLICATE SOCKET", this.fetchDebugData(socket.id));
        } else {
            this.players[socket.id] = socket;
        }
    }

    leave(socket) {
        if (!(socket.id in this.players)) { // 해당 방 접속 X
            PrintException("SOCKET NOT FOUND", this.fetchDebugData(socket.id));
        } else {
            this.players.splice(socket.id, 1);
            socket.room = -1;
        }
    }

    start() {
        if (this.isPlaying) { // 이미 게임 진행 중
            PrintException("ROOM ALREADY PLAYING", [this.isPlaying]);
        } else {
            this.players.forEach(e => {
                e.onGame = true;
            });
        }
    }

    broadcast(data) {
        this.players.forEach(e => {
            e.send();
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

let room = new Rooms();
room.createRoom("A");
room.createRoom("A");


module.exports = {
    Rooms: new Rooms()
}