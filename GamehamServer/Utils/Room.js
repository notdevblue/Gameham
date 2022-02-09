class Rooms
{
    constructor() {
        this.rooms = [];
        this.roomID = 0;
    }

    createRoom(name) {
        this.rooms.forEach(room => {
            // console.log(room.roomName);
            // console.log(name);
            // console.log();
            if (room.roomName == name) {
                return "ERR#이미 존재하는 방 이름입니다.";
            }
        });

        this.rooms[this.roomID] = new Room(this.roomID, name);
        return this.roomID++;
    }

    removeRoom(roomid) {
        if (roomid in this.rooms) {
            // this.rooms = this.rooms.filter(x => x.roomNumber != roomid);
            delete this.rooms[roomid];
            this.rooms = this.rooms.filter(x => x != null);
            console.log(`Deleting room ${roomid}`);
        }
    }

    joinAt(socket, roomid) {
        if (roomid in this.rooms) {
            return this.rooms[roomid].join(socket);
        } else {
            return "ERR#해당하는 방이 존제하지 않습니다."
        }
    }

    leaveAt(socket) {
        if (socket.room in this.rooms) {
            socket.ready = false;
            return this.rooms[socket.room].leave(socket);
        } else {
            return "ERR#Socket not connected to room.";
        }
    }

    startAt(roomid) {
        if (roomid in this.rooms) {
            this.rooms[roomid].start();
        }
    }

    ready(socket) {
        if (socket.room in this.rooms) {
            socket.ready = !socket.ready;
            return "";
        } else {
            return "ERR#Socket not connected to room.";
        }
    }
}

class Room
{
    constructor(id, name) {
        this.players = [];
        this.isPlaying = false;
        this.roomNumber = id;
        this.roomName = name;
    }

    join(socket) {
        if (socket.id in this.players) {
            console.log(`\r\nERR#Duplicate socketID. id:${socket.id}\r\n`);

            console.log(`---- ROOM ID ${this.roomNumber} USER DATA ----`);
            this.players.forEach(e => {
                console.log(`SOCKET ID ${e.id}`);
                console.log(`SOCKET ROOMID ${e.room}\r\n`);
            });

            return `ERR#Duplicate socketID. id:${socket.id}`;
        }
        if (this.players.length >= 2) {
            console.log(`\r\nERR#방이 가득 찼습니다. ${this.roomNumber}\r\n`);
            return "ERR#방이 가득 찼습니다."
        }

        this.players[socket.id] = socket;
        socket.room = this.roomNumber;
        
        console.log(`   id:${socket.id} connected to room${this.roomNumber}`);

        return "";
    }

    leave(socket) {
        this.players.forEach(e => {
            console.log(`\r\ROOM ${this.roomNumber} CONNECTED SOCKET ID: ${e.id}`);
        });

        console.log("RESULT OF this.players[socket.id]: " + JSON.stringify(this.players[socket.id]));

        if (socket.id in this.players) {

            socket.room = -1;

            console.log(`id:${socket.id} left ${this.roomNumber}`);

            if (this.players.length < 1) {
                return "-d";
            } else {
                // this.players = this.players.filter(x => x.id != socket.id);
                delete this.players[socket.id];
                this.players = this.players.filter(x => x != null);
                return "";
            }

        } else {
            console.log(`\r\n\r\n--- Socket not found in this room. id:${socket.id} ---\r\n`);
            console.log(`## ROOMDATA OF ${this.roomNumber} ##`);
            this.players.forEach(e => {
                console.log(`   SOCKET ID: ${e.id}`);
                console.log(`   SOCKET ROOM ID: ${e.room}`);
            });


            return `ERR#Socket not found in this room. id:${socket.id}`;
        }
    }

    start() {
        this.isPlaying = true;
        for (var key in this.players) {
            this.players[key].onGame = true;
        }
    }

    broadcast(data) {
        this.players.forEach(e => {
            e.send(data);
        });
    }
}

module.exports = {
    Rooms: new Rooms()
}