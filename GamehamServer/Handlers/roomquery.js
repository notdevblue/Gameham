const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "roomquery",
    handle(socket, payload) {
        let roomData = [];
        
        Rooms.rooms.forEach(e => {

            e.players = e.players.filter(x => x != null);

            let data = {
                isPlaying: e.isPlaying,
                roomNumber: e.roomNumber,
                players: e.players.length, // FIXME: null 도 하나의 오브젝트
                roomName: e.roomName
            };
            
            console.log(`# ROOMQUERY OF ROOM ${e.roomNumber}`);
            e.players.forEach(e => {
                console.log("PLAYER ID: " + e.id);
                console.log("PLAYER ROOM ID: " + e.room);
            });
            
            roomData.push(data);
        });

        
        if (roomData.length == 0) {
            socket.send(JSON.stringify(new DataVO("roomquery", "")));
        } else {
            socket.send(JSON.stringify(new DataVO("roomquery", JSON.stringify({ roomData: roomData }))));
            console.log("Sending: " + JSON.stringify({ roomData: roomData }));
        }

    }
}