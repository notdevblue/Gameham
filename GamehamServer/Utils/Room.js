class Rooms
{
    constructor() {
        this.rooms = [];
        this.roomID = 0;
    }

    createRoom() {
        this.rooms[this.roomID] = new Room(this.roomID++);
    }

    joinAt(socket, roomid) {
        if (roomid in this.rooms) {
            return this.rooms[roomid].join(socket);
        } else {
            return "ERR#해당하는 방이 존제하지 않습니다."
        }
    }

    leaveAt(socket, roomid) {
        if (roomid in this.rooms) {
            return this.rooms[roomid].leave(socket);
        } else {
            return "ERR#Invalid action.";
        }
    }

    startAt(roomid) {
        if (roomid in this.rooms) {
            this.rooms[roomid].start();
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
            console.log("ERR#Duplicate socketID.");
            return "ERR#Duplicate socketID.";
        }
        if (this.players.length >= 2) {
            return "ERR#방이 가득 찼습니다."
        }

        this.players[socket.id] = socket;
        socket.room = this.roomNumber;
        return "";
    }

    leave(socket) {
        if (socket.id in this.players) {

            if (this.players.length == 1) {
                this.players = [];
            } else {
                delete this.players[socket.id];   
            }

            socket.room = -1;
            return "";
        } else {
            return "ERR#Invalid action";
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