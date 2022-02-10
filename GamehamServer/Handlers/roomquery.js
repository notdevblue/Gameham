const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "roomquery",
    handle(socket, payload) {
        let roomData = [];
        
        Rooms.rooms.forEach(e => {

            let data = {
                isPlaying: e.isPlaying,
                roomNumber: e.roomNumber,
                players: e.players.length,
                roomName: e.roomName
            };

            roomData.push(data);
        });

        
        if (roomData.length == 0) {
            socket.send(JSON.stringify(new DataVO("roomquery", "")));
        } else {
            socket.send(JSON.stringify(new DataVO("roomquery", JSON.stringify({ roomData: roomData }))));
        }

    }
}