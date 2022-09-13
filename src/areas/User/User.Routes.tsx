import React from "react";
import {Route, Routes} from "react-router-dom";
import UserCharacters from "./User.Characters";

function UserRoutes() {
    return (
        <Routes>
            <Route path={"characters"} element={<UserCharacters/>}/>
        </Routes>
    )

}

export default React.memo(UserRoutes);