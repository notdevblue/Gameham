const { broadcast } = require("../Utils/Broadcast");
const { Rooms } = require("../Utils/Room");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "roomquery",
    handle(socket, payload) {
        let roomData = [];
        
        Rooms.rooms.forEach(e => {
            let data = JSON.stringify(e);
            console.log(data);
            roomData.push(data);
        });

        if (roomData.length == 0) {
            socket.send(roomData);
        } else {
            socket.send(JSON.stringify(new DataVO("roomquery", JSON.stringify({roomData}))));
        }

    }
}