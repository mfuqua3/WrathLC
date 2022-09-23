import React from "react";
import {Route, Routes} from "react-router-dom";
import UserCharacters from "./User.Characters";
import UserWishlists from "./User.Wishlists";

function UserRoutes() {
    return (
        <Routes>
            <Route path={"characters"} element={<UserCharacters/>}/>
            <Route path={"wishlists"} element={<UserWishlists />} />
        </Routes>
    )

}

export default React.memo(UserRoutes);