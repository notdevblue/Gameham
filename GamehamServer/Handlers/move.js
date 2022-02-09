const { broadcast } = require("../Utils/Broadcast");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "move",
    handle(socket, payload) {

        broadcast(socket, JSON.stringify(new DataVO("move", payload)));
    }
}