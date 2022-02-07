class Rooms
{
    constructor() {
        this.rooms = [];
        this.roomID = 0;
    }

    createRoom() {
        this.rooms[this.roomID] = new Room(this.roomID++);
    }

    joinAt(socket, roomId) {
        if (roomId in this.rooms) {
            this.rooms[roomId].join(socket);
        }
    }

    leaveAt(socket, roomId) {
        if (roomId in this.rooms) {
            this.rooms[roomId].leave(socket);
        }
    }

    startAt(roomId) {
        if (roomId in this.rooms) {
            this.rooms[roomId].start();
        }
    }
}

class Room
{
    constructor(id) {
        this.players = [];
        this.isPlaying = false;
        this.roomNumber = id;
    }

    join(socket) {
        if (socket.id in this.players) {
            console.log("ERR Duplicate socketID");
            return;
        }
        this.players[socket.id] = socket;
        socket.room = this.roomNumber;
    }

    leave(socket) {
        if (socket.id in this.players) {
            delete this.players[socket.id];
            socket.room = -1;
        }
    }

    start() {
        this.isPlaying = true;
        for (var key in this.players) {
            this.players[key].onGame = true;
        }
    }
}

module.exports = {
    Rooms: Rooms
}