const { broadcast } = require("../Utils/Broadcast");
const { DataVO } = require("../VO/DataVO");

module.exports = {
    type: "levelUpSelected",
    handle(socket, payload) {

        broadcast(socket, JSON.stringify(new DataVO("levelUpSelected", payload)));
    }
}