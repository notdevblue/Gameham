const { broadcast } = require("../Utils/Broadcast");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "levelUp",
    handle(socket, payload) {

        broadcast(socket, JSON.stringify(new DataVO("levelUp", payload)));
    }
}